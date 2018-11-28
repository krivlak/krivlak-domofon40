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
    public partial class выбор_вида_оплат : Form
    {
        public выбор_вида_оплат()
        {
            InitializeComponent();
        }

        private void выбор_вида_оплат_Load(object sender, EventArgs e)
        {
            try
            {
                domofon40.domofon14Entities de = new domofon14Entities();
                List<виды_оплат> vList = de.виды_оплат.OrderBy(n => n.порядок).ToList();
                bindingSource1.DataSource = vList;
                if (de.виды_оплат.Count(n => n.вид_оплаты == клВид_оплаты.вид_оплаты) == 1)
                {
                    виды_оплат oldVid = de.виды_оплат.Single(n => n.вид_оплаты == клВид_оплаты.вид_оплаты);
                    //        System.Predicate<виды_оплат> pred = new Predicate<виды_оплат>()
                    //    var строка = vList.Find(n=>n.вид_оплаты==клВид_оплаты.вид_оплаты);
                    int строка = vList.IndexOf(oldVid);
                    //         int строка = bindingSource1.Find("вид_оплаты", клВид_оплаты.вид_оплаты);
                    //          MessageBox.Show(строка.ToString());
                    if (строка > 0)
                    {
                        bindingSource1.Position = строка;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Сбой загрузки " + ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(bindingSource1.Count>0)
            {
                виды_оплат tRow = bindingSource1.Current as виды_оплат;
                клВид_оплаты.deRow = tRow;
                клВид_оплаты.вид_оплаты = tRow.вид_оплаты;
                клВид_оплаты.наимен = tRow.наимен;
                клВид_оплаты.выбран = true;
                Close();
            }
        }
    }
}
