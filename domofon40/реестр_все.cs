using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Entity;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;


namespace domofon40
{
    public partial class реестр_все : Form
    {
        public реестр_все()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        List<temp> tempList = new List<temp>();
        List<temp2> temp2List = new List<temp2>();
        decimal всего = 0;
        private void реестр_все_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (оплаты oRow in de.оплаты
                      .Where(n => n.дата == клРеестр.дата)
                      .OrderBy(n => n.номер))
                {

                    string текст = "";
                    int сумма = 0;
                    temp2List.Clear();


                    foreach (оплачено оплRow in oRow.оплачено
                           .Where(n => n.услуги.вид_услуги == клВид_услуги.вид_услуги))
                    {
                        if (оплRow.сумма > 0)
                        {

                            сумма += оплRow.сумма;


                            temp2 NewR = new temp2();
                            NewR.год = оплRow.год;
                            NewR.месяц = оплRow.месяц;
                            temp2List.Add(NewR);

                        }
                    }

                    if (сумма > 0)
                    {


                        int кГод = 0;
                        int кМесяц = -1;
                        foreach (temp2 sRow in temp2List
                            .OrderBy(n => n.год)
                            .ThenBy(n => n.месяц))
                        {
                            if (sRow.год != кГод)
                            {
                                sRow.новый_год = true;
                            }
                            if (sRow.месяц != кМесяц + 1)
                            {
                                sRow.начало_периода = true;
                            }
                            кМесяц = sRow.месяц;
                            кГод = sRow.год;
                        }


                        int нГод = 0;
                        int нМесяц = -1;
                        foreach (temp2 sRow in temp2List
                             .OrderByDescending(n => n.год)
                            .ThenByDescending(n => n.месяц))
                        {
                            if (sRow.год != DateTime.Today.Year)
                            {
                                sRow.новый_год = true;

                            }
                            if (нМесяц - 1 != sRow.месяц || нГод != sRow.год)
                            {
                                sRow.конец_периода = true;

                            }
                            нГод = sRow.год;
                            нМесяц = sRow.месяц;
                        }

                        foreach (temp2 sRow in temp2List
                            .OrderBy(n => n.год)
                            .ThenBy(n => n.месяц))
                        {
                            if (sRow.начало_периода && !sRow.конец_периода)
                            {
                                if (sRow.новый_год)
                                {
                                    текст += " " + sRow.год.ToString().Trim();
                                }

                                текст += " " + sRow.месяц.ToString().Trim();
                            }
                            if (sRow.конец_периода && !sRow.начало_периода)
                            {
                                текст += "-" + sRow.месяц.ToString().Trim() + "; ";
                            }

                            if (sRow.конец_периода && sRow.начало_периода)
                            {
                                if (sRow.новый_год)
                                {
                                    текст += " " + sRow.год.ToString().Trim();
                                }
                                текст += " " + sRow.месяц.ToString().Trim() + "; ";
                            }
                        }



                        //       dsТабель.реестрRow NewRow = dsТабель1.реестр.NewреестрRow();
                        temp NewRow = new temp();
                        NewRow.фио = oRow.клиенты.фио;
                        NewRow.адрес = oRow.клиенты.дома.улицы.наимен.Trim()
                            + " " + oRow.клиенты.дома.номер.ToString().Trim()
                            + oRow.клиенты.дома.корпус.Trim()
                            + " - " + oRow.клиенты.квартира.ToString().Trim();
                        NewRow.сумма = сумма;
                        NewRow.месяца = текст;
                        NewRow.номер = oRow.номер;
                        NewRow.менеджер = oRow.сотрудники.фио;
                        tempList.Add(NewRow);

                        всего += сумма;


                    }
                }
                bindingSource1.DataSource = tempList;
                textBox1.Text = всего.ToString();
                клСетка.задать_ширину(dataGridView1);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки  {ex.Message} ");
            }
        }
        class temp
        {
            public int номер { get; set; } 
            public string фио { get; set; }
            public string адрес { get; set; }
            public string месяца { get; set; }
            public int сумма { get; set; }
            public string менеджер { get; set; }

        }
        class temp2
        {
            public int год { get; set; }
            public int месяц { get; set; }
            public bool пусто { get; set; }
            public bool тире { get; set; }
            public bool новый_год { get; set; }
            public bool начало_периода { get; set; }
            public bool конец_периода { get; set; }
            public string наимен_месяца { get; set; }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void заполнитьXML(bool алфавит)
        {
            Cursor = Cursors.WaitCursor;
            //    Word.Application oWord = new Word.Application();

            string curDir = System.IO.Directory.GetCurrentDirectory();

            string шаблон = curDir + @"\реестр7.docx";

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
                    Table table2 = tables.Last();

                    //o.Bookmarks["менеджер"].Range.Text = клРеестр.фио_менеджера;
                    //o.Bookmarks["дата"].Range.Text = клРеестр.дата.ToLongDateString();
                    //o.Bookmarks["филиал"].Range.Text = наименФилиала;
                    //o.Bookmarks["услуга"].Range.Text = клВид_услуги.наимен;

                    клXML.ChangeTextInCell(table0, 0, 1, наименФилиала);
                    клXML.ChangeTextInCell(table0, 0, 2, "Все менеджеры");

                    клXML.ChangeTextInCell(table1, 0, 0, клВид_услуги.наимен);
                    клXML.ChangeTextInCell(table1, 0, 2, DateTime.Today.ToShortDateString());

                    //Table table = package.MainDocumentPart.Document.Body.ChildElements.Last<Table>();
                    TableRow lastRow = table2.Elements<TableRow>().Last();
                    //for (int k = 0; k < 17; k++)
                    //{
                    //    клXML.ChangeTextInCell(table2, 1, k, " ");
                    //}





                    int строк = tempList.Count;
                    for (int s = 1; s <= строк; s++)
                    {
                        TableRow newRow = lastRow.Clone() as TableRow;
                        table2.AppendChild<TableRow>(newRow);
                    }


                    System.Linq.IOrderedEnumerable<temp> query;
              //      System.Data.OrderedEnumerableRowCollection<dsТабель.реестрRow> query;
                    if (алфавит)
                    {
                        query = tempList
                            .OrderBy(n => n.фио);
                    }
                    else
                    {
                        query = tempList
                            .OrderBy(n => n.номер);
                    }

                    int j = 0;
                    foreach (temp rRow in query)
                    {
                        j++;
                        клXML.ChangeTextInCell(table2, j, 0, rRow.номер.ToString());
                        клXML.ChangeTextInCell(table2, j, 1, rRow.фио);
                        клXML.ChangeTextInCell(table2, j, 2, rRow.адрес);
                        клXML.ChangeTextInCell(table2, j, 3, rRow.месяца);
                        клXML.ChangeTextInCell(table2, j, 4, rRow.сумма.ToString());
                        клXML.ChangeTextInCell(table2, j, 5, rRow.менеджер);
                    }
                    клXML.ChangeTextInCell(table2, j + 1, 1, "Всего за день");
                    клXML.ChangeTextInCell(table2, j + 1, 4, всего.ToString());




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

        private void button3_Click(object sender, EventArgs e)
        {
            заполнитьXML(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            заполнитьXML(true);
        }
      

    }
}
