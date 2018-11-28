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
    public partial class бланк1сообщения : Form
    {
        public бланк1сообщения()
        {
            InitializeComponent();
        }
        
        ISmsProvider sms = new SmsRuProvider();
        private void бланк1сообщения_Load(object sender, EventArgs e)
        {
            textBox1.Text = клСообщение.телефон;
            textBox2.Text = клСообщение.текст;
            подчет_символов();
            init_limit();
            initBalance();
            textBox2.Focus();

            textBox2.TextChanged += textBox2_TextChanged;
        }

        void textBox2_TextChanged(object sender, EventArgs e)
        {
            клСообщение.длина_сообщения = textBox2.Text.Trim().Length;
            label4.Text = клСообщение.длина_сообщения.ToString();
            if (клСообщение.длина_сообщения > 70)
            {
                label4.ForeColor = Color.Red;
            }
            else
            {
                label4.ForeColor = Color.Green;
            }
        }


        private void на_проводе()
        {
            string pattern = @"\b\d{10}\b";
            string строка_телефон = textBox1.Text.Trim();

            var mc = Regex.Matches(строка_телефон, pattern);
            if (mc.Count != 1)
            {
                MessageBox.Show("Введите номер телефона 10 знаков");
                return;
            }


            //StringBuilder sb = new StringBuilder();
            //for (int i = 1; i <= 10; i++)
            //{
            //    sb.Append("абвгдесы ");
            //}
            клСообщение.текст = textBox2.Text.Trim();
            if (клСообщение.текст == String.Empty)
            {
                MessageBox.Show("Введите тест сообщения");
                return;
            }
            //   string телефон_клиента = "7" + клСообщение.телефон;

            string телефон_клиента = "7" + textBox1.Text.Trim();
            string текст = "";
            if (клСообщение.программисту)
            {
                текст = sms.Send("79068015888", "79068015888", клСообщение.текст);
            }
            else
            {
                текст = sms.Send("79068015888", телефон_клиента, клСообщение.текст);
            }
            //  string текст = sms.Send("79068015888", "79068015888", DateTime.Now.ToLongTimeString());
            клСообщение.дата = DateTime.Now;
            textBox8.Text = клСообщение.дата.Value.ToLongTimeString();
            MessageBox.Show(текст);
            char сепаратор = '\n';
            string[] строки = текст.Split(сепаратор);
            if (строки.Length > 1)
            {
                // лимит = int.Parse(строки[1]);
                клСообщение.код = строки[1];
                textBox7.Text = клСообщение.код;
            }
            initСтоимость();
            if (клСообщение.стоимость > 0)
            {
                клСообщение.отправлен = true;
            }
            init_limit();

         
        }


        private void подчет_символов()
        {
            клСообщение.длина_сообщения = клСообщение.текст.Length;
            label4.Text = клСообщение.длина_сообщения.ToString();
            //MatchCollection mc = Regex.Matches( клСообщение.текст,"[а-яА-Я]");
            //клСообщение.русских = mc.Count;
            //label5.Text = клСообщение.русских.ToString();
            //MatchCollection mc2 = Regex.Matches(клСообщение.текст, "[a-zA-Z0-9]");
            //клСообщение.латинских = mc2.Count;
            //label7.Text = клСообщение.латинских.ToString();

        }

        private void init_limit()
        {
            string strLimit = sms.CheckLimit(EnumAuthenticationTypes.StrongApi);
            char сепаратор = '\n';
            string[] строки = strLimit.Split(сепаратор);
            if (строки.Length > 1)
            {
                // лимит = int.Parse(строки[1]);
                клСообщение.лимит = int.Parse(строки[1]);
                textBox5.Text = клСообщение.лимит.ToString();
            }
            if (строки.Length > 2)
            {
                клСообщение.сообщений_за_день = int.Parse(строки[2]);
                textBox4.Text = клСообщение.сообщений_за_день.ToString();
            }



        }
        private void initBalance()
        {

            string strLimit = sms.CheckBalance(EnumAuthenticationTypes.Simple);
            char сепаратор = '\n';
            string[] строки = strLimit.Split(сепаратор);
            if (строки.Length > 1)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(строки[1]);
                    sb.Replace(".", ",");
                    клСообщение.баланс = Decimal.Parse(sb.ToString());
                    textBox3.Text = клСообщение.баланс.ToString();
                    клСообщение.старый_баланс = клСообщение.баланс;
                    //     textBox6.Text = клСообщение.старый_баланс.ToString();
                }
                catch
                {
                    MessageBox.Show(strLimit);
                }
            }

        }

        private void initСтоимость()
        {

            string strLimit = sms.CheckBalance(EnumAuthenticationTypes.Simple);
            char сепаратор = '\n';
            string[] строки = strLimit.Split(сепаратор);
            if (строки.Length > 1)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(строки[1]);
                    sb.Replace(".", ",");
                    клСообщение.баланс = Decimal.Parse(sb.ToString());
                    textBox3.Text = клСообщение.баланс.ToString();
                    //    textBox9.Text = клСообщение.старый_баланс.ToString();
                    клСообщение.стоимость = клСообщение.старый_баланс - клСообщение.баланс;
                    textBox6.Text = клСообщение.стоимость.ToString();
                    клСообщение.старый_баланс = клСообщение.баланс;
                }
                catch
                {
                    MessageBox.Show(strLimit);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            клСообщение.программисту = true;
            на_проводе();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            клСообщение.программисту = false;
            на_проводе();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (клСообщение.код.Trim().Length > 0)
            {
                SmsRu.Enumerations.ResponseOnStatusRequest статус = sms.CheckStatus(клСообщение.код, EnumAuthenticationTypes.Simple);
                //    MessageBox.Show(статус.ToString());
                if (статус == SmsRu.Enumerations.ResponseOnStatusRequest.MessageRecieved)
                {
                    MessageBox.Show("Отправлено");
                    клСообщение.отправлен = true; 
                }
                else
                {
                    MessageBox.Show("Не отправлено");

                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
