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
    public partial class выбор_жителя : Form
    {
        public выбор_жителя()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities db = new domofon14Entities();
        private void выбор_жителя_Load(object sender, EventArgs e)
        {
            foreach (var gg in db.поселки.OrderBy(n => n.порядок))
            {
                TreeNode node = this.treeView1.Nodes.Add(gg.наимен);
                node.Tag = gg.поселок;

                foreach (var mm in db.улицы.Where(n => n.поселок == gg.поселок).OrderBy(n => n.наимен))
                {
                    TreeNode node1 = node.Nodes.Add(mm.наимен);
                    node1.Tag = mm;
                    foreach (var dd in mm.дома
                        .OrderBy(n => n.номер)
                        .ThenBy(n => n.корпус))
                    {
                        TreeNode node2 = node1.Nodes.Add(dd.номер.ToString().Trim() + " " + dd.корпус.Trim());
                        node2.Tag = dd;
                        foreach (var kk in dd.клиенты.OrderBy(n => n.квартира))
                        {
                            if (kk.ввод > 0)
                            {
                                TreeNode node3 = node2.Nodes.Add("кв. "
                          + kk.квартира.ToString().PadRight(3)
                          + " ввод " + kk.ввод.ToString().PadRight(3) + " "
                          + kk.фамилия.Trim() + " "
                          + kk.имя.Trim() + " "
                          + kk.отчество.Trim());
                                node3.Tag = kk;
                                if (kk.клиент == клКлиент.клиент)
                                {
                                    treeView1.SelectedNode = node3;
                                }

                            }
                            else
                            {
                                TreeNode node3 = node2.Nodes.Add("кв. "
                                    + kk.квартира.ToString().PadRight(3) + " "
                                    + kk.фамилия.Trim() + " "
                                    + kk.имя.Trim() + " "
                                    + kk.отчество.Trim());
                                node3.Tag = kk;
                                if (kk.клиент == клКлиент.клиент)
                                {
                                    treeView1.SelectedNode = node3;
                                }
                            }
                        }
                    }
                }

            }

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            button2.Enabled = false;
            textBox1.Text = "";

            if (e.Node.Level == 3)
            {
                button2.Enabled = true;

                клКлиент.deRow = (клиенты)e.Node.Tag;
                клКлиент.клиент = клКлиент.deRow.клиент;
                клКлиент.фио = клКлиент.deRow.фио;
                textBox1.Text = клКлиент.клиент.ToString();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (клКлиент.deRow.звонки.Any())
                MessageBox.Show("Удалите звонки");

            if (клКлиент.deRow.оплаты.Any())
                MessageBox.Show("Удалите оплаты");

            if (клКлиент.deRow.отключения.Any())
                MessageBox.Show("Удалите отключения");

            if (клКлиент.deRow.повторы.Any())
                MessageBox.Show("Удалите повторные включения");

            if (клКлиент.deRow.подключения.Any())
                MessageBox.Show("Удалите договора");

            //if (клКлиент.deRow.пре.Any())
            //    MessageBox.Show("Удалите предупреждения");

            if (клКлиент.deRow.примечания.Any())
                MessageBox.Show("Удалите примечания");

            if (клКлиент.deRow.простои.Any())
                MessageBox.Show("Удалите простои");

            if (клКлиент.deRow.раб_дней.Any())
                MessageBox.Show("Удалите рабочие дни");

            //if (клКлиент.deRow.разрешения.Any())
            //    MessageBox.Show("Удалите разрешения");

            if (клКлиент.deRow.услуги.Any())
                MessageBox.Show("Удалите отметку Наш клиент");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
