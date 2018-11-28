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
    public partial class все1кассиры : Form
    {
        public все1кассиры()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
  //      List<temp> tempList = new List<temp>();
        private void все1кассиры_Load(object sender, EventArgs e)
        {
            //foreach(сотрудники uRow in de.сотрудники.OrderBy(n=>n.порядок))
            //{
            //    temp newTemp = new temp();
            //    newTemp.сотрудник = uRow.сотрудник;
            //    newTemp.фио = uRow.фио;
            //    newTemp.продаж = uRow.оплаты.Count(n => n.дата == клКалендарь.дата);
            //    if(uRow.кассир || uRow.оплаты.Count>0)
            //    {
            //        tempList.Add(newTemp);
            //    }

            //}

            //tempList = de.оплаты
            //             .GroupBy(n => n.сотрудники)
            //             .Select(n => new temp
            //             {
            //                 продаж = 0,
            //                 сотрудник = n.Key.сотрудник,
            //                 фио = n.Key.фио
            //             }).ToList();


            //var query = de.оплаты
            //             .Where(n=>n.дата==клКалендарь.дата.Value)
            //             .GroupBy(n => n.сотрудники);


            foreach (сотрудники mm in de.сотрудники.OrderBy(n => n.порядок))
            {
                int всегоОплат = mm.оплаты.Count;
                int оплат = mm.оплаты.Count(n => n.дата == клКалендарь.дата.Value);
                if (mm.кассир || всегоОплат > 0)
                {
                    TreeNode node1 = treeView1.Nodes.Add(mm.фио.PadRight(30) + "  " + оплат.ToString("0;#;#"));
                    node1.Tag = mm;
                    if (mm.сотрудник == клСотрудник.сотрудник)
                    {
                        treeView1.SelectedNode = node1;
                    }
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

        class temp
        {
            public Guid сотрудник { get; set; }
            public string фио { get; set; }
            public int продаж { get; set; }
        }
    }
}
