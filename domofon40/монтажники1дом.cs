using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.IO;  
using Word = Microsoft.Office.Interop.Word;

namespace domofon40
{
    public partial class монтажники1дом : Form
    {
        public монтажники1дом()
        {
            InitializeComponent();
        }
        List<temp> listTemp0 = new List<temp>();
        List<temp> listTemp = new List<temp>();
        domofon40.domofon14Entities de = new domofon14Entities();
        private void монтажники1дом_Load(object sender, EventArgs e)
        {
            try
            {
                string curDir = System.IO.Directory.GetCurrentDirectory();

                string шаблон = curDir + @"\монтажники1дом.sql";

                if (!System.IO.File.Exists(шаблон.ToString()))
                {
                    MessageBox.Show("Нет файла " + шаблон.ToString());
                    Cursor = Cursors.Default;
                    return;
                }
                StreamReader sr = new StreamReader(шаблон,Encoding.Default);
                
                // var template = new System.IO.FileInfo(шаблон);
                string запрос = sr.ReadToEnd();
                //     MessageBox.Show(запрос);

                //    string sqlString = "монтажники1дом @дом='" + клДом.дом + "' ,@вид='" + клВид_услуги.вид_услуги + "'";
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(" declare @дом  uniqueidentifier ='" + клДом.дом.ToString() + "';");
                sb.AppendLine("declare @вид uniqueidentifier = '" + клВид_услуги.вид_услуги.ToString() + "' ; ");
                sb.AppendLine(запрос);

                //string sqlString = запрос + " declare @дом='" + клДом.дом + "';  declare @вид='" + клВид_услуги.вид_услуги + "' ;";
                string sqlString = sb.ToString();

           //     MessageBox.Show(sqlString);

                listTemp0 = de.Database.SqlQuery<temp>(sqlString).ToList();
               

                string адрес = клДом.deRow.улицы.наимен.Trim() + " " + клДом.deRow.номер.ToString();
                if(клДом.deRow.корпус != String.Empty)
                {
                    адрес =адрес+ " " + клДом.deRow.корпус;
                }
                foreach(temp tRow in listTemp0)
                {
                    tRow.адрес = адрес +  " кв. " + tRow.квартира.ToString();
                    if(tRow.ввод>0)
                    {
                        tRow.адрес =адрес + " ввод " + tRow.ввод.ToString();
                    }
                }
                listTemp = listTemp0;
                bindingSource1.DataSource = listTemp;
                клСетка.задать_ширину(dataGridView1);

                имяTextBox.DataBindings.Add("Text", bindingSource1, "имя");
                отчествоTextBox.DataBindings.Add("Text", bindingSource1, "отчество");
                телефонTextBox.DataBindings.Add("Text", bindingSource1, "телефон");
                прим0TextBox.DataBindings.Add("Text", bindingSource1, "прим0");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Сбой загрузки " + ex.Message);
            }
        
            dataGridView1.CellFormatting += DataGridView1_CellFormatting;

           
            temp.Moving += Temp_Moving;
            FormClosing += Монтажники1дом_FormClosing;
        }

        private void Монтажники1дом_FormClosing(object sender, FormClosingEventArgs e)
        {
            temp.Moving -= Temp_Moving;
        }

        private void Temp_Moving(temp obj)
        {
            if (obj.поле == "прим")
            {
                примечания[] aRows = de.примечания.Where(n => n.клиент == obj.клиент && n.услуга == obj.услуга).ToArray();
                foreach (примечания delRow in aRows)
                {
                    de.примечания.Remove(delRow);
                }
                de.SaveChanges();

                if (obj.прим != null)
                {
                    if (obj.прим.Trim() != String.Empty)
                    {
                        примечания newRow = new примечания()
                        {
                            клиент = obj.клиент,
                            прим = obj.прим,
                            услуга = obj.услуга
                        };
                        de.примечания.Add(newRow);

                    }
                }
            }
            if (obj.поле == "прим0")
            {
                клиенты kRow = de.клиенты.Single(n => n.клиент == obj.клиент);
                kRow.прим = obj.прим0;
            }

            if (obj.поле == "телефон")
            {
                клиенты kRow = de.клиенты.Single(n => n.клиент == obj.клиент);
                kRow.телефон = obj.телефон;
            }

            try
            {
                de.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сбой записи " + ex.Message);
            }

        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
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

            if (dataGridView1.Columns[e.ColumnIndex] == долг_месColumn)
            {
              
                bool xy =(bool)      dataGridView1.Rows[e.RowIndex].Cells["должникColumn"].Value ;

              
                    if (xy)
                    {
                        e.CellStyle.ForeColor = System.Drawing.Color.Red;
                    }
              
            }
        }

        class temp
        {
            public string адрес { get; set; }
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
    //        public string телефон { get; set; }
            public int порядок_услуги { get; set; }
            public string наимен_услуги { get; set; }
            public int строка { get; set; }
            public bool наш { get; set; }

            public bool должник { get; set; }
            //         public bool подключить { get; set; }
            public bool отключить { get; set; }
            //        public bool повторно { get; set; }
            //public string прим { get; set; }
            //public string прим0 { get; set; }
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

            public string поле { get; set; }
            public static event Action<temp> Moving;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
                temp aRow = bindingSource1.Current as temp;
                if (aRow.услуга != Guid.Empty)
                {
                    Cursor = Cursors.WaitCursor;
                    клКлиент.клиент = aRow.клиент;
                    клУслуга.услуга = aRow.услуга;
                    клУслуга.deRow = de.услуги.Single(n => n.услуга == aRow.услуга);
                    клКлиент.deRow = de.клиенты.Single(n => n.клиент == клКлиент.клиент);

                    оплаченные1просмотр формаОплатить = new оплаченные1просмотр();

                    формаОплатить.Text = $"Оплаты за {aRow.наимен_услуги.Trim()} {клКлиент.deRow.адрес}  {aRow.фио}";

                    формаОплатить.ShowDialog();
                    Cursor = Cursors.Default;
                }
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            string curDir = System.IO.Directory.GetCurrentDirectory();

            string шаблон = curDir + @"\монтажники1дом.docx";

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
                  //  int строкаРаб = 0;

                    var tables = package.MainDocumentPart.Document.Body.Elements<Table>();
                    Table table1 = tables.ElementAt(0);
                    Table table2 = tables.ElementAt(1);


                    клXML.ChangeTextInCell(table1, 0, 0, this.Text + " " + DateTime.Today.ToLongDateString());

                    TableRow lastRow = table2.Elements<TableRow>().Last();

                    var queryTemp = listTemp.ToArray();
                    int j = 0;

                    foreach (temp kRow in listTemp)
                    {
                        TableRow newRow1 = lastRow.Clone() as TableRow;


                        table2.AppendChild<TableRow>(newRow1);


                        j++;

                        клXML.ChangeTextInCell(table2, j, 0, kRow.квартира.ToString("0;#;#"));
                        клXML.ChangeTextInCell(table2, j, 1, kRow.ввод.ToString("0;#;#"));
                        клXML.ChangeTextInCell(table2, j, 2, kRow.фио);
                        клXML.ChangeTextInCell(table2, j, 3, kRow.телефон);
                        клXML.ChangeTextInCell(table2, j, 4, kRow.наимен_услуги);

                        клXML.ChangeTextInCell(table2, j, 5, kRow.долг_мес.ToString("0;#;#"));

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
                    клXML.ChangeTextInCell(table2, j, 6, "");
                 //   клXML.ChangeTextInCell(table2, j, 7, "");


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

            dataGridView1.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            string curDir = System.IO.Directory.GetCurrentDirectory();

            string шаблон = curDir + @"\монтажники1дом.docx";

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


                    foreach (temp kRow in listTemp.Where(n => n.должник))
                    {
                        TableRow newRow1 = lastRow.Clone() as TableRow;


                        table2.AppendChild<TableRow>(newRow1);


                        j++;

                        клXML.ChangeTextInCell(table2, j, 0, kRow.квартира.ToString("0;#;#"));
                        клXML.ChangeTextInCell(table2, j, 1, kRow.ввод.ToString("0;#;#"));
                        клXML.ChangeTextInCell(table2, j, 2, kRow.фио);

                        клXML.ChangeTextInCell(table2, j, 3, kRow.телефон);
                        клXML.ChangeTextInCell(table2, j, 4, kRow.наимен_услуги);

                        клXML.ChangeTextInCell(table2, j, 5, kRow.долг_мес.ToString("0;#;#"));

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
                    клXML.ChangeTextInCell(table2, j, 6, "");
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.Text = "Все";
                listTemp = listTemp0.FindAll(n => n.должник || n.отключить);
                bindingSource1.DataSource = listTemp;
            }
            else
            {
                listTemp = listTemp0;
                bindingSource1.DataSource = listTemp;
                checkBox1.Text = "Должники";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            клСетка.задать_ширину(dataGridView1);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (listTemp.Count(n => n.отключить) == 0)
            {
                MessageBox.Show("Отметьте клиентов на отключение");
                return;
            }


            string curDir = System.IO.Directory.GetCurrentDirectory();

            string шаблон = curDir + @"\монтажники1дом.docx";

            if (!System.IO.File.Exists(шаблон.ToString()))
            {
                MessageBox.Show("Нет файла " + шаблон.ToString());
                Cursor = Cursors.Default;
                return;
            }

            Cursor = Cursors.WaitCursor;

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
                   
                    //  int строкаРаб = 0;

                    var tables = package.MainDocumentPart.Document.Body.Elements<Table>();
                    Table table1 = tables.ElementAt(0);
                    Table table2 = tables.ElementAt(1);


                    клXML.ChangeTextInCell(table1, 0, 0, this.Text + " " + DateTime.Today.ToLongDateString());

                    TableRow lastRow = table2.Elements<TableRow>().Last();

                    var queryTemp = listTemp.ToArray();
                    int j = 0;

                    foreach (temp kRow in listTemp.Where(n=>n.отключить))
                    {
                        TableRow newRow1 = lastRow.Clone() as TableRow;


                        table2.AppendChild<TableRow>(newRow1);


                        j++;

                        клXML.ChangeTextInCell(table2, j, 0, kRow.квартира.ToString("0;#;#"));
                        клXML.ChangeTextInCell(table2, j, 1, kRow.ввод.ToString("0;#;#"));
                        клXML.ChangeTextInCell(table2, j, 2, kRow.фио);
                        клXML.ChangeTextInCell(table2, j, 3, kRow.телефон);
                        клXML.ChangeTextInCell(table2, j, 4, kRow.наимен_услуги);

                        клXML.ChangeTextInCell(table2, j, 5, kRow.долг_мес.ToString("0;#;#"));

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
                    клXML.ChangeTextInCell(table2, j, 6, "");
                    //   клXML.ChangeTextInCell(table2, j, 7, "");


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


            //if (listTemp.Count(n => n.отключить) == 0)
            //{
            //    MessageBox.Show("Отметьте клиентов на отключение");
            //    return;
            //}
            //try
            //{

            //    Word.Application oWord = new Word.Application();

            //    string curDir = System.IO.Directory.GetCurrentDirectory();

            //    object шаблон = curDir + @"\монтажники1вид.dot";
            //    if (!System.IO.File.Exists(шаблон.ToString()))
            //    {
            //        MessageBox.Show("Нет файла " + шаблон.ToString());
            //        return;
            //    }


            //    Word.Document o = oWord.Documents.Add(Template: шаблон);
            //    oWord.Application.Visible = true;
            //    o.Tables[1].Cell(1, 2).Range.Text = DateTime.Today.ToLongDateString();
            //    int j = 1;

            //    foreach (temp kRow in listTemp
            //        .Where(n => n.отключить))
            //    {
            //        j++;
            //        o.Tables[2].Cell(j, 1).Range.Text = kRow.наимен_услуги.Trim();
            //        o.Tables[2].Cell(j, 2).Range.Text = kRow.адрес.Trim();
            //        o.Tables[2].Cell(j, 3).Range.Text = kRow.фио;
            //        o.Tables[2].Cell(j, 4).Range.Text = kRow.долг_мес.ToString("0;#;#");
            //        o.Tables[2].Cell(j, 5).Range.Text = kRow.прим.Trim() + " " + kRow.прим0.Trim();
            //        //    o.Tables[4].Cell(j, 6).Range.Text = kRow.прим0;
            //        o.Tables[2].Cell(j, 6).Range.Text = kRow.телефон;

            //        o.Tables[2].Rows.Add();
            //    }
            //    o.Tables[2].Cell(j + 1, 2).Range.Text = "Всего квартир ";
            //    o.Tables[2].Cell(j + 1, 4).Range.Text = (j - 1).ToString("0;#;#");



            //    oWord.Application.Visible = true;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Ошибка " + ex.Message);
            //}


        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                listTemp.FindAll(n => n.должник).ForEach(n => n.отключить = true);
                checkBox2.Text = "Снять отметки";
            }
            else
            {
                listTemp.FindAll(n => n.должник).ForEach(n => n.отключить = false);
                checkBox2.Text = "Отметить всех";
            }
            dataGridView1.Refresh();
            dataGridView1.Focus();
        }

      
    }
}

