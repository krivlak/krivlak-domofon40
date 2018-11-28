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
    public partial class список_улиц : Form
    {
        bool изменено = false;
        public список_улиц()
        {
            InitializeComponent();
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        private void список_улиц_Load(object sender, EventArgs e)
        {
            try
            {
                de.улицы
                   .Where(n => n.поселок == клПоселок.поселок)
                   .OrderBy(n => n.наимен)
                   .Load();

                bindingSource1.DataSource = de.улицы.Local.ToBindingList();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Сбой загрузки " + ex.Message);
            }
            наименColumn.DefaultCellStyle.NullValue = "null";
            наименColumn.DefaultCellStyle.DataSourceNullValue = "";

            dataGridView1.CellValidating += dataGridView1_CellValidating;
            bindingSource1.ListChanged += bindingSource1_ListChanged;
            FormClosing += список_улиц_FormClosing;

        }

        void список_улиц_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataGridView1.EndEdit();
            bindingSource1.EndEdit();
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            улицы NewRow = new улицы();
            NewRow.поселок = клПоселок.поселок;
            NewRow.улица = Guid.NewGuid();
            NewRow.наимен = "Новая..";
            int строка = bindingSource1.Add(NewRow);
            bindingSource1.Position = строка;
            dataGridView1.Focus();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            улицы uRow = bindingSource1.Current as улицы;
            if (uRow.дома.Count == 0)
            {
              //  Guid КодУлицы = uRow.улица;
                //de.улицы.Remove(uRow);
                try
                {
                 //   de.SaveChanges();
                    bindingSource1.RemoveCurrent();
                    bindingSource1.MoveLast();

                }
                catch(Exception ex)
                {
                    MessageBox.Show("Сбой записи.."+ex.Message);
                }
            }
            else
            {
                MessageBox.Show("На улице есть дома");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
