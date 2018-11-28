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
    public partial class работы_мастера : Form
    {
        public работы_мастера()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        BindingList<temp> tempList = new BindingList<temp>();
        private void работы_мастера_Load(object sender, EventArgs e)
        {
            int стоимость = 0;
            int материалы = 0;
            int зарплата = 0;
            try
            {
                var query = de.опл_работы
                   .Where(n => n.оплаты.дата.Year == клМесяц.год && n.оплаты.дата.Month == клМесяц.месяц)
                    .OrderBy(n => n.оплаты.дата);

                foreach (опл_работы uRow in query)
                {
                    temp NewRow = new temp();
                    NewRow.дата = uRow.оплаты.дата;

                    NewRow.должность = uRow.сотрудники.должность;

                    NewRow.мастер = uRow.мастер;
                    NewRow.материалы = (int)uRow.ст_материалов;
                    NewRow.наимен_работы = uRow.работы.наимен;
                    NewRow.номер_квитанции = uRow.оплаты.номер;
                    NewRow.работа = uRow.работа;
                    NewRow.сумма = (int)uRow.стоимость;
                    NewRow.зарплата = NewRow.сумма - NewRow.материалы;
                    NewRow.задание = uRow.задание;
                    NewRow.фио_мастера = uRow.сотрудники.фио;
                    NewRow.адрес = uRow.оплаты.клиенты.адрес;
                    NewRow.фио = uRow.оплаты.клиенты.фио;
                    NewRow.клиент = uRow.оплаты.клиент;
                    NewRow.кассир = uRow.оплаты.сотрудник;
                    NewRow.фио_кассира = uRow.оплаты.сотрудники.фио;
                    tempList.Add(NewRow);
                    стоимость += NewRow.сумма;
                    материалы += NewRow.материалы;
                    зарплата += NewRow.зарплата;
                }
                bindingSource1.DataSource = tempList;
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            textBox1.Text = стоимость.ToString();
            textBox2.Text = материалы.ToString();
            textBox3.Text = зарплата.ToString();
//            dataGridView1.CellMouseClick += dataGridView1_CellMouseClick;
            dataGridView1.CellMouseClick += dataGridView1_CellMouseClick;
        }

        void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (dataGridView1.Columns[e.ColumnIndex] == мастерColumn)
                {
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
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Сбой записи..." + ex.Message);
                        }

                    }
                }
            }
        
        }
        //void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    if (e.Button == System.Windows.Forms.MouseButtons.Right)
        //    {
        //        if (dataGridView1.Columns[e.ColumnIndex] == мастерColumn)
        //        {
        //            dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
        //            temp uRow = bindingSource1.Current as temp;
        //            клМастер.мастер = uRow.мастер;
        //            клМастер.выбран = false;
        //            выбор_мастера ВыборМастера = new выбор_мастера();
        //            ВыборМастера.ShowDialog();
        //            if (клМастер.выбран)
        //            {
        //                uRow.мастер = клМастер.мастер;
        //                uRow.фио_мастера = клМастер.фио;
        //                uRow.должность = клМастер.deRow.должность;
        //                try
        //                {
        //                    опл_работы upRow = de.опл_работы.Single(n => n.задание == uRow.задание);
        //                    upRow.мастер = клМастер.мастер;
        //                    de.SaveChanges();
        //                }
        //                catch (Exception ex)
        //                {
        //                    MessageBox.Show("Сбой записи..." + ex.Message);
        //                }

        //            }
        //        }
        //    }
        //}

        //void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    if (e.Button == System.Windows.Forms.MouseButtons.Right)
        //    {
        //        if (dataGridView1.Columns[e.ColumnIndex] == мастерColumn)
        //        {
        //            dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
        //            temp uRow = bindingSource1.Current as temp;
        //            клМастер.мастер = uRow.мастер;
        //            клМастер.выбран = false;
        //            выбор_мастера ВыборМастера = new выбор_мастера();
        //            ВыборМастера.ShowDialog();
        //            if (клМастер.выбран)
        //            {
        //                uRow.мастер = клМастер.мастер;
        //                uRow.фио_мастера = клМастер.фио;
        //                uRow.должность = клМастер.deRow.должность;
        //                try
        //                {
        //                    опл_работы upRow = de.опл_работы.Single(n => n.задание == uRow.задание);
        //                    upRow.мастер = клМастер.мастер;
        //                    de.SaveChanges();
        //                }
        //                catch (Exception ex)
        //                {
        //                    MessageBox.Show("Сбой записи..." + ex.Message);
        //                }

        //            }
        //        }
        //    }
        //}


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
            public Guid кассир { get; set; }
            public String фио_кассира { get; set; }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            заполнитьXML();
        }

        private void заполнитьXML()
        {
            Cursor = Cursors.WaitCursor;
            //  DsTemp.реестрRow uRow = (реестрBindingSource.Current as DataRowView).Row as DsTemp.реестрRow;
            temp uRow = bindingSource1.Current as temp;
            //    Word.Application oWord = new Word.Application();

            string curDir = System.IO.Directory.GetCurrentDirectory();

            string шаблон = curDir + @"\реестр_работ.docx";

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

            //     domofon10.DataClasses1DataContext dc = new DataClasses1DataContext();
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
                    клXML.ChangeTextInCell(table1, 0, 2, uRow.фио_мастера.Trim() + "  " + uRow.должность);

                    //Table table = package.MainDocumentPart.Document.Body.ChildElements.Last<Table>();
                    TableRow lastRow = table2.Elements<TableRow>().Last();
                    //for (int k = 0; k < 17; k++)
                    //{
                    //    клXML.ChangeTextInCell(table2, 1, k, " ");
                    //}


                    var query = tempList
                                      .Where(n => n.мастер == uRow.мастер)
                                      .OrderBy(n => n.дата);


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
                    int sСумма = 0;
                    int sМатериалы = 0;
                    int sЗарплата = 0;
                    int j = 0;
                    foreach (temp rRow in query)
                    {
                        j++;
                        клXML.ChangeTextInCell(table2, j, 0, rRow.дата.ToShortDateString());
                        клXML.ChangeTextInCell(table2, j, 1, rRow.номер_квитанции.ToString());
                        //     клXML.ChangeTextInCell(table2, j, 2, rRow.номер_наряда.ToString());
                        клXML.ChangeTextInCell(table2, j, 2, rRow.наимен_работы);
                        клXML.ChangeTextInCell(table2, j, 3, rRow.зарплата.ToString("0;#;#"));
                        клXML.ChangeTextInCell(table2, j, 4, rRow.материалы.ToString("0;#;#"));
                        клXML.ChangeTextInCell(table2, j, 5, rRow.сумма.ToString("0;#;#"));
                        sСумма += rRow.сумма;
                        sМатериалы += rRow.материалы;
                        sЗарплата += rRow.зарплата;
                    }
                    клXML.ChangeTextInCell(table3, 0, 2, "Всего");

                    клXML.ChangeTextInCell(table3, 0, 3, sЗарплата.ToString("0;#;#"));
                    клXML.ChangeTextInCell(table3, 0, 4, sМатериалы.ToString("0;#;#"));
                    клXML.ChangeTextInCell(table3, 0, 5, sСумма.ToString("0;#;#"));




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

        private void заполнитьXMLменеджер()
        {
            Cursor = Cursors.WaitCursor;
            //  DsTemp.реестрRow uRow = (реестрBindingSource.Current as DataRowView).Row as DsTemp.реестрRow;
            temp uRow = bindingSource1.Current as temp;
            //    Word.Application oWord = new Word.Application();

            string curDir = System.IO.Directory.GetCurrentDirectory();

            string шаблон = curDir + @"\реестр_работ.docx";

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

            //     domofon10.DataClasses1DataContext dc = new DataClasses1DataContext();
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
                    клXML.ChangeTextInCell(table1, 0, 2, uRow.фио_кассира.Trim()) ;

                    //Table table = package.MainDocumentPart.Document.Body.ChildElements.Last<Table>();
                    TableRow lastRow = table2.Elements<TableRow>().Last();
                    //for (int k = 0; k < 17; k++)
                    //{
                    //    клXML.ChangeTextInCell(table2, 1, k, " ");
                    //}


                    var query = tempList
                                      .Where(n => n.кассир == uRow.кассир)
                                      .OrderBy(n => n.дата);


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
                    int sСумма = 0;
                    int sМатериалы = 0;
                    int sЗарплата = 0;
                    int j = 0;
                    foreach (temp rRow in query)
                    {
                        j++;
                        клXML.ChangeTextInCell(table2, j, 0, rRow.дата.ToShortDateString());
                        клXML.ChangeTextInCell(table2, j, 1, rRow.номер_квитанции.ToString());
                        //     клXML.ChangeTextInCell(table2, j, 2, rRow.номер_наряда.ToString());
                        клXML.ChangeTextInCell(table2, j, 2, rRow.наимен_работы);
                        клXML.ChangeTextInCell(table2, j, 3, rRow.зарплата.ToString("0;#;#"));
                        клXML.ChangeTextInCell(table2, j, 4, rRow.материалы.ToString("0;#;#"));
                        клXML.ChangeTextInCell(table2, j, 5, rRow.сумма.ToString("0;#;#"));
                        sСумма += rRow.сумма;
                        sМатериалы += rRow.материалы;
                        sЗарплата += rRow.зарплата;
                    }
                    клXML.ChangeTextInCell(table3, 0, 2, "Всего");

                    клXML.ChangeTextInCell(table3, 0, 3, sЗарплата.ToString("0;#;#"));
                    клXML.ChangeTextInCell(table3, 0, 4, sМатериалы.ToString("0;#;#"));
                    клXML.ChangeTextInCell(table3, 0, 5, sСумма.ToString("0;#;#"));




                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Закройте файл Word..." + ex.Message);
                return;

            }

            клTemp.закрытьWord();


            клXML.просмотрWord(tempFile);
            Cursor = Cursors.Default;



        }

        private void button2_Click(object sender, EventArgs e)
        {
            заполнитьXMLменеджер();
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DataGridViewCell ячейка = sender as DataGridViewCell;
            //dataGridView1.CurrentCell = ячейка;
            //  dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Сбой записи..." + ex.Message);
                }

            }
        }
    }
}
