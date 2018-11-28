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
    public partial class выбор_кассира : Form
    {
        public выбор_кассира()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        private void выбор_кассира_Load(object sender, EventArgs e)
        {
            foreach (var mm in de.сотрудники
                  .Where(n => n.кассир)
                  .OrderBy(n => n.порядок))
            {
                TreeNode node1 = treeView1.Nodes.Add(mm.фио);
                node1.Tag = mm;
                if (mm.сотрудник == клСотрудник.сотрудник)
                {
                    treeView1.SelectedNode = node1;
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            клСотрудник.deRow = (сотрудники)e.Node.Tag;
            клСотрудник.сотрудник = клСотрудник.deRow.сотрудник;
            клСотрудник.фио = клСотрудник.deRow.фио;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            клСотрудник.выбран = true;
            Close();
        }
    }
}
