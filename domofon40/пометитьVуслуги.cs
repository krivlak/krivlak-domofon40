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
    public partial class пометитьVуслуги : Form
    {
        public пометитьVуслуги()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        List<temp> listTemp = new List<temp>();
        private void пометитьVуслуги_Load(object sender, EventArgs e)
        {
            foreach (услуги uRow in de.услуги
                .Where(n=>n.вид_услуги==клВид_услуги.вид_услуги)
                .OrderBy(n=>n.порядок) )
            {
                temp NewClass = new temp();
                NewClass.услуга = uRow.услуга;
                NewClass.наимен = uRow.наимен;
                NewClass.обозначение = uRow.обозначение;
                NewClass.выбран = true;
                if (клВид_услуги.dictУслуг.Any())
                {
                    if (!клВид_услуги.dictУслуг.ContainsKey(uRow.услуга))
                    {
                        NewClass.выбран = false;
                    }
                }
                listTemp.Add(NewClass);
            }
            bindingSource1.DataSource = listTemp;
        }
        partial class temp
        {
            public Guid услуга { get; set; }
            public string наимен { get; set; }
            public string обозначение { get; set; }
            public bool  выбран { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            клВид_услуги.dictУслуг.Clear();
            foreach (temp uRow in listTemp
                .Where(n => n.выбран))
            {
                клВид_услуги.dictУслуг.Add(uRow.услуга, true);
            }
        
            клВид_услуги.выбран = true;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
