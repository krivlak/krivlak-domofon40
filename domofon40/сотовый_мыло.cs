using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace domofon40
{
    public partial class сотовый_мыло : Form
    {
        public сотовый_мыло()
        {
            InitializeComponent();
        }
        RegexUtilities ru = new RegexUtilities();
        private void сотовый_мыло_Load(object sender, EventArgs e)
        {
            textBox5.Text = клРазрешение.все_телефоны;
            textBox1.Text = клРазрешение.телефон;
            textBox2.Text = клРазрешение.эл_почта;
            textBox3.Text = клРазрешение.дата_с.ToShortDateString();
            if (клРазрешение.дата_по != null)
            {
                textBox4.Text = клРазрешение.дата_по.Value.ToShortDateString();
            }

            //textBox1.LostFocus
            textBox1.Validating += textBox1_Validating;
            textBox1.KeyPress += textBox1_KeyPress;

            textBox2.Validating += textBox2_Validating;
        }

        void textBox2_Validating(object sender, CancelEventArgs e)
        {
            string строкаМыло = textBox2.Text.Trim();
            if (строкаМыло != String.Empty)
            {
                RegexUtilities ru = new RegexUtilities();
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

        void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            клKey.int_KeyPress(sender, e);
        }

        void textBox1_Validating(object sender, CancelEventArgs e)
        {
            string строка10 = textBox1.Text.Trim();
            if (строка10 != String.Empty)
            {
                if (проверка_сотового(строка10))
                {
                    //                  клРазрешение.телефон = строка10;
                }
                else
                {
                    MessageBox.Show("Сотовый телефон должен содержать 10 цифр");
                    e.Cancel = true;
                    //                    textBox1.Focus();
                }
            }
        }

        private bool проверка_сотового(string строка_телефон)
        {
            string шаблон = @"\b\d{10}\b";

            if (Regex.Matches(строка_телефон, шаблон).Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            клКалендарь.дата = клРазрешение.дата_с;

            клКалендарь.выбран = false;
            календарь выборДаты = new календарь();
            выборДаты.button3.Visible = false;
            выборДаты.ShowDialog();
            if (клКалендарь.выбран)
            {
                клРазрешение.дата_с = клКалендарь.дата.Value;
                textBox3.Text = клРазрешение.дата_с.ToShortDateString();

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string строка10 = textBox1.Text.Trim();
            if (строка10 != String.Empty)
            {
                if (проверка_сотового(строка10))
                {
                    клРазрешение.телефон = строка10;
                }
                else
                {
                    MessageBox.Show("Сотовый телефон должен содержать 10 цифр");
                    textBox1.Focus();
                    return;
                }
            }

            string строкаМыло = textBox2.Text.Trim();
            if (строкаМыло != String.Empty)
            {
                RegexUtilities ru = new RegexUtilities();
                if (ru.IsValidEmail(строкаМыло))
                {
                    клРазрешение.эл_почта = строкаМыло;
                }
                else
                {
                    MessageBox.Show("Неправильный формат электронной почты");
                    textBox2.Focus();
                    return;
                }
            }
            //            клРазрешение.телефон = textBox1.Text.Trim();

            //    клРазрешение.эл_почта = textBox2.Text.Trim();
            клРазрешение.выбран = true;
            Close();

        }


    }
}
