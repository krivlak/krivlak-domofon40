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
    public partial class отключения1клиента : Form
    {
        public отключения1клиента()
        {
            InitializeComponent();
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Top = 0;
        }
        domofon40.domofon14Entities de = new domofon14Entities();
  //      List<отключения> отключенияЛист = new List<отключения>();
        BindingList<отключения> отключенияЛист = new BindingList<отключения>();

        private void отключения1клиента_Load(object sender, EventArgs e)
        {

            try
            {
                de.сотрудники.Load();
                de.услуги.Load();
                de.отключения
                    .Where(n => n.клиент == клКлиент.клиент)
                    .OrderBy(n => n.дата_с)
                    .Load();


                отключенияЛист = de.отключения.Local.ToBindingList();
                bindingSource1.DataSource = отключенияЛист;
                bindingSource1.Sort = "дата_с";
                bindingSource1.MoveLast();
                клСетка.задать_ширину(dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сбой загрузки   {ex.Message}");
            }


            bindingSource1.ListChanged += bindingSource1_ListChanged;
            FormClosing += отключения1клиента_FormClosing;
            dataGridView1.CellMouseClick += dataGridView1_CellMouseClick;
            //    dataGridView1.CellValidating += dataGridView1_CellValidating;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
        }

        void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] == примColumn)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value==null)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                }
            
            }
            
        }

       

        void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button== System.Windows.Forms.MouseButtons.Right)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                отключения tRow = bindingSource1.Current as отключения;
                if (dataGridView1.Columns[e.ColumnIndex]== мастерColumn)
                {
                    клМастер.мастер = tRow.мастер;
                    клМастер.выбран = false;
                    выбор_мастера ВыборМастера = new выбор_мастера();
                    ВыборМастера.ShowDialog();
                    if (клМастер.выбран)
                    {
                        сотрудники рабочий = de.сотрудники.Single(n => n.сотрудник == клМастер.мастер);
                        tRow.мастер = клМастер.мастер;
                        tRow.сотрудники = рабочий;
                        //if (de.Entry(tRow).State == EntityState.Unchanged)
                        //{
                        //    de.Entry(tRow).State = EntityState.Modified;
                        //}
                       
                     //   de.отключения.Include("сотрудники");
                        dataGridView1.Refresh();
                        label1.Visible = true;
                    }

                }
                if (dataGridView1.Columns[e.ColumnIndex] ==  услугиColumn)
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
                 //       de.Entry(tRow).State = EntityState.Modified;
                        label1.Visible = true;
                    }

                }
            }
        }

        void отключения1клиента_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (label1.Visible)
            {
                try
                {
                    de.SaveChanges();
                }
                catch( Exception ex)
                {
                    MessageBox.Show("Сбой записи"+ ex.Message);
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
                клМастер.выбран = false;
                выбор_бригады выборМастера = new выбор_бригады();
                выборМастера.ShowDialog();
                if (клМастер.выбран)
                {

                    отключения NewRow = new отключения();
                    NewRow.дата_с = DateTime.Today;
                    NewRow.клиент = клКлиент.клиент;
                    NewRow.мастер = клМастер.мастер;
                    NewRow.услуга = клУслуга.услуга;
                    NewRow.дата_по = null;
                    NewRow.прим = "";
                    NewRow.отключение = Guid.NewGuid();

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
            dataGridView1.Select();
        }

    }
}
