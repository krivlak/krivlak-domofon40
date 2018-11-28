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
    public partial class список_домов : Form
    {
        public список_домов()
        {
            InitializeComponent();
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
        }
        domofon40.domofon14Entities de ;
        BindingList<дома> домаЛист = new BindingList<дома>();
     //   DataTable таблица;
        private void список_домов_Load(object sender, EventArgs e)
        {
            обновить();
            //таблица = домаЛист.ToTable();
            //if(таблица.HasErrors)
            //{
            //    MessageBox.Show("Есть ошибки");
            //}
            проверка_уникальности();

            корпусColumn.DefaultCellStyle.NullValue = "null";
            корпусColumn.DefaultCellStyle.DataSourceNullValue = "";
            //номерColumn.DefaultCellStyle.NullValue = "null";
            //номерColumn.DefaultCellStyle.DataSourceNullValue = 0;
            bindingSource1.ListChanged += bindingSource1_ListChanged;
            FormClosing += список_домов_FormClosing;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            dataGridView1.CellValidating += dataGridView1_CellValidating;
        //    dataGridView1.CellValidated += dataGridView1_CellValidated;
            dataGridView1.DataError += dataGridView1_DataError;
            dataGridView1.EditingControlShowing += dataGridView1_EditingControlShowing;
         //   dataGridView1.RowValidating += DataGridView1_RowValidating;
        }

        private void DataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            // при удалении строки выдает ошибку
            try
            {
                проверка_уникальности();

                bool ss = (bool)dataGridView1.Rows[e.RowIndex].Cells["неуникальныйColumn"].Value;
                if (ss)
                {
                    dataGridView1.Rows[e.RowIndex].ErrorText = "Номер дома и корпус не уникальны";
                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].ErrorText = null;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void обновить()
        {
            de = new domofon14Entities();
            de.дома
                .Where(n => n.улица == клУлица.улица)
                .OrderBy(n => n.номер)
                .ThenBy(n => n.корпус)
                .Load();
            домаЛист = de.дома.Local.ToBindingList();
            bindingSource1.DataSource = домаЛист;
        }

        void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Ошибка ввода данных"+e.Exception.Message);
            
        }

        //void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        //{
        //    //if (dataGridView1.Columns[e.ColumnIndex] == номерColumn || dataGridView1.Columns[e.ColumnIndex] == корпусColumn)
        //    //{
        //    //    проверка_уникальности();
        //    //}
        //}

        void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Control_KeyPress);
            string CellName = dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].Name;

            if (CellName == "номерColumn")
            {
                e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
            }
        }
        void Control_KeyPress(object sender, KeyPressEventArgs pressE)
        {
            //            клKey.decimal_KeyPress(sender, pressE);
            клKey.int_KeyPress(sender, pressE);

        }
        void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //if (dataGridView1.Columns[e.ColumnIndex] == корпусColumn || dataGridView1.Columns[e.ColumnIndex] == примColumn)
            //{
            //    if (e.FormattedValue == null || e.FormattedValue.ToString().Trim() == "")
            //    {
            //        dataGridView1.Rows[e.RowIndex].Cells[e.RowIndex].Value = "";
            //    }
            //}
            if (dataGridView1.Columns[e.ColumnIndex] == номерColumn)
            {
                if (e.FormattedValue == null || e.FormattedValue.ToString().Trim() == "")
                {
                    dataGridView1.Rows[e.RowIndex].Cells["номерColumn"].Value = 0;
                }
            }

      
        
        }

        void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells["неуникальныйColumn"].Value != null)
            {
                bool ss = (bool) dataGridView1.Rows[e.RowIndex].Cells["неуникальныйColumn"].Value;
                if (ss )
                {
                    e.CellStyle.ForeColor = Color.Red;
                    dataGridView1.Rows[e.RowIndex].ErrorText = "Номер дома и корпус не уникальны";
                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].ErrorText = null;
                }
            }
        }


        private void проверка_уникальности()
        {
  
            foreach (дома uRow in домаЛист)
            {
                if (de.Entry(uRow).State != EntityState.Deleted)
                {
                    uRow.неуникальный = false; ;
                    int совпадений = домаЛист
                    .Where(n => n.номер == uRow.номер)
                    .Count(n => n.корпус.Trim().ToUpper() == uRow.корпус.Trim().ToUpper());
                    if (совпадений > 1)
                    {
                        uRow.неуникальный = true;
                    }
                }
            }
            dataGridView1.Refresh();

        }


        void список_домов_FormClosing(object sender, FormClosingEventArgs e)
        {
            записать();
            //dataGridView1.EndEdit();
            //bindingSource1.EndEdit();
            //if (label1.Visible)
            //{
            //    try
            //    {
            //        de.SaveChanges();
            //    }
            //    catch(Exception ex)
            //    {
            //        MessageBox.Show("Сбой записи..."+ex.Message);
            //    }
            //}

        }
        void записать()
        {
            dataGridView1.EndEdit();
            bindingSource1.EndEdit();
            if (label1.Visible)
            {
                try
                {
                    de.SaveChanges();
                    label1.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Сбой записи..." + ex.Message);
                }
            }

        }

        void bindingSource1_ListChanged(object sender, ListChangedEventArgs e)
        {
          //  изменено = true;
            label1.Visible = true;
            проверка_уникальности();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            дома NewRow = new дома();
            NewRow.улица = клУлица.улица;
            NewRow.дом = Guid.NewGuid();
            NewRow.номер = 0;
            NewRow.корпус = "";
            NewRow.изменен = DateTime.Now;
        //    de.дома.Add(NewRow);
            int строка = bindingSource1.Add(NewRow);
            bindingSource1.Position = строка;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
                дома uRow = bindingSource1.Current as дома;
                if (uRow.клиенты.Count == 0)
                {
                 //   de.дома.Remove(uRow);
                    bindingSource1.RemoveCurrent();
                    bindingSource1.MoveLast();
                }
                else
                {
                    MessageBox.Show("В доме есть квартиры");
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
                Guid oldString = клУлица.улица;
                дома uRow = bindingSource1.Current as дома;
                клУлица.выбран = false;
                выбор_улицы выборУлицы = new выбор_улицы();
                выборУлицы.ShowDialog();
                if (клУлица.выбран)
                {
                    uRow.улица = клУлица.улица;

                    label1.Visible = true;
                    //if (de.Entry(uRow).State == EntityState.Unchanged)
                    //{
                    //    de.Entry(uRow).State = EntityState.Modified;
                    //    // не работает в добавленой строке.
                    //}
                }
                клУлица.улица = oldString;
                записать();
                обновить();
                проверка_уникальности();
                dataGridView1.Refresh();
            }
            dataGridView1.Focus();

        }

        private void button4_Click(object sender, EventArgs e)
        {

            int dd1 = (int)numericUpDown1.Value;
            int dd2 = (int)numericUpDown2.Value;

            if (dd1 > 0 && dd2 >= dd1)
            {
                Cursor = Cursors.WaitCursor;
                for (int i = dd1; i <= dd2; i++)
                {
                  
                    дома NewRow = new дома();
                    NewRow.дом = Guid.NewGuid();
                    NewRow.номер = i;
                    NewRow.корпус = "";
                    NewRow.улица = клУлица.улица;
                    NewRow.изменен = DateTime.Now; ;
                    //NewRow.прим = "";
                    //NewRow.порядок = 0;
                   
                    bindingSource1.Add(NewRow);
           //         de.дома.Add(NewRow);
                    label1.Visible = true;
          //          изменено = true; 

                }
                проверка_уникальности();
                Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Введите начальный и конечный номера...");
            }

        }
    }
}
