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
    public partial class редактировать1услугу : Form
    {
        public редактировать1услугу()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        private void редактировать1услугу_Load(object sender, EventArgs e)
        {
            

            textBox1.Text = клУслуга.наимен;
            textBox2.Text = клУслуга.обозначение;

            textBox1.TextChanged += textBox1_TextChanged;
            textBox2.TextChanged += textBox1_TextChanged;
           
        }

        void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            if (textBox1.Text != String.Empty
                && textBox2.Text != String.Empty)
            {
                button1.Enabled = true;
                Refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Validate();

            клУслуга.наимен = textBox1.Text.Trim();
            клУслуга.обозначение = textBox2.Text.Trim();
        }
    }
}
