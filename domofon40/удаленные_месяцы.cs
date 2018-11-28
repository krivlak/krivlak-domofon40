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
    public partial class удаленные_месяцы : Form
    {
        public удаленные_месяцы()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        List<temp> tempList = new List<temp>();
        List<temp> temp1List = new List<temp>();
        List<temp2> temp2List = new List<temp2>();
        List<temp2> temp22List = new List<temp2>();
        private void удаленные_месяцы_Load(object sender, EventArgs e)
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
             + "order by оплаты.дата, оплаты.номер ";
            //+ "where оплата.клиент=@клиент";

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
            catch (Exception ex)
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
            if(bindingSource1.Count==1)
            {
                обновить_месяца();
            }
            
            dataGridView1.Focus();
        }

        void bindingSource1_PositionChanged(object sender, EventArgs e)
        {
            //temp tRow = bindingSource1.Current as temp;
            //Guid кодОплаты = tRow.оплата;
            //клиенты kRow = de.клиенты.Single(n => n.клиент == tRow.клиент);

            //label1.Text = kRow.адрес;

            //temp22List = temp2List.FindAll(n => n.оплата == кодОплаты);
            //bindingSource2.DataSource = temp22List;
            //dataGridView2.Refresh();
            обновить_месяца();
        }

        void обновить_месяца()
        {
            temp tRow = bindingSource1.Current as temp;
            Guid кодОплаты = tRow.оплата;
            клиенты kRow = de.клиенты.Single(n => n.клиент == tRow.клиент);

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

        private void button3_Click(object sender, EventArgs e)
        {
            bindingSource1.DataSource = tempList;
            bindingSource1.MoveLast();
            dataGridView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count == 0)
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
    }
}
