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
    public partial class фильтр2 : Form
    {
        public фильтр2()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        BindingList<улицы> улицыЛист = new BindingList<улицы>();
        BindingList<дома> домаЛист = new BindingList<дома>();
        private void фильтр2_Load(object sender, EventArgs e)
        {
            de.улицы.OrderBy(n => n.наимен).Load();
            de.дома.OrderBy(n => n.номер).ThenBy(n => n.корпус).Load();
            улицыЛист = de.улицы.Local.ToBindingList();
            домаЛист = de.дома.Local.ToBindingList();
            bindingSource1.DataSource = улицыЛист;
            bindingSource2.DataSource = домаЛист;
            bindingSource1.PositionChanged += bindingSource1_PositionChanged;
        }

        void bindingSource1_PositionChanged(object sender, EventArgs e)
        {
            улицы uRow = bindingSource1.Current as улицы;
            bindingSource2.DataSource = uRow.дома;
         //   bindingSource2.Filter = "номер =1" ;
            //домаЛист = домаЛист.Where(n => n.улица == uRow.улица) as BindingList<дома>;
            //bindingSource2.DataSource = домаЛист;
            dataGridView2.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            улицы uRow = bindingSource1.Current as улицы;
            дома newRow = new дома();
            newRow.улица = uRow.улица;
            newRow.номер = 33;
            newRow.корпус = "hh";
            newRow.дом = Guid.NewGuid();
            newRow.изменен = DateTime.Now;
            //newRow.прим = "";
            //newRow.порядок = 0;
           
            //uRow.дома.Add(newRow);
            //bindingSource2.Add(newRow);
            //de.SaveChanges();
        }
    }
}
