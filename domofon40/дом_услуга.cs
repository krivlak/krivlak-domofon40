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
    public partial class дом_услуга : Form
    {
        public дом_услуга()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        private void дом_услуга_Load(object sender, EventArgs e)
        {
            
            foreach (var gg in de.поселки.OrderBy(n => n.порядок))
            {
                TreeNode node = this.treeView1.Nodes.Add( gg.наимен);
                node.Tag = gg.поселок;

                foreach (var mm in de.улицы.Where(n => n.поселок == gg.поселок).OrderBy(n => n.наимен))
                {
                    TreeNode node1 = node.Nodes.Add(mm.наимен);
                    node1.Tag = mm;
                    foreach (var dd in mm.дома
                        .OrderBy(n => n.номер)
                        .ThenBy(n => n.корпус))
                    {
                        TreeNode node2 = node1.Nodes.Add(dd.номер.ToString() + dd.корпус);
                        node2.Tag = dd;
                        if (dd.дом == клДом.дом)
                        {
                            treeView1.SelectedNode = node2;
                        }

                    }
                }

            }

            if (клУслуга.услуга == Guid.Empty)
            {
                клУслуга.услуга = de.услуги.OrderBy(n => n.порядок).First().услуга;
            }


            foreach (услуги uRow in de.услуги
                             .OrderBy(n => n.виды_услуг.порядок)
                             .ThenBy(n=>n.порядок))
            {
                TreeNode node2 = treeView2.Nodes.Add(uRow.наимен);
                node2.Tag = uRow;
                if (uRow.услуга == клУслуга.услуга)
                {
                    treeView2.SelectedNode = node2;
                }

            }
            treeView2.Select();
            treeView1.Select();

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            button1.Enabled = false;
            if (e.Node.Level == 2)
            {
                button1.Enabled = true;
                клДом.deRow = (дома)e.Node.Tag;
                клДом.дом = клДом.deRow.дом;
                клДом.номер = клДом.deRow.номер;
                клДом.корпус = клДом.deRow.корпус;
            }
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            клУслуга.deRow = (услуги)e.Node.Tag;
            клУслуга.услуга = клУслуга.deRow.услуга;
            клУслуга.наимен = клУслуга.deRow.наимен;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            должники_дом формаКвартиры = new должники_дом();
            формаКвартиры.Text = "Задолженность за "
            + клУслуга.наимен.Trim()
            + " в доме № "
                + клДом.номер.ToString() + клДом.корпус
                + " по улице " + клДом.deRow.улицы.наимен;
            формаКвартиры.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
