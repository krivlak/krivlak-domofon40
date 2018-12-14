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
    public partial class события1вид : Form
    {
        public события1вид()
        {
            InitializeComponent();
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Top = 0;
        }

    
        domofon40.domofon14Entities de = new domofon14Entities();
 
        List<temp> tempList = new List<temp>();
        private void события1вид_Load(object sender, EventArgs e)
        {
            try
            {
                найти_начало();
                заполнить_договор();
                заполнить_простой();
                заполнить_льготу();
                заполнить_отключение();
                заполнить_повтор();
                tempList = tempList.OrderBy(n => n.дата_с).ToList();
                bindingSource1.DataSource = tempList;
                bindingSource1.MoveLast();
                dataGridView1.Focus();
                клСетка.задать_ширину(dataGridView1);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Сбой загрузки  {ex.Message}");
            }
        }

        class temp
        {
            public Guid услуга { get; set; }
            public Guid клиент { get; set; }
            public string наимен_услуги { get; set; }
            public string наимен { get; set; }
            public DateTime дата_с { get; set; }
            public DateTime? дата_по { get; set; }
            public string прим { get; set; }
            public Guid код { get; set; }
        }

        private void заполнить_повтор()
        {

            foreach (повторы uRow in de.повторы
                .Where(n=>n.услуги.вид_услуги==клВид_услуги.вид_услуги)
                .Where(n => n.клиент == клКлиент.клиент))
            {
                temp NewRow = new temp();
                NewRow.услуга = uRow.услуга;
                NewRow.клиент = uRow.клиент;
                NewRow.наимен_услуги = uRow.услуги.наимен;
                NewRow.наимен = "повтор";
                NewRow.дата_с = uRow.дата_с;
                NewRow.код = uRow.подключение;
                NewRow.прим = uRow.прим;

                tempList.Add(NewRow);

            }
        }

        private void заполнить_простой()
        {

            foreach (простои uRow in de.простои
                .Where(n => n.услуги.вид_услуги == клВид_услуги.вид_услуги)
                .Where(n => n.клиент == клКлиент.клиент))
            {
                temp NewRow = new temp();
                NewRow.услуга = uRow.услуга;
                NewRow.клиент = uRow.клиент;
                NewRow.наимен_услуги = uRow.услуги.наимен;
                NewRow.наимен = "простой";
                NewRow.дата_с = uRow.дата_с;
                NewRow.код = uRow.простой;
                if (uRow.дата_по != null)
                {
                    NewRow.дата_по = uRow.дата_по.Value;
                }
                tempList.Add(NewRow);

            }
        }

        private void заполнить_договор()
        {

            foreach (подключения uRow in de.подключения
                .Where(n => n.услуги.вид_услуги == клВид_услуги.вид_услуги)
                .Where(n => n.клиент == клКлиент.клиент))
            {
                temp NewRow = new temp();
                NewRow.услуга = uRow.услуга;
                NewRow.клиент = uRow.клиент;
                NewRow.наимен_услуги = uRow.услуги.наимен;
                NewRow.наимен = "договор № " + uRow.номер_дог.Trim() + uRow.номер_пп.ToString();
                NewRow.дата_с = uRow.дата_с;
                NewRow.код = uRow.подключение;
                if (uRow.дата_по != null)
                {
                    NewRow.дата_по = uRow.дата_по.Value;
                }
                tempList.Add(NewRow);

            }
        }

        private void заполнить_льготу()
        {

            foreach (льготы uRow in de.льготы
                .Where(n => n.услуги.вид_услуги == клВид_услуги.вид_услуги)
                .Where(n => n.клиент == клКлиент.клиент))
            {
                temp NewRow = new temp();
                NewRow.услуга = uRow.услуга;
                NewRow.клиент = uRow.клиент;
                NewRow.наимен_услуги = uRow.услуги.наимен;
                NewRow.наимен = "Льгота";
                NewRow.код = uRow.льгота;
                NewRow.дата_с = uRow.дата_с;
                if (uRow.дата_по != null)
                {
                    NewRow.дата_по = uRow.дата_по.Value;
                }
                tempList.Add(NewRow);

            }
        }

         private void заполнить_отключение()
        {

            foreach (отключения uRow in de.отключения
                .Where(n => n.услуги.вид_услуги == клВид_услуги.вид_услуги)
                .Where(n => n.клиент == клКлиент.клиент))
            {
                temp NewRow = new temp();
                NewRow.услуга = uRow.услуга;
                NewRow.клиент = uRow.клиент;
                NewRow.наимен_услуги = uRow.услуги.наимен;
                NewRow.наимен = "Отключение";
                NewRow.дата_с = uRow.дата_с;
                NewRow.код = uRow.отключение;
                NewRow.прим = uRow.прим;
                if (uRow.дата_по != null)
                {
                    NewRow.дата_по = uRow.дата_по.Value;
                }
                tempList.Add(NewRow);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        void найти_начало()
        {
            foreach (услуги uRow in de.услуги.Where(n => n.вид_услуги == клВид_услуги.вид_услуги))
            {
                DateTime начало0 = de.начало.First().дата.Date;
                DateTime начало = de.начало.First().дата.Date;
                bool нет_оплат = true;

                if (de.оплачено.Where(n => n.услуга == uRow.услуга && n.оплаты.клиент == клКлиент.клиент).Any())
                {
                    int g100m = de.оплачено.Where(n => n.услуга == uRow.услуга && n.оплаты.клиент == клКлиент.клиент).Min(n => n.год * 100 + n.месяц);
                    int год = (int)g100m / 100;
                    int месяц = g100m - год * 100;
                    DateTime dt1 = new DateTime(год, месяц, 1);
                    нет_оплат = false;
                    if (dt1 > начало)
                    {
                        начало = dt1;
                    }

                }
            //    bool xy = true;  // оплата и договор в одном месяце
                if (de.подключения.Where(n => n.услуга == uRow.услуга && n.клиент == клКлиент.клиент).Any())
                {
                    DateTime dt = de.подключения.Where(n => n.услуга == клУслуга.услуга && n.клиент == клКлиент.клиент).Min(n => n.дата_с);
                    if (dt <= начало || (dt.Year*100+dt.Month == начало.Year * 100 + начало.Month) || нет_оплат)
                    {
                        начало = dt;
           //             xy = false;
                    }
                }

                if (!нет_оплат)
                {
                    temp newTemp = new temp
                    {
                        дата_с = начало,
                        наимен_услуги = uRow.наимен,
                        прим = " ",
                        наимен = "начало оплаты "
                    };
                    tempList.Add(newTemp);
                }
             
            }


        }
    }
}
