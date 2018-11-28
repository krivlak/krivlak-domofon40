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
    public partial class сведения_о_клиенте : Form
    {
        public сведения_о_клиенте()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        private void сведения_о_клиенте_Load(object sender, EventArgs e)
        {
            de.клиенты.Where(n => n.клиент == клКлиент.клиент).Load();
            клКлиент.deRow = de.клиенты.Local.First();
            bindingSource1.DataSource = de.клиенты.Local.ToBindingList();

            фамилияTextBox.DataBindings.Add("Text", bindingSource1, "Фамилия");
            имяTextBox.DataBindings.Add("Text", bindingSource1, "Имя");
            отчествоTextBox.DataBindings.Add("Text", bindingSource1, "Отчество");
            примTextBox.DataBindings.Add("Text", bindingSource1, "прим");
            телефонTextBox.DataBindings.Add("Text", bindingSource1, "телефон");

            //фамилияTextBox.Text = фамилияTextBox.Text.Trim();
            //имяTextBox.Text = имяTextBox.Text.Trim();
            //отчествоTextBox.Text = отчествоTextBox.Text.Trim();
            //примTextBox.Text = примTextBox.Text.Trim();
            //телефонTextBox.Text = телефонTextBox.Text.Trim();


            bindingSource1.ListChanged += bindingSource1_ListChanged;
            FormClosing += сведения_о_клиенте_FormClosing;

            фамилияTextBox.Enter += ФамилияTextBox_Enter;
            имяTextBox.Enter += ФамилияTextBox_Enter;
            отчествоTextBox.Enter += ФамилияTextBox_Enter;
            телефонTextBox.Enter+= ФамилияTextBox_Enter;
            примTextBox.Enter+= ФамилияTextBox_Enter;

        }

        private void ФамилияTextBox_Enter(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = tb.Text.TrimEnd();
        }

        void сведения_о_клиенте_FormClosing(object sender, FormClosingEventArgs e)
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
         //   клКлиент.выбран = true; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            договора1клиента списокДоговоров = new договора1клиента();
            списокДоговоров.Text = "Договора " + клКлиент.deRow.адрес + " " + клКлиент.deRow.фио;
            списокДоговоров.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            льготы1клиент формаПодключен = new льготы1клиент();
            формаПодключен.Text = "Льготы " + клКлиент.deRow.адрес
                + " " + клКлиент.deRow.фио;
               // + " кв. " + клКлиент.deRow.квартира.ToString()
               //+ " дом " + клДом.номер
               //+ "  " + клДом.корпус
               //+ " улица " + клДом.deRow.улицы.наимен;

            формаПодключен.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            отключения1клиента списокДоговоров = new отключения1клиента();
            списокДоговоров.Text = "Отключения " + клКлиент.deRow.фио + " " + клКлиент.deRow.адрес;
            списокДоговоров.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            повторы1клиент списокДоговоров = new повторы1клиент();
            списокДоговоров.Text = "Повторные подключения " + клКлиент.deRow.фио + " " + клКлиент.deRow.адрес;
            списокДоговоров.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            звонки1клиенту списокДоговоров = new звонки1клиенту();
            списокДоговоров.Text = "Отключения " + клКлиент.deRow.фио + " " + клКлиент.deRow.адрес;
            списокДоговоров.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
          
            удаленные1оплаты удаленныеОплаты = new удаленные1оплаты();
            удаленныеОплаты.Text = "Удаленные оплаты  " + клКлиент.deRow.фио + " " + клКлиент.deRow.адрес;

            удаленныеОплаты.ShowDialog();

            Cursor = Cursors.Default;
        }

        private void button5_Click(object sender, EventArgs e)
        {

            Cursor = Cursors.WaitCursor;
 
            удаленные1месяца удаленныеОплаты = new удаленные1месяца();
            удаленныеОплаты.Text = "Удаленные месяцы " + клКлиент.deRow.фио + " " + клКлиент.deRow.адрес;
            удаленныеОплаты.ShowDialog();

            Cursor = Cursors.Default;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            простои1клиента удаленныеОплаты = new  простои1клиента();
            удаленныеОплаты.Text = "Удаленные оплаты  " + клКлиент.deRow.фио + " " + клКлиент.deRow.адрес;

            удаленныеОплаты.ShowDialog();

            Cursor = Cursors.Default;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            клВид_услуги.выбран = false;
            выбор_вида_услуги выборВида = new выбор_вида_услуги();
            выборВида.ShowDialog();
            if (клВид_услуги.выбран)
            {
                
                Cursor = Cursors.WaitCursor;
                оплата_вид ОплатаВида = new оплата_вид();
                ОплатаВида.Text = "Оплаты " + клКлиент.фио + " за " + клВид_услуги.наимен;
                ОплатаВида.ShowDialog();
                Cursor = Cursors.Default;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
