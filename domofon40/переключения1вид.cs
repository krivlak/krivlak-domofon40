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
    public partial class переключения1вид : Form
    {
        public переключения1вид()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        private void переключения1вид_Load(object sender, EventArgs e)
        {
            var queryПовтор = de.повторы
                 .Where(n => n.услуги.вид_услуги == клВид_услуги.вид_услуги)
              .ToArray();

            var queryОткл = de.отключения
               .Where(n => n.услуги.вид_услуги == клВид_услуги.вид_услуги)
                .Where(n => n.дата_с >= клПериод.дата_с)
                .Where(n => n.дата_с <= клПериод.дата_по)
               .ToArray();

            foreach (var uRow in queryОткл)
            {
                foreach (повторы pRow in queryПовтор
                    .Where(n => n.дата_с == uRow.дата_с)
                    .Where(n => n.клиент == uRow.клиент)
                    .Where(n=>n.услуга != uRow.услуга))
                {
                   

                }
            }
        }
        //class temp2 : отключения
        //{
        //  public Guid  код { get;  set}
        //}
    }
}
