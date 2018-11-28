using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace domofon40
{
    public partial class ввод_тарифов : Form
    {
        public ввод_тарифов()
        {
            InitializeComponent();
        }
        bool изменено = false;
        domofon40.domofon14Entities de = new domofon14Entities();
        List<temp> tempList = new List<temp>();
        private void ввод_тарифов_Load(object sender, EventArgs e)
        {
            string команда = "ввод_тарифов @услуга ='"+клУслуга.услуга.ToString()+"'";
            tempList = de.Database.SqlQuery<temp>(команда).ToList();
            bindingSource1.DataSource = tempList;
            int tgggg = DateTime.Today.Year;
            int tmm = DateTime.Today.Month;
            int строка = 0;
            try
            {
                строка = tempList.FindIndex(n => n.год == tgggg && n.месяц == tmm);
            }
            catch
            { }
            bindingSource1.Position = строка;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            bindingSource1.ListChanged += bindingSource1_ListChanged;
            dataGridView1.EditingControlShowing += dataGridView1_EditingControlShowing;
            FormClosing += ввод_тарифов_FormClosing;
        }

        void ввод_тарифов_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            bindingSource1.EndEdit();
            dataGridView1.EndEdit();
            if (изменено)
            {
                Cursor = Cursors.WaitCursor;
                цены[] delRows = de.цены
                    .Where(n => n.услуга == клУслуга.услуга)
                    .ToArray();
                de.цены.RemoveRange(delRows);
                foreach (temp tRow in tempList.Where(n=>n.тариф>0))
                {
                    цены NewRow = new цены();
                    NewRow.услуга = клУслуга.услуга;
                    NewRow.год = tRow.год;
                    NewRow.месяц = tRow.месяц;
                    NewRow.стоимость = tRow.тариф;
                    de.цены.Add(NewRow);
                }
                try
                {
                    de.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Сбой записи");
                }
                Cursor=Cursors.Default;
            }
        }

        void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            string CellName = dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].Name;
            if (CellName == "тарифColumn")
            {
                e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
            }
        }
        void Control_KeyPress(object sender, KeyPressEventArgs pressE)
        {
            клKey.int_KeyPress(sender, pressE);
        }

        void bindingSource1_ListChanged(object sender, ListChangedEventArgs e)
        {
            изменено = true;
            label1.Visible = true;
        }

        void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int номерГода = (int)dataGridView1.Rows[e.RowIndex].Cells["годColumn"].Value;
            if (номерГода % 2 == 0)
            {
                e.CellStyle.ForeColor = Color.Blue;
            }
        }

        partial class temp
        {
            public int год { get; set; }
            public int месяц { get; set; }
            public string наимен  { get; set; }
            public int тариф { get; set; }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > 0)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {

                    foreach (System.Windows.Forms.DataGridViewRow uRow in dataGridView1.Rows)
                    {
                        if (uRow.Selected)
                        {
                    //        uRow.Cells["тарифColumn"].Value = numericUpDown1.Value;
                            tempList[uRow.Index].тариф =(int) numericUpDown1.Value;
                        }
                    }
                    dataGridView1.Refresh();
                    изменено = true;
                    label1.Visible = true;
                }
                else
                {
                    MessageBox.Show("Преварительно выберите строки с месяцами...");
                }
            }
            else
            {
                MessageBox.Show("Введите новый тариф ...");
            }

        }
    }
}
