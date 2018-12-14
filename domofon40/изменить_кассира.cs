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
    public partial class изменить_кассира : Form
    {
        public изменить_кассира()
        {
            InitializeComponent();
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
        }

        domofon40.domofon14Entities de = new domofon14Entities();
        private void изменить_кассира_Load(object sender, EventArgs e)
        {
            foreach (var mm in de.сотрудники
                 .Where(n => n.кассир)
                 .OrderBy(n => n.порядок))
            {
                TreeNode node1 = treeView1.Nodes.Add(mm.фио);
                node1.Tag = mm;
                if (mm.сотрудник == клКассир.сотрудник)
                {
                    treeView1.SelectedNode = node1;
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            клКассир.deRow = (сотрудники)e.Node.Tag;
            клКассир.сотрудник = клКассир.deRow.сотрудник;
            клКассир.фио = клКассир.deRow.фио;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            клКассир.выбран = true;
            Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
