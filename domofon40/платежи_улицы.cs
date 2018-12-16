using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace domofon40
{
    public partial class платежи_улицы : Form
    {
        public платежи_улицы()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        DataTable архив = new DataTable();
        int текГод = DateTime.Today.Year;
        int текМесяц = DateTime.Today.Month;
        private void платежи_улицы_Load(object sender, EventArgs e)
        {
            try
            {
                DataColumn квартираColumn = архив.Columns.Add("квартира");
                квартираColumn.DataType = Type.GetType("System.Int32");

                DataColumn NewColumn;
                var queryДом = de.дома
                    .Where(n => n.улица == клУлица.улица)
                    .OrderBy(n => n.номер)
                    .ThenBy(n => n.корпус);

                foreach (дома dRow in queryДом)
                {

                    NewColumn = new DataColumn(dRow.дом.ToString());
                    NewColumn.DataType = Type.GetType("System.String");
                    NewColumn.DefaultValue = "";
                    NewColumn.Caption = dRow.номер.ToString().Trim() + "\n" + dRow.корпус.Trim();
                    архив.Columns.Add(NewColumn);
                }

                int maxКв = 0;
                if (de.клиенты.Any(n => n.дома.улица == клУлица.улица))
                {
                    maxКв = de.клиенты
                        .Where(n => n.дома.улица == клУлица.улица)
                        .Max(n => n.квартира);
                }


                DataRow NewRow;
                for (int j = 1; j <= maxКв; j++)
                {
                    NewRow = архив.NewRow();
                    NewRow.SetField<int>(квартираColumn, j);
                    архив.Rows.Add(NewRow);
                }


                var queryMax = de.оплачено
                    .Where(n => n.услуга == клУслуга.услуга)
                    .Where(n => n.оплаты.клиенты.дома.улица == клУлица.улица)
                    .GroupBy(n => new { n.оплаты.клиенты.дом, n.оплаты.клиенты.квартира })
                    .Select(n => new
                    {
                        n.Key.дом,
                        n.Key.квартира,
                        maxGM = n.Max(p => p.год * 100 + p.месяц)
                    });


                int mМес = 0;
                int mГод = 0;
                foreach (var uRow in queryMax)
                {
                    if (архив.Select("квартира='" + uRow.квартира.ToString().Trim() + "'").Count() > 0)
                    {

                        mГод = (int)uRow.maxGM / 100;
                        mМес = uRow.maxGM - mГод * 100;
                        string gg = "";
                        int долгМес = текГод * 12 + текМесяц - 1 - mГод * 12 - mМес;
                        if (долгМес > 1)
                        {
                            gg = "*";
                        }
                        string mg = mМес.ToString().Trim() + "." + (mГод - 2000).ToString().Trim() + gg;
                        var tRow = архив.Select("квартира='" + uRow.квартира.ToString().Trim() + "'")[0];
                        tRow.SetField<string>(uRow.дом.ToString(), mg);
                    }

                }




                dataGridView1.DataSource = архив;
                //     int i = 1;
                foreach (дома dRow in queryДом)
                {
                    DataGridViewColumn tCol1 = dataGridView1.Columns["квартира"];
                    tCol1.Width = 50;
                    tCol1.HeaderText = "кв.";
                    DataGridViewColumn tCol = dataGridView1.Columns[dRow.дом.ToString()];
                    tCol.HeaderText = dRow.номер.ToString().Trim()
                        + "\n" + dRow.корпус.Trim();
                    tCol.Width = 50;
                    //    tCol.DefaultCellStyle.Format = "0.0000;#;#";
                    tCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Сбой загрузки {ex.Message}");
            }

    
            dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
            dataGridView1.CellMouseClick += new DataGridViewCellMouseEventHandler(dataGridView1_CellMouseClick);

        }
        void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                Guid  КодДома = Guid.Parse(dataGridView1.Columns[e.ColumnIndex].Name);
                int НомерКвартиры = (int)dataGridView1.Rows[e.RowIndex].Cells["квартира"].Value;
                string текст = "";

                try
                {
                    дома deДом = de.дома.Single(n => n.дом == КодДома);
                    текст += "дом " + deДом.номер.ToString().Trim() + " " + deДом.корпус.Trim() + " кв. " + НомерКвартиры.ToString();
                }
                catch { }
                var жильцы = de.клиенты
                    .Where(n => n.дом == КодДома && n.квартира == НомерКвартиры);

                foreach (клиенты kRow in жильцы)
                {
                    текст += "\n" + kRow.фио;
                }
                MessageBox.Show(текст);
            }
        }

        void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value.ToString().Contains('*'))
            {
                //  e.CellStyle.ForeColor = Color.Red;
                e.CellStyle.BackColor = System.Drawing.Color.FromArgb(255, 200, 200);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            string curDir = System.IO.Directory.GetCurrentDirectory();

            string шаблон = curDir + @"\Платежи7улицы.docx";
            if (!System.IO.File.Exists(шаблон.ToString()))
            {
                MessageBox.Show("Нет файла " + шаблон.ToString());
                Cursor = Cursors.Default;
                return;
            }

            try
            {
                var template = new System.IO.FileInfo(шаблон);
                string tempFile = curDir + @"\temp\temp.docx";
                клTemp.закрытьWord();
                template.CopyTo(tempFile, true);


                string наименФилиала = de.филиалы
                    .OrderBy(n => n.порядок)
                    .First().наимен;


                using (WordprocessingDocument package = WordprocessingDocument.Open(tempFile, true))
                {


                    var tables = package.MainDocumentPart.Document.Body.Elements<Table>();
                    Table table1 = tables.First();
                    Table table2 = tables.Last();


                    клXML.ChangeTextInCell(table1, 0, 1, клУслуга.наимен);
                    клXML.ChangeTextInCell(table1, 1, 1, клУлица.наимен);
                    клXML.ChangeTextInCell(table1, 2, 1, наименФилиала);
                    клXML.ChangeTextInCell(table1, 2, 2, DateTime.Today.ToShortDateString());


                    TableRow firstRow = table2.Elements<TableRow>().First();
                    TableRow lastRow = table2.Elements<TableRow>().Last();

                    TableCell lastCell0 = firstRow.Elements<TableCell>().Last();
                    TableCell lastCell = lastRow.Elements<TableCell>().Last();

                    int домов = архив.Columns.Count - 1;
                    for (int k = 0; k < домов - 1; k++)
                    {
                        TableCell newCell0 = lastCell0.Clone() as TableCell;
                        firstRow.AppendChild<TableCell>(newCell0);

                        TableCell newCell = lastCell.Clone() as TableCell;
                        lastRow.AppendChild<TableCell>(newCell);
                    }

                    for (int k = 1; k <= домов; k++)
                    {
                        клXML.ChangeTextInCell(table2, 0, k, архив.Columns[k].Caption);
                    }
                    lastRow = table2.Elements<TableRow>().Last();
                    int квартир = архив.Rows.Count;

                    for (int i = 1; i < квартир; i++)
                    {
                        TableRow newRow = lastRow.Clone() as TableRow;
                        table2.AppendChild(newRow);
                    }



                    int j = 0;
                    foreach (DataRow uRow in архив.Rows)
                    {
                        j++;
                        клXML.ChangeTextInCell(table2, j, 0, uRow.Field<int>("квартира").ToString());

                        int r = 0;
                        foreach (DataColumn nCol in архив.Columns)
                        {
                            r++;
                            if (r > 1)
                            {
                                клXML.ChangeTextInCell(table2, j, r - 1, uRow.Field<string>(r - 1).ToString());
                            }

                        }
                    }


                }

                Cursor = Cursors.Default;
                клXML.просмотрWord(tempFile);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ошибка {ex.Message}");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int строк = архив.Rows.Count + 1;
                int столбцов = архив.Columns.Count;
                object[,] aRow = new object[строк, столбцов];

                aRow[0, 0] = "дом\n кв.";
                for (int i = 1; i < столбцов; i++)
                {
                    aRow[0, i] = архив.Columns[i].Caption.Trim();
                }

                for (int j = 1; j < строк - 1; j++)
                {

                    aRow[j, 0] = архив.Rows[j].Field<int>(0).ToString();

                    for (int i = 1; i < столбцов; i++)
                    {
                        aRow[j, i] = архив.Rows[j].Field<string>(i);
                    }
                }

                массив_excel(aRow, строк, столбцов);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка {ex.Message}");
            }

        }

        private void массив_excel(object[,] массив, int строк, int столбцов)
        {


            Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();

            string curDir = System.IO.Directory.GetCurrentDirectory();

            object шаблон = curDir + @"\платежи_улица.xlt";
            if (!System.IO.File.Exists(шаблон.ToString()))
            {
                MessageBox.Show("Нет файла " + шаблон.ToString());
                return;
            }

            Microsoft.Office.Interop.Excel.Workbook o = oExcel.Workbooks.Add(Template: шаблон);

            Excel.Worksheet eList = (Excel.Worksheet)o.Worksheets[1];
            //  Excel.ListObject tab1 = eList.ListObjects[1];
            oExcel.Application.Visible = true;


            eList.Cells[1, 2] = this.Text + "   " + DateTime.Today.ToShortDateString();
            eList.Cells[3, 1].Select();
            eList.Cells[3, 1].Copy();

            Excel.Range rg = eList.get_Range("A3", Type.Missing);
            rg = rg.get_Resize(строк - 1, столбцов);
            rg.PasteSpecial(Excel.XlPasteType.xlPasteFormats);
            rg.NumberFormat = "@";
            rg.HorizontalAlignment = Excel.Constants.xlRight;
            rg.VerticalAlignment = Excel.Constants.xlTop;
            //            eList.Cells[3, 1].Paste();
            //    o.ActiveSheet.Paste();
            rg.Value2 = массив;

            eList.Cells[3, 1].Select();
            oExcel.Application.Visible = true;



           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Word.Application oWord = new Word.Application();

            string curDir = System.IO.Directory.GetCurrentDirectory();

            object шаблон = curDir + @"\Платежи_улица.dot";
            if (!System.IO.File.Exists(шаблон.ToString()))
            {
                MessageBox.Show("Нет файла " + шаблон.ToString());
                return;
            }



            string наименФилиала = de.филиалы
                .OrderBy(n => n.порядок)
                .First().наимен;


            Word.Document o = oWord.Documents.Add(Template: шаблон);
            oWord.Application.Visible = true;
            o.Bookmarks["услуга"].Range.Text = клУслуга.наимен;
            o.Bookmarks["улица"].Range.Text = клУлица.наимен;
            o.Bookmarks["филиал"].Range.Text = наименФилиала;
            o.Bookmarks["дата"].Range.Text = DateTime.Today.ToShortDateString();

            o.Tables[2].Rows[1].Cells[2].Range.Text = архив.Columns[1].Caption;

            int i = 0;
            foreach (DataColumn nCol in архив.Columns)
            {
                i++;
                if (nCol.Ordinal > 1)
                {
                    o.Tables[2].Columns.Add();
                    o.Tables[2].Rows[1].Cells[i].Range.Text = nCol.Caption;
                }
            }
            int j = 1;
            //  string dd = "";
            foreach (DataRow uRow in архив.Rows)
            {
                j++;
                o.Tables[2].Rows[j].Cells[1].Range.Text = uRow.Field<int>(0).ToString().Trim();
                int r = 0;
                foreach (DataColumn nCol in архив.Columns)
                {
                    r++;
                    if (r > 1)
                    {
                        o.Tables[2].Rows[j].Cells[r].Range.Text = uRow.Field<string>(r - 1).Trim();
                    }

                }
                o.Tables[2].Rows.Add();

            }
            oWord.Application.Visible = true;

        }


    }
}
