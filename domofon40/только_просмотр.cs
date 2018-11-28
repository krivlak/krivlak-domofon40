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
    public partial class только_просмотр : Form
    {
        public только_просмотр()
        {
            InitializeComponent();
        }
        DateTime начало;
        DateTime maxData;
        domofon40.domofon14Entities de = new domofon14Entities();
        List<temp> tempList = new List<temp>();
        List<temp2> temp2List = new List<temp2>();
        int позиция = 0;
        Dictionary<int, temp> dicTemp = new Dictionary<int, temp>();
        Dictionary<DateTime, temp2> dicTemp2 = new Dictionary<DateTime, temp2>();
        int текГод = DateTime.Today.Year;
        private void только_просмотр_Load(object sender, EventArgs e)
        {
            try
            {
                int махГод = DateTime.Today.Year+1;
                int минГод = de.годы.Min(n => n.год);

                maxData = new DateTime(махГод + 1, 1, 1);
               

                найти_начало();

                наличие_договора();
                услуга_подключена();
                заполнить_дни();
                dicTemp2 = temp2List.ToDictionary(n => n.дата);
                дни_договор();
                дни_оплачено();
                дни_отключено();
                дни_простой();
                дни_льгота();
                подробности_рабочие();
                /////////////////////////////////
                заполнить_месяца();
                dicTemp = tempList.ToDictionary(n => n.год * 100 + n.месяц);
                //            dicTemp1 = tempList.ToDictionary(n => n.ключ1);
                заполнить_цену();
                //if(клУслуга.подключена)
                //{
                //    заполнить_всего_дней();
                //}

                заполнить_всего_дней();  //14 секунд   второй раз 
                заполнить_оплачено();
                заполнить_раб_дней();
                заполнить_возврат();
                пересчет_долга();
                заполнить_горизонталь();
                //            следить = true; 
                bindingSource1.DataSource = tempList;
                bindingSource1.Position = позиция;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Сбой загрузки " + ex.Message);
            }

    
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            temp.Moving += temp_Moving;
            FormClosing += Только_просмотр_FormClosing;
            dataGridView1.EditingControlShowing += dataGridView1_EditingControlShowing;
            dataGridView1.CellMouseClick += dataGridView1_CellMouseClick;

        }

        void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                //                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                temp uRow = bindingSource1.Current as temp;
                //    dsТабель.вертикальRow uRow = (вертикальBindingSource.Current as DataRowView).Row as dsТабель.вертикальRow;

                Guid КодОплаты = uRow.оплата;
                //   Guid КодОплаты =(Guid) dataGridView1.Rows[e.RowIndex].Cells["оплатаColumn"].Value;

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
                    //dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    //dsТабель.вертикальRow uRow = (вертикальBindingSource.Current as DataRowView).Row as dsТабель.вертикальRow;
                    uRow.раб_дней = uRow.всего_дней;
                    dataGridView1.Refresh();
                }

                if (dataGridView1.Columns[e.ColumnIndex] == подкл_днейColumn)
                {
                    //dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
                    //dsТабель.вертикальRow uRow = (вертикальBindingSource.Current as DataRowView).Row as dsТабель.вертикальRow;
                    uRow.раб_дней = uRow.подк_дней;
                    dataGridView1.Refresh();
                }



            }
        }


        void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Control_KeyPress);
            string CellName = dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].Name;

            if ( CellName == "раб_днейColumn")
            {
                e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
            }
            //if (CellName == "раб_днейColumn")
            //{
            //    e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
            //}
        }

        void Control_KeyPress(object sender, KeyPressEventArgs pressE)
        {
            //            клKey.decimal_KeyPress(sender, pressE);
            клKey.int_KeyPress(sender, pressE);
        }

        private void Только_просмотр_FormClosing(object sender, FormClosingEventArgs e)
        {
            temp.Moving -= temp_Moving;
        }

        private void заполнить_возврат()
        {
            foreach (возврат uRow in de.возврат
                .Where(n => n.услуга == клУслуга.услуга)
                .Where(n => n.оплаты.клиент == клКлиент.клиент))
            {
                int ключ = uRow.год * 100 + uRow.месяц;
                if (dicTemp.ContainsKey(ключ))
                {
                    temp tRow = dicTemp[ключ];
                    //    tRow.оплата = uRow.оплаты.оплата;
                    tRow.возврат = uRow.сумма;
                    tRow.оплата_возврат = uRow.оплата;
                }
            }
        }






        void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {


            if (dataGridView1.Columns[e.ColumnIndex] == подкл_днейColumn)
            {
                try
                {
                    int подкл_дней = (int)dataGridView1.Rows[e.RowIndex].Cells["подкл_днейColumn"].Value;
                    int всего_дней = (int)dataGridView1.Rows[e.RowIndex].Cells["всего_днейColumn"].Value;

                    if (подкл_дней < всего_дней)
                    {
                        e.CellStyle.ForeColor = Color.Red;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            if (dataGridView1.Columns[e.ColumnIndex] == раб_днейColumn)
            {
                try
                {
                    int подкл_дней = (int)dataGridView1.Rows[e.RowIndex].Cells["раб_днейColumn"].Value;
                    int всего_дней = (int)dataGridView1.Rows[e.RowIndex].Cells["всего_днейColumn"].Value;

                    if (подкл_дней < всего_дней)
                    {
                        e.CellStyle.ForeColor = Color.Red;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }


            if (dataGridView1.Columns[e.ColumnIndex] == годColumn || dataGridView1.Columns[e.ColumnIndex] == месяцColumn)
            {
                int nGod = (int)dataGridView1.Rows[e.RowIndex].Cells["годColumn"].Value;
                if (nGod % 2 == 0)
                {
                    e.CellStyle.ForeColor = Color.Blue;
                }
            }
        }


        private void пересчет_долга()
        {
            bindingSource1.EndEdit();

            int gg = DateTime.Today.Year;
            int mm = DateTime.Today.Month;
            int sДолг = 0;
            foreach (temp tRow in tempList
                .Where(n => n.год * 100 + n.месяц < gg * 100 + mm))
            {

                //    tRow.долг = tRow.оплатить - tRow.оплачено;

                sДолг += tRow.долг;
            }

            textBox1.Text = sДолг.ToString("0;-0;#");
        }
        private void заполнить_оплачено()
        {
            foreach (оплачено uRow in de.оплачено
                .Where(n => n.услуга == клУслуга.услуга)
                .Where(n => n.оплаты.клиент == клКлиент.клиент))
            {
                int ключ = uRow.год * 100 + uRow.месяц;
                if (dicTemp.ContainsKey(ключ))
                {
                    temp tRow = dicTemp[ключ];
                    tRow.оплата = uRow.оплаты.оплата;
                    tRow.оплачено = uRow.сумма;
                    tRow.раб_дней = tRow.всего_дней;
                    tRow.номер_счета = uRow.оплаты.номер;
                    tRow.дата_счета = uRow.оплаты.дата;
                    if (uRow.цена > 0)
                    {
                        tRow.цена = uRow.цена;
                    }
                }
            }
        }

        private void заполнить_раб_дней()
        {



            foreach (раб_дней uRow in de.раб_дней
               .Where(n => n.клиент == клКлиент.клиент && n.услуга == клУслуга.услуга))
            {
                int gg = uRow.год;
                int mm = uRow.месяц;
                if (gg > 0 && mm > 0)
                {
                    int ключ = uRow.год * 100 + uRow.месяц;
                    if (dicTemp.ContainsKey(ключ))
                    {
                        temp tRow = dicTemp[ключ];

                        tRow.раб_дней = uRow.дней;
                        tRow.прим = uRow.прим;
                    }
                }


            }
        }


        private void заполнить_всего_дней()
        {
            foreach (temp vRow in tempList)
            {
                if (vRow.год > начало.Year || (vRow.год == начало.Year && vRow.месяц >= начало.Month))
                {
                    vRow.раб_дней = vRow.всего_дней;
                }
            }
        }
        class temp  {
            public int год { get; set; }
            public int месяц { get; set; }
            public string наимен_месяца { get; set; }
            public int тариф { get; set; }
            public int возврат { get; set; }
            public int цена { get; set; }
            public int оплатить
            {
                get
                {
                    int опл = 0;
                    if (всего_дней > 0)
                    { опл = (int)(цена * раб_дней / всего_дней); }

                    return опл;
                }
            }
   

            public int оплачено { get; set; }
   

            public int долг
            {
                get
                {
                    int долг0 = 0;
                    int gggg = DateTime.Today.Year;
                    int mm = DateTime.Today.Month;
                    if (год * 100 + месяц < gggg * 100 + mm)
                    {
                        долг0 = оплатить - оплачено;
                    }
                    return долг0;
                }
            }
            public DateTime? дата_счета { get; set; }
            public int номер_счета { get; set; }
            public int всего_дней { get; set; }
            int РабочихДней;
            public int раб_дней
            {
                get { return РабочихДней; }
                set
                {
                    РабочихДней = value;
                    //if (РабочихДней < всего_дней)
                    //{
                    if (Moving != null)
                    {
                        поле = "раб_дней";
                        Moving(this);
                    }
                    //}
                }
            }
            public int подк_дней { get; set; }
            public string подробности { get; set; }
            public string прим { get; set; }
            public Guid оплата { get; set; }
            public Guid оплата_возврат { get; set; }
            public string поле = "";

            public static event Action<temp> Moving;



        }

        class temp2
        {
            public int год { get; set; }
            public int месяц { get; set; }
            public int день { get; set; }
            public DateTime дата { get; set; }
            public bool льгота { get; set; } = false;
            public bool отключен { get; set; } = false;
            public bool простой { get; set; } = false;
            public bool раб_день { get; set; } = false;
            public string номер_дог { get; set; }
            public DateTime? дата_с { get; set; } = null;
            public bool договор { get; set; } = false;
            public bool оплачен  { get; set; } = false;
            public string прим { get; set; } = "";
        }

        private void заполнить_дни()
        {

            foreach (годы gg in de.годы.Where(n=>n.год<=текГод+1).Where(n=>n.год>=начало.Year).OrderBy(n => n.год))
            {
                foreach (var mm in de.месяцы.OrderBy(n => n.месяц))
                {
                    int длина = DateTime.DaysInMonth(gg.год, mm.месяц);
                    for (int d = 1; d <= длина; d++)
                    {
                        DateTime dt = new DateTime(gg.год, mm.месяц, d);
                        if (dt >= начало)
                        {
                            temp2 NewRow = new temp2();
                            NewRow.дата = dt;
                            NewRow.год = gg.год;
                            NewRow.месяц = mm.месяц;
                            NewRow.день = d;
                            temp2List.Add(NewRow);
                        }

                    }



                }
            }
        }

        private void заполнить_месяца()
        {

            int i = 0;
            foreach (var gg in de.годы.Where(n => n.год <= текГод + 1).Where(n=>n.год>=начало.Year).OrderBy(n => n.год))
            {
                foreach (var mm in de.месяцы.OrderBy(n => n.месяц))
                {
                    DateTime dm = new DateTime(gg.год, mm.месяц, 1);
                    if (dm >= начало)
                    {
                        temp NewRow = new temp();
                        NewRow.год = gg.год;
                        NewRow.месяц = mm.месяц;
                        NewRow.наимен_месяца = mm.наимен;
                        NewRow.всего_дней = DateTime.DaysInMonth(gg.год, mm.месяц);
                        NewRow.оплата = Guid.Empty;
                        tempList.Add(NewRow);


                        i++;
                        if (gg.год == DateTime.Today.Year && mm.месяц == DateTime.Today.Month)
                        {
                            позиция = i;
                        }
                    }


                }
            }
        }
        private void заполнить_цену()
        {
            foreach (цены uRow in de.цены.Where(n => n.услуга == клУслуга.услуга))
            {

                if (dicTemp.ContainsKey(uRow.год * 100 + uRow.месяц))
                {
                    dicTemp[uRow.год * 100 + uRow.месяц].цена = uRow.стоимость;
                    dicTemp[uRow.год * 100 + uRow.месяц].тариф = uRow.стоимость;
                }

            }

        }

        private void наличие_договора()
        {

            клКлиент.есть_договор = false;
            if (de.подключения.Any(n => n.клиент == клКлиент.клиент && n.услуга == клУслуга.услуга))
            {
                клКлиент.есть_договор = true;
            }
        }
        private void услуга_подключена()
        {
            клУслуга.подключена = false;
            if (de.услуги.Single(n => n.услуга == клУслуга.услуга).клиенты.Any(n => n.клиент == клКлиент.клиент))
            {
                клУслуга.подключена = true;
            }


            if (de.оплачено.Any(n => n.оплаты.клиент == клКлиент.клиент && n.услуга == клУслуга.услуга))
            {
                клУслуга.подключена = true;
            }

        }

        private void дни_оплачено()
        {
            if (de.подключения.Where(n => n.клиент == клКлиент.клиент).Any(n => n.услуга == клУслуга.услуга))
            {
                DateTime подключен = de.подключения.Where(n => n.клиент == клКлиент.клиент).Where(n => n.услуга == клУслуга.услуга).Min(n => n.дата_с);
                int dog100 = подключен.Year * 100 + подключен.Month;

                if (de.оплачено.Where(n => n.оплаты.клиент == клКлиент.клиент).Any(n => n.услуга == клУслуга.услуга))
                {
                    // Вычисляется дата начала оплаты

                    int g100m = de.оплачено.Where(n => n.оплаты.клиент == клКлиент.клиент).Where(n => n.услуга == клУслуга.услуга).Min(n => n.год * 100 + n.месяц);
                    if (dog100 > g100m)
                    {
                        int minG = (int)g100m / 100;
                        int minM = g100m - minG * 100;
                        DateTime minD = new DateTime(minG, minM, 1).AddMonths(-1);

                        foreach (temp2 tRow in temp2List.Where(n => n.дата < подключен && n.дата >= minD))
                        {
                            tRow.оплачен = true;
                        }

                    }

                    // присваивается оплачен с начала оплаты

                }
            }


        }
        private void дни_договор()
        {
            foreach (подключения uRow in de.подключения
                .Where(n => n.клиент == клКлиент.клиент && n.услуга == клУслуга.услуга)
                .OrderBy(n => n.дата_с))
            {
                string НаименДоговора = "без номера";
                if (uRow.номер_дог.Trim().Length == 0 && uRow.номер_пп == 0)
                {
                    //         tRow.номер_дог = "без номера";
                }
                else
                {
                    НаименДоговора = uRow.номер_дог.Trim() + uRow.номер_пп.ToString();
                }

                if (uRow.дата_по == null)
                {
                    for (DateTime dm = uRow.дата_с.AddDays(1); dm < maxData; dm = dm.AddDays(1))
                    {

                        if (dicTemp2.ContainsKey(dm))
                        {
                            temp2 tRow = dicTemp2[dm];
                            //if (uRow.номер_дог.Trim().Length == 0 && uRow.номер_пп == 0)
                            //{
                            //    tRow.номер_дог = "без номера";
                            //}
                            //else
                            //{
                            //    tRow.номер_дог = uRow.номер_дог.Trim() + uRow.номер_пп.ToString();
                            //    tRow.дата_с = uRow.дата_с;
                            //}
                            tRow.номер_дог = НаименДоговора;
                            //tRow.код_договора = uRow.код;
                            tRow.дата_с = uRow.дата_с;
                            tRow.договор = true;

                        }
                    }
                }
                else
                {
                    for (DateTime dm = uRow.дата_с.AddDays(1); dm <= uRow.дата_по; dm = dm.AddDays(1))
                    {
                        if (dicTemp2.ContainsKey(dm))
                        {
                            temp2 tRow = dicTemp2[dm];
                            //if (uRow.номер_дог.Trim().Length == 0 && uRow.номер_пп == 0)
                            //{
                            //    tRow.номер_дог = "без номера";
                            //}
                            //else
                            //{
                            //    tRow.номер_дог = uRow.номер_дог.Trim() + uRow.номер_пп.ToString();
                            //}
                            tRow.номер_дог = НаименДоговора;
                            tRow.дата_с = uRow.дата_с;
                            //tRow.код_договора = uRow.код;
                            tRow.договор = true;

                        }

                    }
                }
            }
        }
        private void дни_льгота()
        {
            foreach (льготы uRow in de.льготы
                .Where(n => n.клиент == клКлиент.клиент && n.услуга == клУслуга.услуга)
                .OrderBy(n => n.дата_с))
            {
                if (uRow.дата_по == null)
                {
                    for (DateTime dm = uRow.дата_с; dm < maxData; dm = dm.AddDays(1))
                    {
                        if (dicTemp2.ContainsKey(dm))
                        {
                            temp2 tRow = dicTemp2[dm];
                            tRow.льгота = true;
                        }
                    }
                }
                else
                {
                    for (DateTime dm = uRow.дата_с; dm <= uRow.дата_по; dm = dm.AddDays(1))
                    {
                        if (dicTemp2.ContainsKey(dm))
                        {
                            temp2 tRow = dicTemp2[dm];
                            tRow.льгота = true;
                        }
                    }
                }

            }
        }
        private void дни_отключено()
        {

            var dОтк = de.отключения
                  .Where(n => n.клиент == клКлиент.клиент)
                  .Where(n => n.услуга == клУслуга.услуга)
                  .GroupBy(n => n.дата_с)
                  .Select(n => new { дата_с = n.Key, прим = n.Max(p => p.прим) }).ToDictionary(n => n.дата_с);

            var dПовт = de.повторы
                .Where(n => n.клиент == клКлиент.клиент)
                .Where(n => n.услуга == клУслуга.услуга)
                 .GroupBy(n => n.дата_с)
                  .Select(n => new { дата_с = n.Key, прим = n.Max(p => p.прим) }).ToDictionary(n => n.дата_с);




            bool Отк = false;
            string Прим = "";
            DateTime? датаОтключения = null;
            foreach (temp2 tRow in temp2List)
            {
                if (dОтк.ContainsKey(tRow.дата))
                {
                    Отк = true;
                    Прим = dОтк[tRow.дата].прим;
                    датаОтключения = tRow.дата;

                }

                if (dПовт.ContainsKey(tRow.дата.AddDays(-1)))
                {
                    Отк = false;
                    Прим = dПовт[tRow.дата.AddDays(-1)].прим;
               
                }

                if (датаОтключения != null)
                {
                    if (tRow.дата_с >= датаОтключения.Value)
                    {
                        Отк = false;
                        Прим = "";
                    }
                }

                if (Отк)
                {
                    tRow.отключен = true;
                    tRow.прим = Прим;
                }

            }


        }
        private void дни_простой()
        {
            foreach (простои uRow in de.простои
                .Where(n => n.клиент == клКлиент.клиент && n.услуга == клУслуга.услуга)
                .OrderBy(n => n.дата_с))
            {
                if (uRow.дата_по == null)
                {
                    for (DateTime dm = uRow.дата_с; dm < maxData; dm = dm.AddDays(1))
                    {
                        if (dicTemp2.ContainsKey(dm))
                        {
                            temp2 tRow = dicTemp2[dm];
                            tRow.простой = true;
                            tRow.прим = uRow.наимен;
                        }
                    }
                }
                else
                {
                    for (DateTime dm = uRow.дата_с; dm <= uRow.дата_по; dm = dm.AddDays(1))
                    {
                        if (dicTemp2.ContainsKey(dm))
                        {
                            temp2 tRow = dicTemp2[dm];
                            tRow.простой = true;
                            tRow.прим = uRow.наимен;
                        }
                    }
                }

            }
        }

        private void подробности_рабочие()
        {

            foreach (temp2 pRow in temp2List)
            {
                bool xy = false;
                if(pRow.договор || pRow.оплачен)
                {
                    xy = true;
                }

                if (pRow.льгота || pRow.отключен || pRow.простой)
                {
                    xy = false;
                }

              

                pRow.раб_день = xy;

            }
            //foreach (temp2 pRow in temp2List)
            //{
            //    bool xy = true;
            //    if (клКлиент.есть_договор)
            //    {
            //        if (pRow.льгота || pRow.отключен || pRow.простой || (pRow.договор == false && pRow.оплачен==false))
            //            xy = false;
            //    }
            //    else
            //    {
            //        if (pRow.льгота || pRow.отключен || pRow.простой)
            //            xy = false;
            //    }
            //    //                

            //    pRow.раб_день = xy;

            //}
        }
        private void заполнить_горизонталь()
        {
            foreach (temp vRow in tempList)
            {

                string текст = "";
                int рабДней = 0;
                foreach (temp2 pRow in temp2List
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
                        if (pRow.льгота)
                        {
                            xx = "Лг";
                        }
                        текст += xx;

                    }
                }
                vRow.подк_дней = рабДней;
                vRow.подробности = текст;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            клКлиент.deRow = de.клиенты.Single(n => n.клиент == клКлиент.клиент);
            все_события удаленныеОплаты = new все_события();
            удаленныеОплаты.Text = "Все события " + клКлиент.deRow.адрес + " " + клКлиент.deRow.фио;
            удаленныеОплаты.ShowDialog();

            Cursor = Cursors.Default;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
                
                temp uRow = bindingSource1.Current as temp;
                дни_месяца дниМесяца = new дни_месяца();
                List<temp2> листМесяц = temp2List
                    .Where(n => n.год == uRow.год)
                    .Where(n => n.месяц == uRow.месяц)
                    .ToList();
                дниМесяца.bindingSource1.DataSource = листМесяц;
                клКлиент.deRow = de.клиенты.Single(n => n.клиент == клКлиент.клиент);
                дниМесяца.Text = клКлиент.deRow.адрес + " " + клУслуга.deRow.наимен + " " + uRow.наимен_месяца;
                дниМесяца.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            foreach (System.Windows.Forms.DataGridViewCell cRow in dataGridView1.SelectedCells)
            {
                if (dataGridView1.Columns[cRow.ColumnIndex] == раб_днейColumn)
                {
                    cRow.Value = 0;
                }
            }
            Cursor = Cursors.Default;
        }

        void temp_Moving(temp tRow)
        {
            //   tRow.оплатить = (int)(tRow.цена * tRow.раб_дней / tRow.всего_дней);
            dataGridView1.Refresh();
            if (tRow.поле == "раб_дней")
            {
                Cursor = Cursors.WaitCursor;
                //  Console.WriteLine(tRow.месяц);
                // Медленно работает
                if (tRow.раб_дней <= tRow.всего_дней)
                {
                    раб_дней[] aRow = de.раб_дней
                        .Where(n => n.год == tRow.год)
                        .Where(n => n.месяц == tRow.месяц)
                        .Where(n => n.услуга == клУслуга.услуга)
                        .Where(n => n.клиент == клКлиент.клиент)
                        .ToArray();
                    foreach (раб_дней delRow in aRow)
                    {
                        de.раб_дней.Remove(delRow);
                    }
                    de.SaveChanges();

                    if (tRow.раб_дней < tRow.всего_дней)
                    {
                        раб_дней NewRow = new раб_дней();
                        NewRow.клиент = клКлиент.клиент;
                        NewRow.услуга = клУслуга.услуга;
                        NewRow.год = tRow.год;
                        NewRow.месяц = tRow.месяц;
                        NewRow.дней = tRow.раб_дней;
                        NewRow.прим = "";
                        de.раб_дней.Add(NewRow);
                        try
                        {
                            de.SaveChanges();
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("Сбой... Insert раб_дней"+ex.Message);
                        }
                    }

                        пересчет_долга();
                    Cursor = Cursors.Default;
                }
            }
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count>0)
            {
                Cursor = Cursors.WaitCursor;
                temp tRow = bindingSource1.Current as temp;
                tempList.FindAll(n => n.год * 100 + n.месяц < tRow.год * 100 + tRow.месяц).ForEach(n => n.раб_дней = 0);
                dataGridView1.Refresh();
                Cursor = Cursors.Default;
            }
        }
        void найти_начало()
        {
            начало = de.начало.First().дата;

            if (de.подключения.Where(n => n.услуга == клУслуга.услуга && n.клиент == клКлиент.клиент).Any())
            {
                DateTime dt = de.подключения.Where(n => n.услуга == клУслуга.услуга && n.клиент == клКлиент.клиент).Min(n => n.дата_с);
                if (dt > начало)
                {
                    начало = dt;
                }
            }
            if (de.оплачено.Where(n => n.услуга == клУслуга.услуга && n.оплаты.клиент == клКлиент.клиент).Any())
            {
                int g100m = de.оплачено.Where(n => n.услуга == клУслуга.услуга && n.оплаты.клиент == клКлиент.клиент).Min(n => n.год * 100 + n.месяц);
                int год = (int)g100m / 100;
                int месяц = g100m - год * 100;
                DateTime dt1 = new DateTime(год, месяц, 1);
                if (dt1 < начало)
                {
                    начало = dt1;
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
