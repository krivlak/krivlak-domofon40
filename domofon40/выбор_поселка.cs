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
    public partial class выбор_поселка : Form
    {
        public выбор_поселка()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void выбор_поселка_Load(object sender, EventArgs e)
        {
            domofon40.domofon14Entities de = new domofon14Entities();
            foreach (var gg in de.поселки.OrderBy(n => n.порядок))
            {
                TreeNode node = this.treeView1.Nodes.Add( gg.наимен);
                node.Tag = gg;
                if (gg.поселок == клПоселок.поселок)
                {
                    treeView1.SelectedNode = node;
                }

            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            клПоселок.deRow = (поселки)e.Node.Tag;
            клПоселок.поселок = клПоселок.deRow.поселок;
            клПоселок.наимен = клПоселок.deRow.наимен;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            клПоселок.выбран = true;
            Close();
        }
    }
}
