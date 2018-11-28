using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace domofon40
{
    public partial class оплаты22клиента : Form
    {
        public оплаты22клиента()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        List<temp> tempList = new List<temp>();
        List<temp2> temp2List = new List<temp2>();

        private void оплаты22клиента_Load(object sender, EventArgs e)
        {
            try
            {
                string curDir = System.IO.Directory.GetCurrentDirectory();

                string шаблон = curDir + @"\оплаты1клиента.sql";

                if (!System.IO.File.Exists(шаблон.ToString()))
                {
                    MessageBox.Show("Нет файла " + шаблон.ToString());
                    Cursor = Cursors.Default;
                    return;
                }
                StreamReader sr = new StreamReader(шаблон, Encoding.Default);

                string запрос = sr.ReadToEnd();
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("declare @клиент  uniqueidentifier ='" + клКлиент.клиент.ToString() + "';");
                sb.AppendLine(запрос);

                string sqlString = sb.ToString();


                tempList = de.Database.SqlQuery<temp>(sqlString).ToList();


                //string sqlString = "exec оплаты1клиента @клиент='"+ клКлиент.клиент.ToString()+"'";
                //tempList = de.Database.SqlQuery<temp>(sqlString).ToList();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            bindingSource1.DataSource = tempList;
            bindingSource1.MoveLast();
            клСетка.задать_ширину(dataGridView1);
            if (bindingSource1.Count > 0)
            {
                заполнить_услуги();
            }

            bindingSource1.PositionChanged += bindingSource1_PositionChanged;
        }

        void bindingSource1_PositionChanged(object sender, EventArgs e)
        {
            заполнить_услуги();
        }



        class temp2
        {
            public Guid услуга { get; set; }
            public string наимен { get; set; }
            public int месяцев { get; set; }
            public int сумма { get; set; }
            public string договор { get; set; }

        }

        class temp
        {
            public Guid оплата { get; set; }
            public int номер { get; set; }
            public Guid клиент { get; set; }
            public DateTime дата { get; set; }
            public Guid сотрудник { get; set; }
            public string адрес { get; set; }
            public string фио { get; set; }
            public int оплатить { get; set; }
            public string менеджер { get; set; }
            public string наимен_вида { get; set; }


        }
        private void заполнить_услуги()
        {
            if (bindingSource1.Count > 0)
            {

                temp uRow = bindingSource1.Current as temp;

                List<temp2> query = new List<temp2>();
                if (de.оплачено
                    .Any(n => n.оплата == uRow.оплата))
                {
                    query = de.оплачено
                        .Where(n => n.оплата == uRow.оплата)
                        .OrderBy(n => n.услуги.порядок)
                       .GroupBy(n => n.услуги)
                       .Select(n => new temp2
                       {
                           услуга = n.Key.услуга,
                           наимен = n.Key.наимен,
                           месяцев = n.Count(),
                           сумма = n.Sum(p => p.сумма)
                       }).ToList();
                }
                List<temp2> query2 = new List<temp2>();
                if (de.опл_работы
                     .Any(n => n.оплата == uRow.оплата))
                {
                    query2 = de.опл_работы
                        .Where(n => n.оплата == uRow.оплата)
                        .OrderBy(n => n.работы.порядок)
                        .Select(n => new temp2
                        {
                            услуга = n.работа,
                            наимен = n.работы.наимен,
                            месяцев = 0,
                            сумма = (int)n.стоимость,
                            договор = n.сотрудники.фио
                        }).ToList();
                }
                List<temp2> query3 = new List<temp2>();
                if (de.возврат
                   .Any(n => n.оплата == uRow.оплата))
                {
                    query3 = de.возврат
                       .Where(n => n.оплата == uRow.оплата)
                       .OrderBy(n => n.услуги.порядок)
                      .GroupBy(n => n.услуги)
                      .Select(n => new temp2
                      {
                          услуга = n.Key.услуга,
                          наимен = " Возврат " + n.Key.наимен,
                          месяцев = n.Count(),
                          сумма = n.Sum(p => -p.сумма)
                      }).ToList();

                }

                Guid КодКлиента2 = uRow.клиент;


                int мСумма = 0;

                temp2List.Clear();
                foreach (temp2 newRow in query)
                {
                    temp2List.Add(newRow);
                }
                foreach (temp2 newRow in query2)
                {
                    temp2List.Add(newRow);
                }
                foreach (temp2 newRow in query3)
                {
                    temp2List.Add(newRow);
                }



                if (temp2List.Any())
                {
                    мСумма = temp2List.Sum(n => n.сумма);
                }


                foreach (подключения pRow in de.подключения
                    .Where(n => n.клиент == uRow.клиент)
                    .OrderBy(n => n.дата_дог))
                {
                    if (temp2List.Any(n => n.услуга == pRow.услуга))
                    {
                        temp2 sRow = temp2List.First(n => n.услуга == pRow.услуга);
                        sRow.договор = pRow.номер_пп.ToString("0;#;#")+" с "+pRow.дата_с.ToShortDateString();
                    }
                }



                if (uRow.оплатить != мСумма)
                {
                    uRow.оплатить = мСумма;
                }

                textBox1.Text = мСумма.ToString();
                bindingSource2.DataSource = null;
                bindingSource2.DataSource = temp2List;
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = bindingSource2;
                bindingSource2.MoveLast();
                dataGridView2.Refresh();
            }

       
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
                //          записать();
                temp uRow = bindingSource1.Current as temp;
                клОплата.оплата = uRow.оплата;
                клОплата.deRow = de.оплаты.Single(n=>n.оплата==uRow.оплата);
                клКлиент.клиент = uRow.клиент;
                клУслуга.выбран = false;
         //       int строка = bindingSource1.Position;
                выбор4услуги выборУслуги = new выбор4услуги();
                выборУслуги.ShowDialog();
                if (клУслуга.выбран)
                {
                    Cursor = Cursors.WaitCursor;
                    оплаченные1просмотр оплаченыеМесяца = new оплаченные1просмотр();
                    оплаченыеМесяца.Text = "Оплата  " + клУслуга.deRow.наимен + " " + uRow.адрес;
                    оплаченыеМесяца.ShowDialog();
                    //обновить();

                    //пересчет();

           //         bindingSource1.Position = строка;

                    Cursor = Cursors.Default;
                }

            }

            dataGridView1.Focus();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
