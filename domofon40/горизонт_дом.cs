using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace domofon40
{
    public partial class горизонт_дом : Form
    {
        public горизонт_дом()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        List<temp> tempList = new List<temp>();
        private void горизонт_дом_Load(object sender, EventArgs e)
        {
            клНачало.начало = de.начало.First().дата;
            клНачало.месяцНачало = клНачало.начало.Month;
            клНачало.годНачало = клНачало.начало.Year;
       //     раскрасить_заголовки();

            обновить_дом();
            клСетка.задать_ширину(dataGridView1);
            имяTextBox.DataBindings.Add("Text", bindingSource1, "имя");
            отчествоTextBox.DataBindings.Add("Text", bindingSource1, "отчество");
            телефонTextBox.DataBindings.Add("Text", bindingSource1, "телефон");
            прим0TextBox.DataBindings.Add("Text", bindingSource1, "прим0");
         //   показать_имя();
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
         //   bindingSource1.PositionChanged += bindingSource1_PositionChanged;
            dataGridView1.Focus();
        }

        //void bindingSource1_PositionChanged(object sender, EventArgs e)
        //{
        //   // показать_имя();
        //}
        //void показать_имя()
        //{
        //    temp uRow = bindingSource1.Current as temp;
        //    имяTextBox.Text = uRow.имя;
        //    отчествоTextBox.Text = uRow.отчество;
        //    телефонTextBox.Text = uRow.телефон;
        //    прим0TextBox.Text = uRow.прим0;
        //}

        void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            bool yy = (bool)dataGridView1.Rows[e.RowIndex].Cells["цветColumn"].Value;
            if (yy)
            {
                e.CellStyle.BackColor = System.Drawing.Color.FromArgb(200, 255, 200);
            }
        }

        private void раскрасить_заголовки()
        {

            for (int i = 1; i <= 12; i++)
            {
                string поле = "M" + i.ToString().Trim() + "Column";
                if ((i >= клНачало.месяцНачало && клНачало.годНачало == клМесяц.год) || клНачало.годНачало < клМесяц.год)
                {

                    dataGridView1.Columns[поле].HeaderCell.Style.BackColor =
                        System.Drawing.Color.FromArgb(200, 255, 200);
                    dataGridView1.Columns[поле].Tag = true;
                }
                else
                {

                    dataGridView1.Columns[поле].HeaderCell.Style.BackColor =
                        System.Drawing.Color.FromArgb(200, 200, 255);
                    dataGridView1.Columns[поле].Tag = false;
                }

            }

        }

        private void обновить_дом()
        {
            
            bool yy = false;


            foreach (var uRow in de.клиенты
                .Where(n => n.дом == клДом.дом)
                .OrderBy(n => n.квартира)
                .ThenBy(n => n.ввод))
            {
                Guid КодУслуги = Guid.Empty;
                Guid КодКлиента = Guid.Empty;
                // ??????????????
                //var queryОплата = uRow.оплаты
                //    .Count(n => n.оплачено.Count(p => p.услуга == КодУслуги) > 0);

                // массив кода услуги

                Guid[] dict88 = de.оплачено
                    .Where(n => n.оплаты.клиент==uRow.клиент)
                    .GroupBy(n => n.услуга )
                    .Select(n => n.Key)
                    .ToArray();

                //    .ToDictionary(n=> new { n.клиент, n.услуга});

                //     КодКлиента = uRow.клиент1;
                int i = 0;
                //foreach (var yRow in query2)

                foreach (var yRow in de.услуги
                    .OrderBy(n => n.порядок))
                {
                    КодУслуги = yRow.услуга;
               //     string ключ = uRow.клиент + yRow.услуга;

                    if (uRow.услуги.Contains(yRow) || dict88.Contains(yRow.услуга))  // наш клиент или есть оплаты
                    {
                        //      КодУслуги = yRow.услуга1;
             //           dsТабель.абоненты1домаRow NewRow = dsТабель1.абоненты1дома.Newабоненты1домаRow();
                        temp NewRow = new temp();
                        NewRow.квартира = uRow.квартира;
                        NewRow.ввод = uRow.ввод;
                        NewRow.клиент = uRow.клиент;
//                        NewRow.фио = uRow.фио;
                        NewRow.услуга = yRow.услуга;
                        NewRow.дом = uRow.дом;
                        NewRow.наимен_услуги = yRow.обозначение;
                        NewRow.имя = uRow.имя;
                        NewRow.отчество = uRow.отчество;
                        NewRow.телефон = uRow.телефон;
                        NewRow.прим0 = uRow.прим;
                        i++;
                        if (i == 1)
                        {
                            NewRow.квартира = uRow.квартира;
                            NewRow.подъезд = uRow.подъезд;
                            NewRow.фио = uRow.фио;
                            yy = !yy;
                        }
                        else
                        {
                            NewRow.квартира = 0;
                            NewRow.подъезд = 0;
                            NewRow.фио = "";
                        }
                        if (yy)
                        {
                            NewRow.цвет = true;
                        }

                        NewRow.прим = "";

                     //   var qПрим = uRow.примечания.Where(n => n.услуга == yRow.услуга);
                        if (uRow.примечания.Any(n => n.услуга == yRow.услуга))
                        {
                            //примечания pRow = qПрим.First();
                            //NewRow.прим += pRow.прим.Trim();
                            NewRow.прим = uRow.примечания.Where(n => n.услуга == yRow.услуга).First().прим;
                        }

                      //  var qОткл = uRow.отключения.Where(n => n.услуга == yRow.услуга);

                        if (uRow.подключения.Any(n => n.услуга == yRow.услуга))
                        {
                            //   DateTime maxData = uRow.отключения.Where(n => n.услуга == yRow.услуга).Max(p => p.дата_с);
                            NewRow.mПодключено = uRow.подключения.Where(n => n.услуга == yRow.услуга).Max(p => p.дата_с);
                            // NewRow.прим += " Откл " + maxData.ToShortDateString();
                        }

                        var qПереключено = uRow.подключения.Where(n => n.услуга != yRow.услуга && n.услуги.вид_услуги == yRow.вид_услуги);

                        if (qПереключено.Any())
                        {
                            NewRow.mПереключено = qПереключено.Max(p => p.дата_с);
                           
                        }



                        if (uRow.отключения.Any(n => n.услуга == yRow.услуга))
                        {
                            NewRow.mОтключено = uRow.отключения.Where(n => n.услуга == yRow.услуга).Max(p => p.дата_с);
                        }

                        if (NewRow.mПереключено != null)
                        {
                            if (NewRow.mОтключено != null)
                            {
                                if (NewRow.mОтключено < NewRow.mПереключено)
                                {
                                    NewRow.mОтключено = NewRow.mПереключено;
                                    NewRow.прим += " переключено ";
                                }
                            }
                            else
                            {
                                NewRow.mОтключено = NewRow.mПереключено;
                                NewRow.прим += " переключено ";

                            }
                        }


                        var qЛьгота = uRow.льготы.Where(n => n.услуга == yRow.услуга);

                        if (qЛьгота.Any())
                        {
                            DateTime maxData = qЛьгота.Max(p => p.дата_с);
                            NewRow.прим += " Льгота " + maxData.ToShortDateString();
                        }

                        var qПовт = uRow.повторы.Where(n => n.услуга == yRow.услуга);

                        if (uRow.повторы.Any(n => n.услуга == yRow.услуга))
                        {
                            NewRow.mПовторно = uRow.повторы.Where(n => n.услуга == yRow.услуга).Max(p => p.дата_с);
                            //DateTime maxData = qПовт.Max(p => p.дата_с);
                            //NewRow.прим += " Повт.подк " + maxData.ToShortDateString();
                        }

                        if (NewRow.mОтключено != null && NewRow.mПовторно != null)
                        {
                            if (NewRow.mОтключено > NewRow.mПовторно)
                            {
                                NewRow.mПовторно = null;
                            }
                        }



                        if(NewRow.прим==null)
                        {
                            NewRow.прим = "";
                        }

                        foreach (оплаты oRow in uRow.оплаты)
                        {

                            foreach (оплачено jRow in oRow.оплачено
                                .Where(n => n.услуга == yRow.услуга)
                                .Where(n => n.год == клМесяц.год))
                            {
                             
                                NewRow.setField(jRow.месяц, jRow.сумма);
                          //      NewRow.SetField<string>(поле, jRow.сумма.ToString());
                            }

                        }

                        if (dict88.Contains(yRow.услуга))
                        {
                            //int queryMax = uRow.оплаты.Max(n => n.оплачено.Max(p => p.год * 100 + p.месяц));

                            int queryMax =de.оплачено
                                .Where(n=>n.оплаты.клиент==uRow.клиент)
                                .Where(n=>n.услуга==yRow.услуга)
                                .Max(p => p.год * 100 + p.месяц);

                            NewRow.mГод = (int)(queryMax / 100);
                            NewRow.mМесяц = queryMax - NewRow.mГод * 100;
                        }

                        
                   //     dsТабель1.абоненты1дома.Rows.Add(NewRow);
                        tempList.Add(NewRow);
                    }

                }
            }




            bindingSource1.DataSource = tempList;

            this.Text = "Оплаты жильцов дома № " + клДом.deRow.номер.ToString().Trim()
              + " " + клДом.deRow.корпус.Trim()
              + " по улице  " + клДом.deRow.улицы.наимен
              + " за " + клМесяц.год.ToString() + "  год";

            dataGridView1.Focus();
        }


        class temp
        {
            public int год { get; set; }
            public int M1 { get; set; }
            public int M2 { get; set; }
            public int M3 { get; set; }
            public int M4 { get; set; }
            public int M5 { get; set; }
            public int M6 { get; set; }
            public int M7 { get; set; }
            public int M8 { get; set; }
            public int M9 { get; set; }
            public int M10 { get; set; }
            public int M11 { get; set; }
            public int M12 { get; set; }
            public Guid услуга { get; set; }
            public string наимен_услуги { get; set; }
            public string фио { get; set; }
            public Guid клиент { get; set; }
            public int квартира { get; set; }
            public bool цвет { get; set; }
            public string прим { get; set; }
            public int mГод { get; set; }
            public int mМесяц { get; set; }
            public Guid дом { get; set; }
            public bool подключен { get; set; }
            public string фамилия { get; set; }
            public string имя { get; set; }
            public string отчество { get; set; }
            public string телефон { get; set; }
            public string прим0 { get; set; }
            public int подъезд { get; set; }
            public int долг_мес { get; set; }
            public bool должник { get; set; }
            public int ввод { get; set; }
            public DateTime? mПодключено { get; set; }
            public DateTime? mОтключено { get; set; }
            public DateTime? mПовторно { get; set; }
            public DateTime? mПереключено { get; set; }

            public void setField(int месяц, int оплачено)
            {
                //                int caseSwitch = 1;
                switch (месяц)
                {
                    case 1:
                        M1 = оплачено;
                        break;
                    case 2:
                        M2 = оплачено;
                        break;
                    case 3:
                        M3 = оплачено;
                        break;
                    case 4:
                        M4 = оплачено;
                        break;
                    case 5:
                        M5 = оплачено;
                        break;
                    case 6:
                        M6 = оплачено;
                        break;
                    case 7:
                        M7 = оплачено;
                        break;
                    case 8:
                        M8 = оплачено;
                        break;
                    case 9:
                        M9 = оплачено;
                        break;
                    case 10:
                        M10 = оплачено;
                        break;
                    case 11:
                        M11 = оплачено;
                        break;
                    case 12:
                        M12 = оплачено;
                        break;
                    default:

                        break;
                }
            }

            public int Field(int месяц)
            {
                int внесено = 0;
                switch (месяц)
                {
                    case 1:
                        внесено = M1;
                        break;
                    case 2:
                        внесено = M2;
                        break;
                    case 3:
                        внесено = M3;
                        break;
                    case 4:
                        внесено = M4;
                        break;
                    case 5:
                        внесено = M5;
                        break;
                    case 6:
                        внесено = M6;
                        break;
                    case 7:
                        внесено = M7;
                        break;
                    case 8:
                        внесено = M8;
                        break;
                    case 9:
                        внесено = M9;
                        break;
                    case 10:
                        внесено = M10;
                        break;
                    case 11:
                        внесено = M11;
                        break;
                    case 12:
                        внесено = M12;
                        break;
                    default:
                        внесено = 0;
                        break;
                }
                return внесено;


            }
        }
           
    

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            //    Word.Application oWord = new Word.Application();

            string curDir = System.IO.Directory.GetCurrentDirectory();

            string шаблон = curDir + @"\Платежи7дома.docx";

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

            //if (template.Exists)
            //{
            //    клTemp.закрытьWord();
            //    template.CopyTo(tempFile, true);
            //}

  
            string наименФилиала = de.филиалы
                .OrderBy(n => n.порядок)
                .First().наимен;


            //Word.Document o = oWord.Documents.Add(Template: шаблон);
            ////  oWord.Application.Visible = true;
            //o.Bookmarks["дом"].Range.Text = клДом.номер.ToString().Trim() + " " + клДом.корпус;
            //o.Bookmarks["улица"].Range.Text = клУлица.наимен;
            //o.Bookmarks["филиал"].Range.Text = наименФилиала;
            //o.Bookmarks["год"].Range.Text = оМесяц.год.ToString();
            //o.Bookmarks["дата"].Range.Text = DateTime.Today.ToShortDateString();
            try
            {
                using (WordprocessingDocument package = WordprocessingDocument.Open(tempFile, true))
                {


                    var tables = package.MainDocumentPart.Document.Body.Elements<Table>();
                    Table table1 = tables.First();
                    Table table2 = tables.Last();


                    клXML.ChangeTextInCell(table1, 0, 1, наименФилиала);
                    клXML.ChangeTextInCell(table1, 0, 2, клМесяц.год.ToString());
                    клXML.ChangeTextInCell(table1, 1, 1, клУлица.наимен);
                    клXML.ChangeTextInCell(table1, 2, 1, клДом.номер.ToString().Trim() + " " + клДом.корпус);
                    клXML.ChangeTextInCell(table1, 2, 2, DateTime.Today.ToShortDateString());

                    //Table table = package.MainDocumentPart.Document.Body.ChildElements.Last<Table>();
                    TableRow lastRow = table2.Elements<TableRow>().Last();
                    //for (int k = 0; k < 17; k++)
                    //{
                    //    клXML.ChangeTextInCell(table2, 1, k, " ");
                    //}
                    int строк = tempList.Count;
                    for (int s = 1; s < строк; s++)
                    {
                        TableRow newRow = lastRow.Clone() as TableRow;
                        table2.AppendChild<TableRow>(newRow);
                    }


                    int j = 0;
                    foreach (temp uRow in tempList)
                    {
                        j++;
                        клXML.ChangeTextInCell(table2, j, 0, uRow.квартира.ToString("0;#;#"));
                        клXML.ChangeTextInCell(table2, j, 1, uRow.ввод.ToString("0;#;#"));
                        клXML.ChangeTextInCell(table2, j, 2, uRow.фио.Trim());
                        клXML.ChangeTextInCell(table2, j, 3, uRow.наимен_услуги.Substring(0, 10));

                        //o.Tables[2].Rows[j].Cells[1].Range.Text = uRow.квартира.ToString("0;#;#");
                        //o.Tables[2].Rows[j].Cells[2].Range.Text = uRow.фио.Trim();
                        //o.Tables[2].Rows[j].Cells[3].Range.Text = uRow.наимен_услуги.Substring(0, 5);

                        if (uRow.mГод > 0)
                        {
                            //    o.Tables[2].Rows[j].Cells[16].Range.Text =
                            //        uRow.mМесяц.ToString().Trim() + "." + (uRow.mГод - 2000).ToString().Trim();
                            string послОплата = uRow.mМесяц.ToString().Trim() + "." + (uRow.mГод - 2000).ToString().Trim();
                            клXML.ChangeTextInCell(table2, j, 16, послОплата);

                        }
                       
                        клXML.ChangeTextInCell(table2, j, 17, uRow.прим.Trim());
                        for (int i = 1; i <= 12; i++)
                        {
                            //  string поле = "M" + i.ToString().Trim();
                            //                        o.Tables[2].Rows[j].Cells[i + 3].Range.Text = uRow.Field<string>(поле);
                            клXML.ChangeTextInCell(table2, j, i + 3, uRow.Field(i).ToString("0;#;#"));
                        }

                        //o.Tables[2].Rows.Add();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Сбой..."+ex.Message);
                return;

            }

            //клTemp.закрытьWord();
            //string tempFile = @"C:\temp\temp.doc";


            //oWord.Application.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;
            //o.SaveAs(FileName: tempFile);
            //клTemp.Caption = o.ActiveWindow.Caption;
            //oWord.Application.Visible = true;

            //var template2 = new System.IO.FileInfo(tempFile);
            //string tempFile2 = curDir + @"\temp\temp.dotx";
            клTemp.закрытьWord();
            //   template2.S.CopyTo(tempFile2, true);


            клXML.просмотрWord(tempFile);
            Cursor = Cursors.Default;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            //    Word.Application oWord = new Word.Application();

            string curDir = System.IO.Directory.GetCurrentDirectory();

            string шаблон = curDir + @"\Платежи7дома.docx";

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

           

            string наименФилиала = de.филиалы
                .OrderBy(n => n.порядок)
                .First().наимен;


            
            try
            {
                using (WordprocessingDocument package = WordprocessingDocument.Open(tempFile, true))
                {


                    var tables = package.MainDocumentPart.Document.Body.Elements<Table>();
                    Table table1 = tables.First();
                    Table table2 = tables.Last();


                    клXML.ChangeTextInCell(table1, 0, 1, наименФилиала);
                    клXML.ChangeTextInCell(table1, 0, 2, клМесяц.год.ToString());
                    клXML.ChangeTextInCell(table1, 1, 1, клУлица.наимен);
                    клXML.ChangeTextInCell(table1, 2, 1, клДом.номер.ToString().Trim() + " " + клДом.корпус);
                    клXML.ChangeTextInCell(table1, 2, 2, DateTime.Today.ToShortDateString());

                  
                    TableRow lastRow = table2.Elements<TableRow>().Last();
                   
                    int строк = tempList.Count;
                    for (int s = 1; s < строк; s++)
                    {
                        TableRow newRow = lastRow.Clone() as TableRow;
                        table2.AppendChild<TableRow>(newRow);
                    }


                    int j = 0;
                    foreach (temp uRow in tempList)
                    {
                        j++;
                        клXML.ChangeTextInCell(table2, j, 0, uRow.квартира.ToString("0;#;#"));
                        клXML.ChangeTextInCell(table2, j, 1, uRow.ввод.ToString("0;#;#"));
                        клXML.ChangeTextInCell(table2, j, 2, uRow.фио.Trim());
                        клXML.ChangeTextInCell(table2, j, 3, uRow.наимен_услуги.Substring(0, 5));

                        

                        //if (uRow.mГод > 0)
                        //{
                        
                        //    string послОплата = uRow.mМесяц.ToString().Trim() + "." + (uRow.mГод - 2000).ToString().Trim();
                        //    клXML.ChangeTextInCell(table2, j, 16, послОплата);

                        //}

                        //клXML.ChangeTextInCell(table2, j, 17, uRow.прим.Trim());
                        //for (int i = 1; i <= 12; i++)
                        //{
                        //    //  string поле = "M" + i.ToString().Trim();
                        //    //                        o.Tables[2].Rows[j].Cells[i + 3].Range.Text = uRow.Field<string>(поле);
                        //    клXML.ChangeTextInCell(table2, j, i + 3, uRow.Field(i).ToString("0;#;#"));
                        //}

                       
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сбой..." + ex.Message);
                return;

            }

           
            клTemp.закрытьWord();
         

            клXML.просмотрWord(tempFile);
            Cursor = Cursors.Default;

        }

        private void button9_Click(object sender, EventArgs e)
        {
            //выбратьVуслуги выбратьУслуги = new выбратьVуслуги();
            //выбратьУслуги.ShowDialog();

            Cursor = Cursors.WaitCursor;
            //    Word.Application oWord = new Word.Application();

            string curDir = System.IO.Directory.GetCurrentDirectory();

            string шаблон = curDir + @"\Платежи7дома.docx";

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



            string наименФилиала = de.филиалы
                .OrderBy(n => n.порядок)
                .First().наимен;



            try
            {
                using (WordprocessingDocument package = WordprocessingDocument.Open(tempFile, true))
                {


                    var tables = package.MainDocumentPart.Document.Body.Elements<Table>();
                    Table table1 = tables.First();
                    Table table2 = tables.Last();


                    клXML.ChangeTextInCell(table1, 0, 1, наименФилиала);
                    клXML.ChangeTextInCell(table1, 0, 2, клМесяц.год.ToString());
                    клXML.ChangeTextInCell(table1, 1, 1, клУлица.наимен);
                    клXML.ChangeTextInCell(table1, 2, 1, клДом.номер.ToString().Trim() + " " + клДом.корпус);
                    клXML.ChangeTextInCell(table1, 2, 2, DateTime.Today.ToShortDateString());


                    TableRow lastRow = table2.Elements<TableRow>().Last();

                    //int строк = tempList.Count;

                    int строк = de.клиенты
                                       .Count(n => n.дом == клДом.дом) * 2;
                    for (int s = 1; s < строк; s++)
                    {
                        TableRow newRow = lastRow.Clone() as TableRow;
                        table2.AppendChild<TableRow>(newRow);
                    }


                    int j = 0;
                   
                        foreach (клиенты uRow in de.клиенты
                                       .Where(n => n.дом == клДом.дом)
                                       .OrderBy(n => n.квартира)
                                       .ThenBy(n=>n.ввод))
                    {
                        j++;
                        клXML.ChangeTextInCell(table2, j, 0, uRow.квартира.ToString("0;#;#"));
                                    клXML.ChangeTextInCell(table2, j, 1, uRow.ввод.ToString("0;#;#"));
                                    клXML.ChangeTextInCell(table2, j, 2, uRow.фио.Trim());
                                    клXML.ChangeTextInCell(table2, j, 3, "");
                                    j++;
                                    клXML.ChangeTextInCell(table2, j, 0, "");
                                    клXML.ChangeTextInCell(table2, j, 1, "");
                                    клXML.ChangeTextInCell(table2, j, 2, "");
                                    клXML.ChangeTextInCell(table2, j, 3, "");

                        //int y = 0;
                        //foreach (услуги yRow in de.услуги
                        //    .OrderBy(n=>n.виды_услуг.порядок)
                        //    .ThenBy(n=>n.порядок))
                        //{
                        //    if (клУслуга.dictУслуг.ContainsKey(yRow.услуга))
                        //    {
                        //        y++;
                        //        j++;
                        //        if (y == 1)
                        //        {
                        //            клXML.ChangeTextInCell(table2, j, 0, uRow.квартира.ToString("0;#;#"));
                        //            клXML.ChangeTextInCell(table2, j, 1, uRow.ввод.ToString("0;#;#"));
                        //            клXML.ChangeTextInCell(table2, j, 2, uRow.фио.Trim());
                        //        }
                        //        клXML.ChangeTextInCell(table2, j, 3, yRow.обозначение);
                        //    }
                            
                        //}

                        //if (uRow.mГод > 0)
                        //{

                        //    string послОплата = uRow.mМесяц.ToString().Trim() + "." + (uRow.mГод - 2000).ToString().Trim();
                        //    клXML.ChangeTextInCell(table2, j, 16, послОплата);

                        //}

                        //клXML.ChangeTextInCell(table2, j, 17, uRow.прим.Trim());
                        //for (int i = 1; i <= 12; i++)
                        //{
                        //    //  string поле = "M" + i.ToString().Trim();
                        //    //                        o.Tables[2].Rows[j].Cells[i + 3].Range.Text = uRow.Field<string>(поле);
                        //    клXML.ChangeTextInCell(table2, j, i + 3, uRow.Field(i).ToString("0;#;#"));
                        //}


                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сбой..." + ex.Message);
                return;

            }


            клTemp.закрытьWord();


            клXML.просмотрWord(tempFile);
            Cursor = Cursors.Default;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(bindingSource1.Count>0)
            {
                temp uRow = bindingSource1.Current as temp;
                клУслуга.deRow = de.услуги.Single(n => n.услуга == uRow.услуга);

                клУслуга.услуга = uRow.услуга;
                клКлиент.клиент = uRow.клиент;
                клКлиент.deRow = de.клиенты.Single(n => n.клиент == клКлиент.клиент);
              //  только_просмотр вертикальПросмотр = new только_просмотр();
                оплаченные1просмотр вертикальПросмотр = new оплаченные1просмотр();
                вертикальПросмотр.Text = "Подробности оплаты " + uRow.наимен_услуги + " " + клКлиент.deRow.адрес;
                вертикальПросмотр.ShowDialog();
            }
            dataGridView1.Focus();
        }
    }
}
