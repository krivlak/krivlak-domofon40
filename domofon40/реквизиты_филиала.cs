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
    public partial class реквизиты_филиала : Form
    {
        public реквизиты_филиала()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        private void реквизиты_филиала_Load(object sender, EventArgs e)
        {
            try
            {
                de.филиалы.OrderBy(n => n.порядок).Load();
                филиалыBindingSource.DataSource = de.филиалы.Local.ToBindingList();
                филиалыBindingSource.MoveFirst();
                this.адресTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.филиалыBindingSource, "адрес", true));
                this.наименTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.филиалыBindingSource, "наимен", true));
                this.телефонTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.филиалыBindingSource, "телефон", true));
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка загрузки..." + ex.Message);
            }
            филиалыBindingSource.ListChanged += филиалыBindingSource_ListChanged;
            FormClosing += реквизиты_филиала_FormClosing;
        }

        void реквизиты_филиала_FormClosing(object sender, FormClosingEventArgs e)
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

        void филиалыBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            label1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
