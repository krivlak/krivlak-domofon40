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
    public partial class реестр_опл_работ : Form
    {
        public реестр_опл_работ()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        //BindingList<temp> tempList = new BindingList<temp>();
        List<temp> tempList = new List<temp>();

        private void реестр_опл_работ_Load(object sender, EventArgs e)
        {

          
           
            int стоимость = 0;
            int материалы = 0;
            int зарплата = 0;
            try
            {
                // как добавить возврат за работы ?
                var query = de.опл_работы
                            .Where(n => n.оплаты.дата >= клПериод.дата_с && n.оплаты.дата <= клПериод.дата_по)
                            .OrderBy(n => n.оплаты.дата)
                            .ThenBy(n =>n.работы.порядок );

                foreach (опл_работы uRow in query)
                {
                    temp NewRow = new temp()
                    {
                        дата = uRow.оплаты.дата,

                        должность = uRow.сотрудники.должность,

                        мастер = uRow.мастер,
                        материалы = uRow.ст_материалов,
                        наимен_работы = uRow.работы.наимен,
                        номер_квитанции = uRow.оплаты.номер,
                        работа = uRow.работа,
                        сумма = uRow.стоимость,
                        зарплата = uRow.стоимость - uRow.ст_материалов,
                        задание = uRow.задание,
                        фио_мастера = uRow.сотрудники.фио,
                        адрес = uRow.оплаты.клиенты.адрес,
                        фио = uRow.оплаты.клиенты.фио,
                        клиент = uRow.оплаты.клиент,
                        номер = uRow.номер,
                        прейскурант = uRow.работы.прейскурант,
                        вид_оплаты = uRow.оплаты.вид_оплаты,
                        наимен_вида_опл = uRow.оплаты.виды_оплат.наимен,
                        менеджер = uRow.оплаты.сотрудник,
                        фио_менеджера = uRow.оплаты.сотрудники.фио
                    };

                    tempList.Add(NewRow);
                    стоимость += NewRow.сумма;
                    материалы += NewRow.материалы;
                    зарплата += NewRow.зарплата;
                }
                var query2 = de.воз_работы
                           .Where(n => n.оплаты.дата >= клПериод.дата_с && n.оплаты.дата <= клПериод.дата_по)
                           .OrderBy(n => n.оплаты.дата)
                           .ThenBy(n => n.работы.порядок);
                foreach ( воз_работы uRow in query2)
                {
                    temp NewRow = new temp()
                    {
                        дата = uRow.оплаты.дата,

                        //должность = uRow.сотрудники.должность,

                        мастер = Guid.Empty,
                        //материалы = uRow.ст_материалов,
                        наимен_работы = uRow.работы.наимен ,
                        номер_квитанции = uRow.оплаты.номер,
                        работа = uRow.работа,
                        сумма = - uRow.сумма,
                        //зарплата = uRow.стоимость - uRow.ст_материалов,
                        //задание = uRow.задание,
                        фио_мастера = "Возврат",
                        адрес = uRow.оплаты.клиенты.адрес,
                        фио = uRow.оплаты.клиенты.фио,
                        клиент = uRow.оплаты.клиент,
                    //   номер = uRow.номер,
                        прейскурант = uRow.работы.прейскурант,
                        вид_оплаты = uRow.оплаты.вид_оплаты,
                        наимен_вида_опл = uRow.оплаты.виды_оплат.наимен,
                        менеджер = uRow.оплаты.сотрудник,
                        фио_менеджера = uRow.оплаты.сотрудники.фио
                    };

                    tempList.Add(NewRow);
                    стоимость += NewRow.сумма;
                    //материалы += NewRow.материалы;
                    //зарплата += NewRow.зарплата;
                }
                tempList = tempList.OrderBy(n => n.дата).ThenBy(n => n.номер_квитанции).ToList();
                клСетка.задать_ширину(dataGridView1);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Сбой загрузки " + ex.Message);
            }
          //  DataTable таблица = tempList.ToTable();
            bindingSource1.DataSource = tempList;
            bindingSource1.MoveLast();
            dataGridView1.Focus();
            textBox1.Text = стоимость.ToString();
            textBox2.Text = материалы.ToString();
            textBox3.Text = зарплата.ToString();
            dataGridView1.CellMouseClick += dataGridView1_CellMouseClick;
        }

        //void задать_ширину()
        //{
        //    int столбцов = dataGridView1.Columns.Count;
        //    int[] aW = new int[столбцов];
        //    int i = 0;
        //    foreach (DataGridViewColumn tCol in dataGridView1.Columns)
        //    {
        //        aW[i] = tCol.Width;
        //        i++;
        //    }
        //    double сумма = aW.Sum();
        //    double ширина = Screen.PrimaryScreen.WorkingArea.Width - 60;
        //    double поправка = ширина / сумма;
        //    i = 0;
        //    foreach (DataGridViewColumn tCol in dataGridView1.Columns)
        //    {
        //        double ss = aW[i] * поправка;
        //        tCol.Width = (int)ss;
        //        i++;
        //    }
        //    dataGridView1.Refresh();
        //}
        void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (dataGridView1.Columns[e.ColumnIndex]== мастерColumn)
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    temp uRow = bindingSource1.Current as temp;
                   // DataRow uRow = bindingSource1.Current as DataRow;
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
                            MessageBox.Show("Сбой записи..."+ ex.Message);
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
            public int номер { get; set; }
            public string прейскурант { get; set; }
            public Guid вид_оплаты { get; set; }
            public string наимен_вида_опл { get; set; }
            public Guid менеджер { get; set; }
            public String фио_менеджера { get; set; }
        }



        private void заполнитьXML()
        {
            if (bindingSource1.Count > 0)
            {
              
                Cursor = Cursors.WaitCursor;
                //  DsTemp.реестрRow uRow = (реестрBindingSource.Current as DataRowView).Row as DsTemp.реестрRow;
                temp uRow = bindingSource1.Current as temp;
                if (uRow.мастер == Guid.Empty)
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show("Выберите мастера");
                    return;
                }
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
                            клXML.ChangeTextInCell(table2, j, 5, rRow.сумма.ToString("0;-0;#"));
                            sСумма += rRow.сумма;
                            sМатериалы += rRow.материалы;
                            sЗарплата += rRow.зарплата;
                        }
                        клXML.ChangeTextInCell(table3, 0, 2, "Всего");

                        клXML.ChangeTextInCell(table3, 0, 3, sЗарплата.ToString("0;#;#"));
                        клXML.ChangeTextInCell(table3, 0, 4, sМатериалы.ToString("0;#;#"));
                        клXML.ChangeTextInCell(table3, 0, 5, sСумма.ToString("0;-0;#"));




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
            dataGridView1.Focus();

        }


        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            заполнитьXML();
        }

        private void реестр_менеджера()
        {
            if (bindingSource1.Count > 0)
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
                        клXML.ChangeTextInCell(table1, 0, 2, uRow.фио_менеджера.Trim() + "  " + uRow.наимен_вида_опл);

                        //Table table = package.MainDocumentPart.Document.Body.ChildElements.Last<Table>();
                        TableRow lastRow = table2.Elements<TableRow>().Last();
                        //for (int k = 0; k < 17; k++)
                        //{
                        //    клXML.ChangeTextInCell(table2, 1, k, " ");
                        //}


                        var query = tempList
                                          .Where(n => n.менеджер == uRow.менеджер)
                                          .Where(n => n.вид_оплаты == uRow.вид_оплаты)
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
                            //    клXML.ChangeTextInCell(table2, j, 4, rRow.материалы.ToString("0;#;#"));
                            if (rRow.мастер == Guid.Empty)
                            {
                                клXML.ChangeTextInCell(table2, j, 4, "Возв.");
                            }
                            else
                            {
                                клXML.ChangeTextInCell(table2, j, 4, rRow.материалы.ToString("0;#;#"));
                            }
                            клXML.ChangeTextInCell(table2, j, 5, rRow.сумма.ToString("0;-0;#"));
                            sСумма += rRow.сумма;
                            sМатериалы += rRow.материалы;
                            sЗарплата += rRow.зарплата;
                        }
                        клXML.ChangeTextInCell(table3, 0, 2, "Всего");

                        клXML.ChangeTextInCell(table3, 0, 3, sЗарплата.ToString("0;#;#"));
                        клXML.ChangeTextInCell(table3, 0, 4, sМатериалы.ToString("0;#;#"));
                        клXML.ChangeTextInCell(table3, 0, 5, sСумма.ToString("0;-0;#"));




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
            dataGridView1.Focus();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            реестр_менеджера();
        }
    }
}
