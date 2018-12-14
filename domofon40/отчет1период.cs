using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Word = Microsoft.Office.Interop.Word;


namespace domofon40
{
    public partial class отчет1период : Form
    {
        public отчет1период()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        DataTable dt = new DataTable("таблица");
        int всего = 0;
        private void отчет1период_Load(object sender, EventArgs e)
        {
           
            DataColumn col1 = new DataColumn();
            col1.Caption = "дата";
            col1.ColumnName = "датаColumn";
            col1.DataType = typeof(DateTime);
            col1.Unique = true;
            
            dt.Columns.Add(col1);

            DataColumn[] массив = new DataColumn[1];
            массив[0] = col1;
            dt.PrimaryKey = массив;


          

            foreach (виды_услуг vRow in de.виды_услуг.OrderBy(n => n.порядок))
            {
                DataColumn col = new DataColumn();
                col.Caption = vRow.наимен;
                col.ColumnName = vRow.вид_услуги.ToString();
                col.DataType = typeof(Int32);
                col.DefaultValue = 0;
                dt.Columns.Add(col);
            }

            DataColumn col2 = new DataColumn();
            col2.Caption = "всего";
            col2.ColumnName = "всегоColumn";
            col2.DataType = typeof(Int32);
            col2.DefaultValue = 0;
            dt.Columns.Add(col2);

            try
            {
                var query0 =de.оплаты
                    .Where(n => n.дата >= клПериод.дата_с && n.дата <= клПериод.дата_по)
                    .Where(n=>n.оплачено.Any())
                       .GroupBy(n => n.дата)
                            .Select(n => new
                            {
                                дата = n.Key,
                                всего = n.Sum(z => z.оплачено.Sum(p=>p.сумма))
                            }).ToArray();

                //var query0 = de.оплачено
                //       .Where(n => n.оплаты.дата >= клПериод.дата_с && n.оплаты.дата <= клПериод.дата_по)
                //       .GroupBy(n => n.оплаты.дата)
                //            .Select(n => new
                //            {
                //                дата = n.Key,
                //                всего = n.Sum(z => z.сумма)
                //            }).ToArray();
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}



                foreach (var uRow in query0.OrderBy(n=>n.дата))
                {
                    DataRow row = dt.NewRow();

                    row.SetField<DateTime>("датаColumn", uRow.дата);
                    row.SetField<int>("всегоColumn", uRow.всего);
                    dt.Rows.Add(row);
                    всего += uRow.всего;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            var query = de.оплачено
                .Where(n => n.оплаты.дата >= клПериод.дата_с && n.оплаты.дата <= клПериод.дата_по)
                .GroupBy(n => new { n.услуги.вид_услуги, n.оплаты.дата })
                .Select(n => new
                {
                    вид = n.Key.вид_услуги,
                    дата = n.Key.дата,
                    сумма = n.Sum(z => z.сумма),
                }).ToArray();





            foreach (var uRow in query)
            {
                var row = dt.Rows.Find(uRow.дата);
                   row.SetField<int>(uRow.вид.ToString(), uRow.сумма);
            }



            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "дата";
            dataGridView1.Columns[0].Name = "датаColumn";
            

            int i = 0;
            foreach (виды_услуг vRow in de.виды_услуг.OrderBy(n => n.порядок))
            {
                i++;
                dataGridView1.Columns[i].HeaderText = vRow.наимен;
                dataGridView1.Columns[i].Tag = vRow.вид_услуги;
                dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[i].DefaultCellStyle.Format = "0;#;0";
            }
            i++;
            dataGridView1.Columns[i].HeaderText = "всего";
            dataGridView1.Columns[i].Tag = Guid.Empty;
            dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[i].DefaultCellStyle.Format = "0;#;0";


            textBox1.Text = всего.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(dt.Rows.Count>0)
            {
                
                int колонка = dataGridView1.CurrentCell.ColumnIndex;
                int строка = dataGridView1.CurrentRow.Index;

                if (колонка > 0 && колонка < dataGridView1.ColumnCount-1) 
                {
                    DateTime дата = (DateTime)dataGridView1.CurrentRow.Cells["датаColumn"].Value;
                    клВид_услуги.вид_услуги =(Guid)  dataGridView1.Columns[колонка].Tag;
                    клВид_услуги.наимен = dataGridView1.Columns[колонка].HeaderText;
                    клРеестр.дата = дата;

                    Cursor = Cursors.WaitCursor;
                    реестр_все формаРеестр = new реестр_все();
                    формаРеестр.Text = "Реестр за " + клРеестр.дата.ToLongDateString() + " по ";
                    формаРеестр.Text += " " + клВид_услуги.наимен.Trim();
                    формаРеестр.Text += "  Все менеджеры ";

                    string наименФилиала = de.филиалы
                        .OrderBy(n => n.порядок)
                        .First().наимен;
                    формаРеестр.Text += " по филиалу " + наименФилиала;

                    формаРеестр.ShowDialog();
                    Cursor = Cursors.Default;

                }
                else
                {
                    MessageBox.Show("Выберите вид услуги....");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            Word.Application oWord = new Word.Application();

            string curDir = System.IO.Directory.GetCurrentDirectory();

            object шаблон = curDir + @"\отчет1период.dot";
            if (!System.IO.File.Exists(шаблон.ToString()))
            {
                MessageBox.Show("Нет файла " + шаблон.ToString());
                return;
            }

    //        domofon10.DataClasses1DataContext dc = new DataClasses1DataContext();
            string наименФилиала = de.филиалы
                .OrderBy(n => n.порядок)
                .First().наимен;

            Word.Document o = oWord.Documents.Add(Template: шаблон);
      //      oWord.Application.Visible = true;
            o.Bookmarks["дата_с"].Range.Text = " с " + клПериод.дата_с.ToShortDateString();
            o.Bookmarks["дата_по"].Range.Text = " по " + клПериод.дата_по.ToShortDateString(); ;
            o.Bookmarks["филиал"].Range.Text = наименФилиала;
            o.Bookmarks["менеджер"].Range.Text = "Все менеджеры";

            //        o.Bookmarks["услуга"].Range.Text = клВид_услуги.наимен;
            int maxCol = dt.Columns.Count;
            int ii = 0;
            foreach (DataColumn col in dt.Columns)
            {
                ii++;
                if(ii>1)
                {
                    o.Tables[3].Cell(1, ii).Range.Text = col.Caption;
                  //  maxCol = sRow.порядок + 1;
                }
               
            }
           
            //foreach (dsТабель.заголовкиRow sRow in dsТабель1.заголовки.OrderBy(n => n.порядок))
            //{
            //    if (sRow.виден)
            //    {
            //        o.Tables[3].Cell(1, sRow.порядок + 1).Range.Text = sRow.название;
            //        maxCol = sRow.порядок + 1;

            //    }
            //    else
            //    {
            //        o.Tables[3].Columns[sRow.порядок + 1].Delete();
            //    }

            //}

            //int всего1 = 0;
            //int всего2 = 0;
            //int всего3 = 0;
            //int всего4 = 0;
        //    int всего = 0;
            //if (dsТабель1.отчет.Any())
            //{
            //    var lastRow = dsТабель1.отчет.Last();
            //    всего = (int)(lastRow.вид1 + lastRow.вид2 + lastRow.вид3 + lastRow.вид4);
            //}
            int[] aSum = new int[dt.Columns.Count];


            int j = 1;
            foreach (DataRow row in dt.Rows)
            {
                j++;
                o.Tables[3].Cell(j, 1).Range.Text = row.Field<DateTime>("датаColumn").ToShortDateString();

                int i=0;
                foreach(DataColumn col in dt.Columns)
                {
                    i++;
                    if (i > 1)
                    {
                        aSum[i - 1] += row.Field<int>(col.ColumnName);
                        o.Tables[3].Cell(j, i).Range.Text = row.Field<int>(col.ColumnName).ToString();
                    }
                   
                }
                //i++;
                //o.Tables[3].Cell(i, 2).Range.Text = row.Field<int>("всегоColumn").ToString();

                o.Tables[3].Rows.Add();
            }
          
            //foreach (dsТабель.отчетRow rRow in dsТабель1.отчет.Rows)
            //{
            //    j++;
            //    o.Tables[3].Cell(j, 1).Range.Text = rRow.дата2;
            //    o.Tables[3].Cell(j, 2).Range.Text = rRow.вид1.ToString("0.00;#;#");
            //    o.Tables[3].Cell(j, 3).Range.Text = rRow.вид2.ToString("0.00;#;#");
            //    o.Tables[3].Cell(j, 4).Range.Text = rRow.вид3.ToString("0.00;#;#");
            //    o.Tables[3].Cell(j, 5).Range.Text = rRow.вид4.ToString("0.00;#;#");
            //    o.Tables[3].Rows.Add();
            //}


            j++;
            o.Tables[3].Cell(j, 1).Range.Text = "Всего ";
       //     o.Tables[3].Cell(j, 2).Range.Text = всего.ToString();
            o.Tables[3].Rows[j ].Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray05;
            int t = 0;
            foreach(int ss in aSum)
            {
                t++;
                if(t>1)
                {
                    o.Tables[3].Cell(j, t).Range.Text = ss.ToString();
                }
            }


            for (int i = 5; i > maxCol; i--)
            {
                o.Tables[3].Columns[i].Delete();
            }


            клTemp.Caption = o.ActiveWindow.Caption;
            oWord.Application.Visible = true;
            Cursor = Cursors.Default;

        }
    }
}
