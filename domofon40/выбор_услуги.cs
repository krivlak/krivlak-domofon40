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
    public partial class выбор_услуги : Form
    {
        public выбор_услуги()
        {
            InitializeComponent();
        }

        private void выбор_услуги_Load(object sender, EventArgs e)
        {
            try
            {

                domofon40.domofon14Entities de = new domofon14Entities();

                foreach (var gg in de.услуги.
                    OrderBy(n => n.виды_услуг.порядок)
                    .ThenBy(n => n.порядок))
                {
                    TreeNode node = this.treeView1.Nodes.Add(gg.наимен);
                    node.Tag = gg;
                    if (gg.услуга == клУслуга.услуга)
                    {
                        treeView1.SelectedNode = node;
                    }

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Сбой загрузки {ex.Message}");
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            клУслуга.deRow = (услуги)e.Node.Tag;
            клУслуга.услуга = клУслуга.deRow.услуга;
            клУслуга.наимен = клУслуга.deRow.наимен;
            клУслуга.обозначение = клУслуга.deRow.обозначение;
            клУслуга.порядок = клУслуга.deRow.порядок;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            клУслуга.выбран = true;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        
            Close();
        }
    }
}
