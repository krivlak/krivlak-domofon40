using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace domofon40
{
    public partial class период1кассир : Form
    {
        public период1кассир()
        {
            InitializeComponent();
        }
        int всего = 0;
        int видов = 0;
        int[] aVid;
        domofon40.domofon14Entities de = new domofon14Entities();
        System.Data.DataTable dt = new System.Data.DataTable();
        private void период1кассир_Load(object sender, EventArgs e)
        {

            видов = de.виды_услуг.Count();
            aVid = new int[видов];
            //try
            //{
                var query = de.оплачено
                .Where(n => n.оплаты.дата>= клПериод.дата_с && n.оплаты.дата <= клПериод.дата_по)
                .Where(n => n.оплаты.сотрудник == клСотрудник.сотрудник)
                .GroupBy(n => new { n.услуги.виды_услуг,  n.оплаты.дата})
                .Select(n => new
                {
                    вид = n.Key.виды_услуг.вид_услуги,
                    дата = n.Key.дата,
                    сумма = n.Sum(z => z.сумма)
                }).ToList();

                var query1 = query.GroupBy(n => n.дата)
                    .Select(n => new { дата = n.Key, всего = n.Sum(p=>p.сумма) });

            //dataGridView1.DataSource = query;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            

            //System.Data.DataColumn dc0 = new System.Data.DataColumn("вид");
            ////dc0.Caption = "услуга";
            //dc0.DataType = typeof(string);
            //dc0.DefaultValue = "";
            //dt.Columns.Add(dc0);

            System.Data.DataColumn dc1 = new System.Data.DataColumn("дата");
            dc1.Caption = "дата";
    //        dc1.ColumnName = "датаColumn";
            dc1.DataType = typeof(DateTime);
         //   dc1.DefaultValue = "";
            dt.Columns.Add(dc1);

            foreach (виды_услуг pRow in de.виды_услуг
                .OrderBy(n => n.порядок))
            {

                System.Data.DataColumn dc = new System.Data.DataColumn(pRow.вид_услуги.ToString());
                dc.Caption = pRow.наимен;
                dc.DataType = typeof(int);
                dc.ColumnName = pRow.вид_услуги.ToString();
                dc.DefaultValue = 0;
                dt.Columns.Add(dc);

            }

            System.Data.DataColumn dc5 = new System.Data.DataColumn("всего");
            dc5.Caption = "Всего";
            dc5.DataType = typeof(int);
            dc5.DefaultValue = 0;
            dt.Columns.Add(dc5);
            всего = 0;
            foreach (var uRow in query1.OrderBy(n=>n.дата))
            {

                DataRow NewRow = dt.NewRow();
                NewRow.SetField<DateTime>("дата", uRow.дата);
                NewRow.SetField<int>("всего",uRow.всего);
                dt.Rows.Add(NewRow);
                всего += uRow.всего;
            }
            textBox1.Text = всего.ToString();

            foreach (var uRow in query)
            {
                DataRow iRow = dt.Select("дата='" + uRow.дата.ToShortDateString() + "'").First();
                iRow.SetField<int>(uRow.вид.ToString(), uRow.сумма);
            }

            foreach (DataRow uRow in dt.Rows)
            {
                for (int i=1 ; i <=видов ; i++)
                {
                    aVid[i - 1] += uRow.Field<int>(i);
                }
            }
            DataRow NewRow1 = dt.NewRow();
          //  NewRow1.SetField<DateTime>("дата", uRow.дата);
            NewRow1.SetField<int>("всего", всего );
            for (int i = 0; i < aVid.Count(); i++ )
            {
                NewRow1.SetField<int>(i+1, aVid[i]);
            }
                dt.Rows.Add(NewRow1);
           


            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Name = "датаColumn";
            int ii = 0;
            foreach(виды_услуг uRow in de.виды_услуг.OrderBy(n=>n.порядок))
            {
                ii++;
                dataGridView1.Columns[ii].HeaderText = uRow.наимен;
                dataGridView1.Columns[ii].Tag = uRow.вид_услуги;
                dataGridView1.Columns[ii].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[ii].DefaultCellStyle.Format = "0;#;#";
            }
            ii++;
            dataGridView1.Columns[ii].HeaderText = "Всего";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Word.Application oWord = new Word.Application();

            string curDir = System.IO.Directory.GetCurrentDirectory();

            object шаблон = curDir + @"\период1кассир.dot";
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
            o.Bookmarks["дата_с"].Range.Text = " с " + клПериод.дата_с.ToShortDateString();
            o.Bookmarks["дата_по"].Range.Text = " по " + клПериод.дата_по.ToShortDateString(); ;
            o.Bookmarks["филиал"].Range.Text = наименФилиала;
            o.Bookmarks["менеджер"].Range.Text = клСотрудник.фио;
      //      int maxCol = 0;
            int ii = 1;
            foreach (виды_услуг sRow in de.виды_услуг.OrderBy(n => n.порядок))
            {
                ii++;
                    o.Tables[3].Cell(1, ii).Range.Text = sRow.наимен;
                //    maxCol = sRow.порядок + 1;
            }
            ii++;
            o.Tables[3].Cell(1, ii).Range.Text = "всего";
           // o.Tables[3].Cell(1, ii).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray05;
            o.Tables[3].Columns[ii].Shading.BackgroundPatternColor = Word.WdColor.wdColorGray05;
            //decimal всего1 = 0;
            //decimal всего2 = 0;
            //decimal всего3 = 0;
            //decimal всего4 = 0;
            int j = 1;
            foreach (DataRow rRow in dt.Rows )
            {
                j++;
                //всего1 += rRow.вид1;
                //всего2 += rRow.вид2;
                //всего3 += rRow.вид3;
                //всего4 += rRow.вид4;
                try
                {
                    o.Tables[3].Cell(j, 1).Range.Text = rRow.Field<DateTime>("дата").ToShortDateString();
                }
                catch { }

       
                for (int i=1; i<=видов+1 ; i++)
               {
                   o.Tables[3].Cell(j, i+1).Range.Text = rRow.Field<int>(i).ToString("0;#;#");
               }

                //o.Tables[3].Cell(j, 2).Range.Text = rRow.вид1.ToString("0;#;#");
                //o.Tables[3].Cell(j, 3).Range.Text = rRow.вид2.ToString("0;#;#");
                //o.Tables[3].Cell(j, 4).Range.Text = rRow.вид3.ToString("0;#;#");
                //o.Tables[3].Cell(j, 5).Range.Text = rRow.вид4.ToString("0;#;#");
                o.Tables[3].Rows.Add();
            }

            //j++;
            //o.Tables[3].Cell(j, 1).Range.Text = "Всего за все услуги";
            //o.Tables[3].Cell(j, видов + 2).Range.Text = всего.ToString("0;#;#");

            //o.Tables[3].Cell(j + 1, 1).Range.Text = "за период";
            //o.Tables[3].Cell(j + 1, 2).Range.Text = всего1.ToString("0.00");
            //o.Tables[3].Cell(j + 1, 3).Range.Text = всего2.ToString("0.00");
            //o.Tables[3].Cell(j + 1, 4).Range.Text = всего3.ToString("0.00");
            //o.Tables[3].Cell(j + 1, 5).Range.Text = всего4.ToString("0.00");

            for (int i = 5; i > видов+2; i--)
            {
                o.Tables[3].Columns[i].Delete();
            }


            //клTemp.закрытьWord();
            //object tempFile = @"C:\temp\temp.doc";
            //oWord.Application.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;
            //o.SaveAs(FileName: tempFile);
            клTemp.Caption = o.ActiveWindow.Caption;
            //            MessageBox.Show(o.ActiveWindow.Caption);
            oWord.Application.Visible = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {

                int колонка = dataGridView1.CurrentCell.ColumnIndex;
                int строка = dataGridView1.CurrentRow.Index;

                if (колонка > 0 && колонка <3)
                {
                    выбор_вида_оплат выборВида = new выбор_вида_оплат();
                    выборВида.ShowDialog();
                    if (выборВида.DialogResult == DialogResult.OK)
                    { 

                        DateTime дата = (DateTime)dataGridView1.CurrentRow.Cells["датаColumn"].Value;
                        клВид_услуги.вид_услуги = (Guid)dataGridView1.Columns[колонка].Tag;
                        клВид_услуги.наимен = dataGridView1.Columns[колонка].HeaderText;
                        клРеестр.дата = дата;
                        клРеестр.вид_оплаты = клВид_оплаты.вид_оплаты;
                        клРеестр.наименВидаОплаты= клВид_оплаты.наимен;

                        Cursor = Cursors.WaitCursor;
                        реестр_услуг формаРеестр = new реестр_услуг();
                        формаРеестр.Text = "Реестр за " + клРеестр.дата.ToLongDateString() + " по ";
                        формаРеестр.Text += " " + клВид_услуги.наимен.Trim();
                        формаРеестр.Text += " менеджер " + клСотрудник.фио;
                        формаРеестр.Text += "вид оплаты " + клВид_оплаты.наимен;

                        string наименФилиала = de.филиалы
                            .OrderBy(n => n.порядок)
                            .First().наимен;
                        формаРеестр.Text += " по филиалу " + наименФилиала;

                        формаРеестр.ShowDialog();
                        Cursor = Cursors.Default;
                    }

                }
                else
                {
                    MessageBox.Show("Выберите вид услуги....");
                }
            }

        }
    }
}
