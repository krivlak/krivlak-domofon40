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
    public partial class список_видов_оплат : Form
    {
        public список_видов_оплат()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        private void список_видов_оплат_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                de.виды_оплат.OrderBy(n => n.порядок).Load();

                bindingSource1.DataSource = de.виды_оплат.Local.ToBindingList();
                bindingSource1.Sort = "порядок";
            }
            catch(Exception ex)
            {
                MessageBox.Show("Сбой загрузки " + ex.Message);
            }
            bindingSource1.ListChanged += bindingSource1_ListChanged;
            FormClosing += список_видов_FormClosing;
            вид_услугиDataGridView.CellValidating += вид_услугиDataGridView_CellValidating;
            наименColumn.DefaultCellStyle.NullValue = "null";
            наименColumn.DefaultCellStyle.DataSourceNullValue = "";
            Cursor = Cursors.Default;
        }

        void вид_услугиDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (вид_услугиDataGridView.Columns[e.ColumnIndex] == наименColumn)
            {
                if (e.FormattedValue == null || e.FormattedValue.ToString() == String.Empty)
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
                catch(Exception ex)
                {
                    MessageBox.Show("Сбой записи.."+ex.Message);
                }
            }
        }

        void bindingSource1_ListChanged(object sender, ListChangedEventArgs e)
        {

            label1.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            виды_оплат oldRow = bindingSource1.Current as виды_оплат;
         //   int oldPor = oldRow.порядок;
            if (bindingSource1.Position > 0)
            {
                bindingSource1.MovePrevious();

                виды_оплат lastRow = bindingSource1.Current as виды_оплат;
                //int lastPor = lastRow.порядок;
                //oldRow.порядок = lastPor;
                //lastRow.порядок = oldPor;
                (oldRow.порядок, lastRow.порядок) = (lastRow.порядок, oldRow.порядок);
                // виды_оплатЛист.Sort((a, b) => a.порядок.CompareTo(b.порядок));
                bindingSource1.Sort = "порядок";
                вид_услугиDataGridView.Refresh();
                //    изменено = true;
                label1.Visible = true;
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            виды_оплат oldRow = bindingSource1.Current as виды_оплат;

        //    int oldPor = oldRow.порядок;
            if (bindingSource1.Position < bindingSource1.Count - 1)
            {
                bindingSource1.MoveNext();
                виды_оплат lastRow = bindingSource1.Current as виды_оплат;
                //int lastPor = lastRow.порядок;
                //oldRow.порядок = lastPor;
                //lastRow.порядок = oldPor;
                (oldRow.порядок, lastRow.порядок) = (lastRow.порядок, oldRow.порядок);
                //        виды_оплатЛист.Sort((a, b) => a.порядок.CompareTo(b.порядок));
                bindingSource1.Sort = "порядок";
                вид_услугиDataGridView.Refresh();
                //     виды_оплатDataGridView.Refresh();
                //       изменено = true;
                label1.Visible = true;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int maxPor = 0;
            if (de.виды_оплат.Local.Any())
            {
                maxPor = de.виды_оплат.Local.Max(n => n.порядок);
            }

            виды_оплат NewRow = new виды_оплат();
            NewRow.вид_оплаты = Guid.NewGuid();
            NewRow.порядок = maxPor + 1;
            NewRow.наимен = "Новый вид";
            bindingSource1.Add(NewRow);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
                виды_оплат uRow = bindingSource1.Current as виды_оплат;
                if (uRow.оплат == 0)
                {
                    bindingSource1.RemoveCurrent();
                }
                else
                {
                    MessageBox.Show("Предварительно удалите оплаты этого вида ...");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
