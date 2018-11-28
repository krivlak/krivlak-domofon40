using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
namespace domofon40
{
    public partial class дом1месяц : Form
    {
        public дом1месяц()
        {
            InitializeComponent();
        }

        domofon40.domofon14Entities de = new domofon14Entities();
        List<temp> tempList0 = new List<temp>();
        List<temp> tempList = new List<temp>();
        int днейМесяца = DateTime.DaysInMonth(клМесяц.год, клМесяц.месяц);
        private void дом1месяц_Load(object sender, EventArgs e)
        {
            try
            {

                foreach (клиенты kRow in de.клиенты
                    .Where(n => n.дом == клДом.дом)
                    .OrderBy(n => n.квартира)
                    .ThenBy(n => n.ввод))
                {
                    foreach (услуги uRow in de.услуги
                        .Where(n => n.вид_услуги == клВид_услуги.вид_услуги)
                        .OrderBy(n => n.порядок))
                    {
                        temp newTemp = new temp();
                        newTemp.ввод = kRow.ввод;
                        newTemp.квартира = kRow.квартира;
                        newTemp.клиент = kRow.клиент;
                        newTemp.наимен_услуги = uRow.обозначение;
                        newTemp.подъезд = kRow.подъезд;
                        newTemp.порядок_услуги = uRow.порядок;
                        newTemp.прим0 = kRow.прим;
                        newTemp.телефон = kRow.телефон;
                        newTemp.услуга = uRow.услуга;
                        newTemp.фио = kRow.фио;
                        newTemp.всего_дней = днейМесяца;
                        if (kRow.услуги.Any(n => n.услуга == uRow.услуга))
                        {
                            newTemp.наш = true;
                        }
                        if (kRow.раб_дней
                            .Where(n => n.год == клМесяц.год)
                            .Where(n => n.месяц == клМесяц.месяц)
                            .Any(n => n.услуга == uRow.услуга))
                        {

                            newTemp.раб_дней = kRow.раб_дней
                                .Where(n => n.год == клМесяц.год)
                                .Where(n => n.месяц == клМесяц.месяц)
                                .Single(n => n.услуга == uRow.услуга).дней;
                        }
                        else
                        {
                            newTemp.раб_дней = днейМесяца;
                        }
                        //if(uRow.оплачено
                        //    .Where(n=>n.год==клМесяц.год)
                        //    .Where(n => n.месяц == клМесяц.месяц)
                        //    .Any(n=>n.оплаты.клиент==kRow.клиент))
                        //{
                        //    newTemp.оплачено = uRow.оплачено
                        //    .Where(n => n.год == клМесяц.год)
                        //    .Where(n => n.месяц == клМесяц.месяц)
                        //    .First(n => n.оплаты.клиент == kRow.клиент).сумма;
                        //}

                        temp2 t2 = линейка(kRow.клиент, uRow.услуга);
                        newTemp.карта = t2.карта;
                        newTemp.подк_дней = t2.раб_дней;


                        //   newTemp.дней = расчет_дней(kRow.клиент1, uRow.услуга1);
                        //  newTemp.аДни = new bool[30];
                        //newTemp.дней = de.раб_дней
                        //    .Where(n => n.клиент == kRow.клиент1)
                        //    .Where(n => n.услуга == uRow.услуга1).Count();
                        //    //.Where(n => n.год == клМесяц.год)
                        //    //.Where(n => n.месяц == клМесяц.месяц).Count();



                        tempList0.Add(newTemp);
                    }
                }
                var dictTemp = tempList0.ToDictionary(n => new { n.клиент, n.услуга });
                foreach (примечания uRow in de.примечания)
                {
                    var ключ = new { uRow.клиент, uRow.услуга };
                    if (dictTemp.ContainsKey(ключ))
                    {
                        dictTemp[ключ].прим = uRow.прим;
                    }
                }
                foreach (подключения pRow in de.подключения
                    .Where(n => n.услуги.вид_услуги == клВид_услуги.вид_услуги)
                    .OrderBy(n => n.дата_с))
                {
                    int g100m = клМесяц.год * 100 + клМесяц.месяц;
                    if (pRow.дата_с.Year * 100 + pRow.дата_с.Month <= g100m)
                    {
                        var ключ = new { pRow.клиент, pRow.услуга };
                        if (dictTemp.ContainsKey(ключ))
                        {
                            dictTemp[ключ].договор_с = pRow.дата_с;
                        }
                    }
                }

                foreach (отключения pRow in de.отключения
                  .Where(n => n.услуги.вид_услуги == клВид_услуги.вид_услуги)
                  .OrderBy(n => n.дата_с))
                {
                    int g100m = клМесяц.год * 100 + клМесяц.месяц;
                    if (pRow.дата_с.Year * 100 + pRow.дата_с.Month <= g100m)
                    {
                        var ключ = new { pRow.клиент, pRow.услуга };
                        if (dictTemp.ContainsKey(ключ))
                        {
                            dictTemp[ключ].отключен = pRow.дата_с;
                        }
                    }
                }

           //     foreach (звонки pRow in de.звонки
           //.OrderBy(n => n.дата))
           //     {

           //         var ключ = new { pRow.клиент };
           //         if (dictTemp.ContainsKey(ключ))
           //         {
           //             dictTemp[ключ].звонок = pRow.дата;
           //         }

           //     }

                //за месяц могут несколько раз отключить



                foreach (льготы pRow in de.льготы
            .Where(n => n.услуги.вид_услуги == клВид_услуги.вид_услуги)
            .OrderBy(n => n.дата_с))
                {
                    int g100m = клМесяц.год * 100 + клМесяц.месяц;
                    if (pRow.дата_с.Year * 100 + pRow.дата_с.Month <= g100m)
                    {
                        var ключ = new { pRow.клиент, pRow.услуга };
                        if (dictTemp.ContainsKey(ключ))
                        {
                            dictTemp[ключ].льгота_с = pRow.дата_с;
                        }
                    }
                }



                foreach (повторы pRow in de.повторы
            .Where(n => n.услуги.вид_услуги == клВид_услуги.вид_услуги)
            .OrderBy(n => n.дата_с))
                {
                    int g100m = клМесяц.год * 100 + клМесяц.месяц;
                    if (pRow.дата_с.Year * 100 + pRow.дата_с.Month <= g100m)
                    {
                        var ключ = new { pRow.клиент, pRow.услуга };
                        if (dictTemp.ContainsKey(ключ))
                        {
                            dictTemp[ключ].повтор = pRow.дата_с;
                        }
                    }
                }

                var dicТариф = de.цены
.Where(n => n.услуги.вид_услуги == клВид_услуги.вид_услуги)
         .Where(n => n.год == клМесяц.год)
         .Where(n => n.месяц == клМесяц.месяц)
         .Select(n => new { n.услуга, n.стоимость }).ToDictionary(n => n.услуга);

                foreach (temp tRow in tempList0)
                {
                    if (dicТариф.ContainsKey(tRow.услуга))
                    {
                        tRow.тариф = (int)dicТариф[tRow.услуга].стоимость;
                    }
                 //   tRow.оплатить = (int)(tRow.тариф * tRow.раб_дней / днейМесяца);
                }

                //if (tempList0.Any())
                //{
                //    int сумма1месяц = tempList0.Sum(n => n.оплатить);

                //    textBox2.Text = сумма1месяц.ToString();
                //    int человек = tempList0.Count(n => n.оплатить > 0);
                //    textBox3.Text = человек.ToString();
                //}
              

                tempList = tempList0.Where(n => n.наш ).ToList();
         //       tempList = tempList0.Where(n => n.подк_дней > 0 || n.наш).ToList();

                //  || (n.подк_дней == 0 && n.раб_дней > 0)
                //    tempList = tempList0.ToList();


                bindingSource1.DataSource = tempList;
                пересчет();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            textBox1.DataBindings.Add("Text", bindingSource1, "карта");
            прим0TextBox.DataBindings.Add("Text", bindingSource1, "прим0");
            dataGridView1.CellMouseClick += DataGridView1_CellMouseClick;
            temp.Moving += Temp_Moving;
            FormClosing += Дом1месяц_FormClosing;
            dataGridView1.DataError += DataGridView1_DataError;
            dataGridView1.CellFormatting += DataGridView1_CellFormatting;
            dataGridView1.EditingControlShowing += dataGridView1_EditingControlShowing;

        }

        void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            string CellName = dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].Name;
            if (CellName == "раб_днейColumn")
            {
                e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
            }
        }
        void Control_KeyPress(object sender, KeyPressEventArgs pressE)
        {
            клKey.int_KeyPress(sender, pressE);
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] == раб_днейColumn)
            {
               int рабДней =(int) dataGridView1.Rows[e.RowIndex].Cells["раб_днейColumn"].Value;
                int подкДней = (int)dataGridView1.Rows[e.RowIndex].Cells["подк_днейColumn"].Value;
               if(рабДней != подкДней)
                {
                    e.CellStyle.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void DataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] == примColumn)
            {
                dataGridView1.Rows[e.RowIndex].Cells["примColumn"].Value = "";
            }
            if (dataGridView1.Columns[e.ColumnIndex] == раб_днейColumn)
            {
                dataGridView1.Rows[e.RowIndex].Cells["раб_днейColumn"].Value = 0;
            }
        }

        private void Дом1месяц_FormClosing(object sender, FormClosingEventArgs e)
        {
            temp.Moving -= Temp_Moving;
        }

        private void Temp_Moving(temp obj)
        {

            if (obj.поле == "раб_дней")
            {
                //          клиенты kRow = de.клиенты.Single(n => n.клиент == obj.клиент);
                //раб_дней[] delRow = kRow.раб_дней
                //    .Where(n=>n.услуга== obj.услуга)
                //    .Where(n => n.год == клМесяц.год && n.месяц == клМесяц.месяц).ToArray();
                try
                {
                    de.Database.ExecuteSqlCommand("delete from раб_дней where услуга=@p0 and клиент = @p1 and год = @p2 and месяц= @p3", obj.услуга, obj.клиент, клМесяц.год, клМесяц.месяц);

                    //foreach (раб_дней dRow in delRow)
                    //{
                    //    kRow.раб_дней.Remove(dRow);
                    //}
                    // de.раб_дней.RemoveRange(delRow);
                    //      de.SaveChanges();
                    if (obj.раб_дней != днейМесяца)
                    {
                        de.Database.ExecuteSqlCommand("insert into раб_дней (год,месяц,клиент,услуга,дней,прим) values( @p0,@p1,@p2,@p3,@p4,@p5)", клМесяц.год, клМесяц.месяц, obj.клиент, obj.услуга, obj.раб_дней, "");
                        //раб_дней newRow = new раб_дней
                        //{
                        //    год = клМесяц.год,
                        //    дней = obj.раб_дней,
                        //    клиент = kRow.клиент,
                        //    месяц = клМесяц.месяц,
                        //    прим = "",
                        //    услуга = obj.услуга
                        //};
                        //de.раб_дней.Add(newRow);
                        //de.SaveChanges();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Сбой записи раб_дней " + ex.Message);
                }
                пересчет();
            }

            if (obj.поле == "прим")
            {

                try
                {
                    de.Database.ExecuteSqlCommand("delete from примечания where услуга=@p0 and клиент = @p1 ", obj.услуга, obj.клиент);


                    if (obj.прим != null)
                    {
                        if (obj.прим.Trim() != String.Empty)
                        {

                            de.Database.ExecuteSqlCommand("insert into примечания (клиент,услуга,прим) values( @p0,@p1,@p2)", obj.клиент, obj.услуга, obj.прим);
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Сбой записи прим " + ex.Message);
                }
            }


            if (obj.поле == "наш")
            {

                try
                {
                    de.Database.ExecuteSqlCommand("delete from услуги_клиента where услуга=@p0 and клиент = @p1 ", obj.услуга, obj.клиент);



                    if (obj.наш)
                    {

                        de.Database.ExecuteSqlCommand("insert into услуги_клиента (клиент,услуга) values( @p0,@p1)", obj.клиент, obj.услуга);
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Сбой записи наш " + ex.Message);
                }
            }

            if (obj.поле == "прим0")
            {

                try
                {
                    de.Database.ExecuteSqlCommand("update клиенты set прим =@p0 where  клиент = @p1 ", obj.прим0, obj.клиент);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Сбой записи прим0 " + ex.Message);
                }
            }

            if (obj.поле == "телефон")
            {

                try
                {
                    de.Database.ExecuteSqlCommand("update клиенты set телефон =@p0 where  клиент = @p1 ", obj.телефон, obj.клиент);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Сбой записи " + ex.Message);
                }
            }
        }
            //примечания[] aRows = de.примечания.Where(n => n.клиент == obj.клиент && n.услуга == obj.услуга).ToArray();
            //foreach (примечания delRow in aRows)
            //{
            //    de.примечания.Remove(delRow);
            //}
            //de.SaveChanges();

            //if (obj.прим != null)
            //{
            //    if (obj.прим.Trim() != String.Empty)
            //    {
            //        примечания newRow = new примечания()
            //        {
            //            клиент = obj.клиент,
            //            прим = obj.прим,
            //            услуга = obj.услуга
            //        };
            //        de.примечания.Add(newRow);
            //        de.SaveChanges();
            //    }
            //}
            //}

            //if (obj.поле == "прим0")
            //{
            //    клиенты kRow = de.клиенты.Single(n => n.клиент == obj.клиент);
            //    kRow.прим = obj.прим0;
            //    de.SaveChanges();
            //}

            //if (obj.поле == "телефон")
            //{
            //    клиенты kRow = de.клиенты.Single(n => n.клиент == obj.клиент);
            //    kRow.телефон = obj.телефон;
            //    de.SaveChanges();
            //}

            //if (obj.поле == "наш")
            //{
            //    клиенты kRow = de.клиенты.Single(n => n.клиент == obj.клиент);
            //    услуги[] delRow = kRow.услуги
            //        .Where(n => n.услуга == obj.услуга)
            //        .ToArray();
            //    foreach (услуги dRow in delRow)
            //    {
            //        kRow.услуги.Remove(dRow);
            //    }
            //    de.SaveChanges();

            //   if(obj.наш)
            //    {
            //        услуги newRow = de.услуги.Single(n => n.услуга == obj.услуга);
            //        kRow.услуги.Add(newRow);
            //        de.SaveChanges();
            //    }  
               
            //}

            //try
            //{
            //    de.SaveChanges();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Сбой записи " + ex.Message);
            //}

        //}

        void пересчет()
        {
            int человек = 0;
            int сумма1месяц = 0;

         

            if (tempList0.Any())
            {
                сумма1месяц = tempList
                    .Where(n=>n.раб_дней>0)
                    .Sum(n => n.оплатить);


                textBox2.Text = сумма1месяц.ToString();
                человек = tempList
                    .Count(n => n.оплатить > 0);


                textBox3.Text = человек.ToString();
            }
      
            textBox2.Text = сумма1месяц.ToString();
            
            textBox3.Text = человек.ToString();
            textBox2.Refresh();
            textBox3.Refresh();

        }

        private void DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                Cursor = Cursors.WaitCursor;

                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                temp uRow = bindingSource1.Current as temp;

                //Guid КодОплаты = uRow.оплата;

                //if ((клОплата.оплата != Guid.Empty) && (КодОплаты == клОплата.оплата) || (КодОплаты == Guid.Empty))
                //{

                //    if (dataGridView1.Columns[e.ColumnIndex] == оплаченоColumn)
                //    {


                //        uRow.оплачено = uRow.оплатить;
                //        dataGridView1.Refresh();
                //    }
                //}

                if (dataGridView1.Columns[e.ColumnIndex] == раб_днейColumn)
                {
                   
                    uRow.раб_дней = днейМесяца;
                    dataGridView1.Refresh();
                 //   пересчет();
                }

                if (dataGridView1.Columns[e.ColumnIndex] == подк_днейColumn)
                {
                   
                    uRow.раб_дней = uRow.подк_дней;
                    dataGridView1.Refresh();
                   // пересчет();

                }

                Cursor = Cursors.Default;

            }
        }

        private temp2 линейка(Guid  клиент, Guid услуга)
        {
            DateTime началоМесяца = new DateTime(клМесяц.год, клМесяц.месяц, 1);
            DateTime конецМесяца = new DateTime(клМесяц.год, клМесяц.месяц, днейМесяца);
            List<temp30> temp30List = new List<temp30>();

            for (int i = 1; i <= днейМесяца; i++)
            {
                temp30 newTemp = new temp30();
                newTemp.дата = new DateTime(клМесяц.год, клМесяц.месяц, i);
                newTemp.договор = false;
                newTemp.отключен = false;
                newTemp.повторно = false;
                newTemp.льгота = false;
                newTemp.рабочий = false;
                newTemp.марка = "Х ";
                temp30List.Add(newTemp);
            }
            bool естьДоговор = false;
            //      Dictionary<DateTime, temp30> dicTemp = temp30List.ToDictionary(n => n.дата);
            foreach (подключения uRow in de.подключения
                .Where(n => n.клиент == клиент)
                .Where(n => n.услуга == услуга)
                .OrderBy(n => n.дата_с))
            {
                естьДоговор = true;
                foreach (temp30 dRow in temp30List.Where(n => n.дата >= uRow.дата_с))
                {
                    dRow.договор = true;
                    dRow.марка = " ";
                    dRow.договор_с = uRow.дата_с;
                }
                //temp30List.Where(n => n.дата > uRow.дата_с).ToList().ForEach(n => n.договор = true);
                //temp30List.Where(n => n.дата > uRow.дата_с).ToList().ForEach(n => n.марка = "  ");
            }

            foreach (отключения uRow in de.отключения
             .Where(n => n.клиент == клиент)
             .Where(n => n.услуга == услуга)
             .OrderBy(n => n.дата_с))
            {
                foreach (temp30 dRow in temp30List.Where(n => n.дата >= uRow.дата_с))
                {
                    if (dRow.договор_с != null)
                    {
                        if(dRow.договор_с<uRow.дата_с)
                        {
                            dRow.отключен = true;
                            dRow.марка = "От";
                            dRow.отключен_с = uRow.дата_с;
                        }
                    }
                    else
                    {
                        dRow.отключен = true;
                        dRow.марка = "От";
                        dRow.отключен_с = uRow.дата_с;
                    }
            
                }
                //temp30List.Where(n => n.дата >= uRow.дата_с).ToList().ForEach(n => n.отключен = true);
                //temp30List.Where(n => n.дата >= uRow.дата_с).ToList().ForEach(n => n.марка = "От");
                //temp30List.Where(n => n.дата > uRow.дата_с).ToList().ForEach(n => n.договор = false);
            }

            foreach (простои uRow in de.простои
         .Where(n => n.клиент == клиент)
         .Where(n => n.услуга == услуга)
         .OrderBy(n => n.дата_с))
            {
                if (uRow.дата_по == null)
                {
                    foreach (temp30 dRow in temp30List.Where(n => n.дата >= uRow.дата_с))
                    {

                        dRow.простой = true;
                        dRow.марка = "Пр";
                    
                    }
                }
                else
                {
                    foreach (temp30 dRow in temp30List.Where(n => n.дата >= uRow.дата_с).Where(n => n.дата <= uRow.дата_по))
                    {

                        dRow.простой = true;
                        dRow.марка = "Пр";
                     
                    }
                }
                //temp30List.Where(n => n.дата >= uRow.дата_с).ToList().ForEach(n => n.отключен = true);
                //temp30List.Where(n => n.дата >= uRow.дата_с).ToList().ForEach(n => n.марка = "От");
                //temp30List.Where(n => n.дата > uRow.дата_с).ToList().ForEach(n => n.договор = false);
            }

            foreach (повторы uRow in de.повторы
       .Where(n => n.клиент == клиент)
       .Where(n => n.услуга == услуга)
       .OrderBy(n => n.дата_с))
            {
                foreach (temp30 dRow in temp30List.Where(n => n.дата > uRow.дата_с))
                {
                    if (dRow.отключен_с == null)
                    {
                        dRow.повторно = true;
                        dRow.марка = " ";
                        dRow.отключен = false;
                        dRow.повторно_с = uRow.дата_с;
                    }
                    else
                    {
                        if (dRow.отключен_с < uRow.дата_с)
                        {
                            dRow.повторно = true;
                            dRow.марка = " ";
                            dRow.отключен = false;
                            dRow.повторно_с = uRow.дата_с;
                        }
                    }
                   
                }
                //temp30List.Where(n => n.дата > uRow.дата_с).ToList().ForEach(n => n.повторно = true);
                //temp30List.Where(n => n.дата > uRow.дата_с).ToList().ForEach(n => n.марка = "  ");
                //temp30List.Where(n => n.дата >= uRow.дата_с).ToList().ForEach(n => n.отключен = false);

            }
            foreach (льготы uRow in de.льготы
                .Where(n => n.клиент == клиент)
                .Where(n => n.услуга == услуга)
                .OrderBy(n => n.дата_с))
            {
                foreach (temp30 dRow in temp30List.Where(n => n.дата > uRow.дата_с))
                {
                    dRow.льгота = true;
                    dRow.марка = "Лг";
                    dRow.льгота_с = uRow.дата_с;
                }
                //temp30List.Where(n => n.дата >= uRow.дата_с).ToList().ForEach(n => n.льгота = true);
                //temp30List.Where(n => n.дата >= uRow.дата_с).ToList().ForEach(n => n.марка = "Лг");
            }

            int дней2 = 0;
            foreach (temp30 tRow in temp30List)
            {
                bool xy = true;
                if (естьДоговор)
                {
                    if (tRow.льгота || tRow.отключен || tRow.простой || tRow.договор == false)
                    {
                        xy = false;
                    }
                  
                }
                else
                {
                    if (tRow.льгота || tRow.отключен || tRow.простой)
                    {
                        xy = false;
                    }

                }
                 tRow.рабочий = xy;
                
                if(xy)
                {
                    tRow.марка = "  ";
                    дней2++;
                }

                //bool xy = false;
                //if (tRow.договор)
                //{
                //    xy = true;
                //}
                //if (tRow.льгота || tRow.отключен)
                //{
                //    xy = false;
                //}

                //if (tRow.повторно)
                //{
                //    xy = true;
                //}

                //if (xy)
                //{
                //    tRow.рабочий = true;
                //    дней2++;
                //}
                //else
                //{
                //    tRow.рабочий = false;
                //}
            }

            System.Text.StringBuilder sb = new StringBuilder();
            foreach (temp30 tRow in temp30List)
            {
                sb.Append(tRow.марка);
            }
            temp2 t2 = new temp2();
            t2.карта = sb.ToString();
            t2.раб_дней = дней2;
            return t2;
        }


        class temp30
        {
            public DateTime дата { get; set; }
            public bool договор { get; set; } = false;
            public bool отключен { get; set; } = false;
            public bool повторно { get; set; } = false;
            public bool льгота { get; set; } = false;
            public bool простой { get; set; } = false;

            public DateTime ? договор_с { get; set; }
            public DateTime? отключен_с { get; set; }
            public DateTime? повторно_с { get; set; }
            public DateTime? льгота_с { get; set; }
            public bool рабочий { get; set; }

            public string марка { get; set; }

        }

        class temp2
        {
            public int раб_дней = 0;
            public string карта = "";
        }

        class temp
        {

            public Guid клиент { get; set; }
            public Guid услуга { get; set; }
            //   public int год { get; set; }
            //    public int месяц { get; set; }
            //    public int долг_мес { get; set; }
            public DateTime? договор_с { get; set; }
            public DateTime? отключен { get; set; }
            public DateTime? повтор { get; set; }
            public DateTime? звонок { get; set; }
            public DateTime? льгота_с { get; set; }
            public string фио { get; set; }
            public int квартира { get; set; }
            public int квартира0 { get; set; }
            public int ввод { get; set; }
            public int подъезд { get; set; }
            //public string телефон { get; set; }
            public int порядок_услуги { get; set; }
            public string наимен_услуги { get; set; }
            public int строка { get; set; }
            // public bool наш { get; set; }
            bool Наш;
            public bool наш
            {
                get
                {
                    return Наш;
                }
                set
                {
                    Наш = value;
                    if (Moving != null)
                    {
                        поле = "наш";
                        Moving(this);
                    }
                }
            }

            //    public bool должник { get; set; }
            //         public bool подключить { get; set; }
            public bool отключить { get; set; }
            //        public bool повторно { get; set; }
            //public string прим { get; set; }
            //public string прим0 { get; set; }
        //    public int дней { get; set; }
            public int тариф { get; set; }
            public int всего_дней  { get; set; }
         //   public int оплачено { get; set; } = 0;
            public int оплатить {
                get
                {
                    int сумма = 0;

                    if (всего_дней > 0)
                    {
                        сумма = (int)тариф * раб_дней / всего_дней;
                    }
                    return сумма;
                }
            }
            public string карта { get; set; }
            public int подк_дней { get; set; }

            int рабДней ;
            public int  раб_дней
            {

                get
                {
                    return рабДней;
                }

                set
                {
                    рабДней = value;
                    if (Moving != null)
                    {
                        поле = "раб_дней";
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

            public string поле { get; set; }
            public static event Action<temp> Moving;


            //    public bool[] аДни { get; set; }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
                temp.Moving -= Temp_Moving;
                Cursor = Cursors.WaitCursor;

                temp tRow = bindingSource1.Current as temp;
                клКлиент.клиент = tRow.клиент;
                клУслуга.услуга = tRow.услуга;
                клОплата.выбран = false;
              оплаченные1просмотр формаОплатить = new  оплаченные1просмотр();

                формаОплатить.Text = "Оплаты за " + tRow.наимен_услуги.Trim() + " " + tRow.фио;

                //            клОплата.изменено = false;
                формаОплатить.ShowDialog();
                if(клОплата.выбран )
                {
                    if(tRow.раб_дней != формаОплатить.рабТек)
                    {
                        tRow.раб_дней = формаОплатить.рабТек;
                        пересчет();
                    }
                    dataGridView1.Refresh();
                }
                Cursor = Cursors.Default;
                temp.Moving += Temp_Moving;
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            string curDir = System.IO.Directory.GetCurrentDirectory();

            string шаблон = curDir + @"\дом1месяц.docx";

            if (!System.IO.File.Exists(шаблон.ToString()))
            {
                MessageBox.Show("Нет файла " + шаблон.ToString());
                Cursor = Cursors.Default;
                return;
            }

            var template = new System.IO.FileInfo(шаблон);
            string tempFile = curDir + @"\temp\temp.docx";
            try
            {

                клTemp.закрытьWord();
            }
            catch
            {
                MessageBox.Show("Сохраните файл Word...");

            }

            try
            {
                template.CopyTo(tempFile, true);
            }
            catch
            {
                MessageBox.Show("Закройте файл Word...");
                return;
            }

            try
            {
                using (WordprocessingDocument package = WordprocessingDocument.Open(tempFile, true))
                {
                   // int строкаРаб = 0;

                    var tables = package.MainDocumentPart.Document.Body.Elements<Table>();

                    Table table1 = tables.ElementAt(0);
                    Table table2 = tables.ElementAt(1);


                    клXML.ChangeTextInCell(table1, 0, 0, this.Text + " " + DateTime.Today.ToLongDateString());

                    TableRow lastRow = table2.Elements<TableRow>().Last();

                    var queryTemp = tempList.ToArray();
                    int j = 0;

                    int всего = 0;
                    int клиентов = 0;
                    foreach (temp kRow in tempList)
                    {
                        TableRow newRow1 = lastRow.Clone() as TableRow;


                        table2.AppendChild<TableRow>(newRow1);


                        j++;

                        клXML.ChangeTextInCell(table2, j, 0, kRow.квартира.ToString("0;#;#"));
                        клXML.ChangeTextInCell(table2, j, 1, kRow.ввод.ToString("0;#;#"));
                        клXML.ChangeTextInCell(table2, j, 2, kRow.фио);

                        клXML.ChangeTextInCell(table2, j, 3, kRow.наимен_услуги);

                        клXML.ChangeTextInCell(table2, j, 4, kRow.раб_дней.ToString("0;#;#"));

                        клXML.ChangeTextInCell(table2, j, 5, kRow.тариф.ToString("0;#;#"));
                        клXML.ChangeTextInCell(table2, j, 6, kRow.оплатить.ToString("0;#;#"));
                        if (kRow.оплатить > 0)
                        {
                            клиентов++;
                        }

                        всего += kRow.оплатить;
                    }


                    j++;
                    клXML.ChangeTextInCell(table2, j, 0, "");
                    клXML.ChangeTextInCell(table2, j, 1, "");
                    клXML.ChangeTextInCell(table2, j, 2, "");
                    клXML.ChangeTextInCell(table2, j, 3, "Число клиентов ");
                    клXML.ChangeTextInCell(table2, j, 4, клиентов.ToString());
                    клXML.ChangeTextInCell(table2, j, 5, "");
                    клXML.ChangeTextInCell(table2, j, 6, всего.ToString());
                    //клXML.ChangeTextInCell(table2, j, 7, "");


                }
                //  }
            }
            catch
            {
                MessageBox.Show("Закройте файл Word...");
                return;
            }



            клTemp.закрытьWord();


            клXML.просмотрWord(tempFile);

            Cursor = Cursors.Default;

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
               
                tempList = tempList0;
                checkBox1.Text = "Сжать";
            }
            else
            {
                tempList = tempList0.Where(n => n.наш).ToList();
                checkBox1.Text = "Все";
            }
            bindingSource1.DataSource = tempList;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            пересчет();
        }

        //private void button3_Click_1(object sender, EventArgs e)
        //{
        //    клСотрудник.выбран = false;
        //    выбор_кассира выборКассира = new выбор_кассира();
        //    выборКассира.ShowDialog();
        //    if (клСотрудник.выбран)
        //    {
        //        Cursor = Cursors.WaitCursor;
        //        int maxNum = 0;
        //        if(de.оплаты.Any())
        //        {
        //            maxNum = de.оплаты.Max(n => n.номер);
        //        }
        //        foreach (temp tRow in tempList.Where(n => n.оплатить > 0).Where(n => n.оплачено == 0))
        //        {
        //            maxNum++;
        //            оплаты новОплата = new оплаты()
        //            {
        //                клиент = tRow.клиент,
        //                дата = DateTime.Today,
        //                номер = maxNum,
        //                оплата = Guid.NewGuid(),
        //                сотрудник = клСотрудник.сотрудник
        //            };
        //            оплачено новМес = new оплачено()
        //            {
        //                год = клМесяц.год,
        //                месяц = клМесяц.месяц,
        //                оплата = новОплата.оплата,
        //                сумма = tRow.оплатить,
        //                услуга = tRow.услуга,
        //                цена = tRow.тариф,
        //                дней = tRow.раб_дней
        //            };
        //            новОплата.оплачено.Add(новМес);
        //            de.оплаты.Add(новОплата);
        //            tRow.оплачено = tRow.оплатить;
        //        }
        //        de.SaveChanges();
        //        dataGridView1.Refresh();
        //        Cursor = Cursors.Default;
        //    }
        //}
    }
}
