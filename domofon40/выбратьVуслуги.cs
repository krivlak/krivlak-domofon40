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
    public partial class выбратьVуслуги : Form
    {
        public выбратьVуслуги()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        List<temp> tempList = new List<temp>();
        private void выбратьVуслуги_Load(object sender, EventArgs e)
        {
            if( клУслуга.dictУслуг.Count==0)
            {
                клУслуга.заполнить_услуги();
            }
            foreach(услуги uRow in de.услуги
                .OrderBy(n=>n.виды_услуг.порядок)
                .ThenBy(n=>n.порядок))
            {
                temp newTemp = new temp();
                newTemp.услуга = uRow.услуга;
                newTemp.наимен_вида = uRow.виды_услуг.наимен;
                newTemp.наимен = uRow.наимен;
                newTemp.обозначение = uRow.обозначение;
                if (клУслуга.dictУслуг.ContainsKey(uRow.услуга))
                {
                    newTemp.выбрана = true;
                }
                tempList.Add(newTemp);
            }
            bindingSource1.DataSource = tempList;
            bindingSource1.ListChanged += bindingSource1_ListChanged;
          //  FormClosing += выбратьVуслуги_FormClosing;
        }

        void выбратьVуслуги_FormClosing(object sender, FormClosingEventArgs e)
        {
          
        }

        void bindingSource1_ListChanged(object sender, ListChangedEventArgs e)
        {
            label1.Visible = true;
        }
        class temp
        {
            public Guid услуга { get; set; }
            public string наимен_вида  { get; set; }
            public string наимен { get; set; }
            public string обозначение { get; set; }
            public bool выбрана { get; set; }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label1.Visible)
            {
                клУслуга.dictУслуг.Clear();
                foreach (temp uRow in tempList.Where(n => n.выбрана))
                {
                    клУслуга.dictУслуг.Add(uRow.услуга, true);
                }
            }
            Close();
        }
    }
}
