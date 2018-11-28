using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmsRu;
using SmsRu.Enumerations;
using System.Text.RegularExpressions;

namespace domofon40
{
    public partial class список_звонков : Form
    {
        public список_звонков()
        {
            InitializeComponent();
        }
        ISmsProvider sms = new SmsRuProvider();
        domofon14Entities de = new domofon14Entities();
        List<temp> listTemp = new List<temp>();
        List<комбо> listКомбо = new List<комбо>();
        private void список_звонков_Load(object sender, EventArgs e)
        {
            
            string sqlComanda = "звонки_на_сотовый";
        //    var ee = de.Database.SqlQuery<temp>(sqlComanda);

            listTemp = de.Database.SqlQuery<temp>(sqlComanda).ToList();

            //MessageBox.Show(ee.Count().ToString());
            //foreach (temp tRow in ee)
            //{
            //    listTemp.Add(tRow);
            //}
            //      MessageBox.Show(listTemp.Count.ToString());
            bindingSource1.DataSource = listTemp;
            bindingSource1.MoveLast();

            заполнить_комбо();
            //init_limit();
            //initBalance();

            //    bindingSource1.PositionChanged += bindingSource1_PositionChanged;
            dataGridView1.CellPainting += dataGridView1_CellPainting;

            comboBox1.SelectedValueChanged += comboBox1_SelectedValueChanged;
        }

        void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            int строка = (int)comboBox1.SelectedValue;
            switch (строка)
            {
                case 1:
                 //   listTemp = listTemp0.OrderBy(n => n.дата_с).ToList();
//                    работыЛист.Sort((a, b) => a.стоимость.CompareTo(b.стоимость));
                    listTemp.Sort((a, b) => a.дата_звонка.Value.CompareTo(b.дата_звонка.Value));
                    break;
                case 2:
                   // listTemp = listTemp0.OrderBy(n => n.фио).ToList();
                    listTemp.Sort((a, b) => a.фио.CompareTo(b.фио));
                    break;
                //case 3:
                //    listTemp = listTemp0
                //        .OrderBy(n => n.наимен_улицы)
                //        .ThenBy(n => n.номер_дома)
                //        .ThenBy(n => n.корпус)
                //        .ThenBy(n => n.квартира)
                //        .ThenBy(n => n.ввод)
                //        .ToList();


                //    break;
                //case 4:
                //    listTemp = listTemp0.OrderBy(n => n.номер).ToList();
                //    break;
            }
         //   bindingSource1.DataSource = listTemp;
            dataGridView1.Refresh();
        }

        void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            string[] заголовки = { "отключитьColumn", "повторноColumn", "действуетColumn", "подключитьColumn", "вводColumn", "квартираColumn", "должникColumn", "корпусColumn" };
            if (e.RowIndex > -1 || e.ColumnIndex < 0)
            {
                e.Handled = false;
                return;
            }
            if (заголовки.Contains(dataGridView1.Columns[e.ColumnIndex].Name))
            {
                e.PaintBackground(e.ClipBounds, true);
                e.Graphics.RotateTransform(-90.0F);
                string текст = dataGridView1.Columns[e.ColumnIndex].HeaderText;
                //                System.Drawing.Font шрифт = квартирыDataGridView.Font;
                System.Drawing.Font шрифт = label1.Font;

                RectangleF p = new RectangleF(-e.CellBounds.Top - e.CellBounds.Height + 5, e.CellBounds.Left + 5,
                                              e.CellBounds.Height, e.CellBounds.Width);
                //if (dataGridView1.Columns[e.ColumnIndex] == отключитьColumn)
                //{
                //    e.Graphics.DrawString(текст, шрифт, Brushes.Red, p);
                //}
                //else
                //{
                e.Graphics.DrawString(текст, шрифт, Brushes.Black, p);
                //    }


                e.Graphics.RotateTransform(90.0F);
                e.Handled = true;
            }

        }

        partial class temp
        {

            public Guid клиент { get; set; }
            public Guid услуга { get; set; }
            public int год { get; set; }
            public int месяц { get; set; }
            public int долг_мес { get; set; }
            public int долг_руб { get; set; }
            public DateTime? договор_с { get; set; }
            public DateTime? отключен { get; set; }
            public DateTime? повтор { get; set; }
            public DateTime? дата_звонка { get; set; }
            public string фио { get; set; }
            public int квартира { get; set; }
            public int квартира0 { get; set; }
            public int ввод { get; set; }
            public string телефон { get; set; }
            public int порядок_вида { get; set; }
            public int порядок_услуги { get; set; }
            public string наимен_услуги { get; set; }
            public int строка { get; set; }
            public bool смс { get; set; }
            public string прим { get; set; }
            public string прим0 { get; set; }
            public string код_сообщения { get; set; }
            public string наимен_улицы { get; set; }
            public string корпус { get; set; }
            public int номер_дома { get; set; }
            public Guid  звонок { get; set; }

            public Guid? разрешение { get; set; }
            public DateTime? дата_разрешения { get; set; }
            public int номер_разрешения { get; set; }
            public string сотовый { get; set; }
            public string эл_почта { get; set; } 


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            temp tRow = bindingSource1.Current as temp;
            клКлиент.клиент = tRow.клиент;
            клУслуга.услуга = tRow.услуга;
            клУслуга.долг_руб = tRow.долг_руб;
            только_просмотр формаОплатить = new только_просмотр();

            формаОплатить.Text = "Оплаты за " + tRow.наимен_услуги.Trim() + " " + tRow.фио;


            формаОплатить.ShowDialog();
            Cursor = Cursors.Default;
            if (клУслуга.долг_руб != tRow.долг_руб && tRow.долг_мес > 1)
            {
                tRow.долг_руб = клУслуга.долг_руб;
                dataGridView1.Refresh();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            temp tRow = bindingSource1.Current as temp;

            Guid КодЗвонка = tRow.звонок;
            if (de.звонки.Any(n => n.звонок == tRow.звонок))
            {
                Cursor = Cursors.WaitCursor;
                var delRow = de.звонки.Single(n => n.звонок == tRow.звонок);
                de.звонки.Remove(delRow);
                de.SaveChanges();
                bindingSource1.RemoveCurrent();
           //     bindingSource1.MoveLast();
                dataGridView1.Refresh();
     
                Cursor = Cursors.Default;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            temp tRow = bindingSource1.Current as temp;

         //   string КодСообщения = tRow.код_сообщения;
            string КодСообщения = "201430-949671";
            string шаблон = @"\b\d{6}[-]\d{6}\b";
            //  string строка_телефон = textBox1.Text.Trim();

            var mc = Regex.Matches(КодСообщения, шаблон);
            if (mc.Count == 1)
            {
                SmsRu.Enumerations.ResponseOnStatusRequest статус = sms.CheckStatus(КодСообщения, EnumAuthenticationTypes.Simple);

                MessageBox.Show(статус.ToString());
                if (статус == SmsRu.Enumerations.ResponseOnStatusRequest.MessageRecieved)
                {
                    MessageBox.Show("Отправлено");
                }
                else
                {
                    MessageBox.Show("Не отправлено");

                }

                tRow.код_сообщения = КодСообщения;
                dataGridView1.Refresh();
            }
            else
            {
                MessageBox.Show("Нет кода сообщения на сотовый");
            }
          //  тип_сообщения тс = new тип_сообщения();
            тип_сообщения tt = тип_сообщения.Телефон;
            int ii = (int)тип_сообщения.Телефон;
            int ii2=(int) tt;
            if (ii == ii2)
            {
                MessageBox.Show(ii.ToString());
            }

       //     Guid КодЗвонка = tRow.звонок;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Enum.GetName(typeof(тип_сообщения), 2));
        }
        class комбо
        {
            public int позиция { get; set; }
            public string наим { get; set; }
        }


        private void заполнить_комбо()
        {
            комбо нК1 = new комбо();
            нК1.позиция = 1;
            нК1.наим = "по дате";
            listКомбо.Add(нК1);
            комбо нК2 = new комбо();
            нК2.позиция = 2;
            нК2.наим = "по фамилии";
            listКомбо.Add(нК2);
            комбо нК3 = new комбо();
            нК3.позиция = 3;
            нК3.наим = "по адресу";
            listКомбо.Add(нК3);

            комбо нК4 = new комбо();
            нК4.позиция = 4;
            нК4.наим = "по номеру разрещения";
            listКомбо.Add(нК4);

            comboBox1.DataSource = listКомбо;
            comboBox1.DisplayMember = "наим";
            comboBox1.ValueMember = "позиция";
            comboBox1.SelectedValue = 1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //List<звонки> звонкиЛист = new List<звонки>();
            //звонкиЛист.Sort((a, b) => a.дата.CompareTo(b.дата));
            listTemp.Sort((a, b) => a.год.CompareTo(b.год));
            dataGridView1.Refresh();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            temp uRow = bindingSource1.Current as temp;
            if (uRow.разрешение != null)
            {
                клРазрешение.все_телефоны = uRow.телефон;
                клРазрешение.разрешение = uRow.разрешение.Value;
                клРазрешение.дата_с = uRow.дата_разрешения.Value;
                клРазрешение.телефон = uRow.сотовый;
                клРазрешение.эл_почта = uRow.эл_почта;
                клРазрешение.номер = uRow.номер_разрешения;
                мыло_подробности формаПодробности = new мыло_подробности();
                формаПодробности.Text = "Подробности разрешения на отправку смс " + uRow.фио;
                формаПодробности.ShowDialog();
            }
        }


    }
}
