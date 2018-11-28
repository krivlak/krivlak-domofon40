using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace domofon40
{
    public partial class реестр_услуг : Form
    {
        public реестр_услуг()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        int  всего = 0;
        List<temp0> temp0List = new List<temp0>();
        List<temp> tempList = new List<temp>();
        private void реестр_услуг_Load(object sender, EventArgs e)
        {
            try
            {
                заполнить();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        class temp0
        {
            public int год { get; set; }
            public int месяц { get; set; }
            public bool пусто { get; set; }
            public bool тире { get; set; }
            public string символ { get; set; }
            public bool новый_год { get; set; }

            public bool начало_периода { get; set; }
            public bool конец_периода { get; set; }
            public string наимен_месяца { get; set; }

        }
        class temp
        {
            public string фио { get; set; }
            public string адрес { get; set; }
            public string месяц { get; set; }
            public int сумма { get; set; }
            public int номер { get; set; }
            public string менеджер { get; set; }



        }

        private void заполнить()
        {
            try
            {
                foreach (оплаты oRow in de.оплаты
        .Where(n => n.дата == клРеестр.дата)
        .Where(n => n.сотрудник == клСотрудник.сотрудник)
        .Where(n => n.вид_оплаты == клРеестр.вид_оплаты)
        .OrderBy(n => n.номер))
                {
                    string текст = "";
                    int сумма = 0;
                    temp0List.Clear();

                    //   dsТабель1.за_месяца.Clear();

                    foreach (оплачено оплRow in de.оплачено
                        .Where(n => n.оплата == oRow.оплата)
                        .Where(n => n.услуги.вид_услуги == клВид_услуги.вид_услуги))
                    {
                        if (оплRow.сумма > 0)
                        {

                            сумма += оплRow.сумма;

                            temp0 NewR = new temp0();
                            NewR.год = оплRow.год;
                            NewR.месяц = оплRow.месяц;
                            temp0List.Add(NewR);

                        }

                    }

                    if (сумма > 0)
                    {
                        int кГод = 0;
                        int кМесяц = -1;
                        foreach (temp0 sRow in temp0List
                            .OrderBy(n => n.год)
                            .ThenBy(n => n.месяц))
                        {
                            if (sRow.год != DateTime.Today.Year)
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

                        foreach (temp0 sRow in temp0List
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


                        foreach (temp0 sRow in temp0List
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



                        temp NewRow = new temp();
                        NewRow.фио = oRow.клиенты.фио;
                        NewRow.адрес = oRow.клиенты.адрес;

                        //NewRow.адрес = oRow.клиенты.дома.улицы.наимен.Trim()
                        //    + " " + oRow.клиенты.дома.номер.ToString().Trim()
                        //    + oRow.клиенты.дома.корпус.Trim()
                        //    + " - " + oRow.клиенты.квартира.ToString().Trim();

                        if (oRow.клиенты.ввод > 0)
                        {
                            NewRow.адрес += " ввод " + oRow.клиенты.ввод.ToString();
                        }

                        NewRow.сумма = сумма;
                        NewRow.месяц = текст;
                        NewRow.номер = oRow.номер;
                        tempList.Add(NewRow);
                        всего += сумма;
                    }
                    //////////////  
                    текст = "";
                    сумма = 0;
                    temp0List.Clear();

                    //   dsТабель1.за_месяца.Clear();

                    foreach (возврат оплRow in de.возврат
                        .Where(n => n.оплата == oRow.оплата)
                        .Where(n => n.услуги.вид_услуги == клВид_услуги.вид_услуги))
                    {
                        if (оплRow.сумма > 0)
                        {

                            сумма += оплRow.сумма;

                            temp0 NewR = new temp0();
                            NewR.год = оплRow.год;
                            NewR.месяц = оплRow.месяц;
                            temp0List.Add(NewR);

                        }

                    }

                    if (сумма > 0)
                    {
                        int кГод = 0;
                        int кМесяц = -1;
                        foreach (temp0 sRow in temp0List
                            .OrderBy(n => n.год)
                            .ThenBy(n => n.месяц))
                        {
                            if (sRow.год != DateTime.Today.Year)
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

                        foreach (temp0 sRow in temp0List
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


                        foreach (temp0 sRow in temp0List
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



                        temp NewRow = new temp();
                        NewRow.фио = oRow.клиенты.фио;
                        NewRow.адрес = oRow.клиенты.адрес;

                        //NewRow.адрес = oRow.клиенты.дома.улицы.наимен.Trim()
                        //    + " " + oRow.клиенты.дома.номер.ToString().Trim()
                        //    + oRow.клиенты.дома.корпус.Trim()
                        //    + " - " + oRow.клиенты.квартира.ToString().Trim();

                        if (oRow.клиенты.ввод > 0)
                        {
                            NewRow.адрес += " ввод " + oRow.клиенты.ввод.ToString();
                        }
                        NewRow.адрес += "  Возврат";
                        NewRow.сумма = -сумма;
                        NewRow.месяц = текст;
                        NewRow.номер = oRow.номер;
                        tempList.Add(NewRow);
                        всего -= сумма;


                    }


                }

                    textBox1.Text = всего.ToString("0;#;#");
                bindingSource1.DataSource = tempList;
                dataGridView1.Focus();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Сбой загрузки " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            заполнитьXML(false);
        }

        private void заполнитьXML(bool алфавит)
        {
            Cursor = Cursors.WaitCursor;
            //    Word.Application oWord = new Word.Application();

            string curDir = System.IO.Directory.GetCurrentDirectory();

            string шаблон = curDir + @"\реестр17.docx";

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
                    клXML.ChangeTextInCell(table0, 0, 2, клРеестр.фио_менеджера);

                    клXML.ChangeTextInCell(table1, 0, 0, клВид_услуги.наимен);
                    клXML.ChangeTextInCell(table1, 0, 1, клРеестр.наименВидаОплаты);
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



                    //System.Data.OrderedEnumerableRowCollection<dsТабель.реестрRow> query;
               //     var ее =tempList.OrderBy(n => n.фио).ToList();
                    List<temp> query;
                    if (алфавит)
                    {
                        query = tempList
                            .OrderBy(n => n.фио).ToList();
                    }
                    else
                    {
                        query = tempList
                            .OrderBy(n => n.номер).ToList();
                    }

                    int j = 0;
                    foreach (temp rRow in query)
                    {
                        j++;
                        клXML.ChangeTextInCell(table2, j, 0, rRow.номер.ToString());
                        клXML.ChangeTextInCell(table2, j, 1, rRow.фио);
                        клXML.ChangeTextInCell(table2, j, 2, rRow.адрес);
                        клXML.ChangeTextInCell(table2, j, 3, rRow.месяц);
                        клXML.ChangeTextInCell(table2, j, 4, rRow.сумма.ToString());
                        //  клXML.ChangeTextInCell(table2, j, 5, rRow.менеджер);
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

        private void button5_Click(object sender, EventArgs e)
        {
            заполнитьXML(true);
        }


    }
}
