using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Entity;
using Word = Microsoft.Office.Interop.Word;
using System.IO;

namespace domofon40
{
    public partial class оплаты1клиент : Form
    {
        public оплаты1клиент()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        BindingList<оплаты> оплатыЛист = new BindingList<оплаты>();
        List<temp> tempList = new List<temp>();
        List<квитанция> квитанцияЛист = new List<квитанция>();
        private void оплаты1клиент_Load(object sender, EventArgs e)
        {
            de.сотрудники.Load();
            de.клиенты.Load();
            de.оплаты
                .Where(n => n.клиент == клКлиент.клиент)
                .OrderBy(n => n.дата)
                .ThenBy(n => n.номер)
                .Load();

            try
            {
                оплатыЛист = de.оплаты.Local.ToBindingList();
                bindingSource1.DataSource = оплатыЛист;
                bindingSource1.Sort = "номер";
                bindingSource1.MoveLast();
            }
            catch
            {
                MessageBox.Show("Сбой загрузки");
            }


            if (bindingSource1.Count > 0)
            {
                заполнить_оплатить();
                заполнить2услуги();
            //    пересчет();
            }
          //  dataGridView1.Refresh();
            dataGridView1.Focus();
            прим0TextBox.Text = клКлиент.deRow.прим.Trim();
            телефонTextBox.Text = клКлиент.deRow.телефон.Trim();
            if(клКлиент.deRow.звонки.Any())
            {
                звонокTextBox.Text = клКлиент.deRow.звонки.Max(n => n.дата).ToShortDateString();
            }

           // bindingSource1.ListChanged += bindingSource1_ListChanged;
    //        FormClosing += оплаты1клиента_FormClosing;
            dataGridView1.CellMouseClick += dataGridView1_CellMouseClick;
            bindingSource1.PositionChanged += bindingSource1_PositionChanged;
            //     dataGridView2.DataError += dataGridView2_DataError;
            //    dataGridView1.CellValidating += dataGridView1_CellValidating;
            // dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;

            налTextBox.KeyPress += налTextBox_KeyPress;
            //      налTextBox.Validated += налTextBox_Validated;
            налTextBox.TextChanged += налTextBox_TextChanged;
            прим0TextBox.Validated += Прим0TextBox_Validated;
            телефонTextBox.Validated += ТелефонTextBox_Validated;

        }

        private void ТелефонTextBox_Validated(object sender, EventArgs e)
        {
            клКлиент.deRow.телефон = телефонTextBox.Text.Trim();
            de.Database.ExecuteSqlCommand("update клиенты set телефон= @p0 where клиент = @p1 ", телефонTextBox.Text.Trim(), клКлиент.клиент);
        }

        private void Прим0TextBox_Validated(object sender, EventArgs e)
        {
            клКлиент.deRow.прим = прим0TextBox.Text.Trim();
            de.Database.ExecuteSqlCommand("update клиенты set прим= @p0 where клиент = @p1 ", прим0TextBox.Text.Trim(), клКлиент.клиент);
        }

        void налTextBox_TextChanged(object sender, EventArgs e)
        {
            int всего = 0;
            int наличными = 0;
            if (Int32.TryParse(налTextBox.Text, out наличными) && Int32.TryParse(textBox1.Text, out всего))
            {
                if (всего <= наличными)
                {
                    сдачаTextBox3.Text = (наличными - всего).ToString();
                }
                else
                {
                    сдачаTextBox3.Text = "";
                }
            }
            else
            {
                сдачаTextBox3.Text = "";
            }
            сдачаTextBox3.Refresh();
        }


        void налTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            клKey.int_KeyPress(sender, e);
        }
        void bindingSource1_PositionChanged(object sender, EventArgs e)
        {
            заполнить2услуги();
        }


        void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                оплаты tRow = bindingSource1.Current as оплаты;
                if (dataGridView1.Columns[e.ColumnIndex] == кассирColumn)
                {
                    клСотрудник.сотрудник = tRow.сотрудник;
                    клСотрудник.выбран = false;
                    выбор_кассира выборКассира = new выбор_кассира();
                    выборКассира.ShowDialog();



                    if (клСотрудник.выбран)
                    {
                        tRow.сотрудник = клСотрудник.сотрудник;
                        if (de.Entry(tRow).State == EntityState.Unchanged)
                        {
                            de.Entry(tRow).State = EntityState.Modified;
                        }

                        dataGridView1.Refresh();
                        label1.Visible = true;
                        de.SaveChanges();
                    }

                }

                if (dataGridView1.Columns[e.ColumnIndex] == датаColumn)
                {

                    клКалендарь.дата = tRow.дата;
                    клКалендарь.выбран = false;
                    календарь выборДаты = new календарь();
                    выборДаты.button3.Visible = false;
                    выборДаты.ShowDialog();
                    if (клКалендарь.выбран)
                    {
                        tRow.дата = клКалендарь.дата.Value;
                        label1.Visible = true;
                        dataGridView1.Refresh();
                        de.SaveChanges();
                    }

                }
            }
        }

        private void заполнить_услуги()
        {
            try
            {
                оплаты uRow = (оплаты)bindingSource1.Current;


                List<temp> query = de.оплачено
                    .Where(n => n.оплата == uRow.оплата)
                    .OrderBy(n => n.услуги.порядок)
                   .GroupBy(n => n.услуги)
                   .Select(n => new temp
                   {
                       услуга = n.Key.услуга,
                       наимен = n.Key.наимен,
                       месяцев = n.Count(),
                       сумма = n.Sum(p => p.сумма)
                   }).ToList();
                //     Console.WriteLine(query.Count());
                List<temp> query2 = de.опл_работы
                     .Where(n => n.оплата == uRow.оплата)
                     .OrderBy(n => n.работы.порядок)
                     .Select(n => new temp
                     {
                         услуга = n.работа,
                         наимен = n.работы.наимен,
                         месяцев = 0,
                         сумма = (int)n.стоимость,
                         договор = n.сотрудники.фио
                     }).ToList();

                List<temp> query3 = de.возврат
                   .Where(n => n.оплата == uRow.оплата)
                   .OrderBy(n => n.услуги.порядок)
                  .GroupBy(n => n.услуги)
                  .Select(n => new temp
                  {
                      услуга = n.Key.услуга,
                      наимен = " Возврат " + n.Key.наимен,
                      месяцев = n.Count(),
                      сумма = n.Sum(p => -p.сумма)
                  }).ToList();

                //          Console.WriteLine(de.возврат.Count(n=>n.оплата== uRow.оплата));

                Guid КодКлиента2 = uRow.клиент;


                int мСумма = 0;

                tempList.Clear();
                foreach (temp newRow in query)
                {
                    tempList.Add(newRow);
                }
                foreach (temp newRow in query2)
                {
                    tempList.Add(newRow);
                }
                foreach (temp newRow in query3)
                {
                    tempList.Add(newRow);
                }

                //if (query != null)
                //{

                //    var query4 = query.Concat(query2).AsQueryable();

                //    tempList = query4.Concat(query3).ToList();
                //}
                //else
                //{
                //    tempList = query3.Concat(query3).ToList();
                //}

                if (tempList.Any())
                {
                    мСумма = tempList.Sum(n => n.сумма);
                }
                //    tempList.Clear();

                //foreach (var mm in query)
                //{

                //    temp NewRow = new temp();
                //    NewRow.услуга = mm.услуга;
                //    NewRow.наимен = mm.наимен;
                //    NewRow.месяцев = mm.месяцев;
                //    NewRow.сумма = mm.сумма;
                //    NewRow.договор = "";
                //    tempList.Add(NewRow);

                //    мСумма += mm.сумма;
                //}

                foreach (подключения pRow in de.подключения
                    .Where(n => n.клиент == uRow.клиент)
                    .OrderBy(n => n.дата_дог))
                {
                    if (tempList.Any(n => n.услуга == pRow.услуга))
                    {
                        temp sRow = tempList.First(n => n.услуга == pRow.услуга);
                        sRow.договор = pRow.номер_пп.ToString("0;#;#");
                    }
                }

                //foreach (var rr in query2)
                //{

                //    temp NewRow = new temp();
                //    NewRow.услуга = rr.работа;
                //    NewRow.наимен = rr.наимен;
                //    NewRow.месяцев = 0;
                //    NewRow.сумма = (int)rr.оплачено;
                //    NewRow.договор = rr.фио;
                //    tempList.Add(NewRow);
                //    мСумма += NewRow.сумма;
                //}

                //  foreach (var vv in query3)
                //  {
                //    //  dsДолги.подробностиRow NewRow = dsДолги1.подробности.NewподробностиRow();
                //      temp NewRow = new temp();
                //      NewRow.услуга = vv.услуга;
                //      NewRow.наимен = "ВОЗВРАТ " + vv.наимен.Trim();
                //      NewRow.месяцев = vv.месяцев;
                //      NewRow.сумма = vv.сумма;
                //      NewRow.договор = "";
                //      tempList.Add(NewRow);
                ////      dsДолги1.подробности.Rows.Add(NewRow);
                //      мСумма -= vv.сумма;
                //  }

                if (uRow.оплатить != мСумма)
                {
                    uRow.оплатить = мСумма;
                }

                textBox1.Text = мСумма.ToString();
                bindingSource2.DataSource = null;
                bindingSource2.DataSource = tempList;
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = bindingSource2;
                bindingSource2.MoveLast();
                dataGridView2.Refresh();

                налTextBox.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка " + ex.Message);
                //tempList.Clear();
                //bindingSource2.DataSource = tempList;
                //dataGridView2.DataSource = bindingSource2;
                //dataGridView2.Refresh();
                //textBox1.Text = "";
            }



        }


        private void заполнить_услуги22()
        {
            try
            {
                оплаты uRow = (оплаты)bindingSource1.Current;


                List<temp> query = de.оплачено
                    .Where(n => n.оплата == uRow.оплата)
                    .OrderBy(n => n.услуги.порядок)
                   .GroupBy(n => n.услуги)
                   .Select(n => new temp
                   {
                       услуга = n.Key.услуга,
                       наимен = n.Key.наимен,
                       месяцев = n.Count(),
                       сумма = n.Sum(p => p.сумма)
                   }).ToList();
                //     Console.WriteLine(query.Count());
                List<temp> query2 = de.опл_работы
                     .Where(n => n.оплата == uRow.оплата)
                     .OrderBy(n => n.работы.порядок)
                     .Select(n => new temp
                     {
                         услуга = n.работа,
                         наимен = n.работы.наимен,
                         месяцев = 0,
                         сумма = (int)n.стоимость,
                         договор = n.сотрудники.фио
                     }).ToList();

                //var query3 = de.возврат
                //   .Where(n => n.оплата == uRow.оплата)
                //   .OrderBy(n => n.услуги.порядок)
                //  .GroupBy(n => n.услуги)
                //  .Select(n => new
                //  {
                //      услуга = n.Key.услуга,
                //      наимен = n.Key.наимен,
                //      месяцев = n.Count(),
                //      сумма = n.Sum(p => p.сумма)
                //  });

                Guid КодКлиента2 = uRow.клиент;


                int мСумма = 0;
                tempList = query.Concat(query2).ToList();
                if (tempList.Any())
                {
                    мСумма = tempList.Sum(n => n.сумма);
                }
                //    tempList.Clear();

                //foreach (var mm in query)
                //{

                //    temp NewRow = new temp();
                //    NewRow.услуга = mm.услуга;
                //    NewRow.наимен = mm.наимен;
                //    NewRow.месяцев = mm.месяцев;
                //    NewRow.сумма = mm.сумма;
                //    NewRow.договор = "";
                //    tempList.Add(NewRow);

                //    мСумма += mm.сумма;
                //}

                foreach (подключения pRow in de.подключения
                    .Where(n => n.клиент == uRow.клиент)
                    .OrderBy(n => n.дата_дог))
                {
                    if (tempList.Any(n => n.услуга == pRow.услуга))
                    {
                        temp sRow = tempList.First(n => n.услуга == pRow.услуга);
                        sRow.договор = pRow.номер_пп.ToString("0;#;#");
                    }
                }

                //foreach (var rr in query2)
                //{

                //    temp NewRow = new temp();
                //    NewRow.услуга = rr.работа;
                //    NewRow.наимен = rr.наимен;
                //    NewRow.месяцев = 0;
                //    NewRow.сумма = (int)rr.оплачено;
                //    NewRow.договор = rr.фио;
                //    tempList.Add(NewRow);
                //    мСумма += NewRow.сумма;
                //}

                //  foreach (var vv in query3)
                //  {
                //    //  dsДолги.подробностиRow NewRow = dsДолги1.подробности.NewподробностиRow();
                //      temp NewRow = new temp();
                //      NewRow.услуга = vv.услуга;
                //      NewRow.наимен = "ВОЗВРАТ " + vv.наимен.Trim();
                //      NewRow.месяцев = vv.месяцев;
                //      NewRow.сумма = vv.сумма;
                //      NewRow.договор = "";
                //      tempList.Add(NewRow);
                ////      dsДолги1.подробности.Rows.Add(NewRow);
                //      мСумма -= vv.сумма;
                //  }

                if (uRow.оплатить != мСумма)
                {
                    uRow.оплатить = мСумма;
                }

                textBox1.Text = мСумма.ToString();
                bindingSource2.DataSource = null;
                bindingSource2.DataSource = tempList;
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = bindingSource2;
                bindingSource2.MoveLast();
                dataGridView2.Refresh();

                налTextBox.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка " + ex.Message);
                //tempList.Clear();
                //bindingSource2.DataSource = tempList;
                //dataGridView2.DataSource = bindingSource2;
                //dataGridView2.Refresh();
                //textBox1.Text = "";
            }



        }

        void заполнить_оплатить()
        {

            string curDir = System.IO.Directory.GetCurrentDirectory();

            string шаблон = curDir + @"\sОплата1.sql";

            if (!System.IO.File.Exists(шаблон.ToString()))
            {
                MessageBox.Show("Нет файла " + шаблон.ToString());
                Cursor = Cursors.Default;
                return;
            }
            StreamReader sr = new StreamReader(шаблон, Encoding.Default);

            string запрос = sr.ReadToEnd();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("declare @клиент  uniqueidentifier ='" + клКлиент.клиент.ToString() + "';");
            sb.AppendLine(запрос);

            string sqlString = sb.ToString();  

            //   string sqlString = "select оплата, оплатить=Sum( from sОплата";
            var query = de.Database.SqlQuery<sTemp>(sqlString);
            Dictionary<Guid, sTemp> dicTemp = query.ToDictionary(n => n.оплата);
            foreach (оплаты uRow in оплатыЛист)
            {
                if (dicTemp.ContainsKey(uRow.оплата))
                {
                    uRow.оплатить = dicTemp[uRow.оплата].оплатить;

                }
            }
        }

        class sTemp
        {
            public Guid оплата { get; set; }
            public int оплатить { get; set; }
        }

        class temp
        {
            public Guid услуга { get; set; }
            public string наимен { get; set; }
            public int месяцев { get; set; }
            public int сумма { get; set; }
            public string договор { get; set; }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            int maxNum1 = 0;
            if (de.оплаты.Count() > 0)
            {
                maxNum1 = de.оплаты.Max(n => n.номер);
            }

            int maxNum2 = 0;
            if (de.оплаты.Local.Count > 0)
            {
                maxNum2 = de.оплаты.Local.Max(n => n.номер);
            }

            int maxNum = maxNum1;
            if (maxNum2 > maxNum1)
            {
                maxNum = maxNum2;
            }
            виды_оплат vRow = de.виды_оплат.OrderBy(n => n.порядок).First();

            оплаты NewRow = new оплаты()
            {
                дата = DateTime.Today,
                клиент = клКлиент.клиент,
                сотрудник = клСотрудник.сотрудник,
                номер = maxNum + 1,
                оплата = Guid.NewGuid(),
                 вид_оплаты= vRow.вид_оплаты
                  
            };
          

            int строка = bindingSource1.Add(NewRow);
            bindingSource1.Position = строка;
            de.SaveChanges();
            dataGridView1.Focus();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
                //    записать();
                оплаты uRow = bindingSource1.Current as оплаты;
                клОплата.оплата = uRow.оплата;
                клОплата.deRow = uRow;
                клОплата.сотрудник = uRow.сотрудник;
                клКлиент.клиент = uRow.клиент;
                int строка = bindingSource1.Position;

                Cursor = Cursors.WaitCursor;
                опл1работ оплатаРабот = new опл1работ();
                оплатаРабот.Text = "Оплаты за работы " + клКлиент.фио;
                оплатаРабот.ShowDialog();
                обновить();
                bindingSource1.Position = строка;
                dataGridView1.Refresh();
                Cursor = Cursors.Default;
            }
            dataGridView1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
                оплаты uRow = bindingSource1.Current as оплаты;
                DialogResult xy = MessageBox.Show("Удалить оплату за  " + uRow.дата.ToLongDateString(), "Удаление", MessageBoxButtons.YesNo);
                if (xy == System.Windows.Forms.DialogResult.Yes)
                {
                    bindingSource1.RemoveCurrent();
                }
                else
                {
                    dataGridView1.Focus();
                    return;
                }

            }
            try
            {
                de.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataGridView1.Focus();
        }

        void записать()
        {
            if (label1.Visible)
            {
                try
                {
                    de.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Сбой записи" + ex.Message);
                }
            }
        }

        void обновить()
        {
            bindingSource1.PositionChanged -= bindingSource1_PositionChanged;
            //tempList.Clear();
            de = new domofon14Entities();
            try
            {
                de.сотрудники.Load();
                de.клиенты.Load();

                de.оплаты
                    .Where(n => n.клиент == клКлиент.клиент)
                    .OrderBy(n => n.дата)
                    .ThenBy(n => n.номер)
                    .Load();
                оплатыЛист = de.оплаты.Local.ToBindingList();
                bindingSource1.DataSource = оплатыЛист;
                bindingSource1.Sort = "номер";
                bindingSource1.MoveLast();
            }
            catch
            {
                MessageBox.Show("Сбой загрузки");
            }

            //   tempList.Clear();

            if (bindingSource1.Count > 0)
            {
                заполнить_оплатить();
                заполнить2услуги();
             //   пересчет();

            }
            //else
            //{
            //    tempList.Clear();
            //    пересчет();
            //}
            dataGridView1.Focus();
            bindingSource1.PositionChanged += bindingSource1_PositionChanged;
            //     bindingSource1.MoveLast();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
            //    записать();
                оплаты uRow = bindingSource1.Current as оплаты;
                клОплата.оплата = uRow.оплата;
                клОплата.deRow = uRow;
                клКлиент.клиент = uRow.клиент;
                клУслуга.выбран = false;
                int строка = bindingSource1.Position;
                выбор4услуги выборУслуги = new выбор4услуги();
                выборУслуги.ShowDialog();
                if (клУслуга.выбран)
                {
                    Cursor = Cursors.WaitCursor;
                    оплаченые1месяца оплаченыеМесяца = new оплаченые1месяца();
                    оплаченыеМесяца.Text = "Оплата  " + клУслуга.deRow.наимен + " " + uRow.адрес;
                    оплаченыеМесяца.ShowDialog();
                    обновить();

                    //пересчет();

                    bindingSource1.Position = строка;

                    Cursor = Cursors.Default;
                }

            }

            dataGridView1.Focus();

        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
                //  записать();
                оплаты uRow = bindingSource1.Current as оплаты;
                клОплата.оплата = uRow.оплата;
                клОплата.deRow = uRow;
                клКлиент.клиент = uRow.клиент;
                клУслуга.выбран = false;
                int строка = bindingSource1.Position;
                выбор4услуги выборУслуги = new выбор4услуги();
                выборУслуги.ShowDialog();
                if (клУслуга.выбран)
                {
                    Cursor = Cursors.WaitCursor;
                    возврат1месяца оплаченыеМесяца = new возврат1месяца();
                    оплаченыеМесяца.Text = "Возврат " + клУслуга.deRow.наимен + " " + uRow.адрес;
                    оплаченыеМесяца.ShowDialog();
                    обновить();

                    //пересчет();

                    bindingSource1.Position = строка;

                    Cursor = Cursors.Default;
                }

            }

            dataGridView1.Focus();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            оплаты uRow = bindingSource1.Current as оплаты;
            клОплата.оплата = uRow.оплата;
            de = new domofon14Entities();

            string[] aMez = de.месяцы
               .OrderBy(n => n.месяц)
               .Select(n => n.наимен)
               .ToArray();

            var услугиQuery = de.оплачено
                    .Where(n => n.оплата == клОплата.оплата)
                    .GroupBy(n => new { n.услуги, n.год, n.сумма })
                    .Select(n => new
                    {
                        n.Key.услуги,
                        n.Key.услуги.наимен,
                        n.Key.услуги.порядок,
                        цена = n.Key.сумма,
                        сумма = n.Sum(p => p.сумма),
                        n.Key.год,
                        minMez = n.Min(p => p.месяц),
                        maxMez = n.Max(p => p.месяц)
                    })
                    .OrderBy(n => n.порядок);




            //dsТабель1.квитанция.Clear();
            квитанцияЛист.Clear();
            foreach (var kRow in услугиQuery)
            {
                //  dsТабель1.за_месяца.Clear();
                //           за_месяцЛист.Clear();

                //                dsТабель.квитанцияRow NewRow = dsТабель1.квитанция.NewквитанцияRow();
                квитанция NewRow = new квитанция();


                NewRow.услуга = kRow.услуги.услуга;
                NewRow.наимен_услуги = kRow.наимен;
                NewRow.тариф = kRow.цена;
                NewRow.месяцы = "";
                NewRow.начало = aMez[kRow.minMez - 1];
                if (kRow.maxMez > kRow.minMez)
                {
                    NewRow.конец = aMez[kRow.maxMez - 1];
                }
                NewRow.сумма = kRow.сумма;
                NewRow.год = kRow.год;
                квитанцияЛист.Add(NewRow);

                //dsТабель1.квитанция.Rows.Add(NewRow);
            }


            Word.Application oWord = new Word.Application();

            string curDir = System.IO.Directory.GetCurrentDirectory();

            object шаблон = curDir + @"\квитанция.dot";
            if (!System.IO.File.Exists(шаблон.ToString()))
            {
                MessageBox.Show("Нет файла " + шаблон.ToString());
                return;
            }


            клФирма.init();
            клФилиал.init();

            Word.Document o = oWord.Documents.Add(Template: шаблон);
            //  oWord.Application.Visible = true;
            o.Bookmarks["менеджер"].Range.Text = uRow.сотрудники.фио;
            o.Bookmarks["менеджер2"].Range.Text = uRow.сотрудники.фио;

            o.Bookmarks["дата"].Range.Text = uRow.дата.ToLongDateString();
            o.Bookmarks["дата2"].Range.Text = uRow.дата.ToLongDateString();

            o.Bookmarks["филиал"].Range.Text = клФилиал.наимен;
            o.Bookmarks["адрес_филиала"].Range.Text = клФилиал.адрес.Trim();
            o.Bookmarks["телефон_филиала"].Range.Text = клФилиал.deRow.телефон.Trim();

            o.Bookmarks["филиал2"].Range.Text = клФилиал.наимен;
            o.Bookmarks["адрес2филиала"].Range.Text = клФилиал.адрес.Trim();
            o.Bookmarks["телефон2филиала"].Range.Text = клФилиал.deRow.телефон.Trim();


            o.Bookmarks["номер_квитанции"].Range.Text = uRow.номер.ToString();
            o.Bookmarks["номер2квитанции"].Range.Text = uRow.номер.ToString();

            o.Bookmarks["фио"].Range.Text = uRow.клиенты.фио;
            //string адрес_абонента = "ул. " + uRow.наимен_улицы.Trim()
            //    + "   д. " + uRow.номер_дома.Trim() + " "
            //    + uRow.корпус.Trim()
            //    + " кв. " + uRow.квартира.Trim();
            string адрес_абонента = uRow.клиенты.адрес;

            if (uRow.клиенты.ввод > 0)
            {
                адрес_абонента += " ввод " + uRow.клиенты.ввод.ToString();
            }

            o.Bookmarks["адрес"].Range.Text = адрес_абонента;

            o.Bookmarks["фио2"].Range.Text = uRow.клиенты.фио;
            o.Bookmarks["адрес2"].Range.Text = адрес_абонента;

            o.Bookmarks["наимен_фирмы"].Range.Text = клФирма.deRow.наимен.Trim();
            o.Bookmarks["наимен2фирмы"].Range.Text = клФирма.deRow.наимен.Trim();
            o.Bookmarks["инн"].Range.Text = "ИНН " + клФирма.deRow.инн.Trim();
            o.Bookmarks["инн2"].Range.Text = "ИНН " + клФирма.deRow.инн.Trim();
            o.Bookmarks["кпп"].Range.Text = "КПП " + клФирма.deRow.код.Trim();
            o.Bookmarks["кпп2"].Range.Text = "КПП " + клФирма.deRow.код.Trim();
            o.Bookmarks["расчетный_счет"].Range.Text = "р/с " + клФирма.deRow.р_счет.Trim();
            o.Bookmarks["расчетный2счет"].Range.Text = "р/с " + клФирма.deRow.р_счет.Trim();
            o.Bookmarks["наимен_банка"].Range.Text = " " + клФирма.deRow.банк.Trim();
            o.Bookmarks["наимен2банка"].Range.Text = " " + клФирма.deRow.банк.Trim();
            o.Bookmarks["город"].Range.Text = клФирма.deRow.город.Trim();
            o.Bookmarks["город2"].Range.Text = клФирма.deRow.город.Trim();
            o.Bookmarks["кор_счет"].Range.Text = "к/с " + клФирма.deRow.к_счет.Trim();
            o.Bookmarks["кор2счет"].Range.Text = "к/с " + клФирма.deRow.к_счет.Trim();
            o.Bookmarks["адрес_фирмы"].Range.Text = клФирма.deRow.адрес.Trim();
            o.Bookmarks["адрес2фирмы"].Range.Text = клФирма.deRow.адрес.Trim();


            int j = 1;
            decimal итого = 0;
            foreach (квитанция kRow in квитанцияЛист)
            {
                string текст1 = kRow.начало + " - " + kRow.конец + " " + kRow.год.ToString();
                j++;
                o.Tables[5].Cell(j, 1).Range.Text = kRow.наимен_услуги;
                o.Tables[5].Cell(j, 2).Range.Text = kRow.тариф.ToString("0.00;#;#");
                o.Tables[5].Cell(j, 3).Range.Text = текст1;
                o.Tables[5].Cell(j, 4).Range.Text = kRow.сумма.ToString("0.00");
                o.Tables[5].Rows.Add();
                итого += kRow.сумма;

                o.Tables[11].Cell(j, 1).Range.Text = kRow.наимен_услуги;
                o.Tables[11].Cell(j, 2).Range.Text = kRow.тариф.ToString("0.00;#;#");
                o.Tables[11].Cell(j, 3).Range.Text = текст1;
                o.Tables[11].Cell(j, 4).Range.Text = kRow.сумма.ToString("0.00");
                o.Tables[11].Rows.Add();
            }
            o.Tables[5].Cell(j + 1, 4).Range.Text = итого.ToString("0.00");
            o.Tables[11].Cell(j + 1, 4).Range.Text = итого.ToString("0.00");


            клTemp.Caption = o.ActiveWindow.Caption;
            oWord.Application.Visible = true;

        }
        class квитанция
        {
            public Guid услуга { get; set; }
            public string наимен_услуги { get; set; }
            public int тариф { get; set; }
            public string месяцы { get; set; }
            public int сумма { get; set; }
            public int год { get; set; }
            public string начало { get; set; }
            public string конец { get; set; }
            public string период { get; set; }
            public int зарплата { get; set; }
            public int материалы { get; set; }
            public int наряд { get; set; }
            public string прейскурант { get; set; }
            public string фио_мастера { get; set; }

        }
        private void печать2квитанции_работ()
        {
          //  записать();
            //          DataSet.оплатаRow uRow = (оплатаBindingSource.Current as DataRowView).Row as DataSet.оплатаRow;
            оплаты uRow = bindingSource1.Current as оплаты;

            клОплата.оплата = uRow.оплата;
            de = new domofon14Entities();

            //        domofon10.DataClasses1DataContext db1 = new DataClasses1DataContext();

            //int номерКвитанции = 0;
            //if (db1.опл_работы
            //    .Any(n => n.оплата == клОплата.оплата))
            //{
            //    номерКвитанции = db1.опл_работы
            //    .Where(n => n.оплата == клОплата.оплата)
            //    .Max(n => n.код);
            //}

            //        var yRow = db1.опл_работы
            //.Where(n => n.оплата == клОплата.оплата)
            //.GroupBy(n => n.работа1)
            //.Select(n => new { n.Key, цена = n.Max(z => z.стоимость), сумма = n.Sum(z => z.оплачено) });

            var query = de.опл_работы
     .Where(n => n.оплата == клОплата.оплата)
     .OrderBy(n => n.работы.порядок);

            квитанцияЛист.Clear();

            foreach (var kRow in query)
            {
                квитанция NewRow = new квитанция();
                NewRow.услуга = kRow.работа;
                NewRow.наимен_услуги = kRow.работы.наимен.Trim();
                NewRow.прейскурант = kRow.работы.прейскурант.Trim();
                //   NewRow.наряд = kRow.задание;
                NewRow.сумма = kRow.стоимость;
                NewRow.материалы = (int)kRow.ст_материалов;
                NewRow.зарплата = (int)NewRow.сумма - NewRow.материалы;
                NewRow.фио_мастера = kRow.сотрудники.фио;
                квитанцияЛист.Add(NewRow);
                //     dsТабель1.квитанция.Rows.Add(NewRow);
            }


            Word.Application oWord = new Word.Application();

            string curDir = System.IO.Directory.GetCurrentDirectory();

            object шаблон = curDir + @"\квитанция3работы.dot";
            if (!System.IO.File.Exists(шаблон.ToString()))
            {
                MessageBox.Show("Нет файла " + шаблон.ToString());
                return;
            }

            клФирма.init();
            клФилиал.init();

            Word.Document o = oWord.Documents.Add(Template: шаблон);
            o.Bookmarks["менеджер"].Range.Text = uRow.сотрудники.фио;
            o.Bookmarks["менеджер2"].Range.Text = uRow.сотрудники.фио;

            o.Bookmarks["дата"].Range.Text = uRow.дата.ToLongDateString();
            o.Bookmarks["дата2"].Range.Text = uRow.дата.ToLongDateString();

            o.Bookmarks["филиал"].Range.Text = клФилиал.наимен;
            o.Bookmarks["адрес_филиала"].Range.Text = клФилиал.адрес.Trim();
            o.Bookmarks["телефон_филиала"].Range.Text = клФилиал.deRow.телефон.Trim();

            o.Bookmarks["филиал2"].Range.Text = клФилиал.наимен;
            o.Bookmarks["адрес2филиала"].Range.Text = клФилиал.адрес.Trim();
            o.Bookmarks["телефон2филиала"].Range.Text = клФилиал.deRow.телефон.Trim();


            o.Bookmarks["номер_квитанции"].Range.Text = uRow.номер.ToString();
            o.Bookmarks["номер2квитанции"].Range.Text = uRow.номер.ToString();

            o.Bookmarks["фио"].Range.Text = uRow.клиенты.фио;
            //string адрес_абонента = "ул. " + uRow.наимен_улицы.Trim()
            //    + "   д. " + uRow.номер_дома.Trim() + " "
            //    + uRow.корпус.Trim() + " кв. " + uRow.квартира.Trim();
            //if (uRow.ввод > 0)
            //{
            //    адрес_абонента += " ввод " + uRow.ввод.ToString();
            //}

            o.Bookmarks["адрес"].Range.Text = uRow.клиенты.адрес;

            o.Bookmarks["фио2"].Range.Text = uRow.клиенты.фио;
            o.Bookmarks["адрес2"].Range.Text = uRow.клиенты.адрес;

            o.Bookmarks["наимен_фирмы"].Range.Text = клФирма.deRow.наимен.Trim();
            o.Bookmarks["наимен2фирмы"].Range.Text = клФирма.deRow.наимен.Trim();
            o.Bookmarks["инн"].Range.Text = "ИНН " + клФирма.deRow.инн.Trim();
            o.Bookmarks["инн2"].Range.Text = "ИНН " + клФирма.deRow.инн.Trim();
            o.Bookmarks["кпп"].Range.Text = "КПП " + клФирма.deRow.код.Trim();
            o.Bookmarks["кпп2"].Range.Text = "КПП " + клФирма.deRow.код.Trim();
            o.Bookmarks["расчетный_счет"].Range.Text = "р/с " + клФирма.deRow.р_счет.Trim();
            o.Bookmarks["расчетный2счет"].Range.Text = "р/с " + клФирма.deRow.р_счет.Trim();
            o.Bookmarks["наимен_банка"].Range.Text = " " + клФирма.deRow.банк.Trim();
            o.Bookmarks["наимен2банка"].Range.Text = " " + клФирма.deRow.банк.Trim();
            o.Bookmarks["город"].Range.Text = клФирма.deRow.город.Trim();
            o.Bookmarks["город2"].Range.Text = клФирма.deRow.город.Trim();
            o.Bookmarks["кор_счет"].Range.Text = "к/с " + клФирма.deRow.к_счет.Trim();
            o.Bookmarks["кор2счет"].Range.Text = "к/с " + клФирма.deRow.к_счет.Trim();
            o.Bookmarks["адрес_фирмы"].Range.Text = клФирма.deRow.адрес.Trim();
            o.Bookmarks["адрес2фирмы"].Range.Text = клФирма.deRow.адрес.Trim();


            int j = 1;
            decimal итого = 0;
            foreach (квитанция kRow in квитанцияЛист)
            {
                //   string текст1 = kRow.начало + " - " + kRow.конец + " " + kRow.год.ToString();
                j++;
                o.Tables[5].Cell(j, 1).Range.Text = kRow.наряд.ToString("0;#;#");

                o.Tables[5].Cell(j, 2).Range.Text = kRow.прейскурант;
                o.Tables[5].Cell(j, 3).Range.Text = kRow.наимен_услуги.Trim() + "  мастер " + kRow.фио_мастера.Trim();
                //  o.Tables[5].Cell(j, 4).Range.Text = kRow.материалы.ToString("0.00;#;#");
                o.Tables[5].Cell(j, 4).Range.Text = kRow.сумма.ToString("0.00;#;#");
                o.Tables[5].Rows.Add();
                итого += kRow.сумма;

                o.Tables[11].Cell(j, 1).Range.Text = kRow.наряд.ToString("0;#;#");

                o.Tables[11].Cell(j, 2).Range.Text = kRow.прейскурант;
                o.Tables[11].Cell(j, 3).Range.Text = kRow.наимен_услуги.Trim() + "  мастер " + kRow.фио_мастера.Trim();
                o.Tables[11].Cell(j, 4).Range.Text = kRow.материалы.ToString("0.00;#;#");
                o.Tables[11].Cell(j, 5).Range.Text = kRow.сумма.ToString("0.00;#;#");
                o.Tables[11].Rows.Add();
            }
            o.Tables[5].Cell(j + 1, 4).Range.Text = итого.ToString("0.00");
            o.Tables[11].Cell(j + 1, 5).Range.Text = итого.ToString("0.00");


            клTemp.Caption = o.ActiveWindow.Caption;
            oWord.Application.Visible = true;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            печать2квитанции_работ();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
                оплаты uRow = bindingSource1.Current as оплаты;
                клОплата.оплата = uRow.оплата;
                string фио = uRow.клиенты.фио;

                de = new domofon14Entities();
                //int СуммаВозврата = de.возврат
                //    .Where(n => n.оплата == клОплата.оплата)
                //    .Sum(n => n.сумма);

                Word.Application oWord = new Word.Application();

                string curDir = System.IO.Directory.GetCurrentDirectory();

                object шаблон = curDir + @"\расходник.dot";
                if (!System.IO.File.Exists(шаблон.ToString()))
                {
                    MessageBox.Show("Нет файла " + шаблон.ToString());
                    return;
                }

                клФирма.init();
                клФилиал.init();

                Word.Document o = oWord.Documents.Add(Template: шаблон);
                o.Bookmarks["кассир"].Range.Text = uRow.сотрудники.фио;

                o.Bookmarks["дата"].Range.Text = uRow.дата.ToLongDateString();

                o.Bookmarks["филиал"].Range.Text = клФилиал.наимен;

                if (de.возврат.Any(n => n.оплата == клОплата.оплата) || de.воз_работы.Any(n => n.оплата == клОплата.оплата))
                {
                    int СуммаВозврата = de.возврат
                       .Where(n => n.оплата == клОплата.оплата)
                       .Sum(n => n.сумма);

                    int ВозвратРаботы = de.воз_работы
                       .Where(n => n.оплата == клОплата.оплата)
                       .Sum(n => n.сумма);

                    СуммаВозврата += ВозвратРаботы;

                    //  MessageBox.Show(прописью.буквами(СуммаВозврата));
                    if (o.Bookmarks.Exists("сумма"))
                        o.Bookmarks["сумма"].Range.Text = СуммаВозврата.ToString();
                    if (o.Bookmarks.Exists("выдано_прописью"))
                        o.Bookmarks["выдано_прописью"].Range.Text = прописью.буквами(СуммаВозврата) + "____";


                }
                //      o.Bookmarks["сумма"].Range.Text = СуммаВозврата.ToString();


                if (o.Bookmarks.Exists("номер"))
                    o.Bookmarks["номер"].Range.Text = uRow.номер.ToString();
                if (o.Bookmarks.Exists("фио"))
                    o.Bookmarks["фио"].Range.Text = фио;

                oWord.Application.Visible = true;
            }

        }

        private void заполнить2услуги()
        {
            int мСумма = 0;
            tempList.Clear();

            if (bindingSource1.Count > 0)
            {
                try
                {
                    оплаты  uRow = bindingSource1.Current as оплаты ;

                    string curDir = System.IO.Directory.GetCurrentDirectory();

                    string шаблон = curDir + @"\заполнить_услуги.sql";

                    if (!System.IO.File.Exists(шаблон.ToString()))
                    {
                        MessageBox.Show("Нет файла " + шаблон.ToString());
                        Cursor = Cursors.Default;
                        return;
                    }
                    StreamReader sr = new StreamReader(шаблон, Encoding.Default);

                    string запрос = sr.ReadToEnd();
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("declare @оплата  uniqueidentifier ='" + uRow.оплата.ToString() + "';");
                    sb.AppendLine(запрос);

                    string sqlString = sb.ToString();


                    tempList = de.Database.SqlQuery<temp>(sqlString).ToList();

                    //оплаты  uRow = (оплаты)bindingSource1.Current;
                    //tempList = de.Database.SqlQuery<temp>("заполнить_услуги @оплата = @p0", uRow.оплата).ToList();

                    if (tempList.Any())
                    {
                        мСумма = tempList.Sum(n => n.сумма);
                    }

                    if (uRow.оплатить != мСумма)
                    {
                        uRow.оплатить = мСумма;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
            textBox1.Text = мСумма.ToString();
            bindingSource2.DataSource = null;
            bindingSource2.DataSource = tempList;
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = bindingSource2;
            bindingSource2.MoveLast();
            dataGridView2.Refresh();
            налTextBox.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {

                оплаты uRow = bindingSource1.Current as оплаты;
                клОплата.оплата = uRow.оплата;
                клОплата.дата = uRow.дата;
                клОплата.номер = uRow.номер;
                клОплата.deRow = de.оплаты.Single(n => n.оплата == клОплата.оплата);
                клКлиент.клиент = uRow.клиент;
                клУслуга.выбран = false;
                int строка = bindingSource1.Position;
                Cursor = Cursors.WaitCursor;
                возврат1работ оплатаРабот = new возврат1работ();

                оплатаРабот.Text = $"Возвраты за работы {клКлиент.адрес}   {клКлиент.фио}";

                оплатаРабот.ShowDialog();
                if (клОплата.выбран)
                {
                    заполнить2услуги();
                  //  пересчет();
                    dataGridView1.Refresh();
                }
                Cursor = Cursors.Default;
            }
        }
    }
}
