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
    public partial class выбор_подъезда : Form
    {
        public выбор_подъезда()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        private void выбор_подъезда_Load(object sender, EventArgs e)
        {
            var query = de.клиенты
              .Where(n => n.дом == клДом.дом)
              .GroupBy(n => n.подъезд)
              .Select(n => new { подъезд =n.Key , квартир = n.Count()})
              .ToList();

            foreach (var uRow in query)
            {
                TreeNode node = this.treeView1.Nodes.Add(uRow.подъезд.ToString(), uRow.подъезд.ToString() + "  " + uRow.квартир.ToString() + " квартир");
                node.Tag = uRow.подъезд;

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            клПодъезд.подъезд = (int)e.Node.Tag;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            клПодъезд.выбран = true;
            Close();
        }
    }
}
