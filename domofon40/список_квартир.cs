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
    public partial class список_квартир : Form
    {
        public список_квартир()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        BindingList<клиенты> клиентыЛист = new BindingList<клиенты>();

     //   List<клиенты> клиентыЛист = new List<клиенты>();
        private void список_квартир_Load(object sender, EventArgs e)
        {

            de.клиенты
             .Where(n => n.дом == клДом.дом)
             .OrderBy(n => n.квартира)
             .ThenBy(n => n.ввод).Load();


            клиентыЛист = de.клиенты.Local.ToBindingList();

            bindingSource1.DataSource = клиентыЛист;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = bindingSource1;
            подъездNumericUpDown.DataBindings.Add("Text", bindingSource1, "подъезд");
            квартираTextBox.DataBindings.Add("Text", bindingSource1, "квартира");
            numericUpDown3.DataBindings.Add("Text", bindingSource1, "ввод");
            textBox3.DataBindings.Add("Text", bindingSource1, "фио");
            фамилияTextBox.DataBindings.Add("Text", bindingSource1, "фамилия");
            имяTextBox.DataBindings.Add("Text", bindingSource1, "имя");
            отчествоTextBox.DataBindings.Add("Text", bindingSource1, "отчество");
            textBox1.DataBindings.Add("Text", bindingSource1, "телефон");
            примTextBox.DataBindings.Add("Text", bindingSource1, "прим");
            //     обновить_звонок();
            //      textBox2.DataBindings.Add("Text", bindingSource1, "звонок");
            примColumn.DefaultCellStyle.NullValue = "null";
            примColumn.DefaultCellStyle.DataSourceNullValue = "";
            квартираColumn.DefaultCellStyle.NullValue = "0";
            вводColumn.DefaultCellStyle.NullValue = "0";
            подъездColumn.DefaultCellStyle.NullValue = "0";
            bindingSource1.ListChanged += bindingSource1_ListChanged;
            FormClosing += список_квартир_FormClosing;
            dataGridView1.EditingControlShowing += dataGridView1_EditingControlShowing;
       //     bindingSource1.PositionChanged += BindingSource1_PositionChanged;
     //       dataGridView1.CellValidated += DataGridView1_CellValidated;
            dataGridView1.CellValidating += DataGridView1_CellValidating;
            //  dataGridView1.CellEndEdit += DataGridView1_CellEndEdit;
            //  dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
        //    dataGridView1.DataError += DataGridView1_DataError;
        }

        private void DataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.FormattedValue.ToString() == "")
            {
                if (dataGridView1.Columns[e.ColumnIndex] == вводColumn || dataGridView1.Columns[e.ColumnIndex] == квартираColumn || dataGridView1.Columns[e.ColumnIndex] == подъездColumn)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                }
                if (dataGridView1.Columns[e.ColumnIndex] == примColumn)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                }
            }
        }

   

        //private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
           
        //}

        //private void DataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (dataGridView1.Columns[e.ColumnIndex] == примColumn)
        //    {
        //        if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
        //        {
        //            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
        //        }
        //    }
       
        //}

        //private void BindingSource1_PositionChanged(object sender, EventArgs e)
        //{
        //   // обновить_звонок();
        //}

        //private void обновить_звонок()
        //{
        //    if (bindingSource1.Count > 0)
        //    {
        //        клиенты tRow = bindingSource1.Current as клиенты;
        //        DateTime? последнийЗвонок = null;
        //        звонокTextBox.Text = "";
        //        if (de.звонки.Any(n => n.клиент == tRow.клиент))
        //        {
        //            последнийЗвонок = de.звонки.Where(n => n.клиент == tRow.клиент).Max(n => n.дата);
        //       //     звонокTextBox.Text = последнийЗвонок.Value.ToShortDateString();
        //            звонокTextBox.Text = последнийЗвонок.Value.ToShortDateString()+" "+ последнийЗвонок.Value.ToShortTimeString();
        //        }
        //    }
        //}

        void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Control_KeyPress);
            string CellName = dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].Name;

            e.Control.KeyPress -= new KeyPressEventHandler(Control_KeyPress);
            if (CellName == "квартираColumn" || CellName == "вводColumn" || CellName == "подъездColumn")
            {
                e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
            }
        }

        void Control_KeyPress(object sender, KeyPressEventArgs pressE)
        {
            клKey.int_KeyPress(sender, pressE);
        }

        void список_квартир_FormClosing(object sender, FormClosingEventArgs e)
        {
            записать();
        }

        void записать()
        {
            if (label1.Visible)
            {
                try
                {
                    de.SaveChanges();
                    label1.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Сбой записи " + ex.Message);
                }
            }
        }

        void bindingSource1_ListChanged(object sender, ListChangedEventArgs e)
        {
            label1.Visible = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            записать();
            if (bindingSource1.Count > 0)
            {
                клиенты uRow = bindingSource1.Current as клиенты;
                клКлиент.клиент = uRow.клиент;
                клКлиент.deRow = uRow;
                договора1клиента списокДоговоров = new договора1клиента();
                списокДоговоров.Text = "Договора " + клКлиент.deRow.фио + " " + клКлиент.deRow.адрес;
                списокДоговоров.ShowDialog();

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            int кв1 = (int)numericUpDown1.Value;
            int кв2 = (int)numericUpDown2.Value;
            if (кв1 > 0 && кв2 > кв1)
            {
                int строка = 0;
                for (int i = кв1; i <= кв2; i++)
                {
                    клиенты NewRow = new клиенты();
                  //  string NewKod = уникальный();
                    NewRow.клиент = Guid.NewGuid();
                    NewRow.дом = клДом.дом;
                    NewRow.квартира = i;
                    NewRow.имя = "";
                    NewRow.отчество = "";
                    NewRow.фамилия = "";
                    NewRow.телефон = "";
                    NewRow.прим = "";
                    NewRow.подъезд = 0;
                   строка = bindingSource1.Add(NewRow);

                }
                bindingSource1.Position = строка;
            }
            Cursor = Cursors.Default;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
                записать();
                клиенты uRow = bindingSource1.Current as клиенты;
                клКлиент.клиент = uRow.клиент;
                клКлиент.deRow = uRow;
                отключения1клиента списокДоговоров = new отключения1клиента();
                списокДоговоров.Text = "Отключения " + клКлиент.deRow.фио + " " + клКлиент.deRow.адрес;
                списокДоговоров.ShowDialog();
            }
        }

        //private void button21_Click(object sender, EventArgs e)
        //{

        //}

        //private void button9_Click(object sender, EventArgs e)
        //{
        //    if (bindingSource1.Count > 0)
        //    {
        //        записать();
        //        клиенты uRow = bindingSource1.Current as клиенты;
        //        клКлиент.клиент = uRow.клиент;
        //        клКлиент.deRow = uRow;
        //        простои1клиента списокДоговоров = new простои1клиента();
        //        списокДоговоров.ShowDialog();

        //    }
        //}

        private void button16_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
                записать();
                клиенты uRow = bindingSource1.Current as клиенты;
                клКлиент.клиент = uRow.клиент;
                клКлиент.deRow = uRow;
                повторы1клиент списокДоговоров = new повторы1клиент();
                списокДоговоров.Text = "Повторные подключения " + uRow.фио +" "+uRow.адрес;
                списокДоговоров.ShowDialog();

            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            List<int> iList = new List<int>();
            foreach (DataGridViewCell uCell in dataGridView1.SelectedCells)
            {
                iList.Add(uCell.RowIndex);
            }
            foreach( int позиция   in iList   )
            {
                bindingSource1.Position = позиция;
                клиенты uRow = bindingSource1.Current as клиенты;
                uRow.подъезд = (int)numericUpDown4.Value;
                label1.Visible = true;
            }

         //       foreach (DataGridViewCell uCell in dataGridView1.SelectedCells)
         //   {
         //       int позиция = uCell.RowIndex;
         //       //if (dataGridView1.Columns[uCell.ColumnIndex] == подъездColumn)
         //       //{
         //       bindingSource1.Position = позиция;
         //        //   dataGridView1.CurrentCell = uCell;
         //       клиенты uRow = bindingSource1.Current as клиенты;

         ////           DataSet.клиентRow uRow = (клиентBindingSource.Current as DataRowView).Row as DataSet.клиентRow;
         //           uRow.подъезд = (int)numericUpDown4.Value;
         //       label1.Visible = true;
         //     //  }
         //   }
            this.Refresh();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            записать();
            Guid oldDom = клДом.дом;
            клиенты uRow = bindingSource1.Current as клиенты;
            
            клДом.выбран = false;
            выбор_дома ВыборДома = new выбор_дома();
            ВыборДома.ShowDialog();
            if (клДом.выбран)
            {
                uRow.дом = клДом.дом;
            //    dataGridView1.CurrentRow.Height = 0;
            }
            клДом.дом = oldDom;
          
            label1.Visible = true;
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Validate();
            bindingSource1.EndEdit();
           



            клиенты NewRow = new клиенты();
            NewRow.клиент = Guid.NewGuid();
            NewRow.дом = клДом.дом;
            NewRow.имя = "";
            NewRow.квартира = 0;
            NewRow.подъезд = 0;
            NewRow.отчество = "";
            NewRow.прим = "";
            NewRow.телефон = "";
            NewRow.фамилия = "новый Клиент";
            NewRow.ввод = 0;
            int строка =bindingSource1.Add(NewRow);
            bindingSource1.Position = строка;
            dataGridView1.Refresh();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count>0)
            {
                клиенты uRow = bindingSource1.Current as клиенты;
                if ( uRow.оплаты.Count==0 
                    &&  uRow.отключения.Count==0 
                    && uRow.повторы.Count==0 
                    && uRow.подключения.Count==0 
                    && ! uRow.простои.Any()
                    && uRow.раб_дней.Count==0)
                {
                    bindingSource1.RemoveCurrent();
                }
                else
                {
                    MessageBox.Show("Клиент присутствует в других таблицах ");
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            записать();
            if (bindingSource1.Count>0)
            {
                Cursor = Cursors.WaitCursor;
                клиенты uRow = bindingSource1.Current as клиенты;
                клКлиент.deRow = uRow;
                клКлиент.клиент = uRow.клиент;
                подключен4услугам подключенУслугам = new подключен4услугам();
                подключенУслугам.Text = "Отметьте подключеные услуги " + uRow.адрес;
                подключенУслугам.ShowDialog();
            //    обновить_звонок();
                dataGridView1.Focus();
                Cursor = Cursors.Default;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
                записать();
                клиенты uRow = bindingSource1.Current as клиенты;
                клКлиент.клиент = uRow.клиент;
                клКлиент.deRow = uRow;

                клКлиент.фио = uRow.фио;
                оплаты22клиента оплатыКлиента = new оплаты22клиента();
                оплатыКлиента.Text = "Оплаты " + клКлиент.фио;
                оплатыКлиента.ShowDialog();
            }
            dataGridView1.Focus();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
                   записать();
                
                клиенты  uRow = bindingSource1.Current as клиенты;
                клКлиент.клиент = uRow.клиент;

                клКлиент.фио = uRow.фио;

                //клУслуга.выбран = false;
                //выбор_услуги ВыборУслуги = new выбор_услуги();
                //ВыборУслуги.ShowDialog();
                //if (клУслуга.выбран)
                //{
                    льготы1клиент формаПодключен = new льготы1клиент();
                    формаПодключен.Text = "Льготы " 
                        + " " + uRow.фио + " кв. " + uRow.квартира.ToString()
                       + " дом " + клДом.номер
                       + "  " + клДом.корпус
                       + " улица " + клДом.deRow.улицы.наимен;

                    формаПодключен.ShowDialog();
                //}
            }
        }

    

        private void button17_Click(object sender, EventArgs e)
        {
             записать();
             if (bindingSource1.Count > 0)
             {
                 Cursor = Cursors.WaitCursor;
                 клиенты uRow = bindingSource1.Current as клиенты;
                 клКлиент.deRow = uRow;
                 клКлиент.клиент = uRow.клиент;

                 клВид_услуги.выбран = false;
                 выбор_вида_услуги выборВида = new выбор_вида_услуги();
                 выборВида.ShowDialog();
                 if (клВид_услуги.выбран)
                 {

                     Cursor = Cursors.WaitCursor;
                     оплата_вид ОплатаВида = new оплата_вид();
                     ОплатаВида.Text = "Оплаты " + клКлиент.deRow.фио + " за " + клВид_услуги.наимен;
                     ОплатаВида.ShowDialog();
                     Cursor = Cursors.Default;
                 }
             }

        }

      

        private void button20_Click(object sender, EventArgs e)
        {
            записать();
            if (bindingSource1.Count > 0)
            {
                Cursor = Cursors.WaitCursor;
                клиенты uRow = bindingSource1.Current as клиенты;
                клКлиент.deRow = uRow;
                клКлиент.клиент = uRow.клиент;
                удаленные1оплаты удаленныеОплаты = new удаленные1оплаты();
                удаленныеОплаты.Text = "Удаленные оплаты  " + uRow.фио+ " "+uRow.адрес;

                удаленныеОплаты.ShowDialog();

                Cursor = Cursors.Default;
            }

        }

        private void button19_Click(object sender, EventArgs e)
        {
            записать();
            if (bindingSource1.Count > 0)
            {
                Cursor = Cursors.WaitCursor;
                клиенты uRow = bindingSource1.Current as клиенты;
                клКлиент.deRow = uRow;
                клКлиент.клиент = uRow.клиент;
                удаленные1месяца удаленныеОплаты = new удаленные1месяца();
                удаленныеОплаты.Text = "Удаленные месяцы " + uRow.фио;
                удаленныеОплаты.ShowDialog();

                Cursor = Cursors.Default;
            }
            dataGridView1.Focus();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            записать();
            if (bindingSource1.Count > 0)
            {
                Cursor = Cursors.WaitCursor;
                клиенты uRow = bindingSource1.Current as клиенты;
                клКлиент.deRow = uRow;
                клКлиент.клиент = uRow.клиент;
                все_события удаленныеОплаты = new все_события();
                удаленныеОплаты.Text = "Все события " + uRow.фио;
                удаленныеОплаты.ShowDialog();

                Cursor = Cursors.Default;
            }
            dataGridView1.Focus();
        }

        private void button9_Click(object sender, EventArgs e)
        {

            записать();
            if (bindingSource1.Count > 0)
            {
                Cursor = Cursors.WaitCursor;
                клиенты uRow = bindingSource1.Current as клиенты;
                клКлиент.deRow = uRow;
                клКлиент.клиент = uRow.клиент;
                простои1клиента удаленныеОплаты = new простои1клиента();
                удаленныеОплаты.Text = "Простои "+uRow.адрес+" " + uRow.фио;
                удаленныеОплаты.ShowDialog();

                Cursor = Cursors.Default;
            }
            dataGridView1.Focus();
           
        }

        private void button6_Click(object sender, EventArgs e)
        {

            записать();
            if (bindingSource1.Count > 0)
            {
                Cursor = Cursors.WaitCursor;
                клиенты uRow = bindingSource1.Current as клиенты;
                клКлиент.deRow = uRow;
                клКлиент.клиент = uRow.клиент;
                звонки1клиенту удаленныеОплаты = new звонки1клиенту();
                удаленныеОплаты.Text = "Звонки и смс " + uRow.адрес + " " + uRow.фио;
                удаленныеОплаты.ShowDialog();
           //     обновить_звонок();
       //         de.SaveChanges();
          //      de.Entry(uRow).Reload();
                Cursor = Cursors.Default;
            }
            dataGridView1.Focus();
        }
    }
}
