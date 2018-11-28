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
    public partial class отчет_дни : Form
    {
        public отчет_дни()
        {
            InitializeComponent();
        }
     //   int всего = 0;
        int видов = 0;
        int[] aVid;
        domofon40.domofon14Entities de = new domofon14Entities();
        System.Data.DataTable dt = new System.Data.DataTable();
        private void отчет_дни_Load(object sender, EventArgs e)
        {

            видов = de.виды_услуг.Count();
            aVid = new int[видов+1];
            try
            {
                var query = de.оплачено
                 .Where(n => n.оплаты.дата >= клПериод.дата_с && n.оплаты.дата <= клПериод.дата_по)
                 .GroupBy(n => new { n.услуги.вид_услуги, дата = n.оплаты.дата, n.оплаты.сотрудник })
                 .Select(n => new
                 {
                     вид = n.Key.вид_услуги,
                     дата = n.Key.дата,
                     сотрудник = n.Key.сотрудник,
                     сумма = n.Sum(z => z.сумма)
                 }).ToArray();

                var фамилии = de.оплаты
                      .Where(n => n.дата >= клПериод.дата_с && n.дата <= клПериод.дата_по)
                      .Where(n=>n.оплачено.Any())
                      .GroupBy(n => new { дата = n.дата, n.сотрудники })
                      .Select(n => new { n.Key.дата, 
                          n.Key.сотрудники.фио, 
                          n.Key.сотрудники.сотрудник,
                     сумма = n.Sum(p=>p.оплачено.Sum(s=>s.сумма))    
                      })
                      .ToArray();


                System.Data.DataColumn dc1 = new System.Data.DataColumn("дата");
                dc1.Caption = "дата";
                dc1.DataType = typeof(DateTime);
                //   dc1.DefaultValue = "";
                dt.Columns.Add(dc1);

                System.Data.DataColumn dc2 = new System.Data.DataColumn("сотрудник");
                dc2.Caption = "сотрудник";
                dc2.DataType = typeof(string);
                //   dc1.DefaultValue = "";
                dt.Columns.Add(dc2);

                System.Data.DataColumn dc3 = new System.Data.DataColumn("фио");
                dc3.Caption = "фио";
                dc3.DataType = typeof(string);
                //   dc1.DefaultValue = "";
                dt.Columns.Add(dc3);

                foreach (виды_услуг pRow in de.виды_услуг
                    .OrderBy(n => n.порядок))
                {

                    System.Data.DataColumn dc = new System.Data.DataColumn(pRow.вид_услуги.ToString());
                    dc.Caption = pRow.наимен;
                    dc.DataType = typeof(int);
                    dc.DefaultValue = 0;
                    dt.Columns.Add(dc);

                }

                System.Data.DataColumn dc5 = new System.Data.DataColumn("всего");
                dc5.Caption = "Всего";
                dc5.DataType = typeof(int);
                dc5.DefaultValue = 0;
                dt.Columns.Add(dc5);

                System.Data.DataColumn dc6 = new System.Data.DataColumn("выбран");
                dc6.Caption = "Выбрать";
                dc6.DataType = typeof(bool);
                dc6.DefaultValue = 0;
                dt.Columns.Add(dc6);

                foreach (var uRow in фамилии.OrderBy(n => n.дата).ThenBy(n => n.фио))
                {
                    DataRow newRow = dt.NewRow();
                    newRow.SetField<DateTime>("дата", uRow.дата);
                    newRow.SetField<string>("сотрудник", uRow.сотрудник.ToString());
                    newRow.SetField<string>("фио", uRow.фио);
                    newRow.SetField<int>("всего", uRow.сумма);
                    aVid[видов] += uRow.сумма;
                    dt.Rows.Add(newRow);
                }

                foreach(var uRow in query)
                {
                    DataRow iRow = dt.Select("дата='" + uRow.дата.ToShortDateString() + "' and сотрудник='"+uRow.сотрудник.ToString()+"'"   ).First();
                    iRow.SetField<int>(uRow.вид.ToString(), uRow.сумма);
                }


                dataGridView1.DataSource = dt;

                dataGridView1.Columns[0].HeaderText = "дата";
                dataGridView1.Columns[0].Name = "датаColumn";

                int колонка = 2;
                foreach (виды_услуг pRow in de.виды_услуг
                  .OrderBy(n => n.порядок))
                {
                    колонка++;
                    dataGridView1.Columns[колонка].HeaderText = pRow.наимен;
                    dataGridView1.Columns[колонка].Tag = pRow.вид_услуги;
                    dataGridView1.Columns[колонка].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns[колонка].DefaultCellStyle.Format = "0;#;#";
                }

                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Width = 150;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Word.Application oWord = new Word.Application();

            string curDir = System.IO.Directory.GetCurrentDirectory();

            object шаблон = curDir + @"\отчет_дни.dot";
            if (!System.IO.File.Exists(шаблон.ToString()))
            {
                MessageBox.Show("Нет файла " + шаблон.ToString());
                return;
            }

         
            string наименФилиала = de.филиалы
                .OrderBy(n => n.порядок)
                .First().наимен;

            Word.Document o = oWord.Documents.Add(Template: шаблон);
            //    oWord.Application.Visible = true;
            o.Bookmarks["дата_с"].Range.Text = " с " + клПериод.дата_с.ToShortDateString();
            o.Bookmarks["дата_по"].Range.Text = " по " + клПериод.дата_по.ToShortDateString(); ;
            o.Bookmarks["филиал"].Range.Text = наименФилиала;
            o.Bookmarks["менеджер"].Range.Text = "Все менеджеры";

            //        o.Bookmarks["услуга"].Range.Text = клВид_услуги.наимен;
         //   int maxCol = 0;
            int колонка = 2;
            foreach (виды_услуг uRow in de.виды_услуг.OrderBy(n=>n.порядок))
            {
                колонка++;
                o.Tables[3].Cell(1, колонка).Range.Text = uRow.наимен;
            }
            колонка++;
            o.Tables[3].Cell(1, колонка).Range.Text = "всего";
           

           
            int j = 1;
            foreach (DataRow  rRow in dt.Rows)
            {
                if (rRow.Field<bool>("выбран"))
                {
                    j++;
                 
                    o.Tables[3].Cell(j, 1).Range.Text = rRow.Field<DateTime>("дата").ToShortDateString();
                    o.Tables[3].Cell(j, 2).Range.Text = rRow.Field<string>("фио");
                    for (int i = 3; i <= видов + 3; i++)
                    {

                        o.Tables[3].Cell(j, i ).Range.Text = rRow.Field<int>(i).ToString("0;#;#");
                        aVid[i-3] += rRow.Field<int>(i);
                    }

                  
                    o.Tables[3].Rows.Add();
                }
            }
            j++;

            o.Tables[3].Rows[j].Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray05;
            for (int i = 0; i <= видов; i++ )
            {
                o.Tables[3].Cell(j, i+3).Range.Text = aVid[i].ToString("0;#;#");
            }
             o.Tables[3].Cell(j + 1, 1).Range.Text = "всего";
                //o.Tables[3].Cell(j + 1, 2).Range.Text = всего.ToString("0");

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

                Guid  ? кодВида = dataGridView1.Columns[колонка].Tag as Guid ?;
                if(кодВида !=null )
                { 
              
                    DateTime дата = (DateTime)dataGridView1.CurrentRow.Cells["датаColumn"].Value;
                    клВид_услуги.вид_услуги = (Guid)dataGridView1.Columns[колонка].Tag;
                    клВид_услуги.наимен = dataGridView1.Columns[колонка].HeaderText;
                    клРеестр.дата = дата;

                    Cursor = Cursors.WaitCursor;
                    реестр_все формаРеестр = new реестр_все();
                    формаРеестр.Text = "Реестр за " + клРеестр.дата.ToLongDateString() + " по ";
                    формаРеестр.Text += " " + клВид_услуги.наимен.Trim();
                    формаРеестр.Text += "Все менеджеры ";

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
    }
}
