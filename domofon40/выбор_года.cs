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
    public partial class выбор_года : Form
    {
        public выбор_года()
        {
            InitializeComponent();
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        private void выбор_года_Load(object sender, EventArgs e)
        {
          
            foreach (var gg in de.годы.OrderBy(n=>n.год))
            {
                TreeNode node = this.treeView1.Nodes.Add(gg.год.ToString(), gg.год.ToString());
                node.Tag = gg.год;
                if (gg.год == клМесяц.год)
                    treeView1.SelectedNode = node;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            клМесяц.выбран = true;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            клМесяц.год = (int)e.Node.Tag;
        }

     
    }
}
