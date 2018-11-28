using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.Data.Entity;

namespace domofon40
{
    public partial class по_видам : Form
    {
        public по_видам()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        List<temp> tempList = new List<temp>();
        List<temp> temp0List = new List<temp>();
        private void по_видам_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                de.услуги
                    .Where(n=>n.вид_услуги== клВид_услуги.вид_услуги)
                    .OrderBy(n=>n.порядок)
                    .Load();

                de.клиенты
                    .Include("услуги")
                    .Where(n => n.услуги.Any(p => p.вид_услуги == клВид_услуги.вид_услуги))
                   .OrderBy(n => n.дома.улицы.наимен)
                  .ThenBy(n => n.дома.номер)
                  .ThenBy(n => n.дома.корпус)
                  .ThenBy(n => n.квартира).Load();

                //     MessageBox.Show(temp.следить.ToString());
                //      temp.следить = false;
                int текГод = DateTime.Today.Year;
                int текМесяц = DateTime.Today.Month;

                //var queryКлиент = de.клиенты
                //  .Where(n => n.услуги.Any(p => p.вид_услуги == клВид_услуги.вид_услуги))
                //   .OrderBy(n => n.дома.улицы.наимен)
                //  .ThenBy(n => n.дома.номер)
                //  .ThenBy(n => n.дома.корпус)
                //  .ThenBy(n => n.квартира);

                progressBar1.Value = 0;
            //    int строк = queryКлиент.Count();
                int строк = de.клиенты.Local.Count();
                progressBar1.Maximum = строк;

                //  bool xy = false;
            //    foreach (клиенты uRow in queryКлиент)
                    foreach (клиенты uRow in de.клиенты.Local)
                    {
                    // j++;
                    //  progressBar1.Value = j / строк;
                    progressBar1.PerformStep();

                    //var queryУслуги = de.услуги
                    //    .Where(n => n.вид_услуги == клВид_услуги.вид_услуги)
                    //    .Where(n => n.клиенты.Contains(uRow));

                    DateTime? махЗвонок = null;
                    if (uRow.звонки.Any())
                    {
                        махЗвонок = uRow.звонки.Max(n => n.дата);
                    }

                    int i = 0;

                    foreach (услуги yRow in uRow.услуги
                       .Where(n => n.вид_услуги == клВид_услуги.вид_услуги))
                    {
                        i++;
                        temp NewRow = new temp();
                        NewRow.клиент = uRow.клиент;
                        if (i == 1)
                        {
                            NewRow.адрес = uRow.адрес;
                            NewRow.фио = uRow.фио.Trim();
                            if (махЗвонок != null)
                            {
                                NewRow.звонок = махЗвонок.Value;
                            }
                            //                 xy = !xy;

                        }
                        NewRow.услуга = yRow.услуга;
                        NewRow.наимен_услуги = yRow.обозначение;
                        NewRow.имя = uRow.имя;
                        NewRow.отчество = uRow.отчество;
                        NewRow.телефон = uRow.телефон;
                        NewRow.прим0 = uRow.прим;


                        //if (yRow.звонки.Any(n=>n.клиент==uRow.клиент))
                        //{
                        //    NewRow.звонок = yRow.звонки.Where(n => n.клиент == uRow.клиент).Max(n => n.дата);
                        //}
                        //if (yRow.повторы.Any(n => n.клиент == uRow.клиент))
                        //{
                        //    NewRow.повторно = yRow.повторы.Where(n => n.клиент == uRow.клиент).Max(n => n.дата_с);
                        //}
                        //if (yRow.примечания.Any(n => n.клиент == uRow.клиент))
                        //{
                        //    NewRow.прим = yRow.примечания.Where(n => n.клиент == uRow.клиент).First().прим;
                        //}
                        //if (yRow.льготы.Any(n => n.клиент == uRow.клиент))
                        //{
                        //    NewRow.прим += "льгота с "+yRow.льготы.Where(n => n.клиент == uRow.клиент).Max(n => n.дата_с).ToShortDateString();
                        //}
                        //var query = yRow.оплачено.Where(n => n.оплаты.клиент == uRow.клиент);
                        //if (query.Any())
                        //{
                        //    int g100m = query.Max(n => n.год * 100 + n.месяц);
                        //    NewRow.год = (int)g100m / 100;
                        //    NewRow.месяц = g100m - NewRow.год * 100;
                        //}

                        //if (yRow.оплачено.Any(n => n.оплаты.клиент == uRow.клиент))
                        //{
                        //    int g100m = yRow.оплачено.Where(n => n.оплаты.клиент == uRow.клиент).Max(n => n.год * 100 + n.месяц);
                        //    NewRow.год = (int)g100m / 100;
                        //    NewRow.месяц = g100m - NewRow.год * 100;
                        //}

                        tempList.Add(NewRow);
                    }
                }

                var dКлиенты = tempList.ToDictionary(n => new { n.клиент, n.услуга });

                var queryОплачено = de.оплачено
                  .Where(n => n.услуги.вид_услуги == клВид_услуги.вид_услуги)
                  .GroupBy(n => new { n.оплаты.клиент, n.услуга })
                  .Select(n => new
                  {
                      клиент = n.Key.клиент,
                      услуга = n.Key.услуга,
                      год = n.Max(p => p.год),
                      mg = n.Max(p => p.год * 100 + p.месяц)
                  }).ToArray();

                progressBar1.Value = 0;
                строк = queryОплачено.Count();
                progressBar1.Maximum = строк;

                foreach (var uRow in queryОплачено)
                {
                    progressBar1.PerformStep();
                    var ключ = new { uRow.клиент, uRow.услуга };
                    temp tRow;
                    if (dКлиенты.TryGetValue(ключ, out tRow))
                    {
                        tRow.год = uRow.год;
                        tRow.месяц = uRow.mg - uRow.год * 100;
                    }

                }

                //var queryЗвонки = de.звонки
                //    .GroupBy(n => new { n.клиент})
                //    .Select(n => new
                //    {
                //        клиент = n.Key.клиент,
                //        дата = n.Max(p => p.дата)
                //    }).ToArray();

                //progressBar1.Value = 0;
                //строк = queryЗвонки.Count();
                //progressBar1.Maximum = строк;

                //foreach (var uRow in queryЗвонки)
                //{
                //    progressBar1.PerformStep();
                //    var ключ = new { uRow.клиент, uRow.услуга };
                //    temp tRow;
                //    if (dКлиенты.TryGetValue(ключ, out tRow))
                //    {
                //        tRow.звонок = uRow.дата;
                //    }

                //}

                var queryОтключения = de.отключения
                 .Where(n => n.услуги.вид_услуги == клВид_услуги.вид_услуги)
                 .GroupBy(n => new { n.клиент, n.услуга })
                 .Select(n => new
                 {
                     клиент = n.Key.клиент,
                     услуга = n.Key.услуга,
                     дата = n.Max(p => p.дата_с)
                 }).ToArray();



                foreach (var uRow in queryОтключения)
                {

                    var ключ = new { uRow.клиент, uRow.услуга };
                    temp tRow;
                    if (dКлиенты.TryGetValue(ключ, out tRow))
                    {
                        tRow.отключен = uRow.дата;
                    }

                }



                var queryПовторы = de.повторы
                 .Where(n => n.услуги.вид_услуги == клВид_услуги.вид_услуги)
                 .GroupBy(n => new { n.клиент, n.услуга })
                 .Select(n => new
                 {
                     клиент = n.Key.клиент,
                     услуга = n.Key.услуга,
                     дата = n.Max(p => p.дата_с)
                 }).ToArray();



                foreach (var uRow in queryПовторы)
                {

                    var ключ = new { uRow.клиент, uRow.услуга };
                    temp tRow;
                    if (dКлиенты.TryGetValue(ключ, out tRow))
                    {
                        tRow.повторно = uRow.дата;
                    }

                }
                var queryПрим = de.примечания
               .Where(n => n.услуги.вид_услуги == клВид_услуги.вид_услуги)
               .GroupBy(n => new { n.клиент, n.услуга })
               .Select(n => new
               {
                   клиент = n.Key.клиент,
                   услуга = n.Key.услуга,
                   прим = n.Max(p => p.прим)
               }).ToArray();



                foreach (var uRow in queryПрим)
                {

                    var ключ = new { uRow.клиент, uRow.услуга };
                    temp tRow;
                    if (dКлиенты.TryGetValue(ключ, out tRow))
                    {
                        tRow.прим = uRow.прим;
                    }

                }

                var queryЛьготы = de.льготы
            .Where(n => n.услуги.вид_услуги == клВид_услуги.вид_услуги)
            .GroupBy(n => new { n.клиент, n.услуга })
            .Select(n => new
            {
                клиент = n.Key.клиент,
                услуга = n.Key.услуга,
                дата = n.Max(p => p.дата_с)
            });



                foreach (var uRow in queryЛьготы)
                {

                    var ключ = new { uRow.клиент, uRow.услуга };
                    temp tRow;
                    if (dКлиенты.TryGetValue(ключ, out tRow))
                    {
                        tRow.прим += "Льгота с " + uRow.дата.ToShortDateString();
                    }

                }

                foreach (temp kRow in tempList)
                {
                    kRow.должник = false;
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
            //    temp.следить = true;
                temp0List = tempList;

                bindingSource1.DataSource = tempList;
                клСетка.задать_ширину(dataGridView1);

                имяTextBox.DataBindings.Add("Text", bindingSource1, "имя");
                отчествоTextBox.DataBindings.Add("Text", bindingSource1, "отчество");
                телефонTextBox.DataBindings.Add("Text", bindingSource1, "телефон");
                прим0TextBox.DataBindings.Add("Text", bindingSource1, "прим0");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сбой загрузки " + ex.Message);
            }
            Cursor = Cursors.Default;
            dataGridView1.Focus();
            progressBar1.Visible = false;
            прим0TextBox.Validated += прим0TextBox_Validated;
            FormClosing += по_видам_FormClosing;
            temp.Moving += Temp_Moving;
            dataGridView1.CellFormatting += DataGridView1_CellFormatting;
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            bool y3 = (bool)dataGridView1.Rows[e.RowIndex].Cells["должникColumn"].Value;
            if (y3)
            {
                if (dataGridView1.Columns[e.ColumnIndex] == годColumn
                    || dataGridView1.Columns[e.ColumnIndex] == месяцColumn
                    || dataGridView1.Columns[e.ColumnIndex] == долгColumn)
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
            }
            if (dataGridView1.Columns[e.ColumnIndex] == звонокColumn)
            {
                DateTime? dt = dataGridView1.Rows[e.RowIndex].Cells["звонокColumn"].Value as DateTime?;
                if (dt != null)
                {
                    if (dt.Value.Date == DateTime.Today)
                    {
                        e.CellStyle.ForeColor = Color.Blue;
                    }
                }
            }
        }

        private void Temp_Moving(temp obj)
        {
            if (obj.поле == "прим")
            {
                примечания[] aRows = de.примечания.Where(n => n.клиент == obj.клиент && n.услуга == obj.услуга).ToArray();
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
                            услуга = obj.услуга
                        };
                        de.примечания.Add(newRow);
                       
                    }
                }
            }
            if (obj.поле == "прим0")
            {
                клиенты kRow = de.клиенты.Single(n => n.клиент == obj.клиент);
                kRow.прим = obj.прим0;
            }
            if (obj.поле == "телефон")
            {
                клиенты kRow = de.клиенты.Single(n => n.клиент == obj.клиент);
                kRow.телефон = obj.телефон;
            }
            try
            {

                de.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сбой записи " + ex.Message);
            }
        }

        void по_видам_FormClosing(object sender, FormClosingEventArgs e)
        {
            temp.Moving -= Temp_Moving;
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
            public DateTime отключен { get; set; }
            public DateTime повторно { get; set; }
            public DateTime звонок { get; set; }

            //string Прим;
            //public string прим
            //{

            //    get
            //    {
            //        return Прим;
            //    }

            //    set
            //    {
            //        Прим = value;
            //        if (следить)
            //        {
            //            domofon40.domofon14Entities de1 = new domofon14Entities();
            //            примечания[] aRows = de1.примечания.Where(n => n.клиент == клиент && n.услуга == услуга).ToArray();
            //            foreach (примечания delRow in aRows)
            //            {
            //                de1.примечания.Remove(delRow);
            //            }
            //            de1.SaveChanges();
            //            if (value != null)
            //            {
            //                if (value.Trim() != String.Empty)
            //                {
            //                    примечания newRow = new примечания();
            //                    newRow.услуга = услуга;
            //                    newRow.клиент = клиент;
            //                    newRow.прим = value;
            //                    de1.примечания.Add(newRow);
            //                    de1.SaveChanges();
            //                }
            //            }
            //        }

            //    }

            //}
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

            public bool должник { get; set; } = false;
            public string имя { get; set; }
            public string отчество { get; set; }
      //      public string телефон { get; set; }
            //public string прим0 { get; set; }

           // public static bool следить = false;
            public string поле { get; set; }
            public static event Action<temp> Moving;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                //bindingSource1.Filter = "должник";
                tempList = temp0List.Where(n => n.должник).ToList();
                checkBox1.Text = "Все";
            }
            else
            {
                //  bindingSource1.Filter = null;
                tempList = temp0List;
                checkBox1.Text = "Должники";
            }
            bindingSource1.DataSource = tempList;
            dataGridView1.Refresh();
            dataGridView1.Focus(); 
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
                o.Tables[4].Cell(j, 1).Range.Text = kRow.наимен_услуги.Trim();
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
                 клУслуга.услуга = uRow.услуга;
                клУслуга.наимен = uRow.наимен_услуги;
                клУслуга.deRow = de.услуги.Single(n => n.услуга == uRow.услуга);
                клКлиент.клиент = uRow.клиент;
                клКлиент.deRow = de.клиенты.Single(n => n.клиент == клКлиент.клиент);
                оплаченные1просмотр вертикальПросмотр = new оплаченные1просмотр();
                вертикальПросмотр.Text = "Подробности оплаты " + uRow.наимен_услуги + " " + клКлиент.deRow.адрес+" "+ uRow.фио;
                вертикальПросмотр.ShowDialog();
                Cursor = Cursors.Default;
            }
            dataGridView1.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if ( bindingSource1.Count > 0)
            {
                Cursor = Cursors.WaitCursor;

               
                temp tRow = bindingSource1.Current as temp;
                //клУслуга.услуга = vRow.услуга;
                //клУслуга.наимен = vRow.наимен_услуги;

                //клКлиент.клиент = vRow.клиент;
                //клКлиент.фио = vRow.фио;


                клКлиент.клиент = tRow.клиент;
                клУслуга.услуга = tRow.услуга;
                звонки новыйЗвонок = new звонки()
                {
                    дата = DateTime.Now,
                    звонок = Guid.NewGuid(),
                     клиент = tRow.клиент,
                      прим=""
                };                ;
               
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
