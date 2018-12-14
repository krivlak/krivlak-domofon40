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
    public partial class список_простоев : Form
    {
        public список_простоев()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        BindingList<простои> простоиЛист = new BindingList<простои>();
        private void список_простоев_Load(object sender, EventArgs e)
        {
            de.сотрудники.Load();
            de.клиенты.Load();
            de.услуги.Load();
            de.простои
                .OrderBy(n => n.дата_с)
                .ThenBy(n=>n.клиенты.квартира)
                .ThenBy(n=>n.клиенты.ввод)
                .Load();

            try
            {
                простоиЛист = de.простои.Local.ToBindingList();
                bindingSource1.DataSource = простоиЛист;
                bindingSource1.Sort = "дата_с";
                bindingSource1.MoveLast();
                клСетка.задать_ширину(dataGridView1);
            }
            catch
            {
                MessageBox.Show("Сбой загрузки");
            }

            bindingSource1.ListChanged += bindingSource1_ListChanged;
            FormClosing += простои1клиента_FormClosing;
            dataGridView1.CellMouseClick += dataGridView1_CellMouseClick;
        //    dataGridView1.DataError += dataGridView1_DataError;
            //    dataGridView1.CellValidating += dataGridView1_CellValidating;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;

        }

        //void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        //{
        //    if (dataGridView1.Columns[e.ColumnIndex]== наименColumn)
        //    {
        //        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
        //    }
        //}

        void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] == наименColumn)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                }

            }

        }

        //void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        //{
        //    if (dataGridView1.Columns[e.ColumnIndex] == примColumn)
        //    {
        //        if (e.FormattedValue == null)
        //        {
        //            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
        //        }
        //    }
        //}

        void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                простои tRow = bindingSource1.Current as простои;
                //if (dataGridView1.Columns[e.ColumnIndex] == мастерColumn)
                //{
                //    клМастер.мастер = tRow.мастер;
                //    клМастер.выбран = false;
                //    выбор_мастера ВыборМастера = new выбор_мастера();
                //    ВыборМастера.ShowDialog();
                //    if (клМастер.выбран)
                //    {
                //        tRow.мастер = клМастер.мастер;
                //        if (de.Entry(tRow).State == EntityState.Unchanged)
                //        {
                //            de.Entry(tRow).State = EntityState.Modified;
                //        }

                //        //   de.простои.Include("сотрудники");
                //        dataGridView1.Refresh();
                //        label1.Visible = true;
                //    }

                //}
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
                        dataGridView1.Refresh();
                    }

                }

                if (dataGridView1.Columns[e.ColumnIndex] == дата_поColumn)
                {

                    клКалендарь.дата = tRow.дата_по;
                    клКалендарь.выбран = false;
                    календарь выборДаты = new календарь();
                 //   выборДаты.button3.Visible = false;
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
                        //       de.Entry(tRow).State = EntityState.Modified;
                        label1.Visible = true;
                        dataGridView1.Refresh();
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


                        простои NewRow = new простои();
                        NewRow.дата_с = DateTime.Today;
                        NewRow.клиент = клКлиент.клиент;
                        //NewRow.мастер = клМастер.мастер;
                        NewRow.услуга = клУслуга.услуга;
                        NewRow.дата_по = null;
                        NewRow.наимен = "";
                        NewRow.простой = Guid.NewGuid();

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
                bindingSource1.MoveLast();

            }
            dataGridView1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            клУслуга.выбран = false;
            выбор_услуги выборУслуги = new выбор_услуги();
            выборУслуги.ShowDialog();
            if (клУслуга.выбран)
            {
                клДом.выбран = false;
                выбор_дома выборДома = new выбор_дома();
                выборДома.ShowDialog();
                if (клДом.выбран)
                {
                    клПодъезд.выбран = false;
                    выбор_подъезда выборПодъезда = new выбор_подъезда();
                    выборПодъезда.ShowDialog();
                    if (клПодъезд.выбран)
                    {
                        клПериод.выбран = false;
                        выбор_периода выборПериода = new выбор_периода();
                        выборПериода.ShowDialog();
                        if (клПериод.выбран)
                        {
                            Cursor = Cursors.WaitCursor;
                            foreach (клиенты uRow in de.клиенты.Local
                                .Where(n => n.дом == клДом.дом)
                                .Where(n => n.подъезд == клПодъезд.подъезд)
                                .OrderBy(n => n.квартира)
                                .ThenBy(n => n.ввод))
                            {
                                простои newRow = new простои();
                                newRow.наимен = "отк. подъезда";
                                newRow.дата_по = клПериод.дата_по;
                                newRow.дата_с = клПериод.дата_с;
                                newRow.клиент = uRow.клиент;
                                newRow.простой = Guid.NewGuid();
                                newRow.услуга = клУслуга.услуга;
                                int строка = bindingSource1.Add(newRow);
                                bindingSource1.Position = строка;
                            }
                            Cursor = Cursors.Default;
                        }
                        
                    }
                }
            }
            dataGridView1.Focus();

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
