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
        DateTime? минОплата = null;
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

                if (de.оплачено.Any())
                {
                    int g100m = de.оплачено.Min(n => n.год * 100 + n.месяц);
                    int год = (int)g100m / 100;
                    int месяц = g100m - год * 100;

                    минОплата = new DateTime(год, месяц, 1);
                    label1.Text = минОплата.Value.ToShortDateString();
                }
                else
                {
                    label1.Text = "";
                }


            }
            catch ( Exception ex)
            {
                MessageBox.Show("Сбой загрузки "+ex.Message);
            }
        //    начало1DateTimePicker.Validating += Начало1DateTimePicker_Validating;
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

        private void button3_Click(object sender, EventArgs e)
        {
            оплачено minOp = de.оплачено.OrderBy(n => n.год * 100 + n.месяц).First();
            MessageBox.Show($" {minOp.оплаты.номер}  {minOp.год} {minOp.месяц} {minOp.сумма} {minOp.услуги.наимен}");
        }
    }
}
