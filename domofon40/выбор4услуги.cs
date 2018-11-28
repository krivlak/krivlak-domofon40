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
    public partial class выбор4услуги : Form
    {
        public выбор4услуги()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        BindingList<temp> tempList = new BindingList<temp>();

        private void выбор4услуги_Load(object sender, EventArgs e)
        {
            foreach(услуги uRow in de.услуги
                .OrderBy(n=>n.виды_услуг.порядок)
                .ThenBy(n=>n.порядок))
            {
                temp newTemp = new temp();
                newTemp.наимен = uRow.наимен;
                newTemp.услуга = uRow.услуга;
                tempList.Add(newTemp);
            }
            Dictionary<Guid, temp> dicTemp = tempList.ToDictionary(n => n.услуга);
            клиенты kRow = de.клиенты.Single(n=>n.клиент==клКлиент.клиент);
            foreach (услуги uRow in  kRow.услуги)
            {
                dicTemp[uRow.услуга].наш = true;
            }
            
            foreach(подключения uRow in kRow.подключения.OrderBy(n=>n.дата_с))
            {
                dicTemp[uRow.услуга].договор_с = uRow.дата_с;
                dicTemp[uRow.услуга].номер_дог = uRow.номер_пп;
            }
            
            foreach(отключения uRow in kRow.отключения.OrderBy(n=>n.дата_с))
            {
                dicTemp[uRow.услуга].отключен = uRow.дата_с;
            }
            
            foreach(повторы uRow in kRow.повторы.OrderBy(n=>n.дата_с))
            {

                dicTemp[uRow.услуга].повторно = uRow.дата_с;
            }

            foreach (примечания uRow in kRow.примечания)
            {
                dicTemp[uRow.услуга].прим = uRow.прим;
            }

            foreach(оплаты  uRow in kRow.оплаты.OrderBy(n=>n.дата))
            {
                foreach(оплачено tRow in uRow.оплачено.OrderBy(n=>n.год*100+n.месяц))
                {
                    dicTemp[tRow.услуга].год = tRow.год;
                    dicTemp[tRow.услуга].месяц = tRow.месяц;
                }
            }

            //foreach(temp tRow in tempList)
            //{
            //    if(tRow.повторно<tRow.отключен)
            //    {
            //        tRow.повторно = null;
            //    }
            //}


            temp.следить = true;
            bindingSource1.DataSource = tempList;

            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
        }

        void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex]==примColumn)
            {
               
                temp tRow = bindingSource1.Current as temp;
                if(tRow.прим==null)
                {
                    tRow.прим = "";
                }
                примечания[] aDel = de.примечания
                    .Where(n => n.клиент == клКлиент.клиент)
                    .Where(n => n.услуга == tRow.услуга)
                    .ToArray();
                foreach(примечания dRow in aDel)
                {
                    de.примечания.Remove(dRow);
                }
                de.SaveChanges();
                
                if(tRow.прим.Trim() != String.Empty)
                {
                    примечания newRow = new примечания();
                    newRow.клиент = клКлиент.клиент;
                    newRow.услуга = tRow.услуга;
                    newRow.прим = tRow.прим.Trim();
                    de.примечания.Add(newRow);
                    de.SaveChanges();
                }


            }

            if (dataGridView1.Columns[e.ColumnIndex] == нашColumn)
            {

                temp tRow = bindingSource1.Current as temp;

                клиенты kRow = de.клиенты.Single(n => n.клиент == клКлиент.клиент);
                услуги[] aDel = kRow.услуги.Where(n => n.услуга == tRow.услуга).ToArray();
                foreach (услуги dRow in aDel)
                {
                    kRow.услуги.Remove(dRow);
                }
                de.SaveChanges();

                if (tRow.наш)
                {
                    услуги newRow = de.услуги.Single(n => n.услуга == tRow.услуга);
                    kRow.услуги.Add(newRow);

                    de.SaveChanges();
                }


            }
        }

   

        class temp
        {
            public Guid услуга { get; set; }
            public String наимен { get; set; }
            public bool наш { get; set; }
            public int год { get; set; }
            public int месяц { get; set; }
            public int номер_дог { get; set; }
            public DateTime договор_с { get; set; }

            public string прим{ get; set; }
            public DateTime отключен { get; set; }
            public DateTime повторно { get; set; }
            public static bool следить = false;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count>0)
            {
                temp uRow = bindingSource1.Current as temp;
                клУслуга.услуга = uRow.услуга;
                клУслуга.подключена = uRow.наш;
                клУслуга.выбран = true;
                клУслуга.deRow = de.услуги.Single(n => n.услуга == клУслуга.услуга);
            }
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close(); 
        }
    }
}
