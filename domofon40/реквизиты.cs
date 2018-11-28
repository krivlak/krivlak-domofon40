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
    public partial class реквизиты : Form
    {
        public реквизиты()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();

        private void реквизиты_Load(object sender, EventArgs e)
        {
            try
            {
                de.фирмы.OrderBy(n => n.порядок).Load();
                фирмыBindingSource.DataSource = de.фирмы.Local.ToBindingList();
                фирмыBindingSource.MoveFirst();
                адресTextBox.DataBindings.Add("Text", фирмыBindingSource, "адрес", true);
                банкTextBox.DataBindings.Add("Text", фирмыBindingSource, "банк", true);
                бикTextBox.DataBindings.Add("Text", фирмыBindingSource, "бик", true);
                городTextBox.DataBindings.Add("Text", фирмыBindingSource, "город", true);
                груз_полTextBox.DataBindings.Add("Text", фирмыBindingSource, "груз_пол", true);
                иннTextBox.DataBindings.Add("Text", фирмыBindingSource, "инн", true);
                к_счетTextBox.DataBindings.Add("Text", фирмыBindingSource, "к_счет", true);
                кодTextBox.DataBindings.Add("Text", фирмыBindingSource, "код", true);
                названиеTextBox.DataBindings.Add("Text", фирмыBindingSource, "название", true);
                наименTextBox.DataBindings.Add("Text", фирмыBindingSource, "наимен", true);
                оконхTextBox.DataBindings.Add("Text", фирмыBindingSource, "оконх", true);
                окпоTextBox.DataBindings.Add("Text", фирмыBindingSource, "окпо", true);
                р_счетTextBox.DataBindings.Add("Text", фирмыBindingSource, "р_счет", true);
                телефонTextBox.DataBindings.Add("Text", фирмыBindingSource, "телефон", true);
                факт_адресTextBox.DataBindings.Add("Text", фирмыBindingSource, "факт_адрес", true);



            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки..." + ex.Message);
            }

            фирмыBindingSource.ListChanged += фирмыBindingSource_ListChanged;
            FormClosing += реквизиты_FormClosing;
        }

        void реквизиты_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (label1.Visible)
            {
                try
                {
                    de.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Сбой записи");
                }
            }
        }

        void фирмыBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            label1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

     

        private void р_счетTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            клKey.int_KeyPress(sender, e);
        }
    }
}
