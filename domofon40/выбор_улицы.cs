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
    public partial class выбор_улицы : Form
    {
        public выбор_улицы()
        {
            InitializeComponent();
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
        }

        private void выбор_улицы_Load(object sender, EventArgs e)
        {
            domofon14Entities de = new domofon14Entities();
           

            foreach (var gg in de.поселки.OrderBy(n => n.порядок))
            {
                TreeNode node = this.treeView1.Nodes.Add( gg.наимен);
              //  node.Tag = gg.поселок;

                foreach (var mm in de.улицы.Where(n => n.поселок == gg.поселок).OrderBy(n => n.наимен))
                {
                    TreeNode node1 = node.Nodes.Add(mm.наимен);
                    node1.Tag = mm;
                    if (mm.улица == клУлица.улица)
                    {
                        treeView1.SelectedNode = node1;
                    }
                }

            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            button1.Enabled = false;
            if (e.Node.Level == 1 && e.Node.Tag is улицы)
            {
                клУлица.deRow = (улицы) e.Node.Tag;
                клУлица.улица = клУлица.deRow.улица;
                клУлица.наимен = клУлица.deRow.наимен;
                button1.Enabled = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            клУлица.выбран = true;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
