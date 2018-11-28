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
    public partial class отметитьVуслуги : Form
    {
        public отметитьVуслуги()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        BindingList<temp> tempBind = new BindingList<temp>();

        private void отметитьVуслуги_Load(object sender, EventArgs e)
        {
            foreach (услуги uRow in клВид_услуги.deRow.услуги
                .OrderBy(n => n.порядок))
            {
                temp newRow = new temp();
                newRow.выбран=true;
                newRow.наимен=uRow.наимен;
                newRow.обозначение = uRow.обозначение;
                newRow.услуга=uRow.услуга;

                if (клВид_услуги.dictУслуг.Any())
                {
                    if (!клВид_услуги.dictУслуг.ContainsKey(uRow.услуга))
                    {
                        newRow.выбран = false;
                    }
                }
                tempBind.Add(newRow);
            }
            bindingSource1.DataSource = tempBind;

        }

        public partial class temp
        {
            public Guid услуга { get; set; }
            public string наимен { get; set; }
            public string обозначение { get; set; }
            public bool выбран { get; set; }
         //   public Guid вид_услуги { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            клВид_услуги.dictУслуг.Clear();
            foreach (var uRow in  tempBind 
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
