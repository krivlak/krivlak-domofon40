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
    public partial class выбор2менеджера : Form
    {
        public выбор2менеджера()
        {
            InitializeComponent();
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        private void выбор2менеджера_Load(object sender, EventArgs e)
        {
            //var query = de.оплаты
            //  .Where(n => n.дата == клКалендарь.дата.Value)
            //  .GroupBy(n => n.сотрудник)
            //  .Select(n => new { сотрудник = n.Key, оплат = n.Count() })
            //  .ToDictionary(n => n.сотрудник);

            foreach (var mm in de.сотрудники
                 .Where(n => n.кассир)
                 .OrderBy(n => n.порядок))
            {
               
                string текст = mm.фио;
                
                TreeNode node1 = treeView1.Nodes.Add(текст);
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

        private void button1_Click(object sender, EventArgs e)
        {
            клСотрудник.выбран = true;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
