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
    public partial class новая1услуга : Form
    {
        public новая1услуга()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        private void новая1услуга_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = de.виды_услуг
                .OrderBy(n => n.порядок)
                .Select(n => new { n.вид_услуги, n.наимен })
                .ToList();
            comboBox1.ValueMember = "вид_услуги";
            comboBox1.DisplayMember = "наимен";
            comboBox1.SelectedValue = клВид_услуги.вид_услуги;
            textBox1.TextChanged += textBox1_TextChanged;
            textBox2.TextChanged += textBox1_TextChanged;
            comboBox1.SelectedValueChanged += textBox1_TextChanged;
        }

        void textBox1_TextChanged(object sender, EventArgs e)
        {
           button1.Enabled = false;
            if (textBox1.Text !=String.Empty 
                && textBox2.Text !=String.Empty
                && comboBox1.SelectedValue !=null)
            {
                button1.Enabled = true;
                Refresh();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Validate();
 
            клУслуга.услуга = Guid.NewGuid();
            клУслуга.наимен = textBox1.Text.Trim();
            клУслуга.обозначение = textBox2.Text.Trim();
            клВид_услуги.вид_услуги = (Guid) comboBox1.SelectedValue;
    //        клУслуга.выбран = true; 
      //      Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Close();
        }

    }
}
