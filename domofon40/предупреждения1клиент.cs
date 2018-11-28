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
    public partial class предупреждения1клиент : Form
    {
        public предупреждения1клиент()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        BindingList<предупреждения> tempList = new BindingList<предупреждения>();
        private void предупреждения1клиент_Load(object sender, EventArgs e)
        {
            de.услуги.Load();

            de.предупреждения
                .Where(n => n.клиент == клКлиент.клиент)
                .OrderBy(n => n.дата)
                .Load();
            tempList = de.предупреждения.Local.ToBindingList();
            bindingSource1.DataSource = tempList;
            bindingSource1.Sort="дата";
            dataGridView1.Focus();
            bindingSource1.ListChanged += bindingSource1_ListChanged;
            FormClosing += предупреждения1клиент_FormClosing;
            dataGridView1.CellMouseClick += dataGridView1_CellMouseClick;

        }

        void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                предупреждения uRow = bindingSource1.Current as предупреждения;

                if (dataGridView1.Columns[e.ColumnIndex] == датаColumn)
                {
                    клКалендарь.выбран = false;
                    клКалендарь.дата = uRow.дата;
                    календарь выборДаты = new календарь();
                    выборДаты.button3.Visible = false;
                    выборДаты.ShowDialog();
                    if (клКалендарь.выбран)
                    {
                        uRow.дата = клКалендарь.дата.Value;
                        label1.Visible = true;
                    }
                }
                if (dataGridView1.Columns[e.ColumnIndex] == наименColumn)
                {
                    клУслуга.выбран = false;
                    клУслуга.услуга = uRow.услуга;
                    выбор_услуги выборУслуги = new выбор_услуги();
                    выборУслуги.ShowDialog();
                    if (клУслуга.выбран)
                    {
                        uRow.услуга = клУслуга.услуга;
                        label1.Visible = true;
                        if (de.Entry(uRow).State == EntityState.Unchanged)
                        {
                            de.Entry(uRow).State = EntityState.Modified;
                        }
                    }
                }

            }
            dataGridView1.Focus();

        }

        void предупреждения1клиент_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (label1.Visible)
            {
                try
                {
                    de.SaveChanges();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Сбой записи " + ex.Message);
                }
            }
        }

        void bindingSource1_ListChanged(object sender, ListChangedEventArgs e)
        {
            label1.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            клУслуга.выбран = false;
            выбор_услуги выборУслуги = new выбор_услуги();
            выборУслуги.ShowDialog();
            if (клУслуга.выбран)
            {
                предупреждения newRow = new предупреждения();
                newRow.дата = DateTime.Today;
                newRow.клиент = клКлиент.клиент;
                newRow.услуга = клУслуга.услуга;
                newRow.предупреждение = Guid.NewGuid();
                int строка = bindingSource1.Add(newRow);
                bindingSource1.Position = строка;
                dataGridView1.Focus();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count>0)
            {
                bindingSource1.RemoveCurrent();
                bindingSource1.MoveLast();
                dataGridView1.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
