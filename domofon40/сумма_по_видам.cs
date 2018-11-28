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
    public partial class сумма_по_видам : Form
    {
        public сумма_по_видам()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        List<temp> tempList = new List<temp>();
        private void сумма_по_видам_Load(object sender, EventArgs e)
        {
            try
            {
                var queryОплачено = de.оплачено
        .Where(n => n.оплаты.сотрудник == клСотрудник.сотрудник)
        .Where(n => n.оплаты.дата == клРеестр.дата)
        .GroupBy(n => n.услуги.виды_услуг)
        .Select(n => new temp { вид_услуги = n.Key.вид_услуги, наимен = n.Key.наимен, сумма = n.Sum(s => s.сумма) });


                int заВсе = 0;
                int всего = 0;
                foreach (var uRow in queryОплачено)
                {
                    всего += uRow.сумма;
                    заВсе += uRow.сумма;
                    temp NewRow = new temp();
                    NewRow.вид_услуги = uRow.вид_услуги;
                    NewRow.наимен = uRow.наимен;
                    NewRow.сумма = uRow.сумма;
                    tempList.Add(NewRow);
                }
                temp NewRow1 = new temp();
                NewRow1.вид_услуги = Guid.Empty;
                NewRow1.наимен = "Всего оплачено ";
                NewRow1.сумма = всего;
                tempList.Add(NewRow1);


                var queryВозврат = de.возврат
            .Where(n => n.оплаты.сотрудник == клСотрудник.сотрудник)
            .Where(n => n.оплаты.дата == клРеестр.дата)
            .GroupBy(n => n.услуги.виды_услуг)
            .Select(n => new { n.Key.вид_услуги, n.Key.наимен, сумма = n.Sum(s => s.сумма) });

                всего = 0;
                foreach (var uRow in queryВозврат)
                {
                    заВсе -= uRow.сумма;
                    всего += uRow.сумма;
                    temp NewRow = new temp();
                    NewRow.вид_услуги = uRow.вид_услуги;
                    NewRow.наимен = "возврат " + uRow.наимен.Trim();
                    NewRow.сумма = uRow.сумма;
                    tempList.Add(NewRow);
                }
                temp NewRow2 = new temp();
                NewRow2.вид_услуги = Guid.Empty;
                NewRow2.наимен = "Всего возврат ";
                NewRow2.сумма = всего;
                tempList.Add(NewRow2);

                var queryРаботы = de.опл_работы
        .Where(n => n.оплаты.сотрудник == клСотрудник.сотрудник)
        .Where(n => n.оплаты.дата == клРеестр.дата)
        .GroupBy(n => n.работы)
        .Select(n => new { n.Key.работа, n.Key.наимен, сумма = n.Sum(s => s.стоимость) });

                всего = 0;
                foreach (var uRow in queryРаботы)
                {
                    заВсе += (int)uRow.сумма;
                    всего += (int)uRow.сумма;
                    temp NewRow = new temp();
                    NewRow.вид_услуги = uRow.работа;
                    NewRow.наимен = uRow.наимен.Trim();
                    NewRow.сумма = (int)uRow.сумма;
                    tempList.Add(NewRow);
                }
                temp NewRow3 = new temp();
                NewRow3.вид_услуги = Guid.Empty;
                NewRow3.наимен = "Всего за работы";
                NewRow3.сумма = всего;
                tempList.Add(NewRow3);

                temp NewRow4 = new temp();
                NewRow4.вид_услуги = Guid.Empty;
                NewRow4.наимен = "Всего за день";
                NewRow4.сумма = заВсе;
                tempList.Add(NewRow4);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Сбой загрузки " + ex.Message);
            }
            bindingSource1.DataSource = tempList;
            dataGridView1.DataSource = bindingSource1;
            dataGridView1.CellFormatting += DataGridView1_CellFormatting;
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            Guid кодУслуги = (Guid) dataGridView1.Rows[e.RowIndex].Cells["видColumn"].Value;
            if (кодУслуги==Guid.Empty)
            {
                e.CellStyle.BackColor = Color.LightBlue;
            }
        }

        class temp
        {
           public Guid вид_услуги { get; set; }
           public string наимен { get; set; }
           public int сумма { get; set; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
