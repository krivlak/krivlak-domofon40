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
    public partial class подключено_клиентов : Form
    {
        public подключено_клиентов()
        {
            InitializeComponent();
        }
        List<temp> tempList = new List<temp>();
        domofon40.domofon14Entities de = new domofon14Entities();
        private void подключено_клиентов_Load(object sender, EventArgs e)
        {
            tempList  = de.услуги
                .OrderBy(n=>n.виды_услуг.порядок)
                .ThenBy(n=>n.порядок)
              .Select(n => new temp
              { услуга = n.услуга, наимен = n.наимен, подключений = n.клиенты.Count }).ToList();
                 
            bindingSource1.DataSource= tempList;
            
        }
        class temp
        {
            public Guid услуга { get; set; }
            public string наимен { get; set; }
            public int подключений { get; set; } = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Environment.UserName);
        }
    }
}
