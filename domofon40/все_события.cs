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
    public partial class все_события : Form
    {
        public все_события()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        List<temp> tempList0 = new List<temp>();
        List<temp> tempList = new List<temp>();
        private void все_события_Load(object sender, EventArgs e)
        {
            заполнить_договор();
            заполнить_простой();
            заполнить_льготу();
            заполнить_отключение();
            заполнить_повтор();
            tempList = tempList0.OrderBy(n => n.дата_с).ToList();
            bindingSource1.DataSource = tempList;
            bindingSource1.MoveLast();
            dataGridView1.Focus();

          //  заполнить_предупреждение();
          
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
                //if (uRow.дата_по != null)
                //{
                //    NewRow.дата_по = uRow.дата_по.Value;
                //}
                tempList0.Add(NewRow);

            }
        }

        private void заполнить_простой()
        {

            foreach (простои uRow in de.простои
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
                tempList0.Add(NewRow);

            }
        }

        private void заполнить_договор()
        {

            foreach (подключения uRow in de.подключения
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
                tempList0.Add(NewRow);

            }
        }

        private void заполнить_льготу()
        {

            //var delRows = dsДолги1.События
            //   .Where(n => n.наимен == "Льгота");
            //foreach (var dRow in delRows)
            //{
            //    dRow.Delete();
            //}

            foreach (льготы uRow in de.льготы
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
                tempList0.Add(NewRow);

            }
        }

        //private void заполнить_предупреждение()
        //{



        //    foreach (предупреждения uRow in de.
        //        .Where(n => n.клиент == клКлиент.клиент))
        //    {
        //        temp NewRow = new temp();
        //        NewRow.услуга = uRow.услуга;
        //        NewRow.клиент = uRow.клиент;
        //        NewRow.наимен_услуги = uRow.услуга1.наимен;
        //        NewRow.наимен = "Предупреждение";
        //        NewRow.код = uRow.предупреждение1;
        //        NewRow.дата_с = uRow.дата;
        //        //if (uRow.дата_по != null)
        //        //{
        //        //    NewRow.дата_по = uRow.дата_по.Value;
        //        //}
        //        tempList.Add(NewRow);

        //    }
        //}

        private void заполнить_отключение()
        {

            foreach (отключения uRow in de.отключения
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
                tempList0.Add(NewRow);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
