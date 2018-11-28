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
    public partial class отключения1дом : Form
    {
        public отключения1дом()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        List<temp> tempList = new List<temp>();
        private void отключения1дом_Load(object sender, EventArgs e)
        {
            string sqlString = "задание1монтажникам @дом='" + клДом.дом.ToString() + "' , @вид_услуги='" + клВид_услуги.вид_услуги.ToString()+"'";
            //Guid[] par = new Guid[2];
            //par[0]=клДом.дом;
            //par[1]= клВид_услуги.вид_услуги;


            tempList = de.Database.SqlQuery<temp>(sqlString ).ToList();
            dataGridView1.AutoGenerateColumns=true;
            bindingSource1.DataSource=tempList;

        }

        public partial class temp
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
            public string прим { get; set; }
            public string прим0 { get; set; }
        }

    }
}
