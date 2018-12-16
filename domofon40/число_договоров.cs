using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Entity;

namespace domofon40
{
    public partial class число_договоров : Form
    {
        public число_договоров()
        {
            InitializeComponent();
        }
        int текГод = DateTime.Today.Year;
        int текМесяц = DateTime.Today.Month;
        domofon40.domofon14Entities de = new domofon14Entities();
        List<temp> tempList = new List<temp>();
        private void число_договоров_Load(object sender, EventArgs e)
        {
            try
            {
                tempList = de.подключения
                    .Where(n => n.услуги.клиенты.Contains(n.клиенты))
                    .GroupBy(n => new { n.клиент, n.услуги })
                    .GroupBy(n => n.Key.услуги)
                      .Select(n => new temp
                      {
                           Услуги=n.Key,
                           услуга =  n.Key.услуга,
                            наимен = n.Key.наимен,
                          клиентов = n.Key.клиенты.Count(),
                           договоров=n.Count()
                      }
                      )
                      .OrderBy(n=>n.Услуги.виды_услуг.порядок)
                      .ThenBy(n=>n.Услуги.порядок)
                      .ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

    
            bindingSource1.DataSource = tempList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        class temp
        {
            public услуги Услуги { get; set; }
            public Guid услуга { get; set; }
            public string наимен { get; set; }
            public int клиентов { get; set; }
            public int договоров { get; set; }
       //     public int договоров2 { get; set; }

        }
    }
}
