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
    public partial class выбор_периода : Form
    {
        public выбор_периода()
        {
            InitializeComponent();
        }

        private void выбор_периода_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = клПериод.дата_с;
            dateTimePicker2.Value = клПериод.дата_по;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            клПериод.дата_с = dateTimePicker1.Value;
            клПериод.дата_по = dateTimePicker2.Value;
            клПериод.выбран = true;
            Close();
        }
    }
}
