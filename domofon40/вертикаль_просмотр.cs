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
    public partial class вертикаль_просмотр : Form
    {
        public вертикаль_просмотр()
        {
            InitializeComponent();
        }
        DateTime maxData;
        decimal sДолг = 0;
        DateTime начало;
  //      DateTime? договор_с = null;
        private void изРассчетаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        domofon14Entities db = new domofon14Entities();
        private void вертикаль_просмотр_Load(object sender, EventArgs e)
        {
            //string dmg = "01.01." + (db.годы.Max(n => n.год) + 1).ToString();
            //maxData = DateTime.Parse(dmg);
            int maxGot=db.годы.Max(n => n.год) + 1;

            maxData = new DateTime(maxGot, 1, 1);

            начало = db.начало.First().начало1.Date;
            наличие_договора();
            услуга_подключена();

            заполнить_дни();
            дни_договор();
            дни_отключено();
            дни_простой();
            дни_льготы();
            подробности_рабочие();

            заполнить_месяца();

            заполнить_цену();
            if (клУслуга.подключена)
            {
                заполнить_всего_дней();
            }
            заполнить_раб_дней();
            заполнить_оплачено();
            // заполнить_к_оплате();
            // заполнить_долг();
            пересчет_долга();
            заполнить_горизонталь();
       //     initRead();
            int строка = вертикальBindingSource.Find("год", DateTime.Today.Year - 1);
            вертикальDataGridView.FirstDisplayedScrollingRowIndex = строка;

            вертикальDataGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(вертикальDataGridView_CellFormatting);
       

        }

        void вертикальDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
      //      if (вертикальDataGridView.Columns[e.ColumnIndex] == dataGridViewTextBoxColumn5
      //|| вертикальDataGridView.Columns[e.ColumnIndex] == dataGridViewTextBoxColumn7
      //|| вертикальDataGridView.Columns[e.ColumnIndex] == dataGridViewTextBoxColumn8)
      //      {
      //          Guid КодОплаты = (Guid) вертикальDataGridView.Rows[e.RowIndex].Cells["оплатаColumn"].Value;
      //          if (КодОплаты == клОплата.оплата)
      //          {
      //              e.CellStyle.BackColor = Color.FromArgb(200, 255, 200);
      //          }
      //      }

            if (вертикальDataGridView.Columns[e.ColumnIndex] == подк_днейColumn)
            {
                int подкл_дней = (int)вертикальDataGridView.Rows[e.RowIndex].Cells["подк_днейColumn"].Value;
                int всего_дней = (int)вертикальDataGridView.Rows[e.RowIndex].Cells["всего_днейColumn"].Value;
                if (подкл_дней < всего_дней)
                    e.CellStyle.ForeColor = Color.Red;
            }

          
            int nGod = (int)вертикальDataGridView.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn1"].Value;
            if (nGod % 2 == 0)
            {
                e.CellStyle.ForeColor = Color.Blue;
            }

        }



//        private void initRead()
//        {
//            foreach (System.Windows.Forms.DataGridViewRow uRow in вертикальDataGridView.Rows)
//            {
//                Guid КодОплаты = (Guid) uRow.Cells["оплатаColumn"].Value ;
//                if (КодОплаты != клОплата.оплата && КодОплаты==Guid.Empty) 
////                    || клОплата.оплата == "1234567890")
//                {
//                    uRow.Cells["dataGridViewTextBoxColumn5"].ReadOnly = true;
//                }
//                if (КодОплаты != клОплата.оплата || клОплата.оплата == "1234567890")
//                {
//                    uRow.Cells["dataGridViewTextBoxColumn4"].ReadOnly = true;
//                }
//            }
//        }


        private void заполнить_горизонталь()
        {
            foreach (dsТабель.вертикальRow vRow in dsТабель1.вертикаль.Rows)
            {

                string текст = "";
                int рабДней = 0;
                foreach (dsТабель.подробностиRow pRow in dsТабель1.подробности
                    .Where(n => n.год == vRow.год && n.месяц == vRow.месяц))
                {
                    if (pRow.раб_день)
                    {
                        текст += "  ";
                        рабДней += 1;
                    }
                    else
                    {
                        string xx = "X ";
                        if (pRow.отключен)
                        {
                            xx = "От";
                        }

                        if (pRow.простой)
                        {
                            xx = "Пр";
                        }
                        if (pRow.льгота > 0)
                        {
                            xx = "Лг";
                        }
                        текст += xx;

                    }
                }
                vRow.подк_дней = рабДней;
                vRow.договор_с = текст;

            }
        }           


        private void пересчет_долга()
        {
            вертикальBindingSource.EndEdit();

            int gg = DateTime.Today.Year;
            int mm = DateTime.Today.Month;
            sДолг = 0;
            foreach (dsТабель.вертикальRow tRow in dsТабель1.вертикаль
                .Where(n => n.год * 100 + n.месяц < gg * 100 + mm))
            {

                tRow.долг = tRow.оплатить - tRow.оплачено;

                sДолг += tRow.долг;
            }

            textBox1.Text = sДолг.ToString("0;-0;#");
            if (sДолг > 0)
            {
                клУслуга.долг_руб = (int)sДолг;
            }
            else
            {
                клУслуга.долг_руб = 0;
            }

        }


        private void заполнить_оплачено()
        {

            foreach (оплачено uRow in db.оплачено
                .Where(n => n.оплаты.клиент == клКлиент.клиент && n.услуга == клУслуга.услуга))
            {

                int gg = uRow.год;
                int mm = uRow.месяц;

                if (dsТабель1.вертикаль
                    .Any(n => n.год == gg
                        && n.месяц == mm))
                {
                    dsТабель.вертикальRow tRow = dsТабель1.вертикаль
                        .Single(n => n.год == gg
                            && n.месяц == mm);

                    tRow.оплачено = uRow.сумма;
                    tRow.дата_сч = uRow.оплаты.дата;
                    tRow.номер_сч = uRow.оплаты.номер.ToString();
                    tRow.оплата = uRow.оплата;
                    if (uRow.цена > 0)
                    {
                        tRow.цена = uRow.цена;
                        tRow.оплатить = Math.Round(tRow.цена * tRow.раб_дней / tRow.всего_дней);
                    }
                }

            }

            

        }

        private void заполнить_раб_дней()
        {



            foreach (раб_дней uRow in db.раб_дней
               .Where(n => n.клиент == клКлиент.клиент && n.услуга == клУслуга.услуга))
            {
                int gg = uRow.год;
                int mm = uRow.месяц;
                if (gg > 0 && mm > 0)
                {
                    if (dsТабель1.вертикаль
                        .Any(n => n.год == gg
                            && n.месяц == mm))
                    {
                        dsТабель.вертикальRow tRow = dsТабель1.вертикаль
                            .Single(n => n.год == gg
                                && n.месяц == mm);

                        tRow.раб_дней = uRow.дней;
                        tRow.прим = uRow.прим;
                        tRow.оплатить = System.Math.Round(tRow.цена * tRow.раб_дней / tRow.всего_дней);
                    }
                }


            }
        }


        private void заполнить_всего_дней()
        {
            foreach (dsТабель.вертикальRow vRow in dsТабель1.вертикаль.Rows)
            {
                if (vRow.год > начало.Year || (vRow.год == начало.Year && vRow.месяц >= начало.Month))
                {
                    vRow.раб_дней = vRow.всего_дней;
                    vRow.оплатить = Math.Round(vRow.цена * vRow.раб_дней / vRow.всего_дней);
                }
            }
        }


        private void заполнить_цену()
        {


            foreach (цены uRow in db.цены.Where(n => n.услуга == клУслуга.услуга))
            {
                int gg = uRow.год;
                int mm = uRow.месяц;

                try
                {
                    dsТабель.вертикальRow tRow = dsТабель1.вертикаль
                        .Single(n => n.год == gg && n.месяц == mm );
                    tRow.цена = uRow.стоимость;
                    tRow.тариф = uRow.стоимость;
                }
                catch { }
            }

        }


        private void заполнить_месяца()
        {
            //      domofon10.DataClasses1DataContext db1 = new DataClasses1DataContext();

            int i = 0;
            foreach (var gg in db.годы.OrderBy(n => n.год))
            {
                foreach (var mm in db.месяцы.OrderBy(n => n.месяц))
                {
                    //DateTime dt = DateTime.Parse("01." + mm.месяц1.ToString().Trim() + "." + gg.год1.ToString().Trim());
                    
                    DateTime dt = new DateTime(gg.год, mm.месяц, 1);

                    dsТабель.вертикальRow NewRow = dsТабель1.вертикаль.NewвертикальRow();

                    NewRow.год = gg.год;
                    NewRow.месяц = mm.месяц;
                    NewRow.наимен_мес = mm.наимен;
                    //NewRow.наимен_услуги = клУслуга.наимен;
                    //NewRow.услуга = клУслуга.услуга;
                    //NewRow.клиент = клКлиент.клиент;
                    NewRow.всего_дней = DateTime.DaysInMonth(gg.год, mm.месяц);

                    dsТабель1.вертикаль.Rows.Add(NewRow);
                    i++;
                    if (gg.год == DateTime.Today.Year && mm.месяц == DateTime.Today.Month)
                    {
                        вертикальBindingSource.Position = i;
                    }


                }
            }
        }


        private void подробности_рабочие()
        {
            foreach (dsТабель.подробностиRow pRow in dsТабель1.подробности.Rows)
            {
                bool xy = true;
                if (клКлиент.есть_договор)
                {
                    if (pRow.льгота > 0 || pRow.отключен || pRow.простой || pRow.договор == false)
                        xy = false;
                }
                else
                {
                    if (pRow.льгота > 0 || pRow.отключен || pRow.простой)
                        xy = false;
                }
                //                

                pRow.раб_день = xy;

            }
        }


        private void дни_льготы()
        {
            foreach (льготы uRow in db.льготы
                .Where(n => n.клиент == клКлиент.клиент && n.услуга == клУслуга.услуга))
            {
                if (uRow.дата_по == null)
                {
                    for (DateTime dm = uRow.дата_с; dm < maxData; dm = dm.AddDays(1))
                    {
                        int gg = dm.Year;
                        int mm = dm.Month;
                        int dd = dm.Day;
                        if (dsТабель1.подробности
                          .Count(n => n.год == gg && n.месяц == mm && n.день == dd ) == 1)
                        {

                            dsТабель.подробностиRow tRow = dsТабель1.подробности
                              .Single(n => n.год == gg && n.месяц == mm && n.день == dd );

                            tRow.льгота = uRow.процент;

                        }

                    }
                }
                else
                {
                    for (DateTime dm = uRow.дата_с; dm <= uRow.дата_по; dm = dm.AddDays(1))
                    {
                        int gg = dm.Year;
                        int mm = dm.Month;
                        int dd = dm.Day;
                        if (dsТабель1.подробности
                       .Count(n => n.год == gg && n.месяц == mm && n.день == dd ) == 1)
                        {
                            dsТабель.подробностиRow tRow = dsТабель1.подробности
                                     .Single(n => n.год == gg && n.месяц == mm && n.день == dd );

                            tRow.льгота = uRow.процент;
                        }
                    }
                }
            }
        }


        private void дни_простой()
        {
            foreach (dsТабель.подробностиRow pRow in dsТабель1.подробности)
            {
                if (pRow.простой)
                    pRow.прим = "";

                pRow.простой = false;
            }


            //foreach (простои uRow in db.простои
            //    .Where(n => n.клиент == клКлиент.клиент && n.услуга == клУслуга.услуга))
            //{
            //    if (uRow.дата_по == null)
            //    {
            //        for (DateTime dm = uRow.дата_с; dm < maxData; dm = dm.AddDays(1))
            //        {
            //            int gg = dm.Year;
            //            int mm = dm.Month;
            //            int dd = dm.Day;

            //            try
            //            {
            //                dsТабель.подробностиRow tRow = dsТабель1.подробности
            //                  .Single(n => n.год == gg && n.месяц == mm && n.день == dd );

            //                tRow.простой = true;
            //                tRow.прим = uRow.наимен;
            //            }
            //            catch { }


            //        }
            //    }
            //    else
            //    {
            //        for (DateTime dm = uRow.дата_с; dm <= uRow.дата_по; dm = dm.AddDays(1))
            //        {
            //            int gg = dm.Year;
            //            int mm = dm.Month;
            //            int dd = dm.Day;
            //            try
            //            {
            //                dsТабель.подробностиRow tRow = dsТабель1.подробности
            //                         .Single(n => n.год == gg && n.месяц == mm && n.день == dd );

            //                tRow.прим = uRow.наимен;
            //                tRow.простой = true;
            //            }
            //            catch { }
            //        }
            //    }
            //}
        }


        private void дни_отключено()
        {

            foreach (dsТабель.подробностиRow pRow in dsТабель1.подробности)
            {
                if (pRow.отключен)
                    pRow.прим = "";

                pRow.отключен = false;
            }



            var dОтк = db.отключения
                  .Where(n => n.клиент == клКлиент.клиент)
                  .Where(n => n.услуга == клУслуга.услуга)
                  .GroupBy(n => n.дата_с)
                  .Select(n => new { дата_с = n.Key, прим = n.Max(p => p.прим) }).ToDictionary(n => n.дата_с);

            var dПовт = db.повторы
                .Where(n => n.клиент == клКлиент.клиент)
                .Where(n => n.услуга == клУслуга.услуга)
                 .GroupBy(n => n.дата_с)
                  .Select(n => new { дата_с = n.Key, прим = n.Max(p => p.прим) }).ToDictionary(n => n.дата_с);


            bool Отк = false;
            string Прим = "";

            foreach (dsТабель.подробностиRow tRow in dsТабель1.подробности)
            {
                if (dОтк.ContainsKey(tRow.дата))
                {
                    Отк = true;
//                    Прим = dОтк.Single(n => n.Key == tRow.дата).Value.прим;
                    Прим = dОтк[tRow.дата].прим;
                }

                if (dПовт.ContainsKey(tRow.дата))
                {
                    Отк = false;
//                    Прим = dПовт.Single(n => n.Key == tRow.дата).Value.прим;
                    Прим = dПовт[tRow.дата].прим;
                }


                if (Отк)
                {
                    tRow.отключен = true;
                    tRow.прим = Прим;
                }

            }

          
        }


        private void дни_договор()
        {
            
            foreach (подключения uRow in db.подключения
                .Where(n => n.клиент == клКлиент.клиент && n.услуга == клУслуга.услуга))
            {
                string НаименДоговора = "без номера";
                if (uRow.номер_дог.Trim().Length == 0 && uRow.номер_пп == 0)
                {
                    
                }
                else
                {
                    НаименДоговора = uRow.номер_дог.Trim() + uRow.номер_пп.ToString();
                }

                if (uRow.дата_по == null)
                {
                    for (DateTime dm = uRow.дата_с.AddDays(1); dm < maxData; dm = dm.AddDays(1))
                    {
                        int gg = dm.Year;
                        int mm = dm.Month;
                        int dd = dm.Day;
                        if (dsТабель1.подробности
                          .Count(n => n.год == gg && n.месяц == mm && n.день == dd ) == 1)
                        {

                            dsТабель.подробностиRow tRow = dsТабель1.подробности
                              .Single(n => n.год == gg && n.месяц == mm && n.день == dd );

                         
                            tRow.номер_дог = НаименДоговора;
                            tRow.код_договора = uRow.подключение;
                            tRow.договор = true;
                        }




                    }
                }
                else
                {
                    for (DateTime dm = uRow.дата_с.AddDays(1); dm <= uRow.дата_по; dm = dm.AddDays(1))
                    {
                        int gg = dm.Year;
                        int mm = dm.Month;
                        int dd = dm.Day;
                        if (dsТабель1.подробности
                        .Count(n => n.год == gg && n.месяц == mm && n.день == dd ) == 1)
                        {
                            dsТабель.подробностиRow tRow = dsТабель1.подробности
                                     .Single(n => n.год == gg && n.месяц == mm && n.день == dd );
                            tRow.код_договора = uRow.подключение;
                            tRow.договор = true;
                            tRow.номер_дог = НаименДоговора;
                            
                        }
                    }
                }
            }
        }


        private void заполнить_дни()
        {
            dsТабель1.подробности.Clear();

            foreach (var gg in db.годы.OrderBy(n => n.год))
            {
                foreach (var mm in db.месяцы.OrderBy(n => n.месяц))
                {
                    int длина = DateTime.DaysInMonth(gg.год, mm.месяц);
                    for (int d = 1; d <= длина; d++)
                    {
                      //  DateTime dt = DateTime.Parse(d.ToString().Trim() + "." + mm.месяц.ToString().Trim() + "." + gg.год.ToString().Trim());
                        DateTime dt = new DateTime(gg.год, mm.месяц, d);
                        dsТабель.подробностиRow NewRow = dsТабель1.подробности.NewподробностиRow();
                        NewRow.дата = dt;
                        NewRow.год = gg.год;
                        NewRow.месяц = mm.месяц;
                        NewRow.день = d;
                     //   NewRow.услуга = клУслуга.услуга;

                        //    NewRow.отключен = true;

                        dsТабель1.подробности.Rows.Add(NewRow);

                    }



                }
            }
        }


        private void услуга_подключена()
        {
            клУслуга.подключена = false;
            if (db.услуги
                .Where(n => n.услуга == клУслуга.услуга)
                .Any(n => n.клиенты.Any(p => p.клиент == клКлиент.клиент)))
            //.Any(n => n.клиент.Any(p=>p.клиент1 == клКлиент.клиент && n.услуга == клУслуга.услуга))
            {
                клУслуга.подключена = true;
            }


            if (db.оплачено.Any(n => n.оплаты.клиент == клКлиент.клиент && n.услуга == клУслуга.услуга))
            {
                клУслуга.подключена = true;
            }

        }


        private void наличие_договора()
        {
            клКлиент.есть_договор = false;
            if (db.подключения.Any(n => n.клиент == клКлиент.клиент && n.услуга == клУслуга.услуга))
            {
                клКлиент.есть_договор = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }
    }
}
