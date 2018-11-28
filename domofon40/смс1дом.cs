using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmsRu;
using SmsRu.Enumerations;
using System.Text.RegularExpressions;

namespace domofon40
{
    public partial class смс1дом : Form
    {
        public смс1дом()
        {
            InitializeComponent();
        }
        ISmsProvider sms = new SmsRuProvider();


        domofon14Entities de = new domofon14Entities();
        List<temp> listTemp0 = new List<temp>();
        List<temp> listTemp = new List<temp>();

        private void смс1дом_Load(object sender, EventArgs e)
        {
            var query = de.клиенты
  .Where(n => n.дом == клДом.дом)
  .OrderBy(n => n.квартира)
  .ThenBy(n => n.ввод);

            foreach (клиенты uRow in query)
            {
                int j = 0;
                foreach (услуги yRow in de.услуги
                                 .OrderBy(n => n.виды_услуг.порядок)
                                 .ThenBy(n => n.порядок))
                {
                    if (de.оплачено
                        .Where(n => n.услуга == yRow.услуга)
                        .Any(n => n.оплаты.клиент == uRow.клиент)
                        || de.льготы
                         .Where(n => n.услуга == yRow.услуга)
                        .Any(n => n.клиент == uRow.клиент))
                    {
                        j++;
                        temp NewRow = new temp();
                        NewRow.клиент = uRow.клиент;
                        if (j == 1)
                        {
                            NewRow.фио = uRow.фио;
                            NewRow.квартира = uRow.квартира;
                            NewRow.ввод = uRow.ввод;
                            NewRow.подъезд = uRow.подъезд;
                            NewRow.телефон = uRow.телефон;
                        }
                        //NewRow.Имя = uRow.имя;
                        //NewRow.Отчество = uRow.отчество;
                        //NewRow.телефон = uRow.телефон;
                        //NewRow.Фамилия = uRow.фамилия;
                        //NewRow.прим0 = uRow.прим;

                        if (uRow.примечания.Any(n => n.услуга == yRow.услуга))
                        {
                            NewRow.прим = uRow.примечания.First(n => n.услуга == yRow.услуга).прим.Trim();
                        }

                        if (uRow.услуги.Any(n => n.услуга == yRow.услуга))
                        {
                            NewRow.действует = true;

                        }


                        if (uRow.подключения.Any(n => n.услуга == yRow.услуга))
                        {
                            NewRow.договор_с = uRow.подключения
                                                   .Where(n => n.услуга == yRow.услуга)
                                                   .Max(n => n.дата_с);
                        }

                        if (uRow.отключения.Any(n => n.услуга == yRow.услуга))
                        {
                            NewRow.откл = uRow.отключения
                                              .Where(n => n.услуга == yRow.услуга)
                                              .Max(n => n.дата_с);
                        }

                        if (uRow.повторы.Any(n => n.услуга == yRow.услуга))
                        {
                            NewRow.подкл = uRow.повторы
                                               .Where(n => n.услуга == yRow.услуга)
                                               .Max(n => n.дата_с);
                        }

                        if (uRow.льготы.Any(n => n.услуга == yRow.услуга))
                        {
                            string текст = uRow.льготы
                                               .Where(n => n.услуга == yRow.услуга)
                                               .Max(n => n.дата_с).ToShortDateString();

                            NewRow.сведения += "Льгота с " + текст;
                        }

                        NewRow.услуга = yRow.услуга;
                        NewRow.наимен_услуги = yRow.обозначение;

                        NewRow.порядок = j;
                        listTemp0.Add(NewRow);


                    }

                }
            }

            int текГод = System.DateTime.Today.Year;
            int текМесяц = DateTime.Today.Month;

            var dicTemp = listTemp0.ToDictionary(n => new { n.клиент, n.услуга });

            var query2 = de.оплачено
                //                           .Where(n => n.услуга1.вид_услуги == клВид_услуги.вид_услуги)
                           .Where(n => n.оплаты.клиенты.дом == клДом.дом)
                           .GroupBy(n => new { n.оплаты.клиент, n.услуга })
                           .Select(n => new
                           {
                               клиент = n.Key.клиент,
                               услуга = n.Key.услуга,
                               махГод = n.Max(k => k.год),
                               maxM = n.Max(k => k.год * 12 + k.месяц)
                           });

            foreach (var uRow in query2)
            {
                var ключ = new { uRow.клиент, uRow.услуга };

                if (dicTemp.ContainsKey(ключ))
                {
                    temp tRow = dicTemp[ключ];

                    tRow.год = uRow.махГод;
                    int mMez = uRow.maxM - uRow.махГод * 12;
                    tRow.месяц = mMez;
                    int долгМес = текГод * 12 + текМесяц - 1 - uRow.махГод * 12 - mMez;
                    if (долгМес > 0)
                    {
                        tRow.долг_мес = долгМес;
                        if (долгМес > 1)
                            tRow.должник = true;
                    }
                }


            }
            var dicZ = de.цены.ToList().ToDictionary(n => new { n.услуга, n.год, n.месяц });

            foreach (temp ttRow in listTemp0
                .Where(n => n.долг_мес > 1)
                .Where(n => n.год > 0)
                .Where(n => n.действует))
            {
                var queryZ = de.цены
                    .Where(n => n.услуга == ttRow.услуга)
                    .ToArray();
                int сумма = 0;
                string ss = "01." + ttRow.месяц.ToString() + "." + ttRow.год.ToString();

                DateTime dt = DateTime.Parse(ss);
                while ((dt.Year < текГод) || (dt.Year == текГод && dt.Month < текМесяц - 1))
                {
                    dt = dt.AddMonths(1);
                    int год = dt.Year;
                    int месяц = dt.Month;
                //    Guid  услуга = ttRow.услуга;
                    var ключ1 = new { ttRow.услуга, год, месяц };

                    if (dicZ.ContainsKey(ключ1))
                    {
                        var zRow = dicZ[ключ1];
                        int цена = (int)zRow.стоимость;
                        сумма += цена;
                    }
                    else
                    {
                        Console.WriteLine(ключ1);
                        //                        сумма += 10000;
                    }
                }


                ttRow.долг_руб = сумма;
                if (сумма > 0 && ttRow.действует)
                {
                    ttRow.смс = true;
                }
            }


            var query3 = de.звонки
                 .Where(n => n.клиенты.дом == клДом.дом)
                           .GroupBy(n => new { n.клиент, n.услуга })
                           .Select(n => new
                           {
                               клиент = n.Key.клиент,
                               услуга = n.Key.услуга,
                               махДата = n.Max(k => k.дата)

                           });

            foreach (var uRow in query3)
            {
                var ключ = new { uRow.клиент, uRow.услуга };

                if (dicTemp.ContainsKey(ключ))
                {
                    temp tRow = dicTemp[ключ];

                    tRow.последний_звонок = uRow.махДата;
                }


            }


            listTemp = listTemp0.FindAll(n => n.долг_руб > 0);
            bindingSource1.DataSource = listTemp;
            checkBox1.Text = "Все";
            //            listTemp = listTemp0;
            bindingSource1.DataSource = listTemp;

            init_limit();
            initBalance();

            //    bindingSource1.PositionChanged += bindingSource1_PositionChanged;
            dataGridView1.CellPainting += dataGridView1_CellPainting;

        }

        void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            string[] заголовки = { "отключитьColumn", "повторноColumn", "действуетColumn", "подключитьColumn", "вводColumn", "квартираColumn", "должникColumn" };
            if (e.RowIndex > -1 || e.ColumnIndex < 0)
            {
                e.Handled = false;
                return;
            }
            if (заголовки.Contains(dataGridView1.Columns[e.ColumnIndex].Name))
            {
                e.PaintBackground(e.ClipBounds, true);
                e.Graphics.RotateTransform(-90.0F);
                string текст = dataGridView1.Columns[e.ColumnIndex].HeaderText;
                //                System.Drawing.Font шрифт = квартирыDataGridView.Font;
                System.Drawing.Font шрифт = label4.Font;

                RectangleF p = new RectangleF(-e.CellBounds.Top - e.CellBounds.Height + 5, e.CellBounds.Left + 5,
                                              e.CellBounds.Height, e.CellBounds.Width);
                if (dataGridView1.Columns[e.ColumnIndex] == отключитьColumn)
                {
                    e.Graphics.DrawString(текст, шрифт, Brushes.Red, p);
                }
                else
                {
                    e.Graphics.DrawString(текст, шрифт, Brushes.Black, p);
                }


                e.Graphics.RotateTransform(90.0F);
                e.Handled = true;
            }

        }


        private void init_limit()
        {
            textBox2.Text = "";
            textBox1.Text = "";
            try
            {
                string strLimit = sms.CheckLimit(EnumAuthenticationTypes.StrongApi);

                char сепаратор = '\n';
                string[] строки = strLimit.Split(сепаратор);
                if (строки.Length > 0)
                {
                    if (строки[0].Trim() != "100")
                    {
                        MessageBox.Show("Сбой...");
                    }
                }

                if (строки.Length > 1)
                {
                    textBox1.Text = строки[1];
                }
                if (строки.Length > 2)
                {
                    textBox2.Text = строки[2];
                }
            }
            catch
            {
                MessageBox.Show("Сбой интернета");
            }


        }
        private void initBalance()
        {
            textBox3.Text = "";
            try
            {
                string strLimit = sms.CheckBalance(EnumAuthenticationTypes.Simple);
                char сепаратор = '\n';
                string[] строки = strLimit.Split(сепаратор);
                if (строки.Length > 1)
                {
                    textBox3.Text = строки[1];
                }
            }
            catch
            {
                MessageBox.Show("Сбой интернета");
            }
        }


        partial class temp
        {
            public int порядок { get; set; }
            public Guid  клиент { get; set; }
            public int подъезд { get; set; }
            public int квартира { get; set; }
            public int ввод { get; set; }
            public string фио { get; set; }
            public Guid услуга { get; set; }
            public string наимен_услуги { get; set; }
            public int год { get; set; }
            public int месяц { get; set; }
            public int долг_мес { get; set; }
            public int долг_руб { get; set; }
            public bool должник { get; set; }
            public bool подключить { get; set; }
            public bool отключить { get; set; }
            public bool смс { get; set; }
            public string прим { get; set; }
            public string телефон { get; set; }
            public string id_сообщения { get; set; }
            public string текст_сообщения { get; set; }
            public DateTime? откл { get; set; }
            public DateTime? подкл { get; set; }
            public DateTime? договор_с { get; set; }
            public DateTime? последний_звонок { get; set; }
            public string сведения { get; set; }
            public bool действует { get; set; }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                listTemp = listTemp0.FindAll(n => n.долг_руб > 0);
                bindingSource1.DataSource = listTemp;
                checkBox1.Text = "Все";
            }
            else
            {
                listTemp = listTemp0;
                bindingSource1.DataSource = listTemp;
                checkBox1.Text = "только должники";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            temp tRow = bindingSource1.Current as temp;
            string номерСообщения = tRow.id_сообщения;
            if (номерСообщения != String.Empty)
            {
                SmsRu.Enumerations.ResponseOnStatusRequest статус = sms.CheckStatus(номерСообщения, EnumAuthenticationTypes.Simple);
                //  MessageBox.Show(статус.ToString());
                if (статус == SmsRu.Enumerations.ResponseOnStatusRequest.MessageRecieved)
                {
                    tRow.сведения = "отправлено";
                    dataGridView1.Refresh();
                }
                else
                {
                    tRow.сведения = "не отправлено";
                    dataGridView1.Refresh();
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            temp tRow = bindingSource1.Current as temp;
            звонки NewRow = new звонки();
            NewRow.звонок = Guid.NewGuid();
            DateTime dt = DateTime.Now; ;
            NewRow.дата = dt;
            NewRow.клиент = tRow.клиент;
            NewRow.услуга = tRow.услуга;

            NewRow.доставка = "";
            NewRow.доставлено = false;
            NewRow.код_сообщения = "";
            NewRow.прим = "";
            NewRow.статус = "";

            de.звонки.Add(NewRow);
            try
            {
                de.SaveChanges();
                tRow.последний_звонок = dt;
                dataGridView1.Refresh();
            }
            catch
            {
                MessageBox.Show("Сбой записи звонка");
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Cursor = Cursors.WaitCursor;
            //temp tRow = bindingSource1.Current as temp;
            //клКлиент.клиент = tRow.клиент;
            //клУслуга.услуга = tRow.услуга;

            //вертикаль_оплатить формаОплатить = new вертикаль_оплатить();

            //формаОплатить.Text = "Оплаты за " + tRow.наимен_услуги.Trim() + " " + tRow.фио;

            ////            клОплата.изменено = false;
            //формаОплатить.ShowDialog();
            //Cursor = Cursors.Default;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            temp tRow = bindingSource1.Current as temp;
            клСообщение.отправлен = false;
            клСообщение.клиент = tRow.клиент;
            temp t1Row = listTemp.First(n => n.клиент == клСообщение.клиент);


            string pattern = @"\b\d{10}\b";
            клСообщение.телефон = "";
            string строка_телефон = t1Row.телефон.Replace("-", "");

            foreach (Match match in Regex.Matches(строка_телефон, pattern))
            {
                клСообщение.телефон = match.Value;
            }

            pattern = @"\b\d{11}\b";
            foreach (Match match in Regex.Matches(строка_телефон, pattern))
            {
                string ss = match.Value;
                клСообщение.телефон = ss.Remove(0, 1);

            }
            if (клСообщение.телефон.Trim().Length != 10)
            {
                MessageBox.Show("Нет сотового телефона у " + t1Row.фио);
                //     return;
            }
            //                Console.WriteLine("'{0}' found at position {1}.", match.Value, match.Index);

        //    string адресКлиента = клДом.deRow.улица1.наимен.Trim() + " дом " + клДом.номер.ToString() + "" + клДом.корпус + " кв." + t1Row.квартира.ToString();
            //            клСообщение.текст = "Сообщение " + адресКлиента + "\n " + t1Row.фио.Trim()+"\n Просим погасить долг \n ";
            клСообщение.текст = "Ваш долг на " + DateTime.Today.ToShortDateString().Substring(0, 6) + " ";

            int сумма = 0;
            foreach (temp uRow in listTemp
                .Where(n => n.клиент == клСообщение.клиент)
                .Where(n => n.смс))
            {
                //                клСообщение.текст+= uRow.наимен_услуги.Trim()+"-"+uRow.долг_руб.ToString()+"руб. за "+uRow.долг_мес.ToString()+" мес. \n";
                клСообщение.текст += uRow.наимен_услуги.Trim() + "-" + uRow.долг_руб.ToString() + "p. ";
                сумма += uRow.долг_руб;
            }
            клСообщение.текст += " Квант тел.31252";
            //    MessageBox.Show(клСообщение.текст.Length.ToString());
            if (сумма == 0)
            {
                MessageBox.Show("Пометьте услуги для " + t1Row.фио);
                //    return;
            }
            //  клСообщение.длина_сообщения = клСообщение.текст.Length;

            бланк1сообщения формаБланк = new бланк1сообщения();
            формаБланк.Text = "Сообщение для " + t1Row.фио + " кв." + t1Row.квартира.ToString();
            формаБланк.ShowDialog();
            if (клСообщение.отправлен && клСообщение.дата != null)
            {
                foreach (temp uRow in listTemp
             .Where(n => n.клиент == клСообщение.клиент)
             .Where(n => n.смс))
                {

                    звонки NewRow = new звонки();
                    NewRow.клиент = uRow.клиент;
                    NewRow.услуга = uRow.услуга;
                    NewRow.звонок = Guid.NewGuid();
                    NewRow.дата = клСообщение.дата.Value;
                    de.звонки.Add(NewRow);
                    uRow.последний_звонок = клСообщение.дата;
                    uRow.id_сообщения = клСообщение.код;
                }
                try
                {
                    de.SaveChanges();
                    dataGridView1.Refresh();
                }
                catch
                {
                    MessageBox.Show("Сбой записи звонков");
                }
                init_limit();
                initBalance();
            }

        }


    }
}
