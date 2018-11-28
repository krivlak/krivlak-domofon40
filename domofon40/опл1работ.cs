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
    public partial class опл1работ : Form
    {
        public опл1работ()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
  
        BindingList<опл_работы>  работыЛист = new BindingList<опл_работы>();
   //     public List<опл_работы> работыЛист = new List<опл_работы>();
        private void опл1работ_Load(object sender, EventArgs e)
        {
            de.работы.Load();
            de.сотрудники.Load();

            de.опл_работы.Where(n => n.оплата == клОплата.оплата)
                .OrderBy(n => n.номер)
                .Load();
            работыЛист = de.опл_работы.Local.ToBindingList();
            bindingSource1.DataSource = работыЛист;
            пересчет();
            bindingSource1.ListChanged += bindingSource1_ListChanged;
            FormClosing += опл1работ_FormClosing;
            dataGridView1.EditingControlShowing += dataGridView1_EditingControlShowing;
            dataGridView1.DataError += dataGridView1_DataError;
            dataGridView1.CellMouseClick += dataGridView1_CellMouseClick;
        }

        void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                опл_работы tRow = bindingSource1.Current as опл_работы;
                if (dataGridView1.Columns[e.ColumnIndex] == мастерColumn)
                {

                    клМастер.мастер = tRow.мастер;
                    клМастер.выбран = false;
                    выбор_мастера выборКассира = new выбор_мастера();
                    выборКассира.ShowDialog();



                    if (клМастер.выбран)
                    {
                        tRow.мастер = клМастер.мастер;
                        if (de.Entry(tRow).State == EntityState.Unchanged)
                        {
                            de.Entry(tRow).State = EntityState.Modified;
                        }

                        dataGridView1.Refresh();
                        label1.Visible = true;
                     //   de.SaveChanges();
                    }

                }

              
            }
        }


        void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex]== оплаченоColumn || dataGridView1.Columns[e.ColumnIndex]== материалыColumn )
            {
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
            }
        }

        void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            DataGridViewColumn ColName = dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex];

            if (ColName ==  оплаченоColumn || ColName == материалыColumn)
            {
                e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
            }

            //string CellName = dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].Name;

            //if (CellName == "стоимостьColumn" || CellName == "ст_материаловColumn")
            //{
            //    e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
            //}
        }

        void Control_KeyPress(object sender, KeyPressEventArgs pressE)
        {
            клKey.int_KeyPress(sender, pressE);
        }

        void опл1работ_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (label1.Visible)
            {
                try
                {
                    de.SaveChanges();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        void bindingSource1_ListChanged(object sender, ListChangedEventArgs e)
        {
            label1.Visible = true;
            клОплата.выбран = true;
            пересчет();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        void пересчет()
        {
            int стоимость = 0;
            int ст_материалов = 0;
            int зарплата = 0;
        
                if (работыЛист.Any())
                {
                    стоимость =  работыЛист.Sum(n => n.стоимость);
                    ст_материалов = работыЛист.Sum(n => n.ст_материалов);
                    зарплата = работыЛист.Sum(n => n.зарплата);

                }
         
            textBox1.Text = стоимость.ToString();
            textBox2.Text = ст_материалов.ToString();
            textBox3.Text = зарплата.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count>0)
            {
                опл_работы delRow = bindingSource1.Current as опл_работы;
                bindingSource1.RemoveCurrent();
                //работыЛист.Remove(delRow);
                bindingSource1.MoveLast();
              //  пересчет();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            клРабота.выбран = false;
            выбор_работы выборРаботы = new выбор_работы();
            выборРаботы.ShowDialog();
            if (клРабота.выбран)
            {
                int[] aMax = new int[2];
                if (de.опл_работы.Local.Any())
                {
                    aMax[0] = de.опл_работы.Local.Max(n => n.номер);
                }
                if (de.опл_работы.Any())
                {
                    aMax[1] = de.опл_работы.Max(n => n.номер);
                }
                int maxNum = aMax.Max();

                опл_работы newRow = new опл_работы();
                newRow.задание = Guid.NewGuid();

                newRow.мастер = клОплата.сотрудник;
                newRow.номер = maxNum + 1;
                newRow.оплата = клОплата.оплата;
                newRow.работа = клРабота.работа;
                newRow.ст_материалов = клРабота.deRow.ст_материалов;
                newRow.стоимость = клРабота.deRow.стоимость;
              

                int строка = bindingSource1.Add(newRow);
                //работыЛист.Add(newRow);

                bindingSource1.Position = строка;
            //    пересчет();
            }
            dataGridView1.Select();

        }
    }
}
