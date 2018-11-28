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
    public partial class список_работ : Form
    {
        public список_работ()
        {
            InitializeComponent();
        }

        bool изменено = false;
 

        domofon40.domofon14Entities de = new domofon14Entities();
        private void список_работ_Load(object sender, EventArgs e)
        {
             de.работы
                .OrderBy(n => n.порядок)
                .Load();
    
     
             bindingSource1.DataSource = de.работы.Local.ToBindingList();
            bindingSource1.Sort = "порядок";

            наименColumn.DefaultCellStyle.NullValue = "null";
            наименColumn.DefaultCellStyle.DataSourceNullValue = "";
            прейскурантColumn.DefaultCellStyle.NullValue = "null";
            прейскурантColumn.DefaultCellStyle.DataSourceNullValue = "";
            bindingSource1.ListChanged += bindingSource1_ListChanged;
            FormClosing += список_работ_FormClosing;
            dataGridView1.CellValidating += dataGridView1_CellValidating;
            dataGridView1.EditingControlShowing += dataGridView1_EditingControlShowing;
        }

        void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Control_KeyPress);
            string CellName = dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].Name;
            if (CellName == "стоимостьColumn" || CellName == "ст_материаловColumn")
            {
                e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
            }
        }

        void Control_KeyPress(object sender, KeyPressEventArgs pressE)
        {
            клKey.int_KeyPress(sender, pressE);
        }

        void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] == наименColumn)
            {
                if (e.FormattedValue == null || e.FormattedValue.ToString().Trim() == string.Empty)
                {
                    MessageBox.Show("Наименование не может быть пустым ...");
                    e.Cancel = true;
                }
            }

            if (dataGridView1.Columns[e.ColumnIndex] == прейскурантColumn)
            {
                if (e.FormattedValue == null || e.FormattedValue.ToString().Trim() == string.Empty)
                {
                    dataGridView1.Rows[e.RowIndex].Cells["прейскурантColumn"].Value = "";
                }
            }

            if (dataGridView1.Columns[e.ColumnIndex] == стоимостьColumn || dataGridView1.Columns[e.ColumnIndex] == ст_материаловColumn)
            {
                if (e.FormattedValue == null || e.FormattedValue.ToString().Trim() == string.Empty)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                }
            }


        }

        void список_работ_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (изменено)
            {
                try
                {
                    de.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Сбой записи...");
                }
            }
        }

        void bindingSource1_ListChanged(object sender, ListChangedEventArgs e)
        {
            изменено = true;
            label1.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int maxPor = 0;
            if (de.работы.Local.Any())
            {
                maxPor = de.работы.Local.Max(n => n.порядок);
            }

            работы NewRow = new работы();
            NewRow.работа = Guid.NewGuid();
            NewRow.наимен = "Новая работа";
            NewRow.порядок = maxPor + 1;
            NewRow.прейскурант = "";
            NewRow.ст_материалов = 0;
            NewRow.стоимость = 0;
         
            int строка =bindingSource1.Add(NewRow);
            bindingSource1.Position = строка;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count>0)
            {
                работы uRow = bindingSource1.Current as работы;
                if (uRow.опл_работы.Count==0)
                {
                 
                    bindingSource1.RemoveCurrent();
                    bindingSource1.MoveLast();
                }
                else
                {
                    MessageBox.Show("Работа присутствует в таблицах");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
                работы oldRow = bindingSource1.Current as работы;
              //  int oldIndex = bindingSource1.Position;

                int oldPor = oldRow.порядок;
                if (bindingSource1.Position > 0)
                {
                    bindingSource1.MovePrevious();

                    работы lastRow = bindingSource1.Current as работы;
                    //int lastIndex = bindingSource1.Position;
                    //int lastPor = lastRow.порядок;
                    //oldRow.порядок = lastPor;
                    //lastRow.порядок = oldPor;
                    (oldRow.порядок, lastRow.порядок) = (lastRow.порядок, oldRow.порядок);
                    //работыЛист[oldIndex] = lastRow;
                    //работыЛист[lastIndex] = oldRow;
                    //       работыЛист.Sort((a, b) => a.порядок.CompareTo(b.порядок));
                    bindingSource1.Sort = "порядок";
                    dataGridView1.Refresh();
                    изменено = true;
                    label1.Visible = true;
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            работы oldRow = bindingSource1.Current as работы;
            //int oldIndex = bindingSource1.Position;

          //  int oldPor = oldRow.порядок;
            if (bindingSource1.Position < bindingSource1.Count - 1)
            {
                bindingSource1.MoveNext();
                работы lastRow = bindingSource1.Current as работы;
                //int lastIndex = bindingSource1.Position;
                //int lastPor = lastRow.порядок;
                //oldRow.порядок = lastPor;
                //lastRow.порядок = oldPor;
                (oldRow.порядок, lastRow.порядок) = (lastRow.порядок, oldRow.порядок);
                bindingSource1.Sort = "порядок";

                //работыЛист[oldIndex] = lastRow;
                //работыЛист[lastIndex] = oldRow;
                //   работыЛист.Sort((a, b) => a.порядок.CompareTo(b.порядок));
                dataGridView1.Refresh();
                изменено = true;
                label1.Visible = true;

            }

        }

        //private void button7_Click(object sender, EventArgs e)
        //{
        //     работы uRow = bindingSource1.Current as работы;
        //        MessageBox.Show(uRow.опл_работы.Count.ToString());
        //}

        //private void button7_Click(object sender, EventArgs e)
        //{
        //    работыЛист.Sort((a, b) => a.стоимость.CompareTo(b.стоимость));
        //    dataGridView1.Refresh();
        //}

    }
}
