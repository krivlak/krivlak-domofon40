using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace domofon40
{
    public partial class должники_дом : Form
    {
        public должники_дом()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        List<temp> tempList = new List<temp>();
        List<temp> tempList0 = new List<temp>();
        private void должники_дом_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (клиенты kRow in de.клиенты
                    .Where(n => n.дом == клДом.дом)
                    .OrderBy(n => n.квартира)
                    .ThenBy(n => n.ввод))
                {
                    temp newTemp = new temp
                    {
                        адрес = kRow.адрес,
                        клиент = kRow.клиент,
                        прим0 = kRow.прим,
                        телефон = kRow.телефон,
                        фио = kRow.фио,
                         имя=kRow.имя,
                          отчество =kRow.отчество
                    };
                    if (kRow.примечания.Any(n => n.услуга == клУслуга.услуга))
                    {
                        newTemp.прим = kRow.примечания.First(n => n.услуга == клУслуга.услуга).прим;
                    }
                    if (kRow.услуги.Any(n => n.услуга == клУслуга.услуга))
                    {
                        newTemp.наш = true;
                    }
                    if(kRow.подключения.Any(n => n.услуга == клУслуга.услуга))
                    {
                        newTemp.договор_с = kRow.подключения.Where(n => n.услуга == клУслуга.услуга).Max(n => n.дата_с);
                    }
                    if (kRow.отключения.Any(n => n.услуга == клУслуга.услуга))
                    {
                        newTemp.отключен = kRow.отключения.Where(n => n.услуга == клУслуга.услуга).Max(n => n.дата_с);
                    }
                    if (kRow.повторы.Any(n => n.услуга == клУслуга.услуга))
                    {
                        newTemp.повтор = kRow.повторы.Where(n => n.услуга == клУслуга.услуга).Max(n => n.дата_с);
                    }
                    if (kRow.звонки.Any())
                    {
                        newTemp.звонок = kRow.звонки.Max(n => n.дата);
                    }
                    List<оплачено> оплаченоЛист = de.оплачено
                        .Where(n => n.услуга == клУслуга.услуга)
                        .Where(n => n.оплаты.клиент == kRow.клиент)
                        .ToList();
                    if (оплаченоЛист.Any())
                    {
                        int g100m = оплаченоЛист.Max(n => n.год * 100 + n.месяц);
                        newTemp.год = (int)g100m / 100;
                        newTemp.месяц = g100m - newTemp.год * 100;
                        int tG = DateTime.Today.Year;
                        int tM = DateTime.Today.Month;
                        int долгМесяцев = tG * 12 + tM - newTemp.год * 12 - newTemp.месяц;
                        if(долгМесяцев > 0)
                        {
                            newTemp.долг_мес = долгМесяцев;
                        }
                        if (долгМесяцев > 1)
                        {
                            newTemp.должник = true;
                        }
                    }
                    tempList0.Add(newTemp);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ощибка загрузки " + ex.Message);
            }
            tempList = tempList0;
            bindingSource1.DataSource = tempList;
            имяTextBox.DataBindings.Add("Text", bindingSource1, "Имя");
            отчествоTextBox.DataBindings.Add("Text", bindingSource1, "отчество");
            телефонTextBox.DataBindings.Add("Text", bindingSource1, "телефон");
            прим0TextBox.DataBindings.Add("Text", bindingSource1, "прим0");
            dataGridView1.DataError += dataGridView1_DataError;
            temp.Moving += temp_Moving;
            FormClosing += Должники_дом_FormClosing;
        }

        private void Должники_дом_FormClosing(object sender, FormClosingEventArgs e)
        {
            temp.Moving -= temp_Moving;
        }

        void temp_Moving(temp obj)
        {
            Console.WriteLine(obj.фио);


            if (obj.поле == "прим0")
            {
                if (obj.прим0 == null)
                {
                    obj.прим0 = "";
                }
                клиенты kRow = de.клиенты.Single(n => n.клиент == obj.клиент);
                kRow.прим = obj.прим0;
                de.SaveChanges();
            }
            if (obj.поле == "телефон")
            {

                if (obj.телефон == null)
                {
                    obj.телефон = "";
                }
                клиенты kRow = de.клиенты.Single(n => n.клиент == obj.клиент);
                kRow.телефон = obj.телефон;

                de.SaveChanges();
            }
            if (obj.поле == "прим")
            {

                if (obj.прим == null)
                {
                    obj.прим = "";
                }
                примечания[] aRow = de.примечания.Where(n => n.клиент == obj.клиент && n.услуга == клУслуга.услуга).ToArray();
                //foreach( примечания delRow in aRow)
                //{
                de.примечания.RemoveRange(aRow);
                de.SaveChanges();


                if (obj.прим != String.Empty)
                {
                    примечания newRow = new примечания();
                    newRow.клиент = obj.клиент;
                    newRow.услуга = клУслуга.услуга;
                    newRow.прим = obj.прим;
                    de.примечания.Add(newRow);
                    de.SaveChanges();
                }

            }


        }


        void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridViewTextBoxColumn[] aColumns = { примColumn };
            if (aColumns.Contains(dataGridView1.Columns[e.ColumnIndex]))
            {
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
            }

        }
        class temp
        {
            public Guid клиент { get; set; }
            public string адрес { get; set; }
            public string фио { get; set; }
          
            public int год { get; set; } = 0;
            public int месяц { get; set; } = 0;
            public int долг_мес { get; set; } = 0;
            public bool должник { get; set; } = false;
            public bool наш { get; set; } = false;
     
            public bool отключить { get; set; } = false;
            public DateTime? договор_с { get; set; }
            public DateTime? отключен { get; set; }
            public DateTime? повтор { get; set; }
            public DateTime? звонок { get; set; }
            public string имя { get; set; }
            public string отчество { get; set; }

            string Прим0;
            public string прим0
            {
                get
                {
                    return Прим0;
                }
                set
                {
                    Прим0 = value;
                    if (Moving != null)
                    {
                        поле = "прим0";
                        Moving(this);
                    }
                }
            }
            string Прим;
            public string прим
            {
                get
                {
                    return Прим;
                }
                set
                {
                    Прим = value;
                    if (Moving != null)
                    {
                        поле = "прим";
                        Moving(this);
                    }
                }
            }

            string Телефон;
            public string телефон
            {
                get
                {
                    return Телефон;
                }
                set
                {
                    Телефон = value;
                    if (Moving != null)
                    {
                        поле = "телефон";
                        Moving(this);
                    }
                }
            }

            public string поле = "";

            public static event Action<temp> Moving;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            temp vRow = bindingSource1.Current as temp;
            //клУслуга.услуга = vRow.услуга;
            //клУслуга.наимен = vRow.наимен_услуги;

            клКлиент.клиент = vRow.клиент;
            клКлиент.фио = vRow.фио;
            Cursor = Cursors.WaitCursor;

            только_просмотр формаОплатить = new только_просмотр();

            формаОплатить.Text = "Оплаты за " + клУслуга.наимен.Trim() + " " + клКлиент.фио + " " + клКлиент.адрес;
            формаОплатить.ShowDialog();

            Cursor = Cursors.Default;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            temp uRow = bindingSource1.Current as temp;
            клКлиент.клиент = uRow.клиент;
            клКлиент.выбран = false;
            ////долг_подробности ДолгПодробности = new долг_подробности();
            ////ДолгПодробности.dsТабель1 = dsТабель1;
            сведения_о_клиенте ДолгПодробности = new сведения_о_клиенте();
            ДолгПодробности.Text = "Подробности   " + uRow.адрес + " " + uRow.фио;
            ДолгПодробности.ShowDialog();
            if (клКлиент.выбран)
            {
                uRow.телефон = клКлиент.deRow.телефон;
                uRow.фио = клКлиент.deRow.фио;
                uRow.прим = клКлиент.deRow.прим;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Word.Application oWord = new Word.Application();

            string curDir = System.IO.Directory.GetCurrentDirectory();

            object шаблон = curDir + @"\отключение.dot";
            if (!System.IO.File.Exists(шаблон.ToString()))
            {
                MessageBox.Show("Нет файла " + шаблон.ToString());
                return;
            }

    

            string наименФилиала = de.филиалы
                .OrderBy(n => n.порядок)
                .First().наимен;

            Word.Document o = oWord.Documents.Add(Template: шаблон);
            oWord.Application.Visible = true;
            //            o.Bookmarks["менеджер"].Range.Text = uRow.менеджер;
            o.Bookmarks["дата"].Range.Text = DateTime.Today.ToLongDateString();
            o.Bookmarks["филиал"].Range.Text = наименФилиала;
            //          o.Bookmarks["номер_квитанции"].Range.Text = uRow.номер.ToString();
            //        o.Bookmarks["фио"].Range.Text = uRow.фио;
            //      o.Bookmarks["адрес"].Range.Text = uRow.наимен_улицы.Trim() + " " + uRow.номер_дома.Trim() + " " + uRow.корпус.Trim() + " " + uRow.квартира.Trim();
            o.Bookmarks["адрес"].Range.Text = this.Text;
            int j = 1;
            //  decimal итого = 0;
            //            foreach (dsТабель.реестрRow rRow in dsТабель1.реестр.Rows)
            foreach (temp kRow in tempList
                .Where(n => n.отключить))
            {
                j++;
                o.Tables[4].Cell(j, 1).Range.Text = kRow.адрес;
            //    o.Tables[4].Cell(j, 2).Range.Text = kRow.ввод.ToString("0;#;#");
                o.Tables[4].Cell(j, 2).Range.Text = kRow.фио;
                o.Tables[4].Cell(j, 3).Range.Text = kRow.долг_мес.ToString("0;#;#");
                o.Tables[4].Cell(j, 4).Range.Text = "V";
                o.Tables[4].Cell(j, 5).Range.Text = kRow.телефон;
                o.Tables[4].Rows.Add();
            }
            o.Tables[4].Cell(j + 1, 1).Range.Text = "Всего квартир ";
            o.Tables[4].Cell(j + 1, 2).Range.Text = (j - 1).ToString("0;#;#");


            //клTemp.закрытьWord();
            //object tempFile = @"C:\temp\temp.doc";
            //oWord.Application.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;
            //o.SaveAs(FileName: tempFile);
            клTemp.Caption = o.ActiveWindow.Caption;
            //            MessageBox.Show(o.ActiveWindow.Caption);
            oWord.Application.Visible = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            temp uRow = bindingSource1.Current as temp;
            клКлиент.клиент = uRow.клиент;
            клКлиент.выбран = false;
            ////долг_подробности ДолгПодробности = new долг_подробности();
            ////ДолгПодробности.dsТабель1 = dsТабель1;
            звонки1клиенту ДолгПодробности = new звонки1клиенту();
            ДолгПодробности.Text = "Звонки   " + uRow.адрес + " " + uRow.фио;
            ДолгПодробности.ShowDialog();
            //if (клКлиент.выбран)
            //{
            //    uRow.телефон = клКлиент.deRow.телефон;
            //    uRow.фио = клКлиент.deRow.фио;
            //    uRow.прим = клКлиент.deRow.прим;
            //}
        }

        private void button6_Click(object sender, EventArgs e)
        {
          
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                tempList = tempList0.Where(n => n.должник).ToList();
                checkBox1.Text = "Все";
            }
            else
            {
                tempList = tempList0;
                checkBox1.Text = "Только должники";
            }
            bindingSource1.DataSource = tempList;
            dataGridView1.Refresh();
            dataGridView1.Focus();
        }
    }
}
