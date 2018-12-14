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
    public partial class календарь : Form
    {
        public календарь()
        {
            InitializeComponent();
        }

        private void календарь_Load(object sender, EventArgs e)
        {
            клКалендарь.isNull = false;
            if (клКалендарь.дата == null)
            {
                monthCalendar1.SetDate(DateTime.Today);
            }
            else
            {
                monthCalendar1.SetDate((DateTime)клКалендарь.дата);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            клКалендарь.выбран = true;
            клКалендарь.дата = (DateTime)monthCalendar1.SelectionStart.Date;
            клКалендарь.isNull = false;
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            клКалендарь.выбран = true;
           
            клКалендарь.isNull = true;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
