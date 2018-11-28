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
    public partial class работы_период : Form
    {
        public работы_период()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        BindingList<temp> tempList = new BindingList<temp>();
        private void работы_период_Load(object sender, EventArgs e)
        {
            обновить();
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
        }

        void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            Guid КодМастера =(Guid)  dataGridView1.Rows[e.RowIndex].Cells["мастерColumn"].Value ;
            Guid КодРаботы =(Guid) dataGridView1.Rows[e.RowIndex].Cells["работаColumn"].Value;
            //if (КодМастера == "1234567890" && КодРаботы != "1234567890")
            //{
            //    e.CellStyle.BackColor = Color.FromArgb(200, 200, 255);
            //}

            if (КодРаботы == Guid.Empty && КодМастера == Guid.Empty)
            {
                e.CellStyle.BackColor = System.Drawing.Color.Cyan;
            }

            if (КодРаботы == Guid.Empty && КодМастера != Guid.Empty)
            {
                e.CellStyle.BackColor = System.Drawing.Color.FromArgb(200, 255, 200);
            }
        }

        class temp
        {
      
            public Guid работа { get; set; }
            public Guid мастер { get; set; }
            public String наимен_работы { get; set; }
            public String фио_мастера { get; set; }
            public String должность { get; set; }
            public int операций { get; set; }
            public int зарплата { get; set; }
            public int материалы { get; set; }
            public int сумма { get; set; }
          
        

        }

        private void обновить()
        {
            var query = de.опл_работы
                          .Where(n => n.оплаты.дата >= клПериод.дата_с && n.оплаты.дата <= клПериод.дата_по)
                          .GroupBy(n => new { n.работы, n.сотрудники })
                          .Select(n => new
                          {
                              работа = n.Key.работы.работа,
                              наимен_работы = n.Key.работы.наимен,
                              мастер = n.Key.сотрудники.сотрудник,
                              фио_мастера = n.Key.сотрудники.фио,
                              должность = n.Key.сотрудники.должность,
                              стоимость = n.Sum(p => p.стоимость),
                              ст_материалов = n.Sum(p => p.ст_материалов),
                              ст_работы = n.Sum(p => p.стоимость - p.ст_материалов),
                              операций = n.Count()
                          });

         //   dsTemp.реестр.Clear();
            tempList.Clear();
            foreach (var uRow in query)
            {
//                DsTemp.реестрRow NewRow = dsTemp.реестр.NewреестрRow();
                temp NewRow = new temp();

           //     NewRow.дата = DateTime.Today;
                NewRow.должность = uRow.должность;
                NewRow.мастер = uRow.мастер;
                NewRow.материалы = (int)uRow.ст_материалов;
                NewRow.наимен_работы = uRow.наимен_работы;
                NewRow.работа = uRow.работа;
                NewRow.сумма = (int)uRow.стоимость;
                NewRow.материалы = (int)uRow.ст_материалов;
                NewRow.зарплата = NewRow.сумма - NewRow.материалы;
                NewRow.фио_мастера = uRow.фио_мастера;
                NewRow.операций = uRow.операций;

                tempList.Add(NewRow);
            //    dsTemp.реестр.Rows.Add(NewRow);

            }


            var queryМастер = de.опл_работы
                .Where(n => n.оплаты.дата >= клПериод.дата_с && n.оплаты.дата <= клПериод.дата_по)
                .GroupBy(n => n.сотрудники)
                .Select(n => new
                {
                    работа = Guid.Empty,
                    наимен_работы = "Всего",
                    мастер = n.Key.сотрудник,
                    фио_мастера = n.Key.фио,
                    должность = n.Key.должность,
                    стоимость = n.Sum(p => p.стоимость),
                    ст_материалов = n.Sum(p => p.ст_материалов),
                    ст_работы = n.Sum(p => p.стоимость - p.ст_материалов),
                    операций = n.Count()
                });

            foreach (var uRow in queryМастер)
            {
              
                temp NewRow = new temp();
           //     NewRow.дата = DateTime.Today;
                NewRow.должность = uRow.должность;
                NewRow.мастер = uRow.мастер;
                NewRow.материалы = (int)uRow.ст_материалов;
                NewRow.наимен_работы = uRow.наимен_работы;
                NewRow.работа = uRow.работа;
                NewRow.сумма = (int)uRow.стоимость;
                NewRow.материалы = (int)uRow.ст_материалов;
                NewRow.зарплата = NewRow.сумма - NewRow.материалы;
                NewRow.фио_мастера = uRow.фио_мастера;
                NewRow.операций = uRow.операций;
            //    NewRow.ввод = 0;
          //      dsTemp.реестр.Rows.Add(NewRow);
                tempList.Add(NewRow);

            }

            var queryВсего = de.опл_работы
                               .Where(n => n.оплаты.дата >= клПериод.дата_с && n.оплаты.дата <= клПериод.дата_по)
                               .ToArray();



         //   DsTemp.реестрRow NewRow1 = dsTemp.реестр.NewреестрRow();
            temp NewRow1 = new temp();
     //       NewRow1.дата = DateTime.Today;
            NewRow1.должность = "";
            NewRow1.мастер = Guid.Empty;
            NewRow1.материалы = (int)queryВсего.Sum(n => n.ст_материалов);
            NewRow1.наимен_работы = "Все работы";
            NewRow1.работа = Guid.Empty;
            NewRow1.сумма = (int)queryВсего.Sum(n => n.стоимость);
            NewRow1.зарплата = NewRow1.сумма - NewRow1.материалы;
            NewRow1.фио_мастера = "Все мастера";
            NewRow1.операций = queryВсего.Count();
   //         NewRow1.ввод = 1;
            tempList.Add(NewRow1);


            var queryРабота = de.опл_работы
          .Where(n => n.оплаты.дата >= клПериод.дата_с && n.оплаты.дата <= клПериод.дата_по)
          .GroupBy(n => n.работы)
          .Select(n => new
          {
              работа = n.Key.работа,
              наимен_работы = n.Key.наимен,
              мастер = Guid.Empty,
              фио_мастера = "Все мастера",
              должность = "",
              стоимость = n.Sum(p => p.стоимость),
              ст_материалов = n.Sum(p => p.ст_материалов),
              ст_работы = n.Sum(p => p.стоимость - p.ст_материалов),
              операций = n.Count()
          });

            foreach (var uRow in queryРабота)
            {
                
                temp NewRow = new temp();
      //          NewRow.дата = DateTime.Today;
                NewRow.должность = uRow.должность;
                NewRow.мастер = uRow.мастер;
                NewRow.материалы = (int)uRow.ст_материалов;
                NewRow.наимен_работы = uRow.наимен_работы;
                NewRow.работа = uRow.работа;
                NewRow.сумма = (int)uRow.стоимость;
                NewRow.материалы = (int)uRow.ст_материалов;
                NewRow.зарплата = NewRow.сумма - NewRow.материалы;
                NewRow.фио_мастера = uRow.фио_мастера;
                NewRow.операций = uRow.операций;
                tempList.Add(NewRow);

                

            }
            bindingSource1.DataSource = tempList;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void заполнитьXML()
        {
            Cursor = Cursors.WaitCursor;
    //        DsTemp.реестрRow uRow = (bindingSource1.Current as DataRowView).Row as DsTemp.реестрRow;
            //    Word.Application oWord = new Word.Application();

            string curDir = System.IO.Directory.GetCurrentDirectory();

            string шаблон = curDir + @"\работы_период.docx";

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
                    Table table2 = tables.ElementAt(2);
                    Table table3 = tables.Last();

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

                    //for (int k = 0; k < 17; k++)
                    //{
                    //    клXML.ChangeTextInCell(table2, 1, k, " ");
                    //}


                    //var query = dsTemp.реестр
                    //                  .Where(n => n.мастер == uRow.мастер)
                    //                  .OrderBy(n => n.дата);
                    var query = tempList
                               .Where(n => n.мастер !=Guid.Empty);
                   //            .Where(n=>n.работа !=Guid.Empty);

                    TableRow lastRow = table2.Elements<TableRow>().Last();
                    int строк = query.Count();
                    for (int s = 1; s <= строк - 1; s++)
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
                    //int sСумма = 0;
                    //int sМатериалы = 0;
                    //int sЗарплата = 0;
                    //int sОпераций = 0;
                    int j = 0;
                    foreach (temp rRow in query)
                    {
                        j++;
                        клXML.ChangeTextInCell(table2, j, 0, rRow.наимен_работы);
                        клXML.ChangeTextInCell(table2, j, 1, rRow.фио_мастера);
                        //                        клXML.ChangeTextInCell(table2, j, 2, rRow.должность);
                        клXML.ChangeTextInCell(table2, j, 2, rRow.операций.ToString("0;#;#"));
                        клXML.ChangeTextInCell(table2, j, 3, rRow.материалы.ToString("0;#;#"));
                        клXML.ChangeTextInCell(table2, j, 4, rRow.зарплата.ToString("0;#;#"));
                        клXML.ChangeTextInCell(table2, j, 5, rRow.сумма.ToString("0;#;#"));
                        //sСумма += rRow.сумма;
                        //sМатериалы += rRow.материалы;
                        //sЗарплата += rRow.зарплата;
                        //sОпераций += rRow.операций;
                    }
                    //клXML.ChangeTextInCell(table2, j + 1, 2, "Всего");
                    //клXML.ChangeTextInCell(table2, j + 1, 3, sСумма.ToString("0;#;#"));
                    //клXML.ChangeTextInCell(table2, j + 1, 4, sМатериалы.ToString("0;#;#"));
                    //клXML.ChangeTextInCell(table2, j + 1, 5, sЗарплата.ToString("0;#;#"));
                    //клXML.ChangeTextInCell(table2, j + 1, 6, sОпераций.ToString("0;#;#"));
                    var query3 = tempList
                           .Where(n => n.мастер == Guid.Empty);
                       

                    TableRow lastRow3 = table3.Elements<TableRow>().Last();
                    int строк3 = query3.Count();
                    for (int s = 1; s <= строк3 - 1; s++)
                    {
                        TableRow newRow = lastRow3.Clone() as TableRow;
                        table3.AppendChild<TableRow>(newRow);
                    }

                    j = 0;
                    foreach (temp rRow in query3)
                    {

                        клXML.ChangeTextInCell(table3, j, 0, rRow.наимен_работы);
                        клXML.ChangeTextInCell(table3, j, 1, rRow.фио_мастера);
                        //                        клXML.ChangeTextInCell(table3, j, 2, rRow.должность);
                        клXML.ChangeTextInCell(table3, j, 2, rRow.операций.ToString("0;#;#"));
                        клXML.ChangeTextInCell(table3, j, 3, rRow.материалы.ToString("0;#;#"));
                        клXML.ChangeTextInCell(table3, j, 4, rRow.зарплата.ToString("0;#;#"));
                        клXML.ChangeTextInCell(table3, j, 5, rRow.сумма.ToString("0;#;#"));
                        j++;
                    }
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

        private void button2_Click(object sender, EventArgs e)
        {
            заполнитьXML();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count == 0)
            {
                return;
            }
            Cursor = Cursors.WaitCursor;
            temp uRow = bindingSource1.Current as temp;
            клМастер.мастер = uRow.мастер;
            клМастер.фио = uRow.фио_мастера;
            клМастер.должность = uRow.должность;
            клРабота.работа = uRow.работа;
            клРабота.наимен = uRow.наимен_работы;
            клМастер.изменен = false;

            подробности1работ формаПодробности = new подробности1работ();
            формаПодробности.Text = "Подробности " + клМастер.фио + " " + клМастер.должность + " " + клРабота.наимен;
            формаПодробности.ShowDialog();
            if (клМастер.изменен)
            {
                обновить();
            }
            Cursor = Cursors.Default;

        }


    }
}
