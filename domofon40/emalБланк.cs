using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Net.Mail;
using System.Net;

namespace domofon40
{
    public partial class emalБланк : Form
    {
        public emalБланк()
        {
            InitializeComponent();
        }
        RegexUtilities ru = new RegexUtilities();
        private void emalБланк_Load(object sender, EventArgs e)
        {
            textBox4.Text = клМыло.телефон0;
            textBox1.Text = клМыло.email;
            textBox3.Text = клМыло.тема;
            textBox2.Text = клМыло.текст;
            textBox1.Validating += textBox1_Validating;
        }

        void textBox1_Validating(object sender, CancelEventArgs e)
        {
            string строкаМыло = textBox1.Text.Trim();
            if (строкаМыло != String.Empty)
            {
                //       RegexUtilities ru = new RegexUtilities();
                if (ru.IsValidEmail(строкаМыло))
                {
                    //         клРазрешение.эл_почта = строкаМыло;
                }
                else
                {
                    MessageBox.Show("Неправильный формат электронной почты");
                    //                    textBox2.Focus();
                    e.Cancel = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MailMessage emal = new MailMessage();
            SmtpClient smtr = new SmtpClient("mail.intess.ru");
            //     SmtpClient smtr = new SmtpClient();

            NetworkCredential nc = new NetworkCredential();
            nc.Password = "123123";
            nc.UserName = "dma";
            smtr.Credentials = nc;
            MailAddress maFrom = new MailAddress("dma@intess.ru");
            emal.From = maFrom;
            MailAddress maTo = new MailAddress("dma@intess.ru");
            emal.To.Add(maTo);
            emal.Body = клМыло.текст.Trim();
            emal.Subject = клМыло.тема.Trim();
            //            System.Net.Mail.Attachment at = new System.Net.Mail.Attachment("Attachment");
            //  emal.Attachments.Add(at);
            //MessageBox.Show(smtr.Host);
            //MessageBox.Show(smtr.Port.ToString());

            try
            {
                smtr.Send(emal);
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Exception caught in CreateTimeoutTestMessage(): {0}",
                //      ex.ToString());
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.ToString());
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string адресПочты = textBox1.Text.Trim();
            if (!ru.IsValidEmail(адресПочты))
            {
                MessageBox.Show("Введите адресс электронной почты");
                return;
            }

            MailMessage emal = new MailMessage();
            SmtpClient smtr = new SmtpClient("mail.intess.ru");
            //SmtpClient smtr = new SmtpClient();

            NetworkCredential nc = new NetworkCredential();
            nc.Password = "123123";
            nc.UserName = "dma";
            smtr.Credentials = nc;
            MailAddress maFrom = new MailAddress("dma@intess.ru");
            emal.From = maFrom;
            MailAddress maTo = new MailAddress(адресПочты);
            emal.To.Add(maTo);

            клМыло.текст = textBox2.Text.Trim();
            клМыло.тема = textBox3.Text.Trim();
            emal.Body = клМыло.текст.Trim();
            emal.Subject = клМыло.тема.Trim();


            try
            {
                smtr.Send(emal);
                клМыло.дата = DateTime.Now;
                textBox8.Text = клМыло.дата.Value.ToLongTimeString();
                клМыло.отправлен = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка отправки.."+ ex.Message);

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
