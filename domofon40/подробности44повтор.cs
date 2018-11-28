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
    public partial class подробности44повтор : Form
    {
        public подробности44повтор()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        List<temp> tempList = new List<temp>();
        private void подробности44повтор_Load(object sender, EventArgs e)
        {
            var query = de.повторы
    .Where(n => n.услуга == клУслуга.услуга)
    .Where(n => n.дата_с >= клПериод.дата_с)
    .Where(n => n.дата_с <= клПериод.дата_по)
    .OrderBy(n => n.дата_с)
    .ThenBy(n => n.мастер)
    .ToArray();


            if (клМастер.мастер != Guid.Empty)
            {
                query = query
                    .Where(n => n.мастер == клМастер.мастер)
                    .ToArray();

            }


            foreach (var uRow in query)
            {
                temp NewRow = new temp();

                NewRow.дата = uRow.дата_с;
                NewRow.клиент = uRow.клиент;
                NewRow.адрес = uRow.клиенты.адрес;
                NewRow.мастер = uRow.мастер;
                NewRow.услуга = uRow.услуга;
                NewRow.наимен_услуги = uRow.услуги.наимен;
                NewRow.фио = uRow.клиенты.фио;
                NewRow.фио_мастера = uRow.сотрудники.фио;
                NewRow.подключение = uRow.подключение;
                NewRow.прим = uRow.прим;
                tempList.Add(NewRow);


            }

            bindingSource1.DataSource = tempList;
            bindingSource1.MoveLast();

            dataGridView1.CellMouseClick += dataGridView1_CellMouseClick;

        }

        void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (dataGridView1.Columns[e.ColumnIndex] == мастерColumn)
                {
                    this.Validate();
                    bindingSource1.EndEdit();

                    dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    temp uRow = bindingSource1.Current as temp;
                    клМастер.мастер = uRow.мастер;
                    клМастер.выбран = false;
                    выбор_мастера ВыборМастера = new выбор_мастера();
                    ВыборМастера.ShowDialog();
                    if (клМастер.выбран)
                    {
                        uRow.мастер = клМастер.мастер;
                        uRow.фио_мастера = клМастер.фио;
                        try
                        {
                            повторы upRow = de.повторы.Single(n => n.подключение == uRow.подключение);
                            upRow.мастер = клМастер.мастер;
                            de.SaveChanges();
                            клМастер.изменен = true;
                        }
                        catch (Exception)
                        {

                            MessageBox.Show("Сбой записи...");
                        }

                    }

                }


            }

        }

        class temp
        {
            public Guid подключение { get; set; }
            public DateTime дата { get; set; }
            public Guid клиент { get; set; }
            public Guid услуга { get; set; }
            public string прим { get; set; }
            public string фио { get; set; }
            public string адрес { get; set; }
            public Guid мастер { get; set; }
            public string фио_мастера { get; set; }
            public string наимен_услуги { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
