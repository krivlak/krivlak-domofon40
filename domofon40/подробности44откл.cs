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
    public partial class подробности44откл : Form
    {
        public подробности44откл()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        List<temp> tempList = new List<temp>();
        private void подробности44откл_Load(object sender, EventArgs e)
        {
            var query = de.отключения
                           .Where(n => n.услуга == клУслуга.услуга)
                           .Where(n => n.дата_с >= клПериод.дата_с)
                           .Where(n => n.дата_с <= клПериод.дата_по)
                           .OrderBy(n => n.дата_с)
                           .ThenBy(n => n.мастер)
                           .ToArray();

            foreach (var oRow in query)
            {
                oRow.дата_по = null;
            }

            var query2 = de.повторы
                             .Where(n => n.услуга == клУслуга.услуга)
                             .OrderBy(n => n.дата_с)
                             .ToArray();

            var Dict3 = de.подключения
                          .Where(n => n.услуга == клУслуга.услуга)
                          .GroupBy(n => n.клиент)
                          .Select(n => new { клиент = n.Key, maxData = n.Max(p => p.дата_с) })
                          .ToDictionary(n => n.клиент);

            foreach (var oRow in query)
            {
                foreach (var pRow in query2
                    .Where(n => n.клиент == oRow.клиент))
                {
                    if (oRow.дата_с <= pRow.дата_с)
                    {
                        oRow.дата_по = pRow.дата_с;
                    }
                }

            }

            foreach (var uRow in query)
            {

                temp NewRow = new temp()
                {
                    адрес = uRow.адрес,
                    дата_с = uRow.дата_с,
                    клиент = uRow.клиент,
                    мастер = uRow.мастер,
                    услуга = uRow.услуга,
                    наимен_услуги = uRow.услуги.обозначение,
                    прим = uRow.прим,
                    фио = uRow.клиенты.фио,
                    фио_мастера = uRow.сотрудники.фио

                };
                if (Dict3.ContainsKey(uRow.клиент))
                {
                    NewRow.договор_с = Dict3.Single(n => n.Key == uRow.клиент).Value.maxData;
                }

                if (uRow.дата_по != null)
                {
                    NewRow.дата_по = uRow.дата_по.Value;
                }

                tempList.Add(NewRow);

            }
            bindingSource1.DataSource = tempList;
            dataGridView1.Focus();
        }
        class temp
        {
            public Guid клиент { get; set; }
            public string адрес { get; set; }
            public string фио { get; set; }
            public Guid мастер { get; set; }
            public string фио_мастера { get; set; }
            public Guid услуга { get; set; }
            public string наимен_услуги { get; set; }
            public DateTime дата_с { get; set; }
            public string прим { get; set; }
            public DateTime договор_с { get; set; }
            public DateTime дата_по { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
