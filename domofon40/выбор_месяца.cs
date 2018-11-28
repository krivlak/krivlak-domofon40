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
    public partial class выбор_месяца : Form
    {
        public выбор_месяца()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        private void выбор_месяца_Load(object sender, EventArgs e)
        {

            foreach (var gg in de.годы)
            {
                TreeNode node = this.treeView1.Nodes.Add(gg.год.ToString(), gg.год.ToString());
                node.Tag = gg.год;

                foreach (var mm in de.месяцы)
                {
                    TreeNode node1 = node.Nodes.Add(mm.наимен);
                    node1.Tag = mm.месяц;
                    if (gg.год == клМесяц.год && mm.месяц == клМесяц.месяц)
                    {
                        treeView1.SelectedNode = node1;
                    }
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            клМесяц.выбран = true;
            this.Close();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            button1.Enabled = false;
            if (e.Node.Level == 1)
            {
                button1.Enabled = true;
                клМесяц.месяц = (int)e.Node.Tag;
                клМесяц.год = (int)e.Node.Parent.Tag;
                клМесяц.наимен = e.Node.Text;

            }
        }
    }
}
