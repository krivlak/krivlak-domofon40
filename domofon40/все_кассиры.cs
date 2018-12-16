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
    public partial class все_кассиры : Form
    {
        public все_кассиры()
        {
            InitializeComponent();
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        private void все_кассиры_Load(object sender, EventArgs e)
        {
            try
            {
                
                foreach (сотрудники mm in de.сотрудники.OrderBy(n => n.порядок))
                {
                    int всегоОплат = mm.оплаты.Count;
                    //  int оплат = mm.оплаты.Count(n => n.дата == клКалендарь.дата.Value);
                    if (mm.кассир || всегоОплат > 0)
                    {
                        TreeNode node1 = treeView1.Nodes.Add(mm.фио.Trim());
                        node1.Tag = mm;
                        if (mm.сотрудник == клСотрудник.сотрудник)
                        {
                            treeView1.SelectedNode = node1;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Сбой загрузки " + ex.Message);
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
