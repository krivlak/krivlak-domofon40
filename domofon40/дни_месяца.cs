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
    public partial class дни_месяца : Form
    {
        public дни_месяца()
        {
            InitializeComponent();
         //   this.Height = Screen.PrimaryScreen.WorkingArea.Height;
        }

        private void дни_месяца_Load(object sender, EventArgs e)
        {
            клСетка.задать_ширину(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
