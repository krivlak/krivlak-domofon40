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
    public partial class все_звонки : Form
    {
        public все_звонки()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        private void все_звонки_Load(object sender, EventArgs e)
        {
            de.клиенты.Load();
            de.звонки
                .OrderBy(n => n.дата)
                .Load();

            try
            {
                bindingSource1.DataSource = de.звонки.Local.ToBindingList();
                bindingSource1.Sort = "дата";
                bindingSource1.MoveLast();
                клСетка.задать_ширину(dataGridView1);
            }
            catch
            {
                MessageBox.Show("Сбой загрузки");
            }

            bindingSource1.ListChanged += bindingSource1_ListChanged;
            FormClosing += звонки1клиента_FormClosing;
            dataGridView1.CellMouseClick += dataGridView1_CellMouseClick;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
        }


        void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] == примColumn || dataGridView1.Columns[e.ColumnIndex] == телефонColumn)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                }

            }

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

        void звонки1клиента_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (label1.Visible)
            {
                try
                {
                    de.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Сбой записи" + ex.Message);
                }
            }
        }

        void bindingSource1_ListChanged(object sender, ListChangedEventArgs e)
        {
            label1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            клКлиент.выбран = false;
            выбор_клиента выборКлиента = new выбор_клиента();
            выборКлиента.ShowDialog();
            if (клКлиент.выбран)
            {
                звонки NewRow = new звонки();
                NewRow.дата = DateTime.Now;
                NewRow.клиент = клКлиент.клиент;

                NewRow.прим = "";
                NewRow.звонок = Guid.NewGuid();


                int строка = bindingSource1.Add(NewRow);
                bindingSource1.Position = строка;
            }
            Cursor = Cursors.Default;
            dataGridView1.Focus();
        }

    


        private void button2_Click(object sender, EventArgs e)
        {
             if (bindingSource1.Count > 0)
            {
                bindingSource1.RemoveCurrent();

            }
            dataGridView1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}