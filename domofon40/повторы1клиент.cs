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
    public partial class повторы1клиент : Form
    {
        public повторы1клиент()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        BindingList<повторы> повторыБинд = new BindingList<повторы>();
        private void повторы1клиент_Load(object sender, EventArgs e)
        {
            try
            {
                de.сотрудники.Load();
                de.услуги.Load();
                de.повторы
                    .Where(n => n.клиент == клКлиент.клиент)
                    .OrderBy(n => n.дата_с)
                    .Load();


                повторыБинд = de.повторы.Local.ToBindingList();
                bindingSource1.DataSource = повторыБинд;
                bindingSource1.Sort = "дата_с";
                клСетка.задать_ширину(dataGridView1);
                bindingSource1.MoveLast();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Сбой загрузки {ex.Message}");
            }

            bindingSource1.ListChanged += bindingSource1_ListChanged;
            FormClosing += повторы1клиента_FormClosing;
            dataGridView1.CellMouseClick += dataGridView1_CellMouseClick;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
          //  dataGridView1.RowHeaderMouseClick += dataGridView1_RowHeaderMouseClick;
   //         dataGridView1.ColumnHeaderMouseClick += dataGridView1_ColumnHeaderMouseClick;
        }

        //void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    if (dataGridView1.Columns[e.ColumnIndex] == услугиColumn)
        //    {
        //        bindingSource1.Sort = "услуга";
        //    //    dataGridView1.Refresh();

        //    }
        //    if (dataGridView1.Columns[e.ColumnIndex] == мастерColumn)
        //    {
        //        bindingSource1.Sort = "мастер";
        //      //  dataGridView1.Refresh();

        //    }
        //}



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

        void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                повторы tRow = bindingSource1.Current as повторы;
                if (dataGridView1.Columns[e.ColumnIndex] == мастерColumn)
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
                        dataGridView1.Refresh();
                        label1.Visible = true;
                    }

                }
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
                        //       de.Entry(tRow).State = EntityState.Modified;
                        label1.Visible = true;
                    }

                }
            }
        }

        void повторы1клиента_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (label1.Visible)
            {
                try
                {
                    de.SaveChanges();
                }
                catch( Exception ex)
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
                клМастер.выбран = false;
                выбор_бригады выборМастера = new выбор_бригады();
                выборМастера.ShowDialog();
                if (клМастер.выбран)
                {

                    повторы NewRow = new повторы();
                    NewRow.дата_с = DateTime.Today;
                    NewRow.клиент = клКлиент.клиент;
                    NewRow.мастер = клМастер.мастер;
                    NewRow.услуга = клУслуга.услуга;
                    NewRow.прим = "";
                    NewRow.подключение = Guid.NewGuid();
                    int строка = bindingSource1.Add(NewRow);
                    bindingSource1.Position = строка;
                //    de.Entry(NewRow).State = EntityState.Added;

                    //             de.повторы.Add(NewRow);

            //        try
            //        {
            ////            de.SaveChanges();
            //            int строка = bindingSource1.Add(NewRow);
            //            bindingSource1.Position = строка;

            //        }
            //        catch
            //        {
            //            MessageBox.Show("Сбой записи");
            //        }

                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
               // повторы tRow = bindingSource1.Current as повторы;
                //de.Entry(tRow).State = EntityState.Deleted;
               bindingSource1.RemoveCurrent();

            //    de.повторы.Remove(tRow);
                //try
                //{
                //    de.SaveChanges();
                //    bindingSource1.RemoveCurrent();
                //}
                //catch
                //{
                //    MessageBox.Show("Сбой записи");
                //}
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            if (bindingSource1.Count > 0)
            {
                повторы tRow = bindingSource1.Current as повторы;
           //     de.повторы.Remove(tRow);
                de.Entry(tRow).State = EntityState.Deleted;
         
                try
                {
                    de.SaveChanges();
                    bindingSource1.RemoveCurrent();
                }
                catch
                {
                    MessageBox.Show("Сбой записи");
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            bool x = true;
            bool y = true;
            MessageBox.Show((x ^ y).ToString());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            клУслуга.выбран = false;
            выбор_услуги ВыборУслуги = new выбор_услуги();
            ВыборУслуги.ShowDialog();
            if (клУслуга.выбран)
            {
                клМастер.выбран = false;
                выбор_мастера выборМастера = new выбор_мастера();
                выборМастера.ShowDialog();
                if (клМастер.выбран)
                {

                    повторы NewRow = new повторы();
                    NewRow.дата_с = DateTime.Today;
                    NewRow.клиент = клКлиент.клиент;
                    NewRow.мастер = клМастер.мастер;
                    NewRow.услуга = клУслуга.услуга;
                    NewRow.прим = "";
                    NewRow.подключение = Guid.NewGuid();
         //           de.повторы.Add(NewRow);

                    try
                    {
                        de.Entry(NewRow).State = EntityState.Added;
                        int строка = bindingSource1.Add(NewRow);
                        bindingSource1.Position = строка;
                    //    de.SaveChanges();

                    }
                    catch
                    {
                        MessageBox.Show("Сбой записи");
                    }

                }
            }
        }

    }
}
