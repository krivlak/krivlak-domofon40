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
    public partial class оплата_вид : Form
    {
        public оплата_вид()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        List<temp> tempList = new List<temp>();
        int строка = 0;
        private void оплата_вид_Load(object sender, EventArgs e)
        {
            try
            {
                заполнить_месяца();
                заполнить_оплачено();
                bindingSource1.DataSource = tempList;
                bindingSource1.Position = строка;
                клСетка.задать_ширину(dataGridView1);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка загрузки " + ex.Message);
            }
        }

        private void заполнить_месяца()
        {
           
            int i = -1;
            foreach (var gg in de.годы.OrderBy(n => n.год))
            {
                foreach (var mm in de.месяцы.OrderBy(n => n.месяц))
                {
                    i++;
              //      DateTime dt = DateTime.Parse("01." + mm.месяц.ToString().Trim() + "." + gg.год.ToString().Trim());

                    temp NewRow = new temp();

                    NewRow.год = gg.год;
                    NewRow.месяц = mm.месяц;
                    NewRow.наим_месяца = mm.наимен;
                    if(gg.год==DateTime.Today.Year && mm.месяц==DateTime.Today.Month)
                    {
                        строка = i;
                    }

                    tempList.Add(NewRow);

                    //i++;
                    //if (gg.год == DateTime.Today.Year && mm.месяц == DateTime.Today.Month)
                    //{
                    //    bindingSource1.Position = i;
                    //}


                }
            }
        }
        class temp
        {
            public int год { get; set;}
            public int месяц { get; set; }
            public string наим_месяца { get; set; }
            public Guid услуга { get; set; }
            public string наим_услуги { get; set; } = "";
            public string сумма { get; set; }
            public string дата { get; set; }
            public string номер { get; set; }
            //    public Guid вид_оплаты { get; set; }
            public string менеджер { get; set; } = "";
            public string наимен_вида { get; set; } = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void заполнить_оплачено()
        {
   //         var query = dsТабель1.вертикаль.ToDictionary(n => new { n.год, n.месяц });
            var query = tempList.ToDictionary(n => new { n.год, n.месяц });


            var queryОплачено = de.оплачено
                                  .Where(n => n.услуги.вид_услуги == клВид_услуги.вид_услуги)
                                  .Where(n => n.оплаты.клиент == клКлиент.клиент);
                              //    .ToArray();

            temp tRow;
           
            foreach (оплачено oRow in queryОплачено)
            {
                
                var ключ = new { oRow.год, oRow.месяц };
                if (query.ContainsKey(ключ))
                {
                   
                    tRow = query[ключ];
                    tRow.услуга = oRow.услуга;

                    if (tRow.наим_услуги == String.Empty)
                    {
                        tRow.наим_услуги = oRow.услуги.обозначение.Trim();
                        tRow.сумма = oRow.сумма.ToString();
                        tRow.дата = oRow.оплаты.дата.ToShortDateString();
                        tRow.номер = oRow.оплаты.номер.ToString().Trim();
                        tRow.наимен_вида = oRow.оплаты.виды_оплат.наимен.Trim();
                        tRow.менеджер = oRow.оплаты.сотрудники.фио.Trim();
                    }
                    else
                    {
                        tRow.наим_услуги += "; " + oRow.услуги.обозначение.Trim();
                        tRow.сумма += "; " + oRow.сумма.ToString();
                        tRow.дата += "; " + oRow.оплаты.дата.ToShortDateString();
                        tRow.номер += "; " + oRow.оплаты.номер.ToString().Trim();
                        tRow.наимен_вида += "; " + oRow.оплаты.виды_оплат.наимен.Trim();
                        tRow.менеджер += "; " + oRow.оплаты.сотрудники.фио.Trim();
                    }
                }
            }


        }

        
    }
}
