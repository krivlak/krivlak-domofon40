using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Entity;

namespace domofon40
{
    public partial class звонки1клиенту : Form
    {
        public звонки1клиенту()
        {
            InitializeComponent();
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        private void звонки1клиенту_Load(object sender, EventArgs e)
        {
            de.звонки
                .Where(n => n.клиент == клКлиент.клиент)
                .OrderBy(n => n.дата)
                .Load();
            bindingSource1.DataSource = de.звонки.Local.ToBindingList();
            bindingSource1.Sort = "дата";
            bindingSource1.ListChanged += bindingSource1_ListChanged;
            FormClosing += звонки1клиенту_FormClosing;
            dataGridView1.CellMouseClick += dataGridView1_CellMouseClick;
            //    dataGridView1.CellValidating += dataGridView1_CellValidating;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
        }

        void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                звонки tRow = bindingSource1.Current as звонки;


                if (dataGridView1.Columns[e.ColumnIndex] == датаColumn)
                {

                    клКалендарь.дата = tRow.дата;
                    клКалендарь.выбран = false;
                    календарь выборДаты = new календарь();
                    выборДаты.button3.Visible = false;
                    выборДаты.ShowDialog();
                    if (клКалендарь.выбран)
                    {
                        tRow.дата = клКалендарь.дата.Value;
                        //       de.Entry(tRow).State = EntityState.Modified;
                        label1.Visible = true;
                        dataGridView1.Refresh();
                    }

                }
            }
        }
        void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] == примColumn)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                }

            }

        }
        void звонки1клиенту_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (label1.Visible)
            {
                try
                {
                    de.SaveChanges();
                }
                catch(Exception ex )
                {
                  
                    MessageBox.Show(ex.Message);
                }
            }
        }

        void bindingSource1_ListChanged(object sender, ListChangedEventArgs e)
        {
            label1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //звонки newRow = new звонки();
            //newRow.дата = DateTime.Now;
            //newRow.звонок = Guid.NewGuid();
            //newRow.клиент = клКлиент.клиент;
            //newRow.прим = "";

            звонки NewRow = new звонки()
            {
                дата = DateTime.Now,
                клиент = клКлиент.клиент,
                прим = "",
                звонок = Guid.NewGuid()
            };

            int строка = bindingSource1.Add(NewRow);
            bindingSource1.Position = строка;
            dataGridView1.Focus();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count>0)
            {
                bindingSource1.RemoveCurrent();
                bindingSource1.MoveLast();
            }
        }
    }
}
