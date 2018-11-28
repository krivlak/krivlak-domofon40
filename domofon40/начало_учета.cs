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
    public partial class начало_учета : Form
    {
        public начало_учета()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
   
        private void начало_учета_Load(object sender, EventArgs e)
        {
            try
            {

                de.начало.Load();

                //DateTime dt = de.начало.First().дата;
                //начало1DateTimePicker.Value = dt;

                bindingSource1.DataSource = de.начало.Local;
                Binding bd = new Binding("Text", bindingSource1, "дата");
                начало1DateTimePicker.DataBindings.Add(bd);
                bindingSource1.MoveFirst();
            }
            catch( Exception ex)
            {
                MessageBox.Show("Сбой загрузки "+ex.Message);
            }
            начало1DateTimePicker.Validating += Начало1DateTimePicker_Validating;
        }

        private void Начало1DateTimePicker_Validating(object sender, CancelEventArgs e)
        {
            DateTime dt = (DateTime)начало1DateTimePicker.Value;
            DateTime? минОплата = null;
            if(de.оплаты.Any())
            {
                минОплата = de.оплаты.Min(n => n.дата);
                if(dt> минОплата)
                {
                    MessageBox.Show("Есть более ранние оплаты");
                    e.Cancel = true;
                }
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            de.SaveChanges();
            Close();
        }
    }
}
