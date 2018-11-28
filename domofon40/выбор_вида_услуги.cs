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
    public partial class выбор_вида_услуги : Form
    {
        public выбор_вида_услуги()
        {
            InitializeComponent();
        }

        private void выбор_вида_услуги_Load(object sender, EventArgs e)
        {
            domofon40.domofon14Entities de = new domofon14Entities();
            foreach (var gg in de.виды_услуг.OrderBy(n => n.порядок))
            {
                TreeNode node = this.treeView1.Nodes.Add(gg.вид_услуги.ToString(), gg.наимен);
                node.Tag = gg;
                if (gg.вид_услуги == клВид_услуги.вид_услуги)
                {
                    treeView1.SelectedNode = node;
                }

            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            клВид_услуги.deRow = (виды_услуг)e.Node.Tag;
            клВид_услуги.вид_услуги = клВид_услуги.deRow.вид_услуги;
            клВид_услуги.наимен = клВид_услуги.deRow.наимен;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            клВид_услуги.выбран = true;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
