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
    public partial class список_предупреждений : Form
    {
        public список_предупреждений()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        BindingList<предупреждения> предупрежденияЛист = new BindingList<предупреждения>();
        private void список_предупреждений_Load(object sender, EventArgs e)
        {
            de.сотрудники.Load();
            de.клиенты.Load();
            de.услуги.Load();
            de.предупреждения
                .OrderBy(n => n.дата)
                .Load();

            try
            {
                предупрежденияЛист = de.предупреждения.Local.ToBindingList();
                bindingSource1.DataSource = предупрежденияЛист;
                bindingSource1.Sort = "дата";
                bindingSource1.MoveLast();
            }
            catch
            {
                MessageBox.Show("Сбой загрузки");
            }

            bindingSource1.ListChanged += bindingSource1_ListChanged;
            FormClosing += предупреждения1клиента_FormClosing;
            dataGridView1.CellMouseClick += dataGridView1_CellMouseClick;
            //    dataGridView1.CellValidating += dataGridView1_CellValidating;
       //     dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;

        }

     

        void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                предупреждения tRow = bindingSource1.Current as предупреждения;
         
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

        void предупреждения1клиента_FormClosing(object sender, FormClosingEventArgs e)
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
                выбор_услуги ВыборУслуги = new выбор_услуги();
                ВыборУслуги.ShowDialog();
                if (клУслуга.выбран)
                {

                        предупреждения NewRow = new предупреждения();
                        NewRow.дата = DateTime.Today;
                        NewRow.клиент = клКлиент.клиент;
                        NewRow.услуга = клУслуга.услуга;
                       
                        NewRow.предупреждение = Guid.NewGuid();

                        int строка = bindingSource1.Add(NewRow);
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

            }
            dataGridView1.Focus();
        }

    }
}
