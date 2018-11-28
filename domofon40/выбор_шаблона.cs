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
    public partial class выбор_шаблона : Form
    {
        public выбор_шаблона()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        private void выбор_шаблона_Load(object sender, EventArgs e)
        {
            de.шаблоны.OrderBy(n => n.наимен).Load();
            bindingSource1.DataSource = de.шаблоны.Local.ToBindingList();
            dataGridView1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            шаблоны uRow = bindingSource1.Current as шаблоны;
            клШаблон.выбран = true;
            клШаблон.путь = uRow.путь;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
