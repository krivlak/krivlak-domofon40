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
    public partial class дом1звонки : Form
    {
        public дом1звонки()
        {
            InitializeComponent();
        }

        domofon14Entities de = new domofon14Entities();
        List<temp> listTemp = new List<temp>();
        ISmsProvider sms = new SmsRuProvider();
        private void дом1звонки_Load(object sender, EventArgs e)
        {
            string sqlComanda = "должники1дома @дом=" + "'" + клДом.дом + "'";
            listTemp = de.Database.SqlQuery<temp>(sqlComanda).ToList();
            //var ee = de.Database.SqlQuery<temp>(sqlComanda);
            ////MessageBox.Show(ee.Count().ToString());
            //foreach (temp tRow in ee)
            //{
            //    listTemp.Add(tRow);
            //}
            //      MessageBox.Show(listTemp.Count.ToString());
            bindingSource1.DataSource = listTemp;
            init_limit();
            initBalance();

           
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


        partial class temp
        {
            public int порядок { get; set; }
            public Guid клиент { get; set; }
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
            public string сотовый { get; set; }
            public string эл_почта { get; set; }
            public Guid? разрешение { get; set; }
            public int номер_разрешения { get; set; }
            public DateTime? дата_разрешения { get; set; }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
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

        private void init_limit()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            try
            {
                string strLimit = sms.CheckLimit(EnumAuthenticationTypes.StrongApi);
            

                char сепаратор = '\n';
                string[] строки = strLimit.Split(сепаратор);
                if (строки.Length > 0)
                {
                    
                    if (строки[0].Trim() != "100")
                    {
                        MessageBox.Show("Сбой...Нет интернета");
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
            NewRow.телефон = "";

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

        private void button5_Click(object sender, EventArgs e)
        {
            temp tRow = bindingSource1.Current as temp;
            клСообщение.отправлен = false;
            клСообщение.клиент = tRow.клиент;
            //            клСообщение.телефон0 = tRow.телефон.Trim();
            temp t1Row = listTemp.First(n => n.клиент == клСообщение.клиент);

            if (t1Row.разрешение == null || t1Row.сотовый == String.Empty)
            {
                MessageBox.Show("Нет разрешения на отправку смс на телефон");
                return;
            }
            string pattern = @"\b\d{10}\b";
            клСообщение.телефон = "";
            string строка_телефон = t1Row.сотовый.Replace("-", "");

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
                MessageBox.Show("Не правильный формат номера сотового телефона " + t1Row.фио);
                return;
            }

            string адресКлиента = клДом.deRow.улицы.наимен.Trim() + " дом " + клДом.номер.ToString() + "" + клДом.корпус + " кв." + t1Row.квартира.ToString();
            клСообщение.текст = "Ваш долг на " + DateTime.Today.ToShortDateString().Substring(0, 6) + " ";

            int сумма = 0;
            foreach (temp uRow in listTemp
                .Where(n => n.клиент == клСообщение.клиент)
                .Where(n => n.смс))
            {
                клСообщение.текст += uRow.наимен_услуги.Trim() + "-" + uRow.долг_руб.ToString() + "p. ";
                сумма += uRow.долг_руб;
            }
            клСообщение.текст += " Квант тел.31252";
            if (сумма == 0)
            {
                MessageBox.Show("Пометьте услуги для " + t1Row.фио);
            }

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

                    NewRow.доставка = "";
                    NewRow.доставлено = false;
                    NewRow.код_сообщения = "";
                    NewRow.прим = "";
                    NewRow.статус = "";
                    NewRow.телефон = "";

                    de.звонки.Add(NewRow);
                //    uRow. = клСообщение.дата;
                    uRow.id_сообщения = клСообщение.код;

                    //if (de.примечания
                    //.Where(n => n.клиент == tRow.клиент)
                    //.Any(n => n.услуга == tRow.услуга))
                    //{
                    //    примечания pRow = de.примечания
                    //.Where(n => n.клиент == tRow.клиент)
                    //.Single(n => n.услуга == tRow.услуга);

                    //    pRow.прим = клСообщение.код;
                    //}
                    //else
                    //{
                    //    примечания nRow = new примечания();
                    //    nRow.услуга = tRow.услуга;
                    //    nRow.клиент = tRow.клиент;
                    //    nRow.прим = клСообщение.код;
                    //    de.примечания.Add(nRow);
                    //}
                    //tRow.прим = клСообщение.код;
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

        private void button2_Click(object sender, EventArgs e)
        {
            temp tRow = bindingSource1.Current as temp;

            клМыло.отправлен = false;
            клМыло.клиент = tRow.клиент;
            temp t1Row = listTemp.First(n => n.клиент == клМыло.клиент);
            if (t1Row.разрешение == null || t1Row.эл_почта == String.Empty)
            {
                MessageBox.Show("Нет разрешения на отправку электронной почты");
                return;
            }
            RegexUtilities ru = new RegexUtilities();
            клМыло.email = "";
            string s1 = t1Row.эл_почта.Trim();
            if (ru.IsValidEmail(s1))
            {
                клМыло.email = s1;
            }
            else
            {
                MessageBox.Show("Не верный формат электронной почты");
                return;
            }


            //клМыло.телефон0 = tRow.телефон.Trim();
            //клМыло.email = "";
            //string[] aStr = t1Row.телефон.Split(' ');
            //foreach (string s1 in aStr)
            //{
            //    if (ru.IsValidEmail(s1))
            //    {
            //        клМыло.email = s1;
            //    }
            //}



            //if (клМыло.email == String.Empty)
            //{
            //    MessageBox.Show("Нет электроной почты у " + t1Row.фио);
            //}

            клМыло.тема = "Информация о долгах за домофон и кабельное  телевидение ";
            string адресКлиента = клДом.deRow.улицы.наимен.Trim() + " дом " + клДом.номер.ToString() + "" + клДом.корпус + " кв." + t1Row.квартира.ToString();
            клМыло.текст = "Сообщение " + адресКлиента + Environment.NewLine + t1Row.фио.Trim() + Environment.NewLine;
            клМыло.текст += "Просим погасить долг " + Environment.NewLine + " На " + DateTime.Today.ToShortDateString() + " он составляет " + Environment.NewLine;

            int сумма = 0;
            foreach (temp uRow in listTemp
                .Where(n => n.клиент == клМыло.клиент)
                .Where(n => n.смс))
            {
                клМыло.текст += uRow.наимен_услуги.Trim() + "-" + uRow.долг_руб.ToString() + "руб. за " + uRow.долг_мес.ToString() + " мес." + Environment.NewLine;
                сумма += uRow.долг_руб;
            }
            клМыло.текст += "ООО Квант  ул. Декабристов дом 15  тел. 83436931252";
            if (сумма == 0)
            {
                MessageBox.Show("Пометьте услуги для " + t1Row.фио);
            }


            emalБланк формаБланк = new emalБланк();
            формаБланк.Text = "Сообщение для " + t1Row.фио + " кв." + t1Row.квартира.ToString();
            формаБланк.ShowDialog();
            if (клМыло.отправлен && клМыло.дата != null)
            {
                foreach (temp uRow in listTemp
             .Where(n => n.клиент == клМыло.клиент)
             .Where(n => n.смс))
                {

                    звонки NewRow = new звонки();
                    NewRow.клиент = uRow.клиент;
                    NewRow.услуга = uRow.услуга;
                    NewRow.звонок = Guid.NewGuid();
                    NewRow.дата = клМыло.дата.Value;

                    NewRow.доставка = "";
                    NewRow.доставлено = false;
                    NewRow.код_сообщения = "";
                    NewRow.прим = "";
                    NewRow.статус = "";
                    NewRow.телефон = "";

                    de.звонки.Add(NewRow);
                    uRow.последний_звонок = клМыло.дата;
                    uRow.id_сообщения = "eMail";
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
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
                        Cursor = Cursors.WaitCursor;
            temp tRow = bindingSource1.Current as temp;
            клКлиент.клиент = tRow.клиент;
            клУслуга.услуга = tRow.услуга;
            клУслуга.долг_руб = tRow.долг_руб;
            вертикаль_просмотр формаОплатить = new вертикаль_просмотр();

            формаОплатить.Text = "Оплаты за " + tRow.наимен_услуги.Trim() + " " + tRow.фио;


            формаОплатить.ShowDialog();
            Cursor = Cursors.Default;
            if(клУслуга.долг_руб != tRow.долг_руб && tRow.долг_мес>1)
            {
                tRow.долг_руб = клУслуга.долг_руб;
                dataGridView1.Refresh();
            }

        }

        
    }
}
