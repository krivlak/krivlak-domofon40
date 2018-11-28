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
using System.Data.Entity;

namespace domofon40
{
    public partial class монтажникам_повтор : Form
    {
        public монтажникам_повтор()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        //    BindingList<temp> listTemp = new BindingList<temp>();
        List<temp> listTemp0 = new List<temp>();
        List<temp> listTemp = new List<temp>();
        private void монтажникам_повтор_Load(object sender, EventArgs e)
        {
            temp.Moving -= temp_Moving;
            //   dateTimePicker1.Value = DateTime.Today;
            //        заполнить_мастеров();

            var query = de.клиенты
                .Where(n => n.дом == клДом.дом)
                .OrderBy(n => n.квартира)
                .ThenBy(n => n.ввод);

            int j = 0;
            foreach (клиенты uRow in query)
            {
                j++;
                int i = 0;
                foreach (услуги yRow in de.услуги
                                                .Where(n => n.вид_услуги == клВид_услуги.вид_услуги)
                                                .OrderBy(n => n.порядок))
                {
                    i++;
                    //bool yx = false;
                    //клВид_услуги.dictУслуг.TryGetValue(yRow.услуга1, out yx);
                    if (клВид_услуги.dictУслуг.ContainsKey(yRow.услуга))
                    {
                       
                        //    DsTemp.квартирыRow NewRow = dsTemp.квартиры.NewквартирыRow();
                        temp NewRow = new temp();
                        NewRow.клиент = uRow.клиент;
                        //if (j == 1)
                        //{
                        NewRow.фио = uRow.фио;
                        NewRow.квартира = uRow.квартира;
                        NewRow.ввод = uRow.ввод;
                        NewRow.подъезд = uRow.подъезд;

                        //}
                        //NewRow.Имя = uRow.имя;
                        //NewRow.Отчество = uRow.отчество;
                        NewRow.телефон = uRow.телефон;
                        //NewRow.Фамилия = uRow.фамилия;
                        NewRow.прим0 = uRow.прим;

                        if (uRow.примечания.Any(n => n.услуга == yRow.услуга))
                        {
                            NewRow.прим = uRow.примечания.First(n => n.услуга == yRow.услуга).прим.Trim();
                        }

                        if (uRow.услуги.Any(n => n.услуга == yRow.услуга))
                        {
                            NewRow.наш = true;

                        }
                        if (uRow.звонки.Any())
                        {
                            NewRow.звонок = uRow.звонки.Max(n => n.дата);
                        }


                        if (uRow.подключения.Any(n => n.услуга == yRow.услуга))
                        {
                            NewRow.договор_с = uRow.подключения
                                                   .Where(n => n.услуга == yRow.услуга)
                                                   .Max(n => n.дата_с);
                        }

                        if (uRow.отключения.Any(n => n.услуга == yRow.услуга))
                        {
                            NewRow.откл = uRow.отключения
                                              .Where(n => n.услуга == yRow.услуга)
                                              .Max(n => n.дата_с);
                        }

                        if (uRow.повторы.Any(n => n.услуга == yRow.услуга))
                        {
                            NewRow.подкл = uRow.повторы
                                               .Where(n => n.услуга == yRow.услуга)
                                               .Max(n => n.дата_с);
                        }

                        if (uRow.льготы.Any(n => n.услуга == yRow.услуга))
                        {
                            string текст = uRow.льготы
                                               .Where(n => n.услуга == yRow.услуга)
                                               .Max(n => n.дата_с).ToShortDateString();

                            //  NewRow.сведения += "Льгота с " + текст;
                            NewRow.прим += " Льгота";
                        }

                        NewRow.услуга = yRow.услуга;
                        NewRow.наимен_услуги = yRow.обозначение;

                        NewRow.порядок2 = j;
                        NewRow.порядок = i;
                        listTemp.Add(NewRow);

                        //   dsTemp.квартиры.Rows.Add(NewRow);
                    }

                }
            }
                int текГод = System.DateTime.Today.Year;
                int текМесяц = DateTime.Today.Month;

                var dicTemp = listTemp.ToDictionary(n => new { n.клиент, n.услуга });

                var query2 = de.оплачено
                               .Where(n => n.услуги.вид_услуги == клВид_услуги.вид_услуги)
                               .Where(n => n.оплаты.клиенты.дом == клДом.дом)
                               .GroupBy(n => new { n.оплаты.клиент, n.услуга })
                               .Select(n => new
                                   {
                                       клиент = n.Key.клиент,
                                       услуга = n.Key.услуга,
                                       махГод = n.Max(k => k.год),
                                       maxM = n.Max(k => k.год * 12 + k.месяц)
                                   });

                foreach (var uRow in query2)
                {
                    var ключ = new  { uRow.клиент, uRow.услуга };

                    if (dicTemp.ContainsKey(ключ))
                    {
                       temp tRow = dicTemp[ключ];

                        tRow.год = uRow.махГод;
                        int mMez = uRow.maxM - uRow.махГод * 12;
                        tRow.месяц = mMez;
                        int долгМес = текГод * 12 + текМесяц - 1 - uRow.махГод * 12 - mMez;
                        if (долгМес > 0)
                        {
                            tRow.долг_мес = долгМес;
                            if (долгМес > 1)
                                tRow.должник = true;
                        }
                    }
                

                }
            listTemp0 = listTemp;
                bindingSource1.DataSource = listTemp;
                dataGridView1.CellPainting += dataGridView1_CellPainting;
                телефонTextBox.DataBindings.Add("Text", bindingSource1, "телефон");
                прим0TextBox.DataBindings.Add("Text", bindingSource1, "прим0");
            //   звонокTextBox.DataBindings.Add("Text", bindingSource1, "звонок");
            //        сведенияTextBox.DataBindings.Add("Text", bindingSource1, "сведения");

            dataGridView1.Focus();

            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            temp.Moving += temp_Moving;
            FormClosing += Монтажникам_повтор_FormClosing;
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

        private void Монтажникам_повтор_FormClosing(object sender, FormClosingEventArgs e)
        {
            temp.Moving -= temp_Moving;
        }

        void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewTextBoxColumn[] aCol = { услугаColumn, годColumn, месяцColumn, договор_сColumn, долг_месColumn,
                подклColumn, отклColumn, примColumn, договор_сColumn, звонокColumn };

            //         DataGridViewTextBoxColumn[] aCol = { услугаColumn };
            if (aCol.Contains(dataGridView1.Columns[e.ColumnIndex]))
            {
                bool действует0 = (bool)dataGridView1.Rows[e.RowIndex].Cells["действуетColumn"].Value;

                if (действует0)
                {
                    // e.CellStyle.ForeColor = Color.Blue;
                    e.CellStyle.BackColor = System.Drawing.Color.FromArgb(200, 255, 200);

                    //System.Drawing.Font NewFont = new System.Drawing.Font(e.CellStyle.Font, FontStyle.Bold);
                    //e.CellStyle.Font = NewFont;
                }
            }

                DataGridViewTextBoxColumn[] aCol2 = { квартираColumn, вводColumn, фиоColumn };
            //         DataGridViewTextBoxColumn[] aCol = { услугаColumn };
            if (aCol2.Contains(dataGridView1.Columns[e.ColumnIndex]))
            {
                int pp = (int)dataGridView1.Rows[e.RowIndex].Cells["порядок2Column"].Value;

                if (pp % 2 == 0)
                {
                    // e.CellStyle.ForeColor = Color.Blue;
                    e.CellStyle.BackColor = System.Drawing.Color.FromArgb(250, 255, 200);

                    //System.Drawing.Font NewFont = new System.Drawing.Font(e.CellStyle.Font, FontStyle.Bold);
                    //e.CellStyle.Font = NewFont;
                }
                //else
                //{
                //    e.CellStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 255); ;
                //}
            }

            //int цвет = (int)dataGridView1.Rows[e.RowIndex].Cells["порядокColumn"].Value;
            //if (цвет == 2)
            //{
            //    e.CellStyle.ForeColor = System.Drawing.Color.Blue;

            //    //                e.CellStyle.BackColor = Color.FromArgb(200, 255, 200);
            //}
            //if (цвет == 3)
            //{
            //    e.CellStyle.ForeColor = System.Drawing.Color.DarkGreen;
            //    //     e.CellStyle.BackColor = Color.FromArgb(200, 200, 255);
            //}
            //if (цвет == 4)
            //{
            //    e.CellStyle.ForeColor = System.Drawing.Color.DarkOrchid;
            //    //    e.CellStyle.BackColor = Color.FromArgb(255, 200, 200);
            //}

            //if (dataGridView1.Columns[e.ColumnIndex] == долг_месColumn)
            //{
            //    int долгМес =(int) dataGridView1.Rows[e.RowIndex].Cells["долг_месColumn"].Value;
            //    if (долгМес>1)
            //    {
            //        e.CellStyle.ForeColor = System.Drawing.Color.Red;
            //    }
            //}
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
            //if (!checkBox1.Checked)
            //{
            //    string[] колонки = { "номер_домаColumn", "фиоColumn", "квартираColumn", "подъездColumn", "корпусColumn" };
            //    if (цвет > 1 && колонки.Contains(dataGridView1.Columns[e.ColumnIndex].Name))
            //    {
            //        e.CellStyle.ForeColor = System.Drawing.Color.White;
            //    }
            //}

        }

        void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            string[] заголовки = { "отключитьColumn", "повторноColumn", "действуетColumn", "подключитьColumn", "вводColumn", "квартираColumn", "должникColumn" };
            if (e.RowIndex > -1 || e.ColumnIndex < 0)
            {
                e.Handled = false;
                return;
            }
            if (заголовки.Contains(dataGridView1.Columns[e.ColumnIndex].Name))
            {
                e.PaintBackground(e.ClipBounds, true);
                e.Graphics.RotateTransform(-90.0F);
                string текст = dataGridView1.Columns[e.ColumnIndex].HeaderText;
                //                System.Drawing.Font шрифт = dataGridView1.Font;
                System.Drawing.Font шрифт = label2.Font;

                RectangleF p = new RectangleF(-e.CellBounds.Top - e.CellBounds.Height + 5, e.CellBounds.Left + 5,
                                              e.CellBounds.Height, e.CellBounds.Width);
                if (dataGridView1.Columns[e.ColumnIndex] == отключитьColumn)
                {
                    e.Graphics.DrawString(текст, шрифт, Brushes.Red, p);
                }
                else
                {
                    e.Graphics.DrawString(текст, шрифт, Brushes.Black, p);
                }


                e.Graphics.RotateTransform(90.0F);
                e.Handled = true;
            }

        }

        partial class temp
        {
            public int порядок { get; set; }
            public int порядок2 { get; set; }
            public Guid клиент { get; set; }
            public int  подъезд { get; set; }
            public int квартира { get; set; }
            public int ввод { get; set; }
            public string фио { get; set; }
            public Guid услуга { get; set; }
            public string наимен_услуги { get; set; }
            public int год { get; set; }
            public int месяц { get; set; }
            public int долг_мес { get; set; }
            public bool должник { get; set; }
            public bool подключить { get; set; }
            public bool отключить { get; set; }
            public bool повторно { get; set; }
           // public string прим { get; set; }
            public DateTime? откл { get; set; }
            public DateTime? подкл { get; set; }
            public DateTime? звонок { get; set; } = null;
            public DateTime? договор_с { get; set; }
        //    public string сведения { get; set; }
        //    public bool действует { get; set; }
            //public string телефон { get; set; }
            //public string прим0 { get; set; }
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

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
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
                  //  int строкаРаб = 0;

                    var tables = package.MainDocumentPart.Document.Body.Elements<Table>();
                    //Table table1 = tables.First();
                    //Table table2 = tables.Last();
                    Table table1 = tables.ElementAt(0);
                    Table table2 = tables.ElementAt(1);


                    клXML.ChangeTextInCell(table1, 0, 0, this.Text + " " + DateTime.Today.ToLongDateString());

                    TableRow lastRow = table2.Elements<TableRow>().Last();

                    //var queryTemp = dsTemp.квартиры.ToArray();
                    //if (checkBox2.Checked)
                    //{
                    //    queryTemp = queryTemp
                    //        .Where(n => n.отключить || n.подключить || n.повторно).ToArray();
                    //}

                    int j = 0;

                    foreach (temp kRow in listTemp)
                    {
                        if (checkBox2.Checked && kRow.отключить==false && kRow.повторно==false && kRow.подключить==false)
                        {
                           continue;
                        }
                        TableRow newRow1 = lastRow.Clone() as TableRow;


                        table2.AppendChild<TableRow>(newRow1);


                        j++;
                        if ((kRow.порядок == 1 && !checkBox2.Checked) || checkBox2.Checked)
                        {

                            клXML.ChangeTextInCell(table2, j, 0, kRow.квартира.ToString("0;#;#"));
                            клXML.ChangeTextInCell(table2, j, 1, kRow.ввод.ToString("0;#;#"));
                            клXML.ChangeTextInCell(table2, j, 2, kRow.фио);
                        }
                        else
                        {
                            клXML.ChangeTextInCell(table2, j, 0, "");
                            клXML.ChangeTextInCell(table2, j, 1, "");
                            клXML.ChangeTextInCell(table2, j, 2, "");

                        }

                        клXML.ChangeTextInCell(table2, j, 3, kRow.наимен_услуги);

                        клXML.ChangeTextInCell(table2, j, 4, kRow.долг_мес.ToString("0;#;#"));
                        if (kRow.подключить)
                        {
                            клXML.ChangeTextInCell(table2, j, 5, "V");
                        }
                        else
                        {
                            клXML.ChangeTextInCell(table2, j, 5, "");
                        }

                        if (kRow.отключить)
                        {
                            клXML.ChangeTextInCell(table2, j, 6, "V");
                        }
                        else
                        {
                            клXML.ChangeTextInCell(table2, j, 6, "");
                        }
                        if (kRow.повторно)
                        {
                            клXML.ChangeTextInCell(table2, j, 7, "V");
                        }
                        else
                        {
                            клXML.ChangeTextInCell(table2, j, 7, "");
                        }

                        //      клXML.ChangeTextInCell(table2, j, 6, kRow.прим0.Trim() + "  " + kRow.прим.Trim());

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

        private void button7_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            string curDir = System.IO.Directory.GetCurrentDirectory();

            string шаблон = curDir + @"\задание2монтажникам.docx";

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
                    //Table table1 = tables.First();
                    //Table table2 = tables.Last();
                    Table table1 = tables.ElementAt(0);
                    Table table2 = tables.ElementAt(1);


                    клXML.ChangeTextInCell(table1, 0, 0, this.Text + " " + DateTime.Today.ToLongDateString());

                    TableRow lastRow = table2.Elements<TableRow>().Last();

                    //var queryTemp = dsTemp.квартиры.ToArray();
                    //if (checkBox2.Checked)
                    //{
                    //    queryTemp = queryTemp
                    //        .Where(n => n.отключить || n.подключить || n.повторно).ToArray();
                    //}

                    int j = 0;

                    foreach (temp kRow in listTemp)
                    {

                        if (checkBox2.Checked && kRow.отключить == false && kRow.повторно == false && kRow.подключить == false)
                        {
                            continue;
                        }
                        TableRow newRow1 = lastRow.Clone() as TableRow;


                        table2.AppendChild<TableRow>(newRow1);


                        j++;
                        if ((kRow.порядок == 1 && !checkBox2.Checked) || checkBox2.Checked)
                        {

                            клXML.ChangeTextInCell(table2, j, 0, kRow.квартира.ToString("0;#;#"));
                            клXML.ChangeTextInCell(table2, j, 1, kRow.ввод.ToString("0;#;#"));
                            клXML.ChangeTextInCell(table2, j, 2, kRow.фио);
                        }
                        else
                        {
                            клXML.ChangeTextInCell(table2, j, 0, "");
                            клXML.ChangeTextInCell(table2, j, 1, "");
                            клXML.ChangeTextInCell(table2, j, 2, "");

                        }
                        клXML.ChangeTextInCell(table2, j, 3, kRow.наимен_услуги);

                        клXML.ChangeTextInCell(table2, j, 4, kRow.месяц.ToString("0;#;#"));
                        клXML.ChangeTextInCell(table2, j, 5, kRow.год.ToString("0;#;#"));

                        клXML.ChangeTextInCell(table2, j, 6, kRow.долг_мес.ToString("0;#;#"));
                        if (kRow.подключить)
                        {
                            клXML.ChangeTextInCell(table2, j, 7, "V");
                        }
                        else
                        {
                            клXML.ChangeTextInCell(table2, j, 7, "");
                        }

                        if (kRow.отключить)
                        {
                            клXML.ChangeTextInCell(table2, j, 8, "V");
                        }
                        else
                        {
                            клXML.ChangeTextInCell(table2, j, 8, "");
                        }
                        if (kRow.повторно)
                        {
                            клXML.ChangeTextInCell(table2, j, 9, "V");
                        }
                        else
                        {
                            клXML.ChangeTextInCell(table2, j, 9, "");
                        }

                        //      клXML.ChangeTextInCell(table2, j, 6, kRow.прим0.Trim() + "  " + kRow.прим.Trim());

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
                    клXML.ChangeTextInCell(table2, j, 9, "");

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

        private void заполнить_мастеров()
        {
            var queryМастера = de.сотрудники
                .OrderBy(n => n.порядок)
                .Select(n => new { n.сотрудник, текст = n.фио.Trim() + " " + n.должность.Trim() });

          //  comboBox1.DataSource = queryМастера.ToList();
          //  comboBox1.ValueMember = "сотрудник";
          //  comboBox1.DisplayMember = "текст";
          ////  comboBox1.SelectedValue = клМастер.мастер;
          //  comboBox1.SelectedIndex = 0;
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        ////private void button9_Click(object sender, EventArgs e)
        //{
        //    if (comboBox1.SelectedIndex < 0)
        //    {
        //        MessageBox.Show("Выберите мастера...");
        //        comboBox1.Focus();
        //        return;
        //    }
        //    Guid КодМастера = (Guid) comboBox1.SelectedValue;

        //    string текст0 = "";
        //    клМастер.мастер = КодМастера;
        //    //foreach (DsTemp.квартирыRow uRow in dsTemp.квартиры
        //    foreach(temp uRow in listTemp
        //        .Where(n => n.отключить || n.повторно)
        //        .Where(n => n.услуга != Guid.Empty))
        //    {
        //        // Model.клиент оКлиент = de.клиент.Single(n => n.клиент1 == uRow.клиент);

        //        if (uRow.отключить)
        //        {
        //            текст0 += " отключение ";
        //            отключения NewRow = new отключения();
        //            NewRow.дата_с = dateTimePicker1.Value;
        //            NewRow.клиент = uRow.клиент;
        //            //                NewRow.мастер = de.сотрудник.First().сотрудник1;
        //            NewRow.мастер = клМастер.мастер;
        //            NewRow.отключение = Guid.NewGuid();
        //            NewRow.прим = "";
        //            NewRow.услуга = uRow.услуга;
        //            NewRow.дата_по = null;
        //            uRow.действует = false;
        //            uRow.откл = NewRow.дата_с;
        //            de.отключения.Add(NewRow);
        //        }

        //        if (uRow.повторно)
        //        {
        //            текст0 += " повторно ";
        //            повторы NewRow = new повторы();
        //            NewRow.дата_с = dateTimePicker1.Value;
        //            NewRow.клиент = uRow.клиент;
        //            //                NewRow.мастер = de.сотрудник.First().сотрудник1;
        //            NewRow.мастер = клМастер.мастер;
        //            NewRow.подключение = Guid.NewGuid();
        //            NewRow.прим = "";
        //            NewRow.услуга = uRow.услуга;
        //            uRow.действует = true;
        //            uRow.подкл = NewRow.дата_с;
        //            de.повторы.Add(NewRow);
        //        }

        //    }

        //    try
        //    {
        //        int tt = de.SaveChanges();

        //        if (tt > 0)
        //        {
        //            string текст = String.Format("Записано {0} строк ", tt);
        //            текст0 = " Записано " + текст0;
        //            MessageBox.Show(текст0, "Запись переключений", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //        dataGridView1.Refresh();
        //    }
        //    catch (Exception)
        //    {

        //        MessageBox.Show("Сбой записи..", "Запись переключений", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //    }

        //}

        private void button12_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
                temp aRow = bindingSource1.Current as temp;
                клКлиент.клиент = aRow.клиент;
                клКлиент.фио = aRow.фио;
                Cursor = Cursors.WaitCursor;
                оплата_вид ОплатаВида = new оплата_вид();
                ОплатаВида.Text = "Оплаты " + клКлиент.фио + " за " + клВид_услуги.наимен;
                ОплатаВида.ShowDialog();
                Cursor = Cursors.Default;
            }
        }

        private void button6_Click(object sender, EventArgs e)
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
                    клКлиент.deRow = de.клиенты.Single(n => n.клиент == клКлиент.клиент);

                    только_просмотр формаОплатить = new только_просмотр();

                    формаОплатить.Text = "Оплаты за " + aRow.наимен_услуги.Trim() + " " + aRow.фио;

                    формаОплатить.ShowDialog();
                    Cursor = Cursors.Default;
                }
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
              if(checkBox1.Checked)
            {
                listTemp = listTemp0.Where(n => n.должник).ToList();
                checkBox1.Text = "Все";
            }
              else
            {
                listTemp = listTemp0;
                checkBox1.Text = "Должники";
            }
            bindingSource1.DataSource = listTemp;
            dataGridView1.Refresh();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
                temp aRow = bindingSource1.Current as temp;

                клКлиент.клиент = aRow.клиент;
                клУслуга.услуга = aRow.услуга;
                клКлиент.фио = aRow.фио;
                клКлиент.deRow = de.клиенты.Single(n => n.клиент == клКлиент.клиент);

                договора1клиента формаПодключен = new договора1клиента();
                формаПодключен.Text = "Договора " + клУслуга.наимен.Trim()
                    + " " + aRow.фио + " кв. " + aRow.квартира.ToString()
                   + " дом " + клДом.номер
                   + "  " + клДом.корпус
                   + " улица " + клДом.deRow.улицы.наимен;

                формаПодключен.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
                temp aRow = bindingSource1.Current as temp;

                клКлиент.клиент = aRow.клиент;
                клУслуга.услуга = aRow.услуга;
                клКлиент.фио = aRow.фио;


                отключения1клиента формаПодключен = new отключения1клиента();
                формаПодключен.Text = "Отключения " + клУслуга.наимен.Trim()
                    + " " + aRow.фио + " кв. " + aRow.квартира.ToString()
                   + " дом " + клДом.номер
                   + "  " + клДом.корпус
                   + " улица " + клДом.deRow.улицы.наимен;

                формаПодключен.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
                temp aRow = bindingSource1.Current as temp;

                клКлиент.клиент = aRow.клиент;
                клУслуга.услуга = aRow.услуга;
                клКлиент.фио = aRow.фио;


                повторы1клиент формаПодключен = new повторы1клиент();
                формаПодключен.Text = "Повторные подключения " + клУслуга.наимен.Trim()
                    + " " + aRow.фио + " кв. " + aRow.квартира.ToString()
                   + " дом " + клДом.номер
                   + "  " + клДом.корпус
                   + " улица " + клДом.deRow.улицы.наимен;

                формаПодключен.ShowDialog();
            }

        }

        private void button4_Click(object sender, EventArgs e)
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
                    //звонокTextBox.Text = tRow.звонок.Value.ToShortDateString();
                    //звонокTextBox.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                //     новыйЗвонок.звонок=



                Cursor = Cursors.Default;
            }

        }
    }
}
