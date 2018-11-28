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
    public partial class удаленные1месяца : Form
    {
        public удаленные1месяца()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        List<temp> tempList = new List<temp>();

        List<temp2> temp2List = new List<temp2>();
        List<temp2> temp22List = new List<temp2>();
        private void удаленные1месяца_Load(object sender, EventArgs e)
        {
            string sqlComm = "select DISTINCT оплаты.оплата, "
             + "оплаты.дата, "
             + "оплаты.номер, "
             + "сотрудники.фио as менеджер, "
             + "клиенты.фио  as абонент ,"
            + "оплаты.клиент "
             + "from оплаты "
            + "inner join del_оплачено "
            + "on оплаты.оплата = del_оплачено.оплата "
            + "inner join сотрудники "
            + "on оплаты.сотрудник=сотрудники.сотрудник "
            + "inner join клиенты "
            + "on клиенты.клиент= оплаты.клиент "
            + "where оплаты.клиент='" + клКлиент.клиент.ToString() + "'"
            + " order by оплаты.дата, оплаты.номер ";

            string sqlComm2 = "select d.дата,d.оплата,d.месяц,d.год,d.сумма,услуги.наимен "
                            + "from del_оплачено as d "
                            + "inner join оплаты "
                            + "on d.оплата=оплаты.оплата "
                            + "inner join услуги "
                            + "on d.услуга =услуги.услуга ";

            try
            {
                tempList = de.Database.SqlQuery<temp>(sqlComm).ToList();
                bindingSource1.DataSource = tempList;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Сбой загрузки оплаты " + ex.Message);
            }
            try
            {
                temp2List = de.Database.SqlQuery<temp2>(sqlComm2).ToList();
                bindingSource2.DataSource = temp2List;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сбой загрузки оплачено " + ex.Message);
            }

            bindingSource1.PositionChanged += bindingSource1_PositionChanged;
            bindingSource1.MoveLast();
            if (bindingSource1.Count==1)
            {
                temp tRow = bindingSource1.Current as temp;
                Guid кодОплаты = tRow.оплата;
                //клиенты kRow = de.клиенты.Single(n => n.клиент == tRow.клиент);

                //label1.Text = kRow.адрес;

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
            //клиенты kRow = de.клиенты.Single(n => n.клиент == tRow.клиент);

            //label1.Text = kRow.адрес;

            temp22List = temp2List.FindAll(n => n.оплата == кодОплаты);
            bindingSource2.DataSource = temp22List;
            dataGridView2.Refresh();
        }

        public class temp
        {
            public System.Guid оплата { get; set; }
            public int номер { get; set; }
            public System.Guid клиент { get; set; }
            public System.Guid сотрудник { get; set; }
            public System.DateTime удалена { get; set; }
            public System.DateTime дата { get; set; }
            public String менеджер { get; set; }
            public String абонент { get; set; }
        }

        public class temp2
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
