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
    public partial class возврат1работ : Form
    {
        public возврат1работ()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();

        BindingList<воз_работы> работыЛист = new BindingList<воз_работы>();
        private void возврат1работ_Load(object sender, EventArgs e)
        {
            de.работы.Load();
         //   de.сотрудники.Load();

            de.воз_работы.Where(n => n.оплата == клОплата.оплата).OrderBy(n=>n.работы.порядок).Load();

            работыЛист = de.воз_работы.Local.ToBindingList();
            bindingSource1.DataSource = работыЛист;
            пересчет();
            bindingSource1.ListChanged += bindingSource1_ListChanged;
            FormClosing += опл1работ_FormClosing;
            dataGridView1.EditingControlShowing += dataGridView1_EditingControlShowing;
            dataGridView1.DataError += dataGridView1_DataError;
         //   dataGridView1.CellMouseClick += dataGridView1_CellMouseClick;
        }

        //void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    if (e.Button == System.Windows.Forms.MouseButtons.Right)
        //    {
        //        dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
        //        опл_работы tRow = bindingSource1.Current as опл_работы;
        //        if (dataGridView1.Columns[e.ColumnIndex] == мастерColumn)
        //        {

        //            клМастер.мастер = tRow.мастер;
        //            клМастер.выбран = false;
        //            выбор_мастера выборКассира = new выбор_мастера();
        //            выборКассира.ShowDialog();



        //            if (клМастер.выбран)
        //            {
        //                tRow.мастер = клМастер.мастер;
        //                if (de.Entry(tRow).State == EntityState.Unchanged)
        //                {
        //                    de.Entry(tRow).State = EntityState.Modified;
        //                }

        //                dataGridView1.Refresh();
        //                label1.Visible = true;
        //                //   de.SaveChanges();
        //            }

        //        }


        //    }
        //}


        void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] == оплаченоColumn )
            {
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
            }
        }

        void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            DataGridViewColumn ColName = dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex];

            if (ColName == оплаченоColumn )
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
                catch (Exception ex)
                {
                    MessageBox.Show("Сбой записи "+ex.Message);
                }
            }
        }

        void bindingSource1_ListChanged(object sender, ListChangedEventArgs e)
        {
            label1.Visible = true;
            клОплата.выбран = true;
            пересчет();
        }

    
        void пересчет()
        {
            int сумма = 0;
            //int ст_материалов = 0;
            //int зарплата = 0;

            if (работыЛист.Any())
            {
                сумма = работыЛист.Sum(n => n.сумма);
                //ст_материалов = работыЛист.Sum(n => n.ст_материалов);
                //зарплата = работыЛист.Sum(n => n.зарплата);

            }

            textBox1.Text = сумма.ToString();
            //textBox2.Text = ст_материалов.ToString();
            //textBox3.Text = зарплата.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
                
                воз_работы delRow = bindingSource1.Current as воз_работы;
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
                //int[] aMax = new int[2];
                //if (de.опл_работы.Local.Any())
                //{
                //    aMax[0] = de.опл_работы.Local.Max(n => n.номер);
                //}
                //if (de.опл_работы.Any())
                //{
                //    aMax[1] = de.опл_работы.Max(n => n.номер);
                //}
                //int maxNum = aMax.Max();

                воз_работы newRow = new воз_работы()
                {
                    код = Guid.NewGuid(),
                    оплата = клОплата.оплата,
                    работа = клРабота.работа,
                    сумма = клРабота.deRow.стоимость
                };


                int строка = bindingSource1.Add(newRow);
                //работыЛист.Add(newRow);

                bindingSource1.Position = строка;
                //    пересчет();
            }
            dataGridView1.Select();
        }
    }
}
