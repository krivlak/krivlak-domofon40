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
    public partial class удаленные1оплаты : Form
    {
        public удаленные1оплаты()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        List<temp> tempList = new List<temp>();
        List<temp2> temp2List = new List<temp2>();
        List<temp2> temp22List = new List<temp2>();

        private void удаленные1оплаты_Load(object sender, EventArgs e)
        {
            string текст = "select del_оплаты.* , сотрудники.фио as менеджер "
            +"from del_оплаты inner join сотрудники on del_оплаты.сотрудник= сотрудники.сотрудник "
            +"Where del_оплаты.клиент='"+клКлиент.клиент.ToString()+"'"
            +"  order by del_оплаты.дата, del_оплаты.номер ";
                

            tempList = de.Database.SqlQuery<temp>(текст).ToList();
            bindingSource1.DataSource = tempList;

            string sqlComm = "SELECT del_оплачено.*, услуги.наимен FROM del_оплачено   inner join услуги   on del_оплачено.услуга=услуги.услуга order by услуги.наимен, del_оплачено.год, del_оплачено.месяц";
            temp2List = de.Database.SqlQuery<temp2>(sqlComm).ToList();
            bindingSource2.DataSource = temp2List;

            bindingSource1.PositionChanged += bindingSource1_PositionChanged;

            bindingSource1.MoveLast();
            if (bindingSource1.Count==1)
            {
                temp tRow = bindingSource1.Current as temp;
                Guid кодОплаты = tRow.оплата;
                temp22List = temp2List.FindAll(n => n.оплата == кодОплаты);
                bindingSource2.DataSource = temp22List;
                dataGridView2.Refresh();
            }
            if (bindingSource1.Count==0)
            {
                temp22List.Clear();
                bindingSource2.DataSource = temp22List;
                dataGridView2.Refresh();
            }

            dataGridView1.Focus();
        }

        void bindingSource1_PositionChanged(object sender, EventArgs e)
        {
            temp tRow = bindingSource1.Current as temp;
            Guid кодОплаты = tRow.оплата;
            temp22List = temp2List.FindAll(n => n.оплата == кодОплаты);
            bindingSource2.DataSource = temp22List;
            dataGridView2.Refresh();
        }

        public  class temp
        {
            public System.Guid оплата { get; set; }
            public int номер { get; set; }
            public System.Guid клиент { get; set; }
            public System.Guid сотрудник { get; set; }
            public System.DateTime удалена { get; set; }
            public System.DateTime дата { get; set; }
            public String менеджер { get; set; }
        }

        public  class temp2
        {
            public int код { get; set; }
            public System.Guid оплата { get; set; }
            public int месяц { get; set; }
            public int год { get; set; }
            public int сумма { get; set; }
            public System.Guid услуга { get; set; }
            public System.DateTime дата { get; set; }
            public string наимен { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
