using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Entity;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace domofon40
{
    public partial class подробности1работ : Form
    {
        public подробности1работ()
        {
            InitializeComponent();
        }

        private int sСтоимость = 0;
        private int sМатериалы = 0;
        private int sЗарплата = 0;
        private int sОпераций = 0;
        domofon40.domofon14Entities de = new domofon14Entities();
        List<temp> tempList = new List<temp>();

        private void подробности1работ_Load(object sender, EventArgs e)
        {
            опл_работы[] query = null;

            опл_работы[] query0 = de.опл_работы
                          .Where(n => n.оплаты.дата >= клПериод.дата_с && n.оплаты.дата <= клПериод.дата_по)
                          .OrderBy(n => n.работы.порядок)
                          .ThenBy(n => n.оплаты.дата)
                          .ToArray();

            if (клМастер.мастер != Guid.Empty && клРабота.работа != Guid.Empty)
            {
                query = query0
                    .Where(n => n.работа == клРабота.работа)
                    .Where(n => n.мастер == клМастер.мастер)
                    .ToArray();

            }

            if (клМастер.мастер == Guid.Empty && клРабота.работа != Guid.Empty)
            {
                query = query0
                    .Where(n => n.работа == клРабота.работа)
                    .ToArray();

            }
            if (клМастер.мастер != Guid.Empty && клРабота.работа == Guid.Empty)
            {
                query = query0
                    .Where(n => n.мастер == клМастер.мастер)
                    .ToArray();

            }

            if (клМастер.мастер == Guid.Empty && клРабота.работа == Guid.Empty)
            {
                query = query0;

            }

            foreach (var uRow in query)
            {
                temp NewRow = new temp();

                NewRow.дата = uRow.оплаты.дата;

                //   NewRow.дата_выпол = uRow.оплата1.дата;
                NewRow.должность = uRow.сотрудники.должность;
                //   NewRow.зарплата = (int)(uRow.стоимость - uRow.ст_материалов);
                NewRow.мастер = uRow.мастер;
                NewRow.материалы = (int)uRow.ст_материалов;
                NewRow.наимен_работы = uRow.работы.наимен;
//                NewRow.номер_наряда = uRow.код;
                NewRow.номер_квитанции = uRow.оплаты.номер;
                NewRow.прим = "";
//                NewRow.прим_выпол = "";
                NewRow.работа = uRow.работа;
                NewRow.сумма = (int)uRow.стоимость;
                NewRow.материалы = (int)uRow.ст_материалов;
                NewRow.зарплата = NewRow.сумма - NewRow.материалы;
  //              NewRow.код = uRow.код;
                NewRow.фио_мастера = uRow.сотрудники.фио;
                NewRow.адрес = uRow.оплаты.клиенты.адрес;
                NewRow.фио = uRow.оплаты.клиенты.фио;
                NewRow.клиент = uRow.оплаты.клиент;
                tempList.Add(NewRow);

                sЗарплата += NewRow.зарплата;
                sМатериалы += NewRow.материалы;
                sСтоимость += NewRow.сумма;
                sОпераций++;

            }
            textBox1.Text = sСтоимость.ToString();
            textBox2.Text = sМатериалы.ToString();
            textBox3.Text = sЗарплата.ToString();
            textBox4.Text = sОпераций.ToString();
            bindingSource1.DataSource = tempList;
            bindingSource1.Sort = "дата";
            dataGridView1.Focus();
            //bindingSource1.Sort = "дата";
            //dataGridView1.Focus();

            dataGridView1.CellMouseClick += dataGridView1_CellMouseClick;
        }

        void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (dataGridView1.Columns[e.ColumnIndex] == мастерColumn)
                {
                    this.Validate();
                    this.bindingSource1.EndEdit();

                    dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    temp uRow = bindingSource1.Current as temp;

                    клМастер.мастер = uRow.мастер;
                    клМастер.выбран = false;
                    выбор_мастера ВыборМастера = new выбор_мастера();
                    ВыборМастера.ShowDialog();
                    if (клМастер.выбран)
                    {
                        uRow.мастер = клМастер.мастер;
                        uRow.фио_мастера = клМастер.фио;
                        uRow.должность = клМастер.deRow.должность;
                        try
                        {
                            опл_работы upRow = de.опл_работы.Single(n => n.задание == uRow.задание);
                            upRow.мастер = клМастер.мастер;
                            de.SaveChanges();
                            клМастер.изменен = true;
                        }
                        catch (Exception ex )
                        {

                            MessageBox.Show("Сбой записи..."+ex.Message);
                        }

                    }

                }


            }

        }

          class temp
        {
            public Guid задание { get; set; }
            public DateTime дата { get; set; }
            public Guid работа { get; set; }
            public Guid мастер { get; set; }
            public String наимен_работы { get; set; }
            public String фио_мастера { get; set; }
            public String должность { get; set; }
            public int зарплата { get; set; }
            public int материалы { get; set; }
            public int сумма { get; set; }
            public String прим { get; set; }
            public Guid клиент { get; set; }
            public String фио { get; set; }
            public String адрес { get; set; }
            public int номер_квитанции { get; set; }

        }

          private void button1_Click(object sender, EventArgs e)
          {
              Close();
          }

          private void button2_Click(object sender, EventArgs e)
          {
              заполнитьXML();
          }
          private void заполнитьXML()
          {
              Cursor = Cursors.WaitCursor;
//              DsTemp.реестрRow uRow = (реестрBindingSource.Current as DataRowView).Row as DsTemp.реестрRow;
              //    Word.Application oWord = new Word.Application();

              string curDir = System.IO.Directory.GetCurrentDirectory();

              string шаблон = curDir + @"\подробности1работ.docx";

              if (!System.IO.File.Exists(шаблон.ToString()))
              {
                  MessageBox.Show("Нет файла " + шаблон.ToString());
                  Cursor = Cursors.Default;
                  return;
              }

              var template = new System.IO.FileInfo(шаблон);
              string tempFile = curDir + @"\temp\temp.docx";
              //     string tempFile = curDir + @"\temp\temp" + StrKod10.kod_rand() + ".docx";
              try
              {

                  клTemp.закрытьWord();
              }
              catch
              {
                  MessageBox.Show("Сохраните файл Word...");

              }

              try
              {
                  template.CopyTo(tempFile, true);
              }
              catch
              {
                  MessageBox.Show("Закройте файл Word...");
                  return;
              }

              //if (template.Exists)
              //{
              //    клTemp.закрытьWord();
              //    template.CopyTo(tempFile, true);
              //}

           //   domofon10.DataClasses1DataContext dc = new DataClasses1DataContext();
              string наименФилиала = de.филиалы
                                       .OrderBy(n => n.порядок)
                                       .First().наимен;

              try
              {
                  using (WordprocessingDocument package = WordprocessingDocument.Open(tempFile, true))
                  {

                      var tables = package.MainDocumentPart.Document.Body.Elements<Table>();
                      Table table0 = tables.First();
                      Table table1 = tables.ElementAt(1);
                      Table table2 = tables.Last();

                      //o.Bookmarks["менеджер"].Range.Text = клРеестр.фио_менеджера;
                      //o.Bookmarks["дата"].Range.Text = клРеестр.дата.ToLongDateString();
                      //o.Bookmarks["филиал"].Range.Text = наименФилиала;
                      //o.Bookmarks["услуга"].Range.Text = клВид_услуги.наимен;

                      клXML.ChangeTextInCell(table0, 0, 1, наименФилиала);
                      //       клXML.ChangeTextInCell(table0, 0, 2, uRow.фио_мастера.Trim()+"  "+uRow.должность);

                      клXML.ChangeTextInCell(table1, 0, 0, "c " + клПериод.дата_с.ToShortDateString());
                      клXML.ChangeTextInCell(table1, 0, 1, "по " + клПериод.дата_по.ToShortDateString());
                      //    клXML.ChangeTextInCell(table1, 0, 2, uRow.фио_мастера.Trim() + "  " + uRow.должность);

                      //Table table = package.MainDocumentPart.Document.Body.ChildElements.Last<Table>();
                      TableRow lastRow = table2.Elements<TableRow>().Last();
                      //for (int k = 0; k < 17; k++)
                      //{
                      //    клXML.ChangeTextInCell(table2, 1, k, " ");
                      //}


                      //var query = dsTemp.реестр
                      //                  .Where(n => n.мастер == uRow.мастер)
                      //                  .OrderBy(n => n.дата);
                      var query = tempList
                                 .OrderBy(n => n.дата);

                      int строк = query.Count();
                      
                      for (int s = 1; s <= строк; s++)
                      {
                          TableRow newRow = lastRow.Clone() as TableRow;
                          table2.AppendChild<TableRow>(newRow);
                      }



                      //System.Data.OrderedEnumerableRowCollection<dsТабель.реестрRow> query;
                      //if (алфавит)
                      //{
                      //    query = dsТабель1.реестр
                      //        .OrderBy(n => n.фио);
                      //}
                      //else
                      //{
                      //    query = dsТабель1.реестр
                      //        .OrderBy(n => n.номер);
                      //}
                      int sСумма = 0;
                      int sМатериалы = 0;
                      int sЗарплата = 0;
                      int j = 0;
                      foreach (temp rRow in query)
                      {
                          j++;
                          клXML.ChangeTextInCell(table2, j, 0, rRow.дата.ToShortDateString());
                          клXML.ChangeTextInCell(table2, j, 1, rRow.номер_квитанции.ToString());
                      //    клXML.ChangeTextInCell(table2, j, 2, rRow.номер_наряда.ToString());
                          клXML.ChangeTextInCell(table2, j, 2, rRow.фио_мастера);
                          клXML.ChangeTextInCell(table2, j, 3, rRow.наимен_работы);
                          клXML.ChangeTextInCell(table2, j, 4, rRow.сумма.ToString("0;#;#"));
                          клXML.ChangeTextInCell(table2, j, 5, rRow.материалы.ToString("0;#;#"));
                          клXML.ChangeTextInCell(table2, j, 6, rRow.зарплата.ToString("0;#;#"));
                          sСумма += rRow.сумма;
                          sМатериалы += rRow.материалы;
                          sЗарплата += rRow.зарплата;
                      }
                      клXML.ChangeTextInCell(table2, j + 1, 3, "Всего");
                      клXML.ChangeTextInCell(table2, j + 1, 4, sСумма.ToString("0;#;#"));
                      клXML.ChangeTextInCell(table2, j + 1, 5, sМатериалы.ToString("0;#;#"));
                      клXML.ChangeTextInCell(table2, j + 1, 6, sЗарплата.ToString("0;#;#"));




                  }
              }
              catch
              {
                  MessageBox.Show("Закройте файл Word...");
                  return;

              }

              клTemp.закрытьWord();


              клXML.просмотрWord(tempFile);
              Cursor = Cursors.Default;



          }

    }
}
