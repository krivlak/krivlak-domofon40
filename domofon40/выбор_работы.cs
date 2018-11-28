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
    public partial class выбор_работы : Form
    {
        public выбор_работы()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        private void выбор_работы_Load(object sender, EventArgs e)
        {
            foreach (var gg in de.работы.OrderBy(n => n.порядок))
            {
                TreeNode node = this.treeView1.Nodes.Add( gg.прейскурант.Trim() + "  " + gg.наимен.Trim());
                node.Tag = gg;
                if (gg.работа == клРабота.работа)
                {
                    treeView1.SelectedNode = node;
                }

            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            клРабота.deRow = (работы)e.Node.Tag;
            клРабота.работа = клРабота.deRow.работа;
            клРабота.наимен = клРабота.deRow.наимен;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            клРабота.выбран = true;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
