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
    public partial class удаленные_оплаты : Form
    {
        public удаленные_оплаты()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        List<temp> tempList = new List<temp>();
        List<temp> temp1List = new List<temp>();
        List<temp2> temp2List = new List<temp2>();
        List<temp2> temp22List = new List<temp2>();
        private void удаленные_оплаты_Load(object sender, EventArgs e)
        {
            string текст = "select del_оплаты.* , сотрудники.фио as менеджер, клиенты.фио as абонент "
           + " from del_оплаты inner join сотрудники "
            +" on del_оплаты.сотрудник= сотрудники.сотрудник "
            + "inner join клиенты on del_оплаты.клиент=клиенты.клиент "
            +" order by del_оплаты.дата, del_оплаты.номер ";
            //+ клКлиент.клиент.ToString() + "'";

            tempList = de.Database.SqlQuery<temp>(текст).ToList();
            bindingSource1.DataSource = tempList;

            string sqlComm = "SELECT del_оплачено.*, услуги.наимен FROM del_оплачено   inner join услуги   on del_оплачено.услуга=услуги.услуга order by услуги.наимен, del_оплачено.год, del_оплачено.месяц";
            temp2List = de.Database.SqlQuery<temp2>(sqlComm).ToList();
            bindingSource2.DataSource = temp2List;

            bindingSource1.PositionChanged += bindingSource1_PositionChanged;

            bindingSource1.MoveLast();
            dataGridView1.Focus();
 
        }
        void bindingSource1_PositionChanged(object sender, EventArgs e)
        {
            temp tRow = bindingSource1.Current as temp;
            Guid кодОплаты = tRow.оплата;
            клиенты kRow = de.клиенты.Single(n => n.клиент == tRow.клиент);

       //     label1.Text = kRow.дома.ToString()+" кв "+kRow.квартира.ToString()+" ввод "+kRow.ввод.ToString() ;
            label1.Text = kRow.адрес;
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count==0)
            {
                return;
            }
            temp tRow = bindingSource1.Current as temp;
            клКлиент.клиент = tRow.клиент;
            клКлиент.выбран = false;
            Cursor = Cursors.WaitCursor;
            выбор_клиента ВыборКлиента = new выбор_клиента();


            ВыборКлиента.ShowDialog();
            Cursor = Cursors.Default;
            if (клКлиент.выбран)
            {
                temp1List = tempList.FindAll(n => n.клиент == клКлиент.клиент);
                if (temp1List.Count > 0)
                {
                    bindingSource1.DataSource = temp1List;
                    dataGridView1.Refresh();
                }
                else
                {
                    MessageBox.Show(клКлиент.фио + " нет удаленных зпаписей ");
                    bindingSource1.DataSource = tempList;
                    bindingSource1.MoveLast();
                    dataGridView1.Refresh();
                }
            }
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bindingSource1.DataSource = tempList;
            bindingSource1.MoveLast();
            dataGridView1.Refresh();
        }

    }
}
