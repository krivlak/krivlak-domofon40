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
    public partial class список_филиалов : Form
    {
        public список_филиалов()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        BindingList<филиалы> филиалыList = new BindingList<филиалы>();
        private void список_филиалов_Load(object sender, EventArgs e)
        {
            try
            {
                de.филиалы.OrderBy(n => n.порядок).Load();
                if(de.филиалы.Local.Count()==0)
                {
                    филиалы newRow = new филиалы();
                    newRow.филиал = Guid.NewGuid();
                    newRow.наимен = "Новый филиал";
                    newRow.адрес = "";
                    newRow.телефон = "";
                    newRow.порядок = 1;
                    de.филиалы.Local.Add(newRow);
                    label1.Visible = true;
                }

                if (de.филиалы.Local.Count>1)
                {
                    филиалы[] aRows = de.филиалы.Local.Skip(1).ToArray();
                    foreach( филиалы dRow in aRows)
                    {
                        de.филиалы.Local.Remove(dRow);
                    }
                    label1.Visible = true;
                }

                 de.филиалы
                     .OrderBy(n => n.порядок)
                     .Load();

                филиалыList = de.филиалы.Local.ToBindingList();
                bindingSource1.DataSource = филиалыList;
                
            }
            catch
            {
                MessageBox.Show("Ошибка загрузки");
            }

            bindingSource1.ListChanged += bindingSource1_ListChanged;
            FormClosing += список_филиалов_FormClosing;
            dataGridView1.CellValidating += dataGridView1_CellValidating;
            dataGridView1.CellValidated += dataGridView1_CellValidated;
        }

        void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value==null)
            {
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
            }
        }

        void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
           

            if (dataGridView1.Columns[e.ColumnIndex]==наименColumn)
            {
                if (e.FormattedValue == null || e.FormattedValue.ToString().Trim() == string.Empty)
                {
                    MessageBox.Show("Наименование не может быть пустым ...");
                    e.Cancel = true;
                }
            }
        }

        void список_филиалов_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataGridView1.EndEdit();
            bindingSource1.EndEdit();

            if (label1.Visible)
            {
                try
                {
                    de.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Сбой записи...");
                }


            }
        }

        void bindingSource1_ListChanged(object sender, ListChangedEventArgs e)
        {
            label1.Visible = true;
        }
    }
}
