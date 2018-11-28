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
    public partial class мыло_подробности : Form
    {
        public мыло_подробности()
        {
            InitializeComponent();
        }

        private void мыло_подробности_Load(object sender, EventArgs e)
        {
            textBox5.Text = клРазрешение.все_телефоны;
            textBox1.Text = клРазрешение.телефон;
            textBox2.Text = клРазрешение.эл_почта;
            textBox3.Text = клРазрешение.дата_с.ToShortDateString();
            textBox4.Text = клРазрешение.номер.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
