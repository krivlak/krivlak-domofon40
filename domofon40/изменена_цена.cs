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
    public partial class изменена_цена : Form
    {
        public изменена_цена()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        //List<temp> tempList = new List<temp>();
        private void изменена_цена_Load(object sender, EventArgs e)
        {
            
            //foreach (услуги uRow in de.услуги)
            //{
            //    int случаев = 0;
            //    foreach (цены zRow in de.цены.Where(n=>n.услуга==uRow.услуга))
            //    {
                  
            //        int yx = de.оплачено.Where(n => n.услуга == uRow.услуга)
            //            .Where(n => n.год == zRow.год)
            //            .Where(n => n.месяц == zRow.месяц)
            //            .Count(n => n.цена != zRow.стоимость);
            //        случаев += yx;
            //    }
            //    Console.Write(uRow.наимен);
            //    Console.WriteLine(случаев.ToString());
            //}
        }

        class ключ
        {
            public int год { get; set; }
            public int месяц { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (услуги uRow in de.услуги)
            {
                int случаев = 0;
                foreach (цены zRow in de.цены.Where(n => n.услуга == uRow.услуга))
                {

                    int yx = de.оплачено.Where(n => n.услуга == uRow.услуга)
                        .Where(n => n.год == zRow.год)
                        .Where(n => n.месяц == zRow.месяц)
                        .Count(n => n.цена != zRow.стоимость);
                    случаев += yx;
                }
                Console.Write(uRow.наимен);
                Console.WriteLine(случаев.ToString());
            }
        }

        //class temp
        //{

        //}
    }
}
