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
    public partial class выбор_мастера : Form
    {
        public выбор_мастера()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        private void выбор_мастера_Load(object sender, EventArgs e)
        {
            foreach (var mm in de.сотрудники
                .OrderBy(n=>n.уволен)
           .ThenBy(n => n.порядок))
            {
                TreeNode node1 = treeView1.Nodes.Add(mm.фио.Trim() + "   " + mm.должность);
                node1.Tag = mm;
                if (mm.уволен!=null)
                {
                    node1.BackColor = Color.LightBlue;
                }

                if (mm.сотрудник == клМастер.мастер)
                {
                    treeView1.SelectedNode = node1;
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            клМастер.deRow = (сотрудники)e.Node.Tag;
            клМастер.мастер = клМастер.deRow.сотрудник;
            клМастер.фио = клМастер.deRow.фио;
            клМастер.фамилия = клМастер.deRow.фамилия;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            клМастер.выбран = true;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Close();
        }
    }
}
