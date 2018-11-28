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
    public partial class список_поселков : Form
    {
        public список_поселков()
        {
            InitializeComponent();
            Height = Screen.PrimaryScreen.WorkingArea.Height;
        }
  
        domofon40.domofon14Entities de = new domofon14Entities();
        BindingList<поселки> поселкиБинд = new BindingList<поселки>(); 
        private void список_поселков_Load(object sender, EventArgs e)
        {
         
    

            try
            {

            de.улицы.Load();
            de.поселки
                .OrderBy(n => n.порядок)
                .Load();
             
                поселкиБинд = de.поселки
                    .Local
                  .ToBindingList();
                поселкиBindingSource.DataSource = поселкиБинд;
                поселкиBindingSource.Sort = "порядок";
            }
            catch(Exception ex)
            {
                MessageBox.Show("Сбой загрузки "+ex.Message);
            }
            наименColumn.DefaultCellStyle.NullValue = "неизвесно";
            наименColumn.DefaultCellStyle.DataSourceNullValue = "";
            поселкиBindingSource.ListChanged += поселкиBindingSource_ListChanged;
            FormClosing += список_поселков_FormClosing;
            поселкиDataGridView.CellValidating += поселкиDataGridView_CellValidating;
      //      поселкиDataGridView.CellValueChanged += (o, s) => { Console.WriteLine("Столбец  {0}", s.ColumnIndex); };
        }

        void поселкиDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (поселкиDataGridView.Columns[e.ColumnIndex] == наименColumn)
            {
                if (e.FormattedValue == null || e.FormattedValue.ToString().Trim() == string.Empty)
                {
                    MessageBox.Show("Наименование не может быть пустым ...");
                    e.Cancel = true;
                }
            }
        }

        void список_поселков_FormClosing(object sender, FormClosingEventArgs e)
        {
            поселкиDataGridView.EndEdit();
            поселкиBindingSource.EndEdit();

            if (label1.Visible)
            {
                try
                {
                    de.SaveChanges();
                }
                catch(Exception ex )
                {
                    MessageBox.Show($"Сбой записи...{ex.Message}");
                }


            }
        }

        void поселкиBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            label1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int maxPor = 0;
            if (de.поселки.Local.Any())
            {
                maxPor = de.поселки.Local.Max(n => n.порядок);
            }
            поселки NewRow = new поселки();
            Guid NewKod = Guid.NewGuid();
            NewRow.поселок = NewKod;
            NewRow.наимен = "Новый поселок";
            NewRow.порядок = maxPor + 1;

        //    de.поселки.Add(NewRow);
            int строка = поселкиBindingSource.Add(NewRow);
            поселкиBindingSource.Position = строка;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (поселкиBindingSource.Count > 0)
            {
                поселки oldRow = поселкиBindingSource.Current as поселки;
                //int oldPor = oldRow.порядок;
                if (поселкиBindingSource.Position > 0)
                {
                    поселкиBindingSource.MovePrevious();

                    поселки lastRow = поселкиBindingSource.Current as поселки;
                    //int lastPor = lastRow.порядок;
                    //oldRow.порядок = lastPor;
                    //lastRow.порядок = oldPor;
                    (oldRow.порядок, lastRow.порядок) = (lastRow.порядок, oldRow.порядок);
                    // поселкиЛист.Sort((a, b) => a.порядок.CompareTo(b.порядок));
                    поселкиBindingSource.Sort = "порядок";
                    label1.Visible = true;
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (поселкиBindingSource.Count > 0)
            {
                поселки oldRow = поселкиBindingSource.Current as поселки;

                // int oldPor = oldRow.порядок;
                if (поселкиBindingSource.Position < поселкиBindingSource.Count - 1)
                {
                    поселкиBindingSource.MoveNext();
                    поселки lastRow = поселкиBindingSource.Current as поселки;
                    //int lastPor = lastRow.порядок;
                    //oldRow.порядок = lastPor;
                    //lastRow.порядок = oldPor;
                    (oldRow.порядок, lastRow.порядок) = (lastRow.порядок, oldRow.порядок);
                    //        поселкиЛист.Sort((a, b) => a.порядок.CompareTo(b.порядок));
                    поселкиBindingSource.Sort = "порядок";
                    поселкиDataGridView.Refresh();
                    label1.Visible = true;

                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (поселкиBindingSource.Count > 0)
            {
                поселки uRow = поселкиBindingSource.Current as поселки;
                if (uRow.улицы.Count==0 )
                {
                    поселкиBindingSource.Remove(uRow);
               //     поселкиBindingSource.MoveLast();
                }
                else
                {
                    MessageBox.Show("Предварительно удалите улицы ...");
                }
            }
        }

     

    
    }
}
