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
    public partial class подключений_поселок : Form
    {
        public подключений_поселок()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        int текГод = DateTime.Today.Year;
        int текМесяц = DateTime.Today.Month;
        List<temp> tempList = new List<temp>();
        private void подключений_поселок_Load(object sender, EventArgs e)
        {
            try
            {

                foreach (поселки pRow in de.поселки.OrderBy(n => n.порядок))
                {
                    foreach (услуги uRow in de.услуги
                        .OrderBy(n => n.виды_услуг.порядок)
                        .ThenBy(n => n.порядок))
                    {
                        temp newTemp = new temp();
                        newTemp.услуга = uRow.услуга;
                        newTemp.наимен_услуги = uRow.наимен;
                        newTemp.поселок = pRow.поселок;
                        newTemp.наимен_поселка = pRow.наимен;
                        newTemp.клиентов = uRow.клиенты.Count(n => n.дома.улицы.поселок == pRow.поселок);
                        tempList.Add(newTemp);
                    }
                }
                //     dataGridView1.DataSource = tempList;


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
                    .ThenBy(n => n.порядок))
                {
                    DataRow NewRow = dt.NewRow();
                    NewRow.SetField<string>("услуга", yRow.услуга.ToString());
                    NewRow.SetField<string>("наимен", yRow.наимен);
                    dt.Rows.Add(NewRow);
                }


                foreach (var uRow in tempList)
                {

                    DataRow iRow = dt.Select("услуга='" + uRow.услуга + "'").First();
                    iRow.SetField<int>(uRow.поселок.ToString(), uRow.клиентов);

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
                MessageBox.Show($"Сбой загрузки {ex.Message}");
            }

        }
        class temp
        {
            public Guid услуга { get; set; }
            public string наимен_услуги { get; set; }
            public Guid поселок { get; set; }
            public string наимен_поселка { get; set; }
            public int клиентов { get; set; }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
