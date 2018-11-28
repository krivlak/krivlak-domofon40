using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
namespace domofon40
{
    public partial class дом1услуга : Form
    {
        public дом1услуга()
        {
            InitializeComponent();
        }
        List<temp> listTemp0 = new List<temp>();
        List<temp> listTemp = new List<temp>();
        domofon40.domofon14Entities de = new domofon14Entities();
        private void дом1услуга_Load(object sender, EventArgs e)
        {
            temp.Moving -= temp_Moving;
            try
            {
              //  string sqlString = "дом1услуга @услуга= @p0, @дом = @p1 ";

                listTemp0 = de.Database.SqlQuery<temp>("дом1услуга @услуга= @p0, @дом = @p1 ", клУслуга.услуга, клДом.дом).ToList();
                listTemp = listTemp0;
                //            listTemp.fi
                bindingSource1.DataSource = listTemp;

                поселокTextBox.DataBindings.Add("Text", bindingSource1, "наимен_поселка");
                имяTextBox.DataBindings.Add("Text", bindingSource1, "Имя");
                отчествоTextBox.DataBindings.Add("Text", bindingSource1, "отчество");
                телефонTextBox.DataBindings.Add("Text", bindingSource1, "телефон");
                прим0TextBox.DataBindings.Add("Text", bindingSource1, "прим0");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сбой записи " + ex.Message);
            }

            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            temp.Moving += temp_Moving;
            FormClosing += монтажникам1дом_FormClosing;
            dataGridView1.DataError += dataGridView1_DataError;

        }

        void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridViewTextBoxColumn[] aColumns = { примColumn };
            if (aColumns.Contains(dataGridView1.Columns[e.ColumnIndex]))
            {
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
            }

        }
        void монтажникам1дом_FormClosing(object sender, FormClosingEventArgs e)
        {
            temp.Moving -= temp_Moving;
        }


        void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            //bool yy = (bool)dataGridView1.Rows[e.RowIndex].Cells["покраситьColumn"].Value;
            //if (yy)
            //{
            //    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(200, 255, 200);
            //}

            bool y3 = (bool)dataGridView1.Rows[e.RowIndex].Cells["должникColumn"].Value;
            if (y3)
            {
                if (dataGridView1.Columns[e.ColumnIndex] == годColumn
                    || dataGridView1.Columns[e.ColumnIndex] == месяцColumn
                    || dataGridView1.Columns[e.ColumnIndex] == долг_месColumn)
                {
                    e.CellStyle.ForeColor = System.Drawing.Color.Red;
                }
            }
            if (dataGridView1.Columns[e.ColumnIndex] == звонокColumn)
            {
                DateTime? dt = dataGridView1.Rows[e.RowIndex].Cells["звонокColumn"].Value as DateTime?;
                if (dt != null)
                {
                    if (dt.Value.Date == DateTime.Today)
                    {
                        e.CellStyle.ForeColor = System.Drawing.Color.Blue;
                    }
                }
            }
        }

        void temp_Moving(temp obj)
        {
            //   Console.WriteLine(obj.фио);

            if (obj.поле == "наш")
            {


                клиенты kRow = de.клиенты.Single(n => n.клиент == obj.клиент);
                услуги[] delRow = kRow.услуги.Where(n => n.услуга == obj.услуга).ToArray();

                foreach (услуги dRow in delRow)
                {
                    kRow.услуги.Remove(dRow);
                }
                de.SaveChanges();
                if (obj.наш)
                {
                    услуги newRow = de.услуги.Single(n => n.услуга == obj.услуга);
                    kRow.услуги.Add(newRow);
                    de.SaveChanges();
                }
            }

            if (obj.поле == "прим0")
            {
                if (obj.прим0 == null)
                {
                    obj.прим0 = "";
                }

                клиенты kRow = de.клиенты.Single(n => n.клиент == obj.клиент);
                kRow.прим = obj.прим0;
                de.SaveChanges();
            }
            if (obj.поле == "телефон")
            {

                if (obj.телефон == null)
                {
                    obj.телефон = "";
                }
                клиенты kRow = de.клиенты.Single(n => n.клиент == obj.клиент);
                kRow.телефон = obj.телефон;

                de.SaveChanges();
            }
            if (obj.поле == "прим")
            {

                if (obj.прим == null)
                {
                    obj.прим = "";
                }
                примечания[] aRow = de.примечания.Where(n => n.клиент == obj.клиент && n.услуга == obj.услуга).ToArray();
                //foreach( примечания delRow in aRow)
                //{
                de.примечания.RemoveRange(aRow);
                de.SaveChanges();


                if (obj.прим != String.Empty)
                {
                    примечания newRow = new примечания();
                    newRow.клиент = obj.клиент;
                    newRow.услуга = obj.услуга;
                    newRow.прим = obj.прим;
                    de.примечания.Add(newRow);
                    de.SaveChanges();
                }

            }


        }

        class temp
        {
            public string адрес { get; set; }
            public string наимен_поселка { get; set; }
            public string наимен_улицы { get; set; }
            public int номер_дома { get; set; }
            public string корпус { get; set; }
            public Guid клиент { get; set; }
            public Guid услуга { get; set; }
            public int год { get; set; }
            public int месяц { get; set; }
            public int долг_мес { get; set; }
            public DateTime? договор_с { get; set; }
            public DateTime? отключен { get; set; }
            public DateTime? повтор { get; set; }
            public DateTime? звонок { get; set; }
            public string фио { get; set; }
            public string имя { get; set; }
            public string отчество { get; set; }
            public int квартира { get; set; }
            public int квартира0 { get; set; }
            public int ввод { get; set; }
            public int подъезд { get; set; }

            public int порядок_услуги { get; set; }
            public string наимен_услуги { get; set; }
            public int строка { get; set; }
            //     public bool наш { get; set; }

            public bool должник { get; set; }
            //         public bool подключить { get; set; }
            public bool отключить { get; set; }
            //        public bool повторно { get; set; }

            bool Наш;
            public bool наш
            {
                get
                {
                    return Наш;
                }
                set
                {
                    Наш = value;
                    if (Moving != null)
                    {
                        поле = "наш";
                        Moving(this);
                    }
                }
            }
            string Прим0;
            public string прим0
            {
                get
                {
                    return Прим0;
                }
                set
                {
                    Прим0 = value;
                    if (Moving != null)
                    {
                        поле = "прим0";
                        Moving(this);
                    }
                }
            }
            string Прим;
            public string прим
            {
                get
                {
                    return Прим;
                }
                set
                {
                    Прим = value;
                    if (Moving != null)
                    {
                        поле = "прим";
                        Moving(this);
                    }
                }
            }

            string Телефон;
            public string телефон
            {
                get
                {
                    return Телефон;
                }
                set
                {
                    Телефон = value;
                    if (Moving != null)
                    {
                        поле = "телефон";
                        Moving(this);
                    }
                }
            }

            public string поле = "";

            public static event Action<temp> Moving;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listTemp.Count(n => n.отключить) == 0)
            {
                MessageBox.Show("Отметьте клиентов на отключение");
                return;
            }
            Word.Application oWord = new Word.Application();

            string curDir = System.IO.Directory.GetCurrentDirectory();

            object шаблон = curDir + @"\монтажники1вид.dot";
            if (!System.IO.File.Exists(шаблон.ToString()))
            {
                MessageBox.Show("Нет файла " + шаблон.ToString());
                return;
            }

            //domofon10.DataClasses1DataContext dc = new DataClasses1DataContext();

            //string наименФилиала = dc.филиал
            //    .OrderBy(n => n.порядок)
            //    .First().наимен;

            Word.Document o = oWord.Documents.Add(Template: шаблон);
            oWord.Application.Visible = true;
            o.Bookmarks["дата"].Range.Text = DateTime.Today.ToLongDateString();
            //       o.Bookmarks["филиал"].Range.Text = наименФилиала;

            o.Bookmarks["адрес"].Range.Text = this.Text;
            int j = 1;

            foreach (temp kRow in listTemp
                .Where(n => n.отключить))
            {
                j++;
                o.Tables[4].Cell(j, 1).Range.Text = kRow.наимен_услуги.Trim();
                o.Tables[4].Cell(j, 2).Range.Text = kRow.адрес.Trim();
                o.Tables[4].Cell(j, 3).Range.Text = kRow.фио;
                o.Tables[4].Cell(j, 4).Range.Text = kRow.долг_мес.ToString("0;#;#");
                o.Tables[4].Cell(j, 5).Range.Text = kRow.прим;
                o.Tables[4].Cell(j, 6).Range.Text = kRow.прим0;
                o.Tables[4].Cell(j, 7).Range.Text = kRow.телефон;
                //o.Tables[4].Cell(j, 8).Range.Text = kRow.месяц.ToString("0;#;#");
                //o.Tables[4].Cell(j, 9).Range.Text = kRow.год.ToString("0;#;#");
                //o.Tables[4].Cell(j, 10).Range.Text = 
                //if (kRow.отключен != null)
                //    o.Tables[4].Cell(j, 11).Range.Text = kRow.отключен.Value.ToShortDateString();
                //if (kRow.повтор != null)
                //    o.Tables[4].Cell(j, 12).Range.Text = kRow.повтор.Value.ToShortDateString();

                o.Tables[4].Rows.Add();
            }
            o.Tables[4].Cell(j + 1, 2).Range.Text = "Всего квартир ";
            o.Tables[4].Cell(j + 1, 4).Range.Text = (j - 1).ToString("0;#;#");



            oWord.Application.Visible = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            temp vRow = bindingSource1.Current as temp;
            клУслуга.услуга = vRow.услуга;
            клУслуга.наимен = vRow.наимен_услуги;

            клКлиент.клиент = vRow.клиент;
            клКлиент.фио = vRow.фио;
            Cursor = Cursors.WaitCursor;

            только_просмотр формаОплатить = new только_просмотр();

            формаОплатить.Text = "Оплаты за " + клУслуга.наимен.Trim() + " " + клКлиент.фио + " " + клКлиент.адрес;
            формаОплатить.ShowDialog();

            Cursor = Cursors.Default;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                // bindingSource1.Filter = "должник";
                listTemp = listTemp0.Where(n => n.должник).ToList();
                bindingSource1.DataSource = listTemp;
                checkBox1.Text = "Все";
            }
            else
            {
                // bindingSource1.Filter = null;
                listTemp = listTemp0;
                bindingSource1.DataSource = listTemp;
                checkBox1.Text = "Должники";

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            string curDir = System.IO.Directory.GetCurrentDirectory();

            string шаблон = curDir + @"\проверка1дом.docx";

            if (!System.IO.File.Exists(шаблон.ToString()))
            {
                MessageBox.Show("Нет файла " + шаблон.ToString());
                Cursor = Cursors.Default;
                return;
            }

            var template = new System.IO.FileInfo(шаблон);
            string tempFile = curDir + @"\temp\temp.docx";
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

            try
            {
                using (WordprocessingDocument package = WordprocessingDocument.Open(tempFile, true))
                {
                    //int строкаРаб = 0;

                    var tables = package.MainDocumentPart.Document.Body.Elements<Table>();

                    Table table1 = tables.ElementAt(0);
                    Table table2 = tables.ElementAt(1);


                    клXML.ChangeTextInCell(table1, 0, 0, this.Text + " " + DateTime.Today.ToLongDateString());

                    TableRow lastRow = table2.Elements<TableRow>().Last();

                    //      var queryTemp = listTemp.ToArray();
                    int j = 0;


                    foreach (temp kRow in listTemp)
                    {
                        TableRow newRow1 = lastRow.Clone() as TableRow;


                        table2.AppendChild<TableRow>(newRow1);


                        j++;

                        клXML.ChangeTextInCell(table2, j, 0, kRow.квартира.ToString("0;#;#"));
                        клXML.ChangeTextInCell(table2, j, 1, kRow.ввод.ToString("0;#;#"));
                        клXML.ChangeTextInCell(table2, j, 2, kRow.фио);

                        клXML.ChangeTextInCell(table2, j, 3, kRow.наимен_услуги);

                        клXML.ChangeTextInCell(table2, j, 4, kRow.долг_мес.ToString("0;#;#"));

                        if (kRow.отключить)
                        {
                            клXML.ChangeTextInCell(table2, j, 5, "V");
                        }
                        else
                        {
                            клXML.ChangeTextInCell(table2, j, 5, "");
                        }
                        if (kRow.договор_с != null)
                        {
                            клXML.ChangeTextInCell(table2, j, 6, kRow.договор_с.Value.ToShortDateString());
                        }
                        else
                        {
                            клXML.ChangeTextInCell(table2, j, 6, "");
                        }
                        if (kRow.отключен != null)
                        {
                            клXML.ChangeTextInCell(table2, j, 7, kRow.отключен.Value.ToShortDateString());
                        }
                        else
                        {
                            клXML.ChangeTextInCell(table2, j, 7, "");
                        }
                        if (kRow.повтор != null)
                        {
                            клXML.ChangeTextInCell(table2, j, 8, kRow.повтор.Value.ToShortDateString());
                        }
                        else
                        {
                            клXML.ChangeTextInCell(table2, j, 8, "");
                        }



                    }


                    j++;
                    клXML.ChangeTextInCell(table2, j, 0, "");
                    клXML.ChangeTextInCell(table2, j, 1, "");
                    клXML.ChangeTextInCell(table2, j, 2, "");
                    клXML.ChangeTextInCell(table2, j, 3, "");
                    клXML.ChangeTextInCell(table2, j, 4, "");
                    клXML.ChangeTextInCell(table2, j, 5, "");
                    клXML.ChangeTextInCell(table2, j, 6, "");
                    клXML.ChangeTextInCell(table2, j, 7, "");
                    клXML.ChangeTextInCell(table2, j, 8, "");


                }
                //  }
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
            if (bindingSource1.Count > 0)
            {
                Cursor = Cursors.WaitCursor;

                temp tRow = bindingSource1.Current as temp;
                //клУслуга.услуга = vRow.услуга;
                //клУслуга.наимен = vRow.наимен_услуги;

                //клКлиент.клиент = vRow.клиент;
                //клКлиент.фио = vRow.фио;


                //клКлиент.клиент = tRow.клиент;
                //клУслуга.услуга = tRow.услуга;
                звонки новыйЗвонок = new звонки();
                Guid NewKod = Guid.NewGuid();
                новыйЗвонок.дата = DateTime.Now;
                новыйЗвонок.звонок = NewKod;
                новыйЗвонок.клиент = tRow.клиент;
                новыйЗвонок.прим = "";


                de.звонки.Add(новыйЗвонок);
                try
                {
                    de.SaveChanges();
                    tRow.звонок = новыйЗвонок.дата;
                    dataGridView1.Refresh();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                //     новыйЗвонок.звонок=



                Cursor = Cursors.Default;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
