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
    public partial class простои1клиента : Form
    {
        public простои1клиента()
        {
            InitializeComponent();
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
        }
        domofon40.domofon14Entities de = new domofon14Entities();
    //    List<простои> простоиЛист = new List<простои>();
        BindingList<простои> простоиЛист = new BindingList<простои>();
        private void простои1клиента_Load(object sender, EventArgs e)
        {
          //  de.сотрудники.Load();
            de.услуги.Load();
            de.простои
                .Where(n => n.клиент == клКлиент.клиент)
                .OrderBy(n => n.дата_с)
                .Load();

            try
            {
                простоиЛист = de.простои.Local.ToBindingList();
                bindingSource1.DataSource = простоиЛист;
            }
            catch
            {
                MessageBox.Show("Сбой загрузки");
            }
            клСетка.задать_ширину(dataGridView1);
            bindingSource1.ListChanged += bindingSource1_ListChanged;
            FormClosing += простои1клиента_FormClosing;
            dataGridView1.CellMouseClick += dataGridView1_CellMouseClick;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
         //   dataGridView1.CellValidating += DataGridView1_CellValidating;
        }

        private void DataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] == примColumn)
            {
                if (e.FormattedValue == null)
                {

                    //if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                    //{
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                    //}
                }
            }
            
        }

        void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] == примColumn)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";  // работает
                }

            }

        }

    

        void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                простои tRow = bindingSource1.Current as простои;
          
                if (dataGridView1.Columns[e.ColumnIndex] == услугиColumn)
                {
                    клУслуга.услуга = tRow.услуга;
                    клУслуга.выбран = false;
                    выбор_услуги Выборуслуги = new выбор_услуги();
                    Выборуслуги.ShowDialog();
                    if (клУслуга.выбран)
                    {
                        tRow.услуга = клУслуга.услуга;
                        if (de.Entry(tRow).State == EntityState.Unchanged)
                        {
                            de.Entry(tRow).State = EntityState.Modified;
                        }
                        dataGridView1.Refresh();
                        label1.Visible = true;
                    }

                }
                if (dataGridView1.Columns[e.ColumnIndex] == датаColumn)
                {

                    клКалендарь.дата = tRow.дата_с;
                    клКалендарь.выбран = false;
                    календарь выборДаты = new календарь();
                    выборДаты.button3.Visible = false;
                    выборДаты.ShowDialog();
                    if (клКалендарь.выбран)
                    {
                        tRow.дата_с = клКалендарь.дата.Value;
                        label1.Visible = true;
                    }

                }
                if (dataGridView1.Columns[e.ColumnIndex] == дата_поColumn)
                {

                    клКалендарь.дата = tRow.дата_по;
                    клКалендарь.выбран = false;
                    календарь выборДаты = new календарь();
//                    выборДаты.button3.Visible = false;
                    выборДаты.ShowDialog();
                    if (клКалендарь.выбран)
                    {
                        if (клКалендарь.isNull)
                        {
                            tRow.дата_по = null;
                        }
                        else
                        {
                            tRow.дата_по = клКалендарь.дата.Value;
                        }
                        label1.Visible = true;
                    }

                }
            }
        }

        void простои1клиента_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (label1.Visible)
            {
                try
                {
                    de.SaveChanges();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Сбой записи "+ex.Message);
                }
            }
        }

        void bindingSource1_ListChanged(object sender, ListChangedEventArgs e)
        {
            label1.Visible = true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            клУслуга.выбран = false;
            выбор_услуги ВыборУслуги = new выбор_услуги();
            ВыборУслуги.ShowDialog();
            if (клУслуга.выбран)
            {

                    простои NewRow = new простои();
                    NewRow.дата_с = DateTime.Today;
                    NewRow.клиент = клКлиент.клиент;
                    NewRow.услуга = клУслуга.услуга;
                    NewRow.дата_по = null;
                    NewRow.наимен = "";
                    NewRow.простой = Guid.NewGuid();
                      
                    int строка = bindingSource1.Add(NewRow);
                    bindingSource1.Position = строка;

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
                простои tRow = bindingSource1.Current as простои;
                bindingSource1.RemoveCurrent();
              
            }
        }

    }
}
