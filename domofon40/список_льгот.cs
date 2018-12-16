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
    public partial class список_льгот : Form
    {
        public список_льгот()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
   //     BindingList<льготы> льготыЛист = new BindingList<льготы>();
        private void список_льгот_Load(object sender, EventArgs e)
        {
            try
            {
                de.клиенты.Load();
                de.услуги.Load();
                de.льготы
                       .OrderBy(n => n.дата_с)
                       .Load();
             
                bindingSource1.DataSource = de.льготы.Local.ToBindingList();
                bindingSource1.Sort = "дата_с";
                bindingSource1.MoveLast();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Сбой загрузки {ex.Message} ");
            }

           bindingSource1.ListChanged += bindingSource1_ListChanged;
            FormClosing += льготы1клиент_FormClosing;
   
            dataGridView1.CellMouseClick += dataGridView1_CellMouseClick;
         
        }
       

        void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                льготы uRow = bindingSource1.Current as льготы;
                if (dataGridView1.Columns[e.ColumnIndex] == дата_сColumn)
                {
                    клКалендарь.выбран = false;
                    клКалендарь.дата = uRow.дата_с;
                    календарь выборДаты = new календарь();
                    выборДаты.button3.Visible = false;
                    выборДаты.ShowDialog();
                    if (клКалендарь.выбран)
                    {
                        uRow.дата_с = клКалендарь.дата.Value;
                        label1.Visible = true;
                    }

                }

                if (dataGridView1.Columns[e.ColumnIndex] == дата_поColumn)
                {

                    клКалендарь.дата = uRow.дата_по;
                    клКалендарь.выбран = false;
                    календарь выборДаты = new календарь();
                    //                    выборДаты.button3.Visible = false;
                    выборДаты.ShowDialog();
                    if (клКалендарь.выбран)
                    {
                        if (клКалендарь.isNull)
                        {
                            uRow.дата_по = null;
                        }
                        else
                        {
                            uRow.дата_по = клКалендарь.дата.Value;
                        }
                        label1.Visible = true;
                    }

                }

            }
        }

        //void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        //{
        //if (dataGridView1.Columns[e.ColumnIndex] == процентColumn)
        //{
        //    if (e.FormattedValue == null)
        //    {
        //        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
        //    }
        //}
        //}

        void льготы1клиент_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (label1.Visible)
            {
                try
                {
                   int строк= de.SaveChanges();
                    //MessageBox.Show(строк.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Сбой записи..." + ex.Message);
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
            клКлиент.выбран = false;
            выбор_клиента выборКлиента = new выбор_клиента();
            выборКлиента.ShowDialog();
            if (клКлиент.выбран)
            {

                клУслуга.выбран = false;
                выбор_услуги выборУслуги = new выбор_услуги();
                выборУслуги.ShowDialog();
                if (клУслуга.выбран)
                {
                    льготы newRow = new льготы();
                    newRow.дата_по = null;
                    newRow.дата_с = DateTime.Today;
                    newRow.клиент = клКлиент.клиент;
                    newRow.льгота = Guid.NewGuid();
            //        newRow.процент = 100;
                    newRow.услуга = клУслуга.услуга;
                    int строка = bindingSource1.Add(newRow);
                    bindingSource1.Position = строка;
                }
            }
            dataGridView1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
                bindingSource1.RemoveCurrent();
                bindingSource1.MoveLast();
            }
            dataGridView1.Focus();
        }

    }
}
