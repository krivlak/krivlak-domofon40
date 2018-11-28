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
    public partial class список_услуг : Form
    {
        public список_услуг()
        {
            InitializeComponent();
        }
     //   bool изменено = false;
        domofon40.domofon14Entities de = new domofon14Entities();
     //   List<услуги> услугиЛист = new List<услуги>();
        BindingList<услуги> услугиBinding = new BindingList<услуги>();
        private void список_услуг_Load(object sender, EventArgs e)
        {
            de.клиенты.Load();
            de.виды_услуг.Load();
            de.услуги
                 .Where(n => n.вид_услуги == клВид_услуги.вид_услуги)
                .OrderBy(n => n.порядок)
                .Load();

           
            услугиBinding = de.услуги
                .Local
                .ToBindingList();

           bindingSource1.DataSource = услугиBinding;
           bindingSource1.Sort = "порядок";
            //наименColumn.DefaultCellStyle.NullValue = "null";
            //наименColumn.DefaultCellStyle.DataSourceNullValue = "";
            //обозначениеColumn.DefaultCellStyle.NullValue = "null";
            //обозначениеColumn.DefaultCellStyle.DataSourceNullValue = "";

            dataGridView1.CellValidating += DataGridView1_CellValidating;
            bindingSource1.ListChanged += bindingSource1_ListChanged;
            FormClosing += список_услуг_FormClosing;
           
        }

        private void DataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] == наименColumn)
            {
                if (e.FormattedValue == null || e.FormattedValue.ToString() == String.Empty)
                {
                    MessageBox.Show("Наименование не может быть пустым");
                    e.Cancel = true;
                }
            }
            if (dataGridView1.Columns[e.ColumnIndex] == обозначениеColumn)
            {
                if (e.FormattedValue == null || e.FormattedValue.ToString() == String.Empty)
                {
                    MessageBox.Show("Краткое обозначение не может быть пустым");
                    e.Cancel = true;
                }
            }
        }

        void список_услуг_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (label1.Visible)
            {
                try
                {
                    de.SaveChanges();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Сбой записи..."+ex.Message);
                }
            }
        }

        void bindingSource1_ListChanged(object sender, ListChangedEventArgs e)
        {
            label1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            клВид_услуги.выбран = false;
            выбор_вида_услуги выборВида = new выбор_вида_услуги();
            //выборВида.ShowDialog();
            //if (клВид_услуги.выбран || выборВида.DialogResult== DialogResult.OK)
            //{
                int maxPor = 0;
                if (de.услуги.Local.Any())
                {
                    maxPor = de.услуги.Local.Max(n => n.порядок);
                }
                услуги NewRow = new услуги();
                NewRow.услуга = Guid.NewGuid();
                NewRow.порядок = maxPor+1;
                NewRow.вид_услуги = клВид_услуги.вид_услуги;
                NewRow.наимен = "Новая услуга";
                NewRow.обозначение = "новая";
                int строка = bindingSource1.Add(NewRow);
                bindingSource1.Position = строка;

            //}

        }

        //private void button7_Click(object sender, EventArgs e)
        //{
        //    if (bindingSource1.Count==0)
        //    {
        //        return;
        //    }

        //    услуги tRow = bindingSource1.Current as услуги;

        //    клУслуга.наимен=tRow.наимен;
        //    клУслуга.обозначение=tRow.обозначение;
        //    клУслуга.услуга=tRow.услуга;

        //    редактировать1услугу Редактор = new редактировать1услугу();

        //    DialogResult xy = Редактор.ShowDialog(this);
        //    if (xy == DialogResult.OK)
        //    {

        //        tRow.наимен = клУслуга.наимен;
        //        tRow.обозначение = клУслуга.обозначение;
               
        //        dataGridView1.Refresh();
        //        label1.Visible = true;
        //    }
        //}

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            
            if (bindingSource1.Count==0)
            {
                Cursor = Cursors.Default;
                return;
            }
            
            услуги tRow = bindingSource1.Current as услуги;
            if ( tRow.клиенты.Count>0
                || tRow.льготы.Count>0
                || tRow.оплачено.Count>0
                || tRow.отключения.Count>0
                || tRow.повторы.Count>0
                || tRow.подключения.Count>0
                || tRow.раб_дней.Count>0
                || tRow.цены.Count>0
            )
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Услугу невозможно удалить...");
                return;
            }

      //      de.услуги.Remove(tRow);
            bindingSource1.RemoveCurrent();
            bindingSource1.MoveLast();
            Cursor = Cursors.Default;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            услуги oldRow = bindingSource1.Current as услуги;
            Guid видУслуги = oldRow.вид_услуги;
          //  int oldPor = oldRow.порядок;
   
            if (bindingSource1.Position > 0)
            {
                bindingSource1.MovePrevious();

                услуги lastRow = bindingSource1.Current as услуги;
                if (lastRow.вид_услуги != видУслуги)
                {
                    bindingSource1.MoveNext();

                }
                else
                {
                    //int lastPor = lastRow.порядок;
                    //oldRow.порядок = lastPor;
                    //lastRow.порядок = oldPor;
                    (oldRow.порядок, lastRow.порядок) = (lastRow.порядок, oldRow.порядок);


                    bindingSource1.Sort = "порядок";
                   dataGridView1.Refresh();
                    label1.Visible = true;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            услуги oldRow = bindingSource1.Current as услуги;
            Guid видУслуги = oldRow.вид_услуги;
           // int oldPor = oldRow.порядок;
            if (bindingSource1.Position < bindingSource1.Count - 1)
            {
                bindingSource1.MoveNext();
   
                услуги lastRow = bindingSource1.Current as услуги;
                if (lastRow.вид_услуги == видУслуги)
                {
                    //int lastPor = lastRow.порядок;
                    //oldRow.порядок = lastPor;
                    //lastRow.порядок = oldPor;
                    (oldRow.порядок, lastRow.порядок) = (lastRow.порядок, oldRow.порядок);
                    bindingSource1.Sort = "порядок";
                    dataGridView1.Refresh();
                    label1.Visible = true;
                }
                else
                {
                    bindingSource1.MovePrevious();
                }

            }
        }

      
    }
}
