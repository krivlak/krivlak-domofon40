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
    public partial class монтажникам1дом : Form
    {
        public монтажникам1дом()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        List<temp> listTemp0 = new List<temp>();
        List<temp> listTemp = new List<temp>();
        private void монтажникам1дом_Load(object sender, EventArgs e)
        {
            temp.следить = false;
            try
            {
                string sqlString = "монтажники1дом @дом='" + клДом.дом + "' ,@вид='" + клВид_услуги.вид_услуги + "'";

                listTemp0 = de.Database.SqlQuery<temp>(sqlString).ToList();

            }
            catch(Exception ex)
            {
                MessageBox.Show("Сбой.." + ex.Message);
            }
            listTemp = listTemp0;
            bindingSource1.DataSource = listTemp;
       //     имяTextBox.DataBindings.Add("Text", bindingSource1, "Имя");
         //   отчествоTextBox.DataBindings.Add("Text", bindingSource1, "отчество");
            телефонTextBox.DataBindings.Add("Text", bindingSource1, "телефон");
            прим0TextBox.DataBindings.Add("Text", bindingSource1, "прим0");

            temp.следить = true;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
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


        class temp
        {

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
            public int квартира { get; set; }
            public int квартира0 { get; set; }
            public int ввод { get; set; }
            public int подъезд { get; set; }
            public string телефон { get; set; }
            public int порядок_услуги { get; set; }
            public string наимен_услуги { get; set; }
            public int строка { get; set; }
            public bool наш { get; set; }

            public bool должник { get; set; }
            //         public bool подключить { get; set; }
            public bool отключить { get; set; }
            //        public bool повторно { get; set; }
            //public string прим { get; set; }
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
                    if (следить)
                    {
                        domofon40.domofon14Entities de1 = new domofon14Entities();
                        примечания[] aRows = de1.примечания.Where(n => n.клиент == клиент && n.услуга == услуга).ToArray();
                        foreach (примечания delRow in aRows)
                        {
                            de1.примечания.Remove(delRow);
                        }
                        de1.SaveChanges();
                        if (value != null)
                        {
                            if (value.Trim() != String.Empty)
                            {
                                примечания newRow = new примечания();
                                newRow.услуга = услуга;
                                newRow.клиент = клиент;
                                newRow.прим = value;
                                de1.примечания.Add(newRow);
                                de1.SaveChanges();
                            }
                        }
                    }

                }

            }
         //   public string прим0 { get; set; }
            string Прим0;
            public string прим0
            {

                get
                {
                    return Прим0;
                }

                set
                {
                    if (value == null)
                    {
                        value = "";
                    }

                    Прим0 = value;
                    if (следить)
                    {
                        domofon40.domofon14Entities de1 = new domofon14Entities();
                       
                        клиенты kRow = de1.клиенты.Single(n => n.клиент == клиент);
                        kRow.прим = value;
                        de1.SaveChanges();
                    }

                }

            }

            public static bool следить = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
                Cursor = Cursors.WaitCursor;

                temp tRow = bindingSource1.Current as temp;
                клКлиент.клиент = tRow.клиент;
             //   клУслуга.услуга = tRow.услуга;
                звонки новыйЗвонок = new звонки();
          //      string NewKod = уникальный();
                новыйЗвонок.дата = DateTime.Now;
                новыйЗвонок.звонок = Guid.NewGuid();
                новыйЗвонок.клиент = tRow.клиент;
                новыйЗвонок.прим = "";
            //    новыйЗвонок.услуга = tRow.услуга;
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

        private void button8_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            string curDir = System.IO.Directory.GetCurrentDirectory();

            string шаблон = curDir + @"\задание1дом.docx";

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
                            клXML.ChangeTextInCell(table2, j, 6, "V");
                        }
                        else
                        {
                            клXML.ChangeTextInCell(table2, j, 6, "");
                        }

                    }


                    j++;
                    клXML.ChangeTextInCell(table2, j, 0, "");
                    клXML.ChangeTextInCell(table2, j, 1, "");
                    клXML.ChangeTextInCell(table2, j, 2, "");
                    клXML.ChangeTextInCell(table2, j, 3, "");
                    клXML.ChangeTextInCell(table2, j, 4, "");
                    клXML.ChangeTextInCell(table2, j, 5, "");
                    //клXML.ChangeTextInCell(table2, j, 6, "");
                    //клXML.ChangeTextInCell(table2, j, 7, "");


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

        private void button4_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            string curDir = System.IO.Directory.GetCurrentDirectory();

            string шаблон = curDir + @"\задание1дом.docx";

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
                   // int строкаРаб = 0;

                    var tables = package.MainDocumentPart.Document.Body.Elements<Table>();

                    Table table1 = tables.ElementAt(0);
                    Table table2 = tables.ElementAt(1);


                    клXML.ChangeTextInCell(table1, 0, 0, this.Text + " " + DateTime.Today.ToLongDateString());

                    TableRow lastRow = table2.Elements<TableRow>().Last();

                    //      var queryTemp = listTemp.ToArray();
                    int j = 0;


                    foreach (temp kRow in listTemp.Where(n=>n.должник))
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
                            клXML.ChangeTextInCell(table2, j, 6, "V");
                        }
                        else
                        {
                            клXML.ChangeTextInCell(table2, j, 6, "");
                        }

                    }


                    j++;
                    клXML.ChangeTextInCell(table2, j, 0, "");
                    клXML.ChangeTextInCell(table2, j, 1, "");
                    клXML.ChangeTextInCell(table2, j, 2, "");
                    клXML.ChangeTextInCell(table2, j, 3, "");
                    клXML.ChangeTextInCell(table2, j, 4, "");
                    клXML.ChangeTextInCell(table2, j, 5, "");
                    //клXML.ChangeTextInCell(table2, j, 6, "");
                    //клXML.ChangeTextInCell(table2, j, 7, "");


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

        private void button2_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
                //DsTemp.квартирыRow aRow = (квартирыBindingSource.Current as DataRowView).Row as DsTemp.квартирыRow;
                temp aRow = bindingSource1.Current as temp;
                if (aRow.услуга != Guid.Empty)
                {
                    Cursor = Cursors.WaitCursor;
                    клКлиент.клиент = aRow.клиент;
                    клУслуга.услуга = aRow.услуга;
                    клУслуга.deRow = de.услуги.Single(n => n.услуга == aRow.услуга);
                    клКлиент.deRow = de.клиенты.Single(n => n.клиент == клКлиент.клиент);

                    только_просмотр формаОплатить = new только_просмотр();

                    формаОплатить.Text = "Оплаты за " + aRow.наимен_услуги.Trim() + " " + клКлиент.deRow.адрес+" " + aRow.фио;

                    формаОплатить.ShowDialog();
                    Cursor = Cursors.Default;
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            string curDir = System.IO.Directory.GetCurrentDirectory();

            string шаблон = curDir + @"\задание1дом.docx";

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


                    foreach (temp kRow in listTemp.Where(n=>n.отключить))
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
                            клXML.ChangeTextInCell(table2, j, 6, "V");
                        }
                        else
                        {
                            клXML.ChangeTextInCell(table2, j, 6, "");
                        }

                    }


                    j++;
                    клXML.ChangeTextInCell(table2, j, 0, "");
                    клXML.ChangeTextInCell(table2, j, 1, "");
                    клXML.ChangeTextInCell(table2, j, 2, "");
                    клXML.ChangeTextInCell(table2, j, 3, "");
                    клXML.ChangeTextInCell(table2, j, 4, "");
                    клXML.ChangeTextInCell(table2, j, 5, "");
                    //клXML.ChangeTextInCell(table2, j, 6, "");
                    //клXML.ChangeTextInCell(table2, j, 7, "");


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
    }
}
