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
    public partial class суммы1день : Form
    {
        public суммы1день()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities db = new domofon14Entities();
        List<temp> tempList = new List<temp>();
        private void суммы1день_Load(object sender, EventArgs e)
        {
 
            try
            {
                суммы_за_день();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
        }

        void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            Guid КодВида =(Guid)  dataGridView1.Rows[e.RowIndex].Cells["вид_услугиColumn"].Value;
            if (КодВида == Guid.Empty)
            {
                e.CellStyle.BackColor = Color.FromArgb(200, 255, 200);
            }
        }
        class temp
        {
            public Guid вид_услуги { get; set; }
            public string наимен { get; set; }
           public  Guid вид_оплаты { get; set; }
            public string наимен_вида_опл  { get; set; }
            public int сумма { get; set; }
            public виды_услуг видыУслуг { get; set; }
            public виды_оплат видыОплат { get; set; }
        }
        private void суммы_за_день()
        {
            клРеестр.дата = DateTime.Today;
            //        клРеестр.дата = new DateTime(2018, 9, 13);
            tempList = db.оплачено
                 .Where(n => n.оплаты.дата == клРеестр.дата)
                 .Where(n => n.оплаты.сотрудник == клСотрудник.сотрудник)
                 .GroupBy(n => new { n.услуги.виды_услуг, n.оплаты.виды_оплат })
                 .Select(n => new temp
                 {
                     вид_услуги = n.Key.виды_услуг.вид_услуги,
                     наимен = n.Key.виды_услуг.наимен,
                     наимен_вида_опл = n.Key.виды_оплат.наимен,
                     сумма = n.Sum(s => s.сумма),
                     вид_оплаты = n.Key.виды_оплат.вид_оплаты,
                     видыОплат = n.Key.виды_оплат,
                     видыУслуг = n.Key.виды_услуг
                 }).ToList();

            //dsTemp.суммы.Clear();

            int заВсе = 0;
           
            //////////////////////////////////////////

            var queryВозврат = db.возврат
        .Where(n => n.оплаты.дата == клРеестр.дата)
         .Where(n => n.оплаты.сотрудник == клСотрудник.сотрудник)
        .GroupBy(n => n.услуги.виды_услуг)
        .Select(n => new temp
        {
            вид_услуги = n.Key.вид_услуги,
            наимен = n.Key.наимен,
            наимен_вида_опл = " возврат",
            сумма =- n.Sum(s => s.сумма),
            видыУслуг = n.Key
        }).ToList();

            tempList.AddRange(queryВозврат);

            int всего_усл = tempList.Sum(n => n.сумма);

            int всего_возврат = queryВозврат.Sum(n => n.сумма);
            if (всего_возврат > 0)
            {
                temp newTemp5 = new temp()
                {
                    наимен = "Всего",
                    наимен_вида_опл = " возврат",
                    сумма = всего_возврат
                };
                tempList.Add(newTemp5);
            }

            var query = tempList
                .GroupBy(n => n.видыУслуг)
               .Select(n => new temp
               {
                   вид_услуги = n.Key.вид_услуги,
                   наимен = n.Key.наимен,
                   наимен_вида_опл = " всего",
                   сумма = n.Sum(s => s.сумма),
                   вид_оплаты = Guid.Empty
               }).ToList();

            tempList.AddRange(query);

          
           
            temp NewRow1 = new temp()
            {
                вид_услуги = Guid.Empty,
                наимен = "Всего оплачено ",
                наимен_вида_опл = "за услуги",
                вид_оплаты = Guid.Empty,
                сумма = всего_усл
            };
            tempList.Add(NewRow1);


          

            //////////////////////////////////////////////////
            List<temp> queryРаботы = db.опл_работы
     .Where(n => n.оплаты.дата == клРеестр.дата)
     .Where(n => n.оплаты.сотрудник == клСотрудник.сотрудник)
    .GroupBy(n => n.оплаты.виды_оплат)
    .Select(n => new temp
    {
        вид_оплаты = n.Key.вид_оплаты,
        наимен_вида_опл = n.Key.наимен,
        наимен = "за работы",
        вид_услуги = Guid.Empty,
        сумма = n.Sum(s => s.стоимость)
    }).ToList();
            tempList.AddRange(queryРаботы);



        
          
            // возврат за работы 
            List<temp> queryРаботыВоз = db.воз_работы
                .Where(n => n.оплаты.дата == клРеестр.дата)
                .Where(n => n.оплаты.сотрудник == клСотрудник.сотрудник)
                .Select(n => new temp
                {
                    вид_оплаты = n.работа,
                    наимен_вида_опл = n.работы.наимен,
                    наимен = "возврат за работы",
                    вид_услуги = Guid.Empty,
                    сумма = - n.сумма
                }).ToList();
     //       tempList.AddRange(queryРаботыВоз);

            int всего_раб_воз = queryРаботыВоз.Sum(n =>  n.сумма);
            if (всего_раб_воз < 0)
            {
                temp NewRow33 = new temp()
                {
                    вид_услуги = Guid.Empty,
                    наимен = "Всего возврат ",
                    сумма = всего_раб_воз,
                    наимен_вида_опл = "за работы"
                };
                tempList.Add(NewRow33);
            }

            int всего_раб = queryРаботы.Sum(n => n.сумма);
            всего_раб += всего_раб_воз;
            //if (всего_раб  0)
            //{
                temp NewRow3 = new temp()
                {
                    вид_услуги = Guid.Empty,
                    наимен = "Всего ",
                    сумма = всего_раб,
                    наимен_вида_опл = "за работы"
                };
                tempList.Add(NewRow3);
            //}

            заВсе = всего_усл  + всего_раб;
            temp NewRow4 = new temp();
            NewRow4.вид_услуги = Guid.Empty;
            NewRow4.наимен = "Всего за день";
            NewRow4.сумма = заВсе;
            tempList.Add(NewRow4);

            int числоОплат = 0;
            числоОплат = db.оплаты
                 .Where(n => n.сотрудник == клСотрудник.сотрудник)
                .Count(n => n.дата == клРеестр.дата);

            temp NewRow5 = new temp();
            NewRow5.вид_услуги = Guid.Empty;
            NewRow5.наимен = "Число оплат";
            NewRow5.сумма = числоОплат;
            tempList.Add(NewRow5);
            //////////////////////////////////////////
         


            //var queryМен = db.оплачено
            //    //    .Where(n => n.оплата1.сотрудник == клСотрудник.сотрудник)
            //    .Where(n => n.оплата1.дата.Date == клРеестр.дата)
            //    .GroupBy(n => n.оплата1.сотрудник1)
            //    .Select(n => new { n.Key.сотрудник1, n.Key.фио, сумма = n.Sum(s => s.сумма) });

            //foreach (var uRow in queryМен)
            //{
            //    DsTemp.суммыRow NewRow = dsTemp.суммы.NewсуммыRow();
            //    NewRow.вид_услуги = uRow.сотрудник1;
            //    NewRow.наимен = uRow.фио;
            //    NewRow.сумма = uRow.сумма;
            //    dsTemp.суммы.Rows.Add(NewRow);
            //}

            bindingSource1.DataSource = tempList;
            dataGridView1.DataSource = bindingSource1;
            dataGridView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            клРеестр.дата = DateTime.Today;
        //    клРеестр.дата = new DateTime(2015, 10, 1);
            клРеестр.фио_менеджера = клСотрудник.фио;
            клРеестр.выбран = false;
            клВид_услуги.выбран = false;
            выбор_вида_услуги выборВида = new выбор_вида_услуги();
            выборВида.ShowDialog();
            if (клВид_услуги.выбран)
            {
                клВид_оплаты.выбран = false;
                выбор_вида_оплат выборВидаОплаты = new выбор_вида_оплат();
                выборВидаОплаты.ShowDialog();
                if (клВид_оплаты.выбран || выборВидаОплаты.DialogResult == DialogResult.OK)
                {
                    клРеестр.вид_оплаты = клВид_оплаты.вид_оплаты;
                    клРеестр.наименВидаОплаты = клВид_оплаты.наимен;

                    Cursor = Cursors.WaitCursor;
                    реестр_услуг формаРеестр = new реестр_услуг();
                    формаРеестр.Text = "Реестр за " + клРеестр.дата.ToLongDateString() + " по ";
                    формаРеестр.Text += " " + клВид_услуги.наимен.Trim();
                    формаРеестр.Text += " " + клСотрудник.фио.Trim();

                    //    Model.domofonEntities de = new Model.domofonEntities();
                    string наименФилиала = db.филиалы
                        .OrderBy(n => n.порядок)
                        .First().наимен;
                    формаРеестр.Text += " вид_оплаты " + клРеестр.наименВидаОплаты;
                   формаРеестр.Text += " по филиалу " + наименФилиала;

                    формаРеестр.ShowDialog();
                    Cursor = Cursors.Default;
                }
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            клВид_оплаты.выбран = false;
            выбор_вида_оплат выборВидаОплаты = new выбор_вида_оплат();
            выборВидаОплаты.ShowDialog();
            if (клВид_оплаты.выбран || выборВидаОплаты.DialogResult == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                клПериод.дата_с = DateTime.Today;
                клПериод.дата_по = DateTime.Today;
                реестр_работ формаАнализ = new реестр_работ();
                формаАнализ.Text = "Реестр оплаченых работ за "
                    + клПериод.дата_с.ToLongDateString() + "  "
                    + клПериод.дата_по.ToLongDateString() + " менеджер  "
                    + клСотрудник.фио;
                формаАнализ.ShowDialog();
                Cursor = Cursors.Default;
            }
        }

    }
}
