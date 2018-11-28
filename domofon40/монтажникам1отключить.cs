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
    public partial class монтажникам1отключить : Form
    {
        public монтажникам1отключить()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities1 sqlDe = new domofon14Entities1();
        domofon40.domofon14Entities de = new domofon14Entities();

        List<задание1монтажникам_Result> Лист0 = new List<задание1монтажникам_Result>();
        List<задание1монтажникам_Result> заданиеЛист = new List<задание1монтажникам_Result>();
        List<temp> tempList = new List<temp>();

        private void монтажникам1отключить_Load(object sender, EventArgs e)
        {
            //object[] oPar = new object[2];
            //oPar[0] = клДом.дом;
            //oPar[1] = клВид_услуги.вид_услуги;

            ////string sqlComand = "задание1монтажникам @дом='" + клДом.дом + "', @вид_услуги ='" + клВид_услуги.вид_услуги + "'";
            ////tempList = de.Database.SqlQuery<temp>(sqlComand).ToList();

            //string sqlComand = "задание1монтажникам ";
            //tempList = de.Database.SqlQuery<temp>(sqlComand,oPar).ToList();

            //задание1монтажникам_ResultBindingSource.DataSource = tempList;
            Guid[] аУслуги = клВид_услуги.dictУслуг
                .Where(n => n.Value)
                .Select(n => n.Key)
                .ToArray();


            Лист0 = sqlDe.задание1монтажникам(клДом.дом, клВид_услуги.вид_услуги).ToList();

            //заданиеЛист = Лист0.Where(n => клВид_услуги.dictУслуг.ContainsKey(n.услуга)).ToList();
            заданиеЛист = Лист0.Where(n => аУслуги.Contains(n.услуга)).ToList();

            int minPor = 0;

            try
            {

                minPor = заданиеЛист.Min(n => n.порядок_услуги);


                foreach (var uRow in заданиеЛист
                    .Where(n => n.порядок_услуги != minPor))
                {
                    uRow.ввод = 0;
                    uRow.прим0 = "";
                    uRow.строка = 1;
                    uRow.телефон = "";
                    uRow.фио = "";
                    uRow.подъезд = 0;
                    uRow.ввод = 0;
                    uRow.квартира = 0;
                }
            }
            catch
            {
                MessageBox.Show("Сбой очистки");
            }

            задание1монтажникам_ResultBindingSource.DataSource = заданиеЛист;
        }

        private partial class temp
        {
            public System.Guid клиент { get; set; }
            public System.Guid услуга { get; set; }
            public int год { get; set; }
            public int месяц { get; set; }
            public int долг_мес { get; set; }
            public int долг_руб { get; set; }
            public Nullable<System.DateTime> договор_с { get; set; }
            public Nullable<System.DateTime> отключен { get; set; }
            public Nullable<System.DateTime> повтор { get; set; }
            public Nullable<System.DateTime> последний_звонок { get; set; }
            public string фио { get; set; }
            public int подъезд { get; set; }
            public int квартира { get; set; }
            public int квартира0 { get; set; }
            public int ввод { get; set; }
            public string телефон { get; set; }
            public int порядок_услуги { get; set; }
            public string наимен_услуги { get; set; }
            public int строка { get; set; }
            public bool отключить { get; set; }
            public bool подключить { get; set; }
            public bool повторно { get; set; }
            public bool наш { get; set; }
            public bool должник { get; set; }
    //        public string прим { get; set; }
   //         public string прим0 { get; set; }
          public string прим66 { get; set; }

        }

    }
}
