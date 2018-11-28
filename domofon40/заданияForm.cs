using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Entity;

namespace domofon40
{
    public partial class заданияForm : Form
    {
        public заданияForm()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        private void заданияForm_Load(object sender, EventArgs e)
        {
            de.опл_работы
                .OrderBy(n => n.оплаты.дата)
                .ThenBy(n => n.оплаты.номер)
                .ThenBy(n => n.работы.порядок)
                .Load();
            bindingSource1.DataSource = de.опл_работы.Local.ToBindingList();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int j = 0;
            foreach (опл_работы uRow in de.опл_работы.Local)
            {
                j++;
                uRow.номер = j;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            de.SaveChanges();
        }
    }
}
