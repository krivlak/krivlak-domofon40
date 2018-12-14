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
    public partial class все_оплаты : Form
    {
        public все_оплаты()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        List<temp> tempList = new List<temp>();
        List<temp2> temp2List = new List<temp2>();


        private void все_оплаты_Load(object sender, EventArgs e)
        {
            try
            {
                DataGridViewCellStyle intStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "0;#;#"
                };
                номерColumn.DefaultCellStyle = intStyle;
                суммаColumn.DefaultCellStyle = intStyle;


                string curDir = System.IO.Directory.GetCurrentDirectory();

                string шаблон = curDir + @"\все_оплаты.sql";

                if (!System.IO.File.Exists(шаблон.ToString()))
                {
                    MessageBox.Show("Нет файла " + шаблон.ToString());
                    Cursor = Cursors.Default;
                    return;
                }
                StreamReader sr = new StreamReader(шаблон, Encoding.Default);

                string запрос = sr.ReadToEnd();
                StringBuilder sb = new StringBuilder();
                //   sb.AppendLine("declare @сотрудник  uniqueidentifier ='" + клСотрудник.сотрудник.ToString() + "';");
                sb.AppendLine(запрос);

                string sqlString = sb.ToString();


                tempList = de.Database.SqlQuery<temp>(sqlString).ToList();



                //string sqlString = "exec все_оплаты";
                //tempList = de.Database.SqlQuery<temp>(sqlString).ToList();





                bindingSource1.DataSource = tempList;
                клСетка.задать_ширину(dataGridView1);
                bindingSource1.MoveLast();

            }
            catch (Exception ex)
            {
                MessageBox.Show($" Ошибка загрузки {ex.Message}");
            }

            заполнить_услуги();

            bindingSource1.PositionChanged += bindingSource1_PositionChanged;
            //     dataGridView1.DataSource = tempList;
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
            public Guid вид_оплаты { get; set; }
            public string наимен_вида { get; set; }

        }

        private void заполнить_услуги22()
        {
            try
            {
                temp uRow = (temp)bindingSource1.Current;


                List<temp2> query = de.оплачено
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

                List<temp2> query2 = de.опл_работы
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



                Guid КодКлиента2 = uRow.клиент;


                int мСумма = 0;
                temp2List = query.Concat(query2).ToList();
                if (temp2List.Any())
                {
                    мСумма = temp2List.Sum(n => n.сумма);
                }
                //    tempList.Clear();

                //foreach (var mm in query)
                //{

                //    temp NewRow = new temp();
                //    NewRow.услуга = mm.услуга;
                //    NewRow.наимен = mm.наимен;
                //    NewRow.месяцев = mm.месяцев;
                //    NewRow.сумма = mm.сумма;
                //    NewRow.договор = "";
                //    tempList.Add(NewRow);

                //    мСумма += mm.сумма;
                //}

                //foreach (подключения pRow in de.подключения
                //    .Where(n => n.клиент == uRow.клиент)
                //    .OrderBy(n => n.дата_дог))
                //{
                //    if (tempList.Any(n => n.услуга == pRow.услуга) )
                //    {
                //        temp sRow = tempList.First(n => n.услуга == pRow.услуга);
                //        sRow.договор = pRow.номер_пп.ToString("0;#;#");
                //    }
                //}

                //foreach (var rr in query2)
                //{

                //    temp NewRow = new temp();
                //    NewRow.услуга = rr.работа;
                //    NewRow.наимен = rr.наимен;
                //    NewRow.месяцев = 0;
                //    NewRow.сумма = (int)rr.оплачено;
                //    NewRow.договор = rr.фио;
                //    tempList.Add(NewRow);
                //    мСумма += NewRow.сумма;
                //}

                //  foreach (var vv in query3)
                //  {
                //    //  dsДолги.подробностиRow NewRow = dsДолги1.подробности.NewподробностиRow();
                //      temp NewRow = new temp();
                //      NewRow.услуга = vv.услуга;
                //      NewRow.наимен = "ВОЗВРАТ " + vv.наимен.Trim();
                //      NewRow.месяцев = vv.месяцев;
                //      NewRow.сумма = vv.сумма;
                //      NewRow.договор = "";
                //      tempList.Add(NewRow);
                ////      dsДолги1.подробности.Rows.Add(NewRow);
                //      мСумма -= vv.сумма;
                //  }

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

                //    налTextBox.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка " + ex.Message);
                //tempList.Clear();
                //bindingSource2.DataSource = tempList;
                //dataGridView2.DataSource = bindingSource2;
                //dataGridView2.Refresh();
                //textBox1.Text = "";
            }
        }

        private void заполнить_услуги()
        {
            try
            {
                int мСумма = 0;
                temp2List.Clear();

                if (bindingSource1.Count > 0)
                {
                    temp uRow = bindingSource1.Current as temp;


                    List<temp2> query = de.оплачено
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
                    //     Console.WriteLine(query.Count());
                    List<temp2> query2 = de.опл_работы
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

                    List<temp2> query3 = de.возврат
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



                    Guid КодКлиента2 = uRow.клиент;



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
                            sRow.договор = pRow.номер_пп.ToString("0;#;#");
                        }
                    }



                    if (uRow.оплатить != мСумма)
                    {
                        uRow.оплатить = мСумма;
                    }

                }

                textBox1.Text = мСумма.ToString();
                bindingSource2.DataSource = null;
                bindingSource2.DataSource = temp2List;
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = bindingSource2;
                bindingSource2.MoveLast();
                dataGridView2.Refresh();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ошибка {ex.Message}");
            }

    
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
                //  записать();
                temp uRow = bindingSource1.Current as temp;
                клОплата.оплата = uRow.оплата;
                клОплата.дата = uRow.дата;
                клОплата.номер = uRow.номер;
                клОплата.deRow = de.оплаты.Single(n => n.оплата == клОплата.оплата);
                клКлиент.клиент = uRow.клиент;
                клУслуга.выбран = false;
                выбор4услуги выборУслуги = new выбор4услуги();
                выборУслуги.Text = "Выберите услугу " + uRow.адрес + " " + uRow.фио;
                выборУслуги.ShowDialog();
                if (клУслуга.выбран)
                {
                    Cursor = Cursors.WaitCursor;
                    //  только_просмотр оплаченыеМесяца = new  только_просмотр();
                    оплаченные1просмотр оплаченыеМесяца = new оплаченные1просмотр();
                    оплаченыеМесяца.Text = "Оплаченые месяца  " + uRow.адрес + " " + uRow.фио;
                    оплаченыеМесяца.ShowDialog();

                    //if (клОплата.выбран)
                    //{
                    //заполнить_услуги();
                    //dataGridView1.Refresh();
                    ////}

                    //    пересчет();
                    Cursor = Cursors.Default;
                }


            }
            dataGridView1.Focus();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value>0)
            {
                //int строка = bindingSource1.Find("номер", numericUpDown1.Value);
                int строка = tempList.FindIndex(n => n.номер == numericUpDown1.Value);
                if(строка >0)
                {
                    bindingSource1.Position = строка;
                }
            }
        }
    }
}

