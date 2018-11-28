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
    public partial class подключены1услуга : Form
    {
        public подключены1услуга()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        List<temp> tempList = new List<temp>();
        List<temp> temp0List = new List<temp>();
        private void подключены1услуга_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            //     MessageBox.Show(temp.следить.ToString());
            temp.следить = false;
            int текГод = DateTime.Today.Year;
            int текМесяц = DateTime.Today.Month;

            tempList = de.клиенты
              .Where(n => n.услуги.Any(p => p.услуга == клУслуга.услуга))
               .OrderBy(n => n.дома.улицы.наимен)
              .ThenBy(n => n.дома.номер)
              .ThenBy(n => n.дома.корпус)
              .ThenBy(n => n.квартира)
              .Select(n => new temp { 
                  имя = n.имя,
                  клиент = n.клиент,
                  отчество = n.отчество, 
                  прим0 = n.прим, 
                  телефон = n.телефон,
                  фио = n.фио ,
                  должник=false,
                  долг_мес=0,
                  год=0,
                  месяц=0, 
                  прим="",
                  отключить=false,
                   адрес=""
                })
              .ToList();

            progressBar1.Value = 0;
            int строк = tempList.Count();
            progressBar1.Maximum = строк;
            progressBar1.Focus();
            progressBar1.Visible = true;
         //   bool xy = false;

            Dictionary<Guid,temp>  dКлиенты = new Dictionary<Guid,temp>();
                dКлиенты = tempList.ToDictionary(n => n.клиент);
            
            foreach (клиенты uRow in de.клиенты)
            {
                if (dКлиенты.ContainsKey(uRow.клиент))
                {

                    temp NewRow = dКлиенты[uRow.клиент];

                    //    // j++;
                    //    //  progressBar1.Value = j / строк;
                    progressBar1.PerformStep();

                    //    //var queryУслуги = de.услуги
                    //    //    .Where(n => n.вид_услуги == клВид_услуги.вид_услуги)
                    //    //    .Where(n => n.клиенты.Contains(uRow));



                    //        //temp NewRow = new temp();
                    //        //NewRow.клиент = uRow.клиент;

                    NewRow.адрес = uRow.адрес;
                    //        //NewRow.фио = uRow.фио.Trim();

                    if (uRow.звонки.Any())
                    {
                        NewRow.звонок = uRow.звонки.Max(n => n.дата);
                    }


                    //        NewRow.услуга = клУслуга.услуга;
                            NewRow.наимен_услуги = клУслуга.deRow.обозначение;
                    //        NewRow.имя = uRow.имя;
                    //        NewRow.отчество = uRow.отчество;
                    //        NewRow.телефон = uRow.телефон;
                    //        NewRow.прим0 = uRow.прим;
                    if (uRow.подключения.Any(n => n.услуга == клУслуга.услуга))
                    {
                        NewRow.подключен = uRow.подключения.Where(n => n.услуга == клУслуга.услуга).Max(p => p.дата_с);
                    }
                    if (uRow.отключения.Any(n => n.услуга == клУслуга.услуга))
                    {
                        NewRow.отключен = uRow.отключения.Where(n => n.услуга == клУслуга.услуга).Max(p => p.дата_с);
                    }
                    if (uRow.повторы.Any(n => n.услуга == клУслуга.услуга))
                    {
                        NewRow.повторно = uRow.повторы.Where(n => n.услуга == клУслуга.услуга).Max(p => p.дата_с);
                    }
                    if (uRow.примечания.Any(n => n.услуга == клУслуга.услуга))
                    {
                        NewRow.прим = uRow.примечания.Where(n => n.услуга == клУслуга.услуга).First().прим;
                    }

                    if (uRow.льготы.Any(n => n.услуга == клУслуга.услуга))
                    {
                        NewRow.прим += "Льгота с " + uRow.льготы.Where(n => n.услуга == клУслуга.услуга).OrderBy(n => n.дата_с).Last().дата_с.ToShortDateString();
                    }
                    //        tempList.Add(NewRow);
                    //  //  }
                }
            }

         //   var dКлиенты = tempList.ToDictionary(n => n.клиент);

            var queryОплачено = de.оплачено
              .Where(n => n.услуга == клУслуга.услуга)
              .GroupBy(n => n.оплаты.клиент)
              .Select(n => new
              {
                  клиент = n.Key,
                  год = n.Max(p => p.год),
                  mg = n.Max(p => p.год * 100 + p.месяц)
              }).ToArray();

            progressBar1.Value = 0;
            строк = queryОплачено.Count();
            progressBar1.Maximum = строк;

            foreach (var uRow in queryОплачено)
            {
                progressBar1.PerformStep();
                
                if (dКлиенты.ContainsKey(uRow.клиент))
                {
                    temp tRow = dКлиенты[uRow.клиент];
                    tRow.год = uRow.год;
                    tRow.месяц = uRow.mg - uRow.год * 100;
                }

            }






            foreach (temp kRow in tempList)
            {
                int g12m = kRow.год * 12 + kRow.месяц;
                if (g12m > 0)
                {
                    int долг_мес = текГод * 12 + текМесяц - g12m - 1;


                    if (долг_мес > 0)
                    {
                        kRow.долг_мес = долг_мес;
                    }
                    if (долг_мес > 1)
                    {
                        kRow.должник = true;
                    }
                }
            }
            temp0List = tempList;

            temp.следить = true;
            bindingSource1.DataSource = tempList;
            имяTextBox.DataBindings.Add("Text", bindingSource1, "имя");
            отчествоTextBox.DataBindings.Add("Text", bindingSource1, "отчество");
            телефонTextBox.DataBindings.Add("Text", bindingSource1, "телефон");
            прим0TextBox.DataBindings.Add("Text", bindingSource1, "прим0");
            Cursor = Cursors.Default;
            dataGridView1.Focus();
            progressBar1.Visible = false;
            прим0TextBox.Validated += прим0TextBox_Validated;
            FormClosing += по_видам_FormClosing;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            temp.Moving += Temp_Moving;

        }

        private void Temp_Moving(temp obj)
        {
            примечания[] aRows = de.примечания.Where(n => n.клиент == obj.клиент && n.услуга == клУслуга.услуга).ToArray();
            foreach (примечания delRow in aRows)
            {
                de.примечания.Remove(delRow);
            }
            de.SaveChanges();

            if (obj.прим != null)
            {
                if (obj.прим.Trim() != String.Empty)
                {
                    примечания newRow = new примечания()
                    {
                        клиент = obj.клиент,
                        прим = obj.прим,
                        услуга = клУслуга.услуга
                    };

                    try
                    {
                        de.примечания.Add(newRow);
                        de.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Сбой записи " + ex.Message);
                    }
                }
            }

        }

        void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {



            bool y3 = (bool)dataGridView1.Rows[e.RowIndex].Cells["должникColumn"].Value;
            if (y3)
            {
                if (dataGridView1.Columns[e.ColumnIndex] == годColumn
                    || dataGridView1.Columns[e.ColumnIndex] == месяцColumn
                    || dataGridView1.Columns[e.ColumnIndex] == долгColumn)
                {
                    e.CellStyle.ForeColor = System.Drawing.Color.Red;
                }
            }
            if (dataGridView1.Columns[e.ColumnIndex] == звонокColumn)
            {
                DateTime? dt = dataGridView1.Rows[e.RowIndex].Cells["звонокColumn"].Value as DateTime?;
                if (dt != null)
                {
                    if (dt.Value.Date == DateTime.Today)
                    {
                        e.CellStyle.ForeColor = System.Drawing.Color.Blue;
                    }
                }
            }
        }
        void прим0TextBox_Validated(object sender, EventArgs e)
        {
            //     DsTemp.квартирыRow vRow = (квартирыBindingSource.Current as DataRowView).Row as DsTemp.квартирыRow;
            temp vRow = bindingSource1.Current as temp;

            Cursor = Cursors.WaitCursor;
            клиенты kRow = de.клиенты.Single(n => n.клиент == vRow.клиент);
            kRow.прим = прим0TextBox.Text;
            try
            {
                de.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Сбой записи......");
            }
            Cursor = Cursors.Default;
        }
        void по_видам_FormClosing(object sender, FormClosingEventArgs e)
        {
            temp.Moving -= Temp_Moving;
            //  temp.следить = false;
        }
        class temp
        {
            public Guid клиент { get; set; }
            public string адрес { get; set; }
            public Guid услуга { get; set; }
            public string наимен_услуги { get; set; }
            public string фио { get; set; }
            public int год { get; set; }
            public int месяц { get; set; }
            public int долг_мес { get; set; }
            public bool отключить { get; set; }
            public DateTime подключен { get; set; }
            public DateTime отключен { get; set; }
            public DateTime повторно { get; set; }
            public DateTime звонок { get; set; }
            public string поле { get; set; }

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
                    //if (следить)
                    //{
                    //    domofon40.domofon14Entities de1 = new domofon14Entities();
                    //    примечания[] aRows = de1.примечания.Where(n => n.клиент == клиент && n.услуга == услуга).ToArray();
                    //    foreach (примечания delRow in aRows)
                    //    {
                    //        de1.примечания.Remove(delRow);
                    //    }
                    //    de1.SaveChanges();
                    //    if (value != null)
                    //    {
                    //        if (value.Trim() != String.Empty)
                    //        {
                    //            примечания newRow = new примечания();
                    //            newRow.услуга = услуга;
                    //            newRow.клиент = клиент;
                    //            newRow.прим = value;
                    //            de1.примечания.Add(newRow);
                    //            de1.SaveChanges();
                    //        }
                    //    }
                    //}

                }

            }
            public bool должник { get; set; }
            public string имя { get; set; }
            public string отчество { get; set; }
            public string телефон { get; set; }
            public string прим0 { get; set; }

            public static bool следить = false;

            public static event Action<temp> Moving;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Word.Application oWord = new Word.Application();

            string curDir = System.IO.Directory.GetCurrentDirectory();

            object шаблон = curDir + @"\по_видам.dot";
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
                o.Tables[4].Cell(j, 1).Range.Text = клУслуга.deRow.наимен.Trim();
                o.Tables[4].Cell(j, 2).Range.Text = kRow.адрес.Trim();
                o.Tables[4].Cell(j, 3).Range.Text = kRow.фио;
                o.Tables[4].Cell(j, 4).Range.Text = kRow.месяц.ToString("0;#;#");
                o.Tables[4].Cell(j, 5).Range.Text = kRow.год.ToString("0;#;#");
                o.Tables[4].Cell(j, 6).Range.Text = kRow.долг_мес.ToString("0;#;#");
                //if (kRow.отключить)
                //{
                //    o.Tables[4].Cell(j, 9).Range.Text = "V";
                //}
                o.Tables[4].Cell(j, 7).Range.Text = kRow.прим;

                o.Tables[4].Rows.Add();
            }
            o.Tables[4].Cell(j + 1, 2).Range.Text = "Всего квартир ";
            o.Tables[4].Cell(j + 1, 4).Range.Text = (j - 1).ToString("0;#;#");



            oWord.Application.Visible = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
                Cursor = Cursors.WaitCursor;
                temp uRow = bindingSource1.Current as temp;
             //   клУслуга.услуга = клУслуга.услуга;
                клКлиент.клиент = uRow.клиент;
                клКлиент.deRow = de.клиенты.Single(n => n.клиент == клКлиент.клиент);
                только_просмотр вертикальПросмотр = new только_просмотр();
                вертикальПросмотр.Text = "Подробности оплаты " + клУслуга.deRow.наимен + " " + клКлиент.deRow.адрес;
                вертикальПросмотр.ShowDialog();
                Cursor = Cursors.Default;
            }
            dataGridView1.Focus();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                tempList = temp0List.Where(n => n.должник).ToList();
                checkBox1.Text = "Все";
            }
            else
            {
                tempList = temp0List;
                checkBox1.Text = "Должники";
            }
            bindingSource1.DataSource = tempList;
            dataGridView1.Refresh();
            dataGridView1.Focus();

        }

        private void прим0TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
                Cursor = Cursors.WaitCursor;

                temp tRow = bindingSource1.Current as temp;
              
                звонки новыйЗвонок = new звонки();
                Guid NewKod = Guid.NewGuid();
                новыйЗвонок.дата = DateTime.Now;
                новыйЗвонок.звонок = NewKod;
                новыйЗвонок.клиент = tRow.клиент;
                новыйЗвонок.прим = "";


                de.звонки.Add(новыйЗвонок);
                try
                {
                    de.SaveChanges();
                    tRow.звонок = новыйЗвонок.дата;
                    dataGridView1.Refresh();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                //     новыйЗвонок.звонок=



                Cursor = Cursors.Default;
            }

        }
    }
}
