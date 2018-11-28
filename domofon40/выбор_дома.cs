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
    public partial class выбор_дома : Form
    {
        public выбор_дома()
        {
            InitializeComponent();
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
        }

        private void выбор_улицы_Load(object sender, EventArgs e)
        {
         
            domofon40.domofon14Entities de = new domofon40.domofon14Entities();
            foreach (var gg in de.поселки.OrderBy(n=>n.порядок))
            {
                TreeNode node = this.treeView1.Nodes.Add( gg.наимен);
                node.Tag = gg.поселок;

                foreach (var mm in de.улицы.Where(n=>n.поселок==gg.поселок)
                    .OrderBy(n=>n.наимен))
                {
                    TreeNode node1 = node.Nodes.Add(mm.наимен);
                    node1.Tag = mm;
                    foreach (var dd in mm.дома
                        .OrderBy(n=>n.номер)
                        .ThenBy(n=>n.корпус))
                    {
                        TreeNode node2 = node1.Nodes.Add(dd.номер.ToString().PadRight(2)+" "+dd.корпус);
                            //+ " "+dd.изменен.ToShortDateString()
                            //+ " "+dd.изменен.ToLongTimeString());
                        node2.Tag = dd;
                        //DateTime датаПечати = DateTime.Now.AddHours(1);
                        //if (dd.изменен > датаПечати)
                        //{
                        //    node2.BackColor = Color.FromArgb(255, 200, 200);
                        //}
                        if (dd.дом == клДом.дом)
                        {
                            treeView1.SelectedNode = node2;
                        }

                    }
                }

            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            button1.Enabled = false;
            if (e.Node.Level == 2)
            {
                клДом.deRow = (дома)e.Node.Tag;
                клДом.дом = клДом.deRow.дом;
                клДом.номер = клДом.deRow.номер;
                клДом.корпус = клДом.deRow.корпус;
                клУлица.улица = клДом.deRow.улица;
                клУлица.наимен = клДом.deRow.улицы.наимен;
                button1.Enabled = true;
           
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            клДом.выбран = true;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
