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
    public partial class список_видов : Form
    {
        public список_видов()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        private void список_видов_Load(object sender, EventArgs e)
        {
            try
            {
                de.виды_услуг
                    .OrderBy(n => n.порядок).Load();

                вид_услугиBindingSource.DataSource = de.виды_услуг.Local.ToBindingList();
                вид_услугиBindingSource.Sort = "порядок";
                вид_услугиBindingSource.ListChanged += вид_услугиBindingSource_ListChanged;
                FormClosing += список_видов_FormClosing;
                вид_услугиDataGridView.CellValidating += вид_услугиDataGridView_CellValidating;
                наименColumn.DefaultCellStyle.NullValue = "null";
                наименColumn.DefaultCellStyle.DataSourceNullValue = "";
            }
            catch(Exception ex)
            {
                MessageBox.Show("Сбой загрузки "+ex.Message);
            }
        }

        void вид_услугиDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (вид_услугиDataGridView.Columns[e.ColumnIndex]==наименColumn)
            {
                if (e.FormattedValue== null || e.FormattedValue.ToString()==String.Empty)
                {
                    MessageBox.Show("Наименование не может быть пустым");
                    e.Cancel = true;
                }
            }
        }

        void список_видов_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (label1.Visible)
            {
                try
                {
                    de.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Сбой записи..");
                }
            }
        }

        void вид_услугиBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
     
            label1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int maxPor = 0;
            if (de.виды_услуг.Local.Any())
            {
                maxPor = de.виды_услуг.Local.Max(n => n.порядок);
            }

            виды_услуг NewRow = new виды_услуг();
            NewRow.вид_услуги = Guid.NewGuid();
            NewRow.порядок = maxPor + 1;
            NewRow.наимен = "Новый вид";
            вид_услугиBindingSource.Add(NewRow);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (вид_услугиBindingSource.Count>0)
            {
                виды_услуг uRow = вид_услугиBindingSource.Current as виды_услуг;
                if(uRow.услуг==0)
                {
                    вид_услугиBindingSource.RemoveCurrent();
                }
                else
                {
                    MessageBox.Show("Предварительно удалите услуги этого вида ...");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            виды_услуг oldRow = вид_услугиBindingSource.Current as виды_услуг;
         //   int oldPor = oldRow.порядок;
            if (вид_услугиBindingSource.Position > 0)
            {
                вид_услугиBindingSource.MovePrevious();

                виды_услуг lastRow = вид_услугиBindingSource.Current as виды_услуг;
                //int lastPor = lastRow.порядок;
                //oldRow.порядок = lastPor;
                //lastRow.порядок = oldPor;
                (oldRow.порядок, lastRow.порядок) = (lastRow.порядок, oldRow.порядок);
                // виды_услугЛист.Sort((a, b) => a.порядок.CompareTo(b.порядок));
                вид_услугиBindingSource.Sort = "порядок";
                вид_услугиDataGridView.Refresh();
            //    изменено = true;
                label1.Visible = true;
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            виды_услуг oldRow = вид_услугиBindingSource.Current as виды_услуг;

          //  int oldPor = oldRow.порядок;
            if (вид_услугиBindingSource.Position < вид_услугиBindingSource.Count - 1)
            {
                вид_услугиBindingSource.MoveNext();
                виды_услуг lastRow = вид_услугиBindingSource.Current as виды_услуг;
                //int lastPor = lastRow.порядок;
                //oldRow.порядок = lastPor;
                //lastRow.порядок = oldPor;
                (oldRow.порядок, lastRow.порядок) = (lastRow.порядок, oldRow.порядок);
                //        виды_услугЛист.Sort((a, b) => a.порядок.CompareTo(b.порядок));
                вид_услугиBindingSource.Sort = "порядок";
                вид_услугиDataGridView.Refresh();
           //     виды_услугDataGridView.Refresh();
         //       изменено = true;
                label1.Visible = true;

            }

        }
    }
}
