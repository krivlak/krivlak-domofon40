using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace domofon40
{
    public partial class договоров_поселок : Form
    {
        public договоров_поселок()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        int текГод = DateTime.Today.Year;
        int текМесяц = DateTime.Today.Month;
        private void договоров_поселок_Load(object sender, EventArgs e)
        {
            try
            {

                var query = de.подключения
                .GroupBy(n => new { n.клиенты.дома.улицы.поселки, n.клиент, n.услуги })
                .GroupBy(n => new { n.Key.поселки, n.Key.услуги })
                .Select(n => new
                {
                    услуга = n.Key.услуги.услуга,
                    наимен_услуги = n.Key.услуги.наимен,
                    поселок = n.Key.поселки.поселок,
                    наимен_поселка = n.Key.поселки.наимен,
                    число_клиентов = n.Count()
                });
                //dataGridView1.DataSource = query.ToList();
                //return;


                System.Data.DataTable dt = new System.Data.DataTable();

                System.Data.DataColumn dc0 = new System.Data.DataColumn("услуга");
                //dc0.Caption = "услуга";
                dc0.DataType = typeof(string);
                dc0.DefaultValue = "";
                dt.Columns.Add(dc0);

                System.Data.DataColumn dc1 = new System.Data.DataColumn("наимен");
                dc1.Caption = "услуга";
                dc1.DataType = typeof(string);
                dc1.DefaultValue = "";
                dt.Columns.Add(dc1);

                foreach (поселки pRow in de.поселки
                    .OrderBy(n => n.порядок))
                {

                    System.Data.DataColumn dc = new System.Data.DataColumn(pRow.поселок.ToString());
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




                foreach (услуги yRow in de.услуги
                    .OrderBy(n => n.виды_услуг.порядок)
                    .ThenBy(n=>n.порядок))
                {
                    DataRow NewRow = dt.NewRow();
                    NewRow.SetField<string>("услуга", yRow.услуга.ToString());
                    NewRow.SetField<string>("наимен", yRow.наимен);
                    dt.Rows.Add(NewRow);
                }


                foreach (var uRow in query)
                {

                    DataRow iRow = dt.Select("услуга='" + uRow.услуга.ToString() + "'").First();
                    iRow.SetField<int>(uRow.поселок.ToString(), uRow.число_клиентов);

                }

                foreach (DataRow tRow in dt.Rows)
                {
                    int ss = 0;
                    for (int i = 2; i < dt.Columns.Count - 1; i++)
                    {
                        ss += tRow.Field<int>(i);
                    }
                    tRow.SetField<int>("всего", ss);
                }


                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "услуга";
                dataGridView1.Columns[1].Width = 200;

                int j = 1;
                foreach (поселки pRow in de.поселки
                   .OrderBy(n => n.порядок))
                {
                    j++;
                    dataGridView1.Columns[j].HeaderText = pRow.наимен.Trim();
                    dataGridView1.Columns[j].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns[j].DefaultCellStyle.Format = "0;#;#";
                    dataGridView1.Columns[j].Width = 150;

                }

                dataGridView1.Columns[j + 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[j + 1].DefaultCellStyle.Format = "0;#;#";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
