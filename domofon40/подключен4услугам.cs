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
    public partial class подключен4услугам : Form
    {
        public подключен4услугам()
        {
            InitializeComponent();
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        BindingList<temp> tempList = new BindingList<temp>();
        private void подключен4услугам_Load(object sender, EventArgs e)
        {
            buttonЗвонок.Text = "Звонок на " + клКлиент.deRow.телефон;
            try
            {
                foreach (услуги uRow in de.услуги
                    .OrderBy(n => n.виды_услуг.порядок)
                    .ThenBy(n=>n.порядок))
                {
                    temp newTemp = new temp();
                    newTemp.услуга = uRow.услуга;
                    newTemp.наимен = uRow.наимен;
                    if (uRow.клиенты.Any(n => n.клиент == клКлиент.клиент))
                    {
                        newTemp.подключена = true;
                    }
                    if (uRow.примечания.Any(n => n.клиент == клКлиент.клиент))
                    {
                        newTemp.прим = uRow.примечания.Last(n => n.клиент == клКлиент.клиент).прим;
                    }
                    if (uRow.отключения.Any(n => n.клиент == клКлиент.клиент))
                    {
                        newTemp.откл = uRow.отключения.Where(n => n.клиент == клКлиент.клиент).Max(n => n.дата_с);
                    }

                    if (uRow.повторы.Any(n => n.клиент == клКлиент.клиент))
                    {
                        newTemp.подк = uRow.повторы
                             .Where(n => n.клиент == клКлиент.клиент)
                            .Max(n => n.дата_с);

                        if(newTemp.откл !=null)
                        {
                            if(newTemp.откл> newTemp.подк)
                            {
                                newTemp.подк = null;
                            }
                        }
                    }
                    if (uRow.подключения.Any(n => n.клиент == клКлиент.клиент))
                    {
                        подключения pRow = uRow.подключения
                              .Where(n => n.клиент == клКлиент.клиент)
                            .OrderBy(n => n.дата_с).Last();

                        newTemp.номер_пп = pRow.номер_пп;
                        newTemp.от = pRow.дата_с;
                    }


                    var query = de.оплачено
                        .Where(n => n.услуга == uRow.услуга)
                        .Where(n => n.оплаты.клиент == клКлиент.клиент);



                    if (query.Any())
                    {
                        int gm = query
                            .Max(n => n.год * 100 + n.месяц);

                        int мГод = (int)gm / 100;
                        int мМесяц = (gm - мГод * 100);
                        newTemp.год = мГод;
                        newTemp.месяц = мМесяц;

                    }
                 

                    tempList.Add(newTemp);
                }
                bindingSource1.DataSource = tempList;
                клСетка.задать_ширину(dataGridView1);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Сбой загрузки " + ex.Message);
            }
            клиенты kRow = de.клиенты.Single(n => n.клиент == клКлиент.клиент);
            if (kRow.звонки.Any())
            {
                DateTime последний_звонок = kRow.звонки.Max(n => n.дата);
                textBox1.Text = последний_звонок.ToShortDateString()+" "+ последний_звонок.ToShortTimeString();
                if(последний_звонок.Date ==DateTime.Today)
                {
                    textBox1.ForeColor = Color.Green;
                }
            }

   //         dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
          //  tempList.ListChanged += tempList_ListChanged;
            //bindingSource1.ListChanged += bindingSource1_ListChanged;
        }

        void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (dataGridView1.Columns[e.ColumnIndex] == подключенColumn)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                temp tRow = bindingSource1.Current as temp;

                //bool xy = (bool)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                //Guid кодУслуги = (Guid)dataGridView1.Rows[e.RowIndex].Cells["услугаColumn"].Value;
                услуги yRow = de.услуги.Single(n=>n.услуга==tRow.услуга);
                клиенты kRow = de.клиенты.Single(n => n.клиент == клКлиент.клиент);
                kRow.услуги.Remove(yRow);
                de.SaveChanges();
                if (tRow.подключена)
                {
                    kRow.услуги.Add(yRow);
                    de.SaveChanges();
                }
            }
            if (dataGridView1.Columns[e.ColumnIndex] == примColumn)
            {

               
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                temp tRow = bindingSource1.Current as temp;

             //   Guid кодУслуги = (Guid)dataGridView1.Rows[e.RowIndex].Cells["услугаColumn"].Value;
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value==null)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                }
                string текст = (string) dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;


                if (de.примечания.Where(n=>n.клиент==клКлиент.клиент).Any(n=>n.услуга==tRow.услуга))
                {
                    примечания pRow = de.примечания.Where(n => n.клиент == клКлиент.клиент).Single(n => n.услуга == tRow.услуга);
                    de.примечания.Remove(pRow);
                    de.SaveChanges();
                }
                if (текст.Trim() != String.Empty)
                {
                    примечания newRow = new примечания();
                    newRow.услуга = tRow.услуга;
                    newRow.клиент = клКлиент.клиент;
                    newRow.прим = текст;
                    de.примечания.Add(newRow);
                    de.SaveChanges();
                }

            
            }
            Cursor = Cursors.Default;
        }

        //void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
           
        //}

        //void bindingSource1_ListChanged(object sender, ListChangedEventArgs e)
        //{
        //  //  MessageBox.Show(e.PropertyDescriptor.Name);
        //}

        //void tempList_ListChanged(object sender, ListChangedEventArgs e)
        //{
        //  MessageBox.Show(  e.PropertyDescriptor.Name);
        //}

        class temp
        {
            public Guid услуга { get; set; }
            public String наимен { get; set; }
            public int год { get; set; }
            public int месяц { get; set; }
            public int долг { get; set; }
            public bool подключена { get; set; }
            public int номер_пп { get; set; }
            public DateTime ? от { get; set; }
            public string договор_с { get; set; }
            public string прим { get; set; }

            public DateTime ? откл { get; set; }
            public DateTime ? подк { get; set; }

    //        public DateTime последний_звонок { get; set; }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close(); 
        }

        private void buttonЗвонок_Click(object sender, EventArgs e)
        {
     //       temp tRow = bindingSource1.Current as temp;
            клиенты kRow = de.клиенты.Single(n => n.клиент == клКлиент.клиент);
            звонки newSv = new звонки();
            newSv.дата= DateTime.Now;
            newSv.звонок=Guid.NewGuid();
            newSv.клиент=клКлиент.клиент;
           
            newSv.прим="";
          


            kRow.звонки.Add(newSv);
            try
            {
                de.SaveChanges();
              //  tRow.последний_звонок = newSv.дата;
                textBox1.Text = newSv.дата.ToShortDateString()+" "+ newSv.дата.ToShortTimeString();
                textBox1.ForeColor = Color.Green;
       //         dataGridView1.Refresh();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Сбой записи звонка "+ex.Message);

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
             
                Cursor = Cursors.WaitCursor;

                temp tRow = bindingSource1.Current as temp;
                клУслуга.услуга = tRow.услуга;
                клОплата.выбран = false;
                оплаченные1просмотр формаОплатить = new оплаченные1просмотр();

                формаОплатить.Text = "Оплаты за " + tRow.наимен.Trim() + " " + клКлиент.фио;

               
                формаОплатить.ShowDialog();
                
                Cursor = Cursors.Default;
               
            }

        }
    }
}
