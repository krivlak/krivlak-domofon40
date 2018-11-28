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
    public partial class новый_клиент : Form
    {
        public новый_клиент()
        {
            InitializeComponent();
        }
        domofon14Entities db = new domofon14Entities();
        BindingList<temp> tempList = new BindingList<temp>();
        Dictionary<Guid , temp> dicTemp = new Dictionary<Guid, temp>();

        private void новый_клиент_Load(object sender, EventArgs e)
        {
            temp.обнулить();
            foreach (var gg in db.поселки.OrderBy(n => n.порядок))
            {
                TreeNode node = this.treeView1.Nodes.Add(gg.наимен);
                node.Tag = gg.поселок;

                foreach (var mm in db.улицы.Where(n => n.поселок == gg.поселок).OrderBy(n => n.наимен))
                {
                    TreeNode node1 = node.Nodes.Add(mm.наимен);
                    node1.Tag = mm;
                    foreach (var dd in mm.дома
                        .OrderBy(n => n.номер)
                        .ThenBy(n => n.корпус))
                    {
                        TreeNode node2 = node1.Nodes.Add(dd.номер.ToString().Trim() + " " + dd.корпус.Trim());
                        node2.Tag = dd;
                        foreach (var kk in dd.клиенты.OrderBy(n => n.квартира))
                        {
                            string ss = "";
                            if (kk.ввод > 0)
                            {
                                ss = " ввод " + kk.ввод.ToString("#;0;0").PadRight(3);
                            }
                            TreeNode node3 = node2.Nodes.Add("кв. "
                      + kk.квартира.ToString().PadRight(3)
                      + ss + " "
                      + kk.фамилия.Trim() + " "
                      + kk.имя.Trim() + " "
                      + kk.отчество.Trim());
                            node3.Tag = kk;
                            if (kk.клиент == клКлиент.клиент)
                            {
                                treeView1.SelectedNode = node3;
                            }

                            //}
                            //else
                            //{
                            //    TreeNode node3 = node2.Nodes.Add("кв. "
                            //        + kk.квартира.ToString().PadRight(3) + " "
                            //        + kk.фамилия.Trim() + " "
                            //        + kk.имя.Trim() + " "
                            //        + kk.отчество.Trim());
                            //    node3.Tag = kk;
                            //    //if (kk.клиент == клКлиент.клиент)
                            //    //{
                            //    //    treeView1.SelectedNode = node3;
                            //    //}
                            //}
                        }
                    }
                }

            }
            treeView1.CollapseAll();
            заполнитьЛист();
            bindingSource1.DataSource = tempList;
           
            textBox1.DataBindings.Add("Text", bindingSource1, "прим0");
            textBox2.DataBindings.Add("Text", bindingSource1, "звонок");
            dataGridView1.DataError += dataGridView1_DataError;
            
            temp.Событие += temp_Событие;

            //dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            //textBox1.TextChanged += textBox1_TextChanged;
            //textBox1.Validated += textBox1_Validated;
        }

        void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] == примColumn)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value==null)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                }
            }
        }

        void temp_Событие(новый_клиент.temp obj)
        {
            Console.WriteLine(obj.поле);
            if (obj.поле=="прим0")
            {
                клКлиент.deRow.прим = obj.прим0;
                db.SaveChanges();
            }
            if (obj.поле == "прим")
            {

                примечания[] delRows = клКлиент.deRow.примечания.Where(n => n.услуга == obj.услуга).ToArray();
                foreach (примечания dRow in delRows)
                {
                    клКлиент.deRow.примечания.Remove(dRow);
                    db.SaveChanges();
                }
                if (obj.прим != null)
                {
                    if (obj.прим.Trim() != String.Empty)
                    {
                        //                    услуги newRow = db.услуги.Single(n => n.услуга == uRow.услуга);
                        примечания newRow = new примечания();
                        newRow.клиент = клКлиент.клиент;
                        newRow.прим = obj.прим;
                        newRow.услуга = obj.услуга;

                        клКлиент.deRow.примечания.Add(newRow);
                    }
                    db.SaveChanges();
                }
            }
            if (obj.поле=="наш")
            {
                услуги[] delRows = клКлиент.deRow.услуги.Where(n => n.услуга == obj.услуга).ToArray();
                foreach (услуги dRow in delRows)
                {
                    клКлиент.deRow.услуги.Remove(dRow);
                    db.SaveChanges();
                }
                if (obj.наш)
                {
                    услуги newRow = db.услуги.Single(n => n.услуга == obj.услуга);
                    клКлиент.deRow.услуги.Add(newRow);
                }
                db.SaveChanges();
            }
        }

        void textBox1_Validated(object sender, EventArgs e)
        {
            if (label1.Visible)
            {
                if (textBox1.Text == null)
                {
                    textBox1.Text = "";
                }
                клКлиент.deRow.прим = textBox1.Text;
                db.SaveChanges();
            }
            label1.Visible = false;

        }

        void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Visible = true;
        }

        void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex]== нашColumn)
            {
                temp uRow = bindingSource1.Current as temp;
                Guid кодУслуги = uRow.услуга;
//                if(клКлиент.deRow.услуги.Count(n=>n.услуга==uRow.услуга)>0)
                услуги[] delRows = клКлиент.deRow.услуги.Where(n => n.услуга == uRow.услуга).ToArray();
                foreach(услуги dRow in delRows)
                {
                    клКлиент.deRow.услуги.Remove(dRow);
                    db.SaveChanges();
                }
                if(uRow.наш)
                {
                    услуги newRow = db.услуги.Single(n => n.услуга == uRow.услуга);
                    клКлиент.deRow.услуги.Add(newRow);
                }
                db.SaveChanges();
            }

            if (dataGridView1.Columns[e.ColumnIndex] == примColumn)
            {
                temp uRow = bindingSource1.Current as temp;
                Guid кодУслуги = uRow.услуга;
                //                if(клКлиент.deRow.услуги.Count(n=>n.услуга==uRow.услуга)>0)
                примечания[] delRows = клКлиент.deRow.примечания.Where(n => n.услуга == uRow.услуга).ToArray();
                foreach (примечания dRow in delRows)
                {
                    клКлиент.deRow.примечания.Remove(dRow);
                    db.SaveChanges();
                }
                if (uRow.прим != null)
                {
                    if (uRow.прим.Trim() != String.Empty)
                    {
                        //                    услуги newRow = db.услуги.Single(n => n.услуга == uRow.услуга);
                        примечания newRow = new примечания();
                        newRow.клиент = клКлиент.клиент;
                        newRow.прим = uRow.прим;
                        newRow.услуга = uRow.услуга;

                        клКлиент.deRow.примечания.Add(newRow);
                    }
                    db.SaveChanges();
                }
            }
        }
    
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            button1.Enabled = false;
    //        button11.Enabled = false;

            if (e.Node.Level == 3)
            {
                button1.Enabled = true;
      //          button11.Enabled = true;
                клКлиент.deRow = (клиенты)e.Node.Tag;
                клКлиент.клиент = клКлиент.deRow.клиент;
                клКлиент.фио = клКлиент.deRow.фио;
                обновитьЛист();

            }
            label1.Visible = false;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            клКлиент.выбран = true;
            Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        class temp
        {
            public Guid услуга { get; set; }
            public string наимен { get; set; }
            bool Наш;
            public bool наш
            {

                get
                {
                    return Наш;
                }
                set
                {
                    Наш = value;
                    поле = "наш";
                    if (Событие != null)
                    {
                        Событие(this);
                    }
                }
            }
            public int год { get; set; }
            public int месяц { get; set; }
            public DateTime ? подключен { get; set; }

            string Прим0;
            public string прим0
            {
                get
                {
                    return Прим0;
                }
                set
                {
                    Прим0 = value;
                    поле = "прим0";
                    if (Событие != null)
                    {
                        Событие(this);
                    }
                }
            }

            string Прим;
            public string прим {
                get
                {
                    return Прим;
                }
                set
                {
                    Прим = value;
                    поле = "прим";
                    if (Событие != null)
                    {
                        Событие(this);
                    }
                }
            }
            public DateTime ? отключен { get; set; }
            public DateTime ? повторно { get; set; }
            public DateTime? звонок  { get; set; }
            public string  звонок_текст
            {
                get
                {
                    string ss = "";
                    if (звонок != null )
                    {
                        ss = звонок.Value.ToShortDateString();
                    }
                    return ss;
                }
            }
            
            public static event Action<temp> Событие;
            public string поле;

            public static  void обнулить()
            {
               
                Событие = null;
            }

        }
        void заполнитьЛист()
        {

           // temp.обнулить();
            temp.Событие -= temp_Событие;
           
            foreach (услуги uRow in db.услуги.OrderBy(n=>n.виды_услуг.порядок).ThenBy(n=>n.порядок))
            {
                temp newTemp = new temp();
                newTemp.услуга = uRow.услуга;
                newTemp.наимен = uRow.обозначение;
                tempList.Add(newTemp);
                
               
            }
            dicTemp = tempList.ToDictionary(n => n.услуга);
        }
        void обновитьЛист()
        {
            temp.Событие -= temp_Событие;
         //   temp.обнулить();

            DateTime? последнийЗвонок = null;
            if (db.звонки.Any(n => n.клиент == клКлиент.клиент))
            {
                последнийЗвонок = db.звонки.Where(n => n.клиент == клКлиент.клиент).Max(n => n.дата);
            }

            foreach(temp tRow in tempList)
            {
              
                tRow.наш = false;
                tRow.год = 0;
                tRow.месяц = 0;
                tRow.прим = "";
                tRow.подключен = null;
                tRow.отключен = null;
                tRow.повторно = null;
                tRow.звонок = null;
                tRow.прим0 = клКлиент.deRow.прим;
                tRow.звонок = последнийЗвонок;
            }
            textBox1.Text = "";
            textBox2.Text = "";

            foreach(услуги uRow in клКлиент.deRow.услуги)
            {
                if (dicTemp.ContainsKey(uRow.услуга))
                {
                    dicTemp[uRow.услуга].наш = true;
                }
               
            }
            foreach (подключения uRow in клКлиент.deRow.подключения.OrderBy(n=>n.дата_с))
            {
                if (dicTemp.ContainsKey(uRow.услуга))
                {
                    dicTemp[uRow.услуга].подключен = uRow.дата_с;
                }
            }

            foreach (примечания uRow in клКлиент.deRow.примечания)
            {
                if (dicTemp.ContainsKey(uRow.услуга))
                {
                    dicTemp[uRow.услуга].прим = uRow.прим;
                }
            }
            foreach (отключения uRow in клКлиент.deRow.отключения.OrderBy(n=>n.дата_с))
            {
                if (dicTemp.ContainsKey(uRow.услуга))
                {
                    dicTemp[uRow.услуга].отключен = uRow.дата_с;
                }
            }
            foreach (повторы uRow in клКлиент.deRow.повторы.OrderBy(n=>n.дата_с))
            {
                if (dicTemp.ContainsKey(uRow.услуга))
                {
                    dicTemp[uRow.услуга].повторно = uRow.дата_с;
                }
            }

            var query = db.оплачено
                .Where(n => n.оплаты.клиент == клКлиент.клиент)
                .GroupBy(n => n.услуга)
                .Select(n => new
                {
                    услуга = n.Key,
                    год = n.Max(p => p.год),
                    g100m = n.Max(p => p.год * 100 + p.месяц)
                });
                


            foreach (var  uRow in query)
            {
                if (dicTemp.ContainsKey(uRow.услуга))
                {
                    dicTemp[uRow.услуга].год = uRow.год;
                    dicTemp[uRow.услуга].месяц = uRow.g100m - uRow.год * 100;
                }
            }

          

            bindingSource1.MoveLast();
            bindingSource1.MoveFirst();
            dataGridView1.Refresh();
            //textBox1.Text = клКлиент.deRow.прим;

            temp.Событие += temp_Событие;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            клКлиент.выбран = true;
            Close();
        }

      
    }
}
