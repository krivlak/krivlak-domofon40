
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
    public partial class оплаченые1месяца : Form
    {
        public оплаченые1месяца()
        {
            InitializeComponent();
        }
        DateTime начало;
        DateTime maxData;
        domofon40.domofon14Entities de = new domofon14Entities();
        List<temp> tempList = new List<temp>();
        List<temp2> temp2List = new List<temp2>();
        int позиция = 0;
        Dictionary<(int , int), temp> dicTemp = new Dictionary<(int , int), temp>();
        Dictionary<DateTime, temp2> dicTemp2 = new Dictionary<DateTime, temp2>();
        //    bool следить = false;

        //      Dictionary<ключ, temp> dicTemp1 = new Dictionary<ключ, temp>();
        //   int sДолг = 0;
        private void оплаченые1месяца_Load(object sender, EventArgs e)
        {

            //            temp.Moving -= temp_Moving;
            try
            {
                int махГод = de.годы.Max(n => n.год);
                maxData = new DateTime(махГод + 1, 1, 1);
          //      начало = de.начало.First().дата;

                найти_начало();
                наличие_договора();
                услуга_подключена();
                заполнить_дни();
                dicTemp2 = temp2List.ToDictionary(n => n.дата);
                без_договора();
                дни_договор();
              //  дни_оплачено();
                дни_отключено();
                дни_простой();
                дни_льгота();
                подробности_рабочие();
                /////////////////////////////////
                заполнить_месяца();
                dicTemp = tempList.ToDictionary(n => (n.год , n.месяц));
                //            dicTemp1 = tempList.ToDictionary(n => n.ключ1);
                заполнить_цену();
                //if(клУслуга.подключена)
                //{
                //    заполнить_всего_дней();
                //}

                заполнить_всего_дней();  //14 секунд   второй раз 
                заполнить_раб_дней();
                заполнить_оплачено();
                заполнить_возврат();
                пересчет_долга();
                заполнить_горизонталь();
                //            следить = true; 
                bindingSource1.DataSource = tempList;
                bindingSource1.Position = позиция;

                initRead();
                клСетка.задать_ширину(dataGridView1);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Сбой загрузки " + ex.Message);
            }

            //      примTextBox.DataBindings.Add("Text", bindingSource1, "прим");

            dataGridView1.CellMouseClick += dataGridView1_CellMouseClick;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            dataGridView1.EditingControlShowing += dataGridView1_EditingControlShowing;
            bindingSource1.ListChanged += bindingSource1_ListChanged;
            dataGridView1.DataError += dataGridView1_DataError;
            temp.Moving += temp_Moving;
            FormClosing += Оплаченые1месяца_FormClosing;
        }

        private void заполнить_возврат()
        {
            foreach (возврат uRow in de.возврат
                .Where(n => n.услуга == клУслуга.услуга)
                .Where(n => n.оплаты.клиент == клКлиент.клиент))
            {
               // int ключ = uRow.год * 100 + uRow.месяц;
                var ключ = (uRow.год , uRow.месяц);
                if (dicTemp.ContainsKey(ключ))
                {
                    temp tRow = dicTemp[ключ];
                    //    tRow.оплата = uRow.оплаты.оплата;
                    tRow.возврат = uRow.сумма;
                    tRow.оплата_возврат = uRow.оплата;
                    //tRow.номер_счета = uRow.оплаты.номер;
                    //tRow.дата_счета = uRow.оплаты.дата;
                    //if (uRow.цена > 0)
                    //{
                    //    tRow.цена = uRow.цена;
                    //    tRow.оплатить = (int)(tRow.цена * tRow.раб_дней / tRow.всего_дней);
                    //}
                }
            }
        }


        private void Оплаченые1месяца_FormClosing(object sender, FormClosingEventArgs e)
        {
            temp.Moving -= temp_Moving;
        }

        void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridViewColumn col = dataGridView1.Columns[e.ColumnIndex];
            if (col == оплаченоColumn || col == ценаColumn || col == раб_днейColumn)
            {
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
            }
            //if (col == примColumn)
            //{
            //    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
            //}
        }

        private void initRead()
        {
            foreach (System.Windows.Forms.DataGridViewRow uRow in dataGridView1.Rows)
            {
                Guid КодОплаты = (Guid)uRow.Cells["оплатаColumn"].Value;

                if ((КодОплаты == клОплата.оплата || КодОплаты == Guid.Empty))
                {
                    uRow.Cells["оплаченоColumn"].ReadOnly = false;

                }
                else
                {
                    uRow.Cells["оплаченоColumn"].ReadOnly = true;

                }
                //if (КодОплаты != клОплата.оплата || клОплата.оплата == "1234567890")
                //{
                //    uRow.Cells["dataGridViewTextBoxColumn4"].ReadOnly = true;
                //}
            }
        }


        void bindingSource1_ListChanged(object sender, ListChangedEventArgs e)
        {
            клОплата.выбран = true;
            label1.Visible = true;
        }

        void temp_Moving(temp tRow)
        {
            //   tRow.оплатить = (int)(tRow.цена * tRow.раб_дней / tRow.всего_дней);
            dataGridView1.Refresh();
            if (tRow.поле == "раб_дней")
            {
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
                        catch
                        {
                            MessageBox.Show("Сбой... Insert раб_дней");
                        }
                    }


                    //    пересчет_долга();
                }


            }
            // if (tRow.поле == "оплачено" || tRow.поле == "цена")
            if (tRow.поле == "оплачено")
            {
                if (tRow.оплата == клОплата.оплата || tRow.оплата == Guid.Empty)
                {


                    оплачено[] query = de.оплачено
                 .Where(n => n.оплата == клОплата.оплата
                 && n.услуга == клУслуга.услуга
                 && n.год == tRow.год
                 && n.месяц == tRow.месяц).ToArray();

                    foreach (оплачено delRow in query)
                    {
                        de.оплачено.Remove(delRow);
                    }
                    de.SaveChanges();

                    if (tRow.оплачено > 0)
                    {
                        оплачено NewRow = new оплачено();
                        NewRow.оплата = клОплата.оплата;
                        NewRow.услуга = клУслуга.услуга;
                        NewRow.сумма = tRow.оплачено;
                        NewRow.год = tRow.год;
                        NewRow.месяц = tRow.месяц;
                        NewRow.цена = tRow.цена;
                        NewRow.платеж = Guid.NewGuid();
                        de.оплачено.Add(NewRow);
                        de.SaveChanges();
                        tRow.оплата = клОплата.оплата;
                        клОплата.изменено = true;

                        tRow.дата_счета = клОплата.deRow.дата;
                        tRow.номер_счета = клОплата.deRow.номер;
                    }
                    else
                    {
                        tRow.оплата = Guid.Empty;
                        клОплата.изменено = true;
                        tRow.дата_счета = null;
                        tRow.номер_счета = 0;
                    }

                    //  tRow.оплатить =(int) (tRow.цена * tRow.раб_дней / tRow.всего_дней);
                    //if (tRow.год * 12 + tRow.месяц < DateTime.Today.Year * 12 + DateTime.Today.Month)
                    //{
                    //    sДолг -= tRow.долг;
                    //    tRow.долг = tRow.оплатить - tRow.оплачено;
                    //    sДолг += tRow.долг;
                    //}
                    //textBox1.Text = sДолг.ToString();

                    if (tRow.оплата == клОплата.оплата)
                    {
                        dataGridView1.CurrentRow.Cells["ценаColumn"].ReadOnly = false;
                    }
                    else
                    {
                        dataGridView1.CurrentRow.Cells["ценаColumn"].ReadOnly = true;
                    }

                }



            }



            if (tRow.поле == "цена")
            {
                if (клОплата.оплата == tRow.оплата && tRow.оплачено > 0)
                {
                    if (de.оплачено
                        .Where(n => n.оплата == клОплата.оплата)
                        .Where(n => n.услуга == клУслуга.услуга)
                        .Where(n => n.месяц == tRow.месяц)
                        .Any(n => n.год == tRow.год)
                        )
                    {
                        оплачено oRow = de.оплачено
                        .Where(n => n.оплата == клОплата.оплата)
                        .Where(n => n.услуга == клУслуга.услуга)
                        .Where(n => n.месяц == tRow.месяц)
                        .Single(n => n.год == tRow.год);

                        oRow.цена = tRow.цена;
                        de.SaveChanges();
                    }
                }

            }
            пересчет_долга();
        }

        void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Control_KeyPress);
            string CellName = dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].Name;

            if (CellName == "ценаColumn" || CellName == "оплаченоColumn" || CellName == "раб_днейColumn")
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

        void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] == оплаченоColumn
                || dataGridView1.Columns[e.ColumnIndex] == дата_счColumn
                || dataGridView1.Columns[e.ColumnIndex] == номер_счColumn)
            {
                Guid КодОплаты = (Guid)dataGridView1.Rows[e.RowIndex].Cells["оплатаColumn"].Value;
                if (КодОплаты == клОплата.оплата)
                {
                    e.CellStyle.BackColor = Color.FromArgb(200, 255, 200);
                }
            }

            if (dataGridView1.Columns[e.ColumnIndex] == возвратColumn)

            {
                Guid КодОплаты = (Guid)dataGridView1.Rows[e.RowIndex].Cells["оплата_возвратColumn"].Value;
                if (КодОплаты == клОплата.оплата)
                {
                    e.CellStyle.BackColor = Color.FromArgb(200, 255, 200);
                }
            }

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

                if ((клОплата.оплата != Guid.Empty) && (КодОплаты == клОплата.оплата) || (КодОплаты == Guid.Empty))
                {

                    if (dataGridView1.Columns[e.ColumnIndex] == оплаченоColumn)
                    {


                        uRow.оплачено = uRow.оплатить;
                        dataGridView1.Refresh();
                    }
                }

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
//                int ключ = uRow.год * 100 + uRow.месяц;
                var ключ = (uRow.год, uRow.месяц);
                if (dicTemp.ContainsKey(ключ))
                {
                    temp tRow = dicTemp[ключ];
                    tRow.оплата = uRow.оплаты.оплата;
                    tRow.оплачено = uRow.сумма;
                    tRow.номер_счета = uRow.оплаты.номер;
                    tRow.дата_счета = uRow.оплаты.дата;
                    if (uRow.цена > 0)
                    {
                        tRow.цена = uRow.цена;
                        //   tRow.оплатить = (int) (tRow.цена * tRow.раб_дней / tRow.всего_дней);
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
                  //  int ключ = uRow.год * 100 + uRow.месяц;
                    var ключ = (uRow.год, uRow.месяц);
                    if (dicTemp.ContainsKey(ключ))
                    {
                        temp tRow = dicTemp[ключ];

                        tRow.раб_дней = uRow.дней;
                        tRow.прим = uRow.прим;
                        //     tRow.оплатить =(int) (tRow.цена * tRow.раб_дней / tRow.всего_дней);
                        //        Console.WriteLine(uRow.дней);
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
                    //     vRow.оплатить =  (int)(vRow.цена * vRow.раб_дней / vRow.всего_дней);
                }
            }
        }
        //class ключ
        //{
        //    public int год { get; set; }
        //    public int месяц { get; set; }
        //}
        class temp
        {
            //       public ключ ключ1 { get; set; }
            public static bool следить { get; set; } = true; 
            public int год { get; set; }
            public int месяц { get; set; }
            public string наимен_месяца { get; set; }
            public int тариф { get; set; }
            public int возврат { get; set; }
            int Цена = 0;
            public int цена
            {
                get
                {
                    return Цена;
                }
                set
                {
                    Цена = value;
                    if (Moving != null)
                    {
                        поле = "цена";
                        Moving(this);
                    }
                }
            }

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
            //public int оплатить { get; set; }


            int Оплачено = 0;

            public int оплачено
            {
                get { return Оплачено; }
                set
                {
                    Оплачено = value;
                    if (Moving != null)
                    {
                        поле = "оплачено";
                        Moving(this);
                    }
                }

            }
            //        public int долг { get; set; }

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
                    if (Moving != null && следить)
                    {
                        поле = "раб_дней";
                        Moving(this);
                    }
                    //}
                }
            }

            public int подк_дней { get; set; }
            public string подробности { get; set; }
            string Примечание = "";
            public string прим
            {
                get { return Примечание; }
                set
                {
                    Примечание = value;
                    if (Moving != null)
                    {
                        поле = "прим";
                        Moving(this);
                    }
                }
            }
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
            public bool оплачен { get; set; } = false;
            public string прим { get; set; } = "";
        }

        private void заполнить_дни()
        {
            //  tempList.Clear();
            int текГод = DateTime.Today.Year;

            foreach (годы gg in de.годы.Where(n=>n.год>=начало.Year).Where(n=>n.год<=текГод+1).OrderBy(n => n.год))
            {
                foreach (var mm in de.месяцы.OrderBy(n => n.месяц))
                {
                    int длина = DateTime.DaysInMonth(gg.год, mm.месяц);
                    DateTime ddtt = new DateTime(gg.год, mm.месяц, длина);
                    if (ddtt >= начало)
                    {

                        for (int d = 1; d <= длина; d++)
                        {
                            //    DateTime dt = DateTime.Parse(d.ToString().Trim() + "." + mm.месяц1.ToString().Trim() + "." + gg.год1.ToString().Trim());
                            DateTime dt = new DateTime(gg.год, mm.месяц, d);
                            //                        dsТабель.подробностиRow NewRow = dsТабель1.подробности.NewподробностиRow();
                            //if (dt >= начало)
                            //{
                            temp2 NewRow = new temp2();
                            NewRow.дата = dt;
                            NewRow.год = gg.год;
                            NewRow.месяц = mm.месяц;
                            NewRow.день = d;
                            temp2List.Add(NewRow);
                            //}

                        }
                    }



                }
            }
        }

        private void заполнить_месяца()
        {

            //     tempList.Clear();
            int текГод = DateTime.Today.Year;
            int i = 0;
            foreach (var gg in de.годы.Where(n => n.год >= начало.Year).Where(n=>n.год<=текГод+1).OrderBy(n => n.год))
            {
                foreach (var mm in de.месяцы.OrderBy(n => n.месяц))
                {
                    //    DateTime dt = DateTime.Parse("01." + mm.месяц1.ToString().Trim() + "." + gg.год1.ToString().Trim());

                    //                    dsТабель.вертикальRow NewRow = dsТабель1.вертикаль.NewвертикальRow();
                    int длина = DateTime.DaysInMonth(gg.год, mm.месяц);
                    DateTime dm = new DateTime(gg.год, mm.месяц, длина);
                    if (dm >= начало)
                    {
                        temp NewRow = new temp();
                        //ключ ключ0 = new ключ();
                        //ключ0.год = gg.год;
                        //ключ0.месяц = mm.месяц;

                        //NewRow.ключ1 = ключ0;
                        NewRow.год = gg.год;
                        NewRow.месяц = mm.месяц;
                        NewRow.наимен_месяца = mm.наимен;
                        NewRow.всего_дней = DateTime.DaysInMonth(gg.год, mm.месяц);
                        //         NewRow.раб_дней = NewRow.всего_дней;
                        NewRow.оплата = Guid.Empty;
                        tempList.Add(NewRow);
                    }


                    i++;
                    if (gg.год == DateTime.Today.Year && mm.месяц == DateTime.Today.Month)
                    {
                        позиция = i;
                    }


                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void заполнить_цену()
        {
            foreach (цены uRow in de.цены.Where(n => n.услуга == клУслуга.услуга))
            {

                //ключ ключ0 = new ключ();
                //ключ0.год = uRow.год;
                //ключ0.месяц = uRow.месяц;

                //if (dicTemp1.ContainsKey(ключ0))
                //{
                //    dicTemp1[ключ0].цена = uRow.стоимость;
                //    dicTemp1[ключ0].тариф = uRow.стоимость;
                //}
                //     Console.WriteLine(uRow.стоимость);
                var ключ = (uRow.год, uRow.месяц);
                if (dicTemp.ContainsKey(ключ))
                {
                    dicTemp[ключ].цена = uRow.стоимость;
                    dicTemp[ключ].тариф = uRow.стоимость;
                    //         Console.Write(uRow.стоимость);
                }

            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //foreach (System.Windows.Forms.DataGridViewCell cRow in dataGridView1.SelectedCells)
            //{
            //    if (dataGridView1.Columns[cRow.ColumnIndex] == раб_днейColumn)
            //    {
            //        dataGridView1.CurrentCell = cRow;
            //        temp uRow = bindingSource1.Current as temp;
            //        uRow.раб_дней = uRow.всего_дней;
            //    }
            //}
            temp.следить = false;
            StringBuilder sb = new StringBuilder();
            string текст = "";
            foreach (System.Windows.Forms.DataGridViewCell cRow in dataGridView1.SelectedCells)
            {
                if (dataGridView1.Columns[cRow.ColumnIndex] == раб_днейColumn)
                {
                    //dataGridView1.CurrentCell = cRow;
                    //temp uRow = bindingSource1.Current as temp;
                    //uRow.раб_дней = uRow.всего_дней;

                    клОплата.выбран = true;
                     

                    int Год = (int)dataGridView1.Rows[cRow.RowIndex].Cells["годColumn"].Value;
                    int Месяц = (int)dataGridView1.Rows[cRow.RowIndex].Cells["номер_месяцаColumn"].Value;
                    int Всего_Дней = (int)dataGridView1.Rows[cRow.RowIndex].Cells["всего_днейColumn"].Value;
                    cRow.Value = Всего_Дней;
                    try
                    {
                        текст = $"delete from раб_дней where год = {Год} and месяц = {Месяц}   and услуга =  '{клУслуга.услуга}'  and клиент = '{клКлиент.клиент}' ;";

                        sb.AppendLine(текст);


                        // de.Database.ExecuteSqlCommand("delete from раб_дней where год = @p0 and месяц =  @p1  and услуга =  @p2  and клиент = @p3 ", Год, Месяц, клУслуга.услуга, клКлиент.клиент);

                        //if (Всего_Дней > 0)
                        //{
                        //    de.Database.ExecuteSqlCommand("insert into раб_дней (год,месяц,услуга,клиент,дней,прим) values( @p0 ,  @p1  ,  @p2  , @p3,  @p4  , @p5) ", Год, Месяц, клУслуга.услуга, клКлиент.клиент, 0, "");
                        //}

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка записи " + ex.Message);
                    }
                }

            }
            //  MessageBox.Show(sb.ToString());
            try
            {
                de.Database.ExecuteSqlCommand(sb.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка записи " + ex.Message);
            }
            temp.следить = true;
            пересчет_долга();
            dataGridView1.Refresh();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            temp.следить = false;
            StringBuilder sb = new StringBuilder();
            string текст = "";
            foreach (System.Windows.Forms.DataGridViewCell cRow in dataGridView1.SelectedCells)
            {
                if (dataGridView1.Columns[cRow.ColumnIndex] == раб_днейColumn)
                {

                    cRow.Value = 0;
                    //    клОплата.выбран = true;
                    int Год = (int)dataGridView1.Rows[cRow.RowIndex].Cells["годColumn"].Value;
                    int Месяц = (int)dataGridView1.Rows[cRow.RowIndex].Cells["номер_месяцаColumn"].Value;
                    int Всего_Дней = (int)dataGridView1.Rows[cRow.RowIndex].Cells["всего_днейColumn"].Value;
                    try
                    {
                        текст = $"delete from раб_дней where год = {Год} and месяц = {Месяц}   and услуга =  '{клУслуга.услуга}'  and клиент = '{клКлиент.клиент}' ;";

                        sb.AppendLine(текст);
                        //  de.Database.ExecuteSqlCommand("delete from раб_дней where год = @p0 and месяц =  @p1  and услуга =  @p2  and клиент = @p3 ", Год, Месяц, клУслуга.услуга, клКлиент.клиент);


                        текст = $"insert into раб_дней (год,месяц,услуга,клиент,дней,прим) values( {Год} ,  {Месяц}  ,  '{клУслуга.услуга}'  , '{клКлиент.клиент}',  0  , '') ;";
                        sb.AppendLine(текст);
                        //   de.Database.ExecuteSqlCommand("insert into раб_дней (год,месяц,услуга,клиент,дней,прим) values( @p0 ,  @p1  ,  @p2  , @p3,  @p4  , @p5) ", Год, Месяц, клУслуга.услуга, клКлиент.клиент, 0, "");


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка записи " + ex.Message);
                    }

                }
            }
           //   MessageBox.Show(sb.ToString());
            try
            {
               de.Database.ExecuteSqlCommand(sb.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка записи " + ex.Message);
            }
            temp.следить = true;
            пересчет_долга();
            dataGridView1.Refresh();


            // Медленно работает
            //Cursor = Cursors.WaitCursor;
            //foreach (System.Windows.Forms.DataGridViewCell cRow in dataGridView1.SelectedCells)
            //{
            //    if (dataGridView1.Columns[cRow.ColumnIndex] == раб_днейColumn)
            //    {
            //        cRow.Value = 0;
            //    }
            //}
            //Cursor = Cursors.Default;
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

        private void button3_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            //клиенты uRow = bindingSource1.Current as клиенты;
            //клКлиент.deRow = uRow;
            //клКлиент.клиент = uRow.клиент;
            клКлиент.deRow = de.клиенты.Single(n => n.клиент == клКлиент.клиент);
            все_события удаленныеОплаты = new все_события();
            удаленныеОплаты.Text = "Все события " + клКлиент.deRow.адрес + " " + клКлиент.deRow.фио;
            удаленныеОплаты.ShowDialog();

            Cursor = Cursors.Default;
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

                            tRow.номер_дог = НаименДоговора;
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
                            tRow.номер_дог = НаименДоговора;
                            tRow.дата_с = uRow.дата_с;
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
        //   if (pRow.льгота  || pRow.отключен || pRow.простой || pRow.договор == false)
        private void подробности_рабочие()
        {
            foreach (temp2 pRow in temp2List)
            {
                bool xy = true;
                if (клКлиент.есть_договор)
                {
                    // если платили без     договора
                    if (pRow.льгота || pRow.отключен || pRow.простой || (pRow.договор == false && pRow.оплачен == false))
                    {
                        xy = false;
                    }
                }
                else
                {
                    if (pRow.льгота || pRow.отключен || pRow.простой)
                        xy = false;
                }
                //                

                pRow.раб_день = xy;

            }
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
                        DateTime minD = new DateTime(minG, minM, 1).AddMonths(-1); // Зачем сдвигать на месяц ?
                        
                            foreach (temp2 tRow in temp2List.Where(n => n.дата < подключен && n.дата >= minD))
                            {
                                tRow.оплачен = true;
                            }
                       
                    }

                    // присваивается оплачен с начала оплаты
                  
                }
            }

            // заменена на функцию ==Без_договора
        }

        void найти_начало()
        {
            начало = de.начало.First().дата;
            bool есть_оплаты = false;

            if (de.оплачено.Where(n => n.услуга == клУслуга.услуга && n.оплаты.клиент == клКлиент.клиент).Any())
            {
                int g100m = de.оплачено.Where(n => n.услуга == клУслуга.услуга && n.оплаты.клиент == клКлиент.клиент).Min(n => n.год * 100 + n.месяц);
                int год = (int)g100m / 100;
                int месяц = g100m - год * 100;
                DateTime dt1 = new DateTime(год, месяц, 1);
                есть_оплаты = true;
                if (dt1 > начало )
                {
                    начало = dt1;
                }

            }

            if (de.подключения.Where(n => n.услуга == клУслуга.услуга && n.клиент == клКлиент.клиент).Any())
            {
                DateTime dt = de.подключения.Where(n => n.услуга == клУслуга.услуга && n.клиент == клКлиент.клиент).Min(n => n.дата_с);
                if (dt <= начало || (dt.Year * 100 + dt.Month == начало.Year * 100 + начало.Month) || !есть_оплаты)
                {
                    начало = dt;
                }
            }
          
        }

        void без_договора()
        {
            if (de.подключения.Any(n => n.клиент == клКлиент.клиент && n.услуга == клУслуга.услуга))
            {
                DateTime minDog = de.подключения
                .Where(n => n.клиент == клКлиент.клиент && n.услуга == клУслуга.услуга)
                .Min(n => n.дата_с);
                if (начало < minDog && (начало.Year * 100 + начало.Month < minDog.Year * 100 + minDog.Month))
                {
                    for (DateTime dm = начало; dm < minDog; dm = dm.AddDays(1))
                    {

                        if (dicTemp2.ContainsKey(dm))
                        {
                            temp2 tRow = dicTemp2[dm];

                            tRow.номер_дог = "без договора";
                            tRow.дата_с = начало;
                            tRow.договор = true;
                            tRow.оплачен = true;
                        }
                    }
                }
            }
            else
            {
                for (DateTime dm = начало; dm < maxData; dm = dm.AddDays(1))
                {

                    if (dicTemp2.ContainsKey(dm))
                    {
                        temp2 tRow = dicTemp2[dm];

                        tRow.номер_дог = "без договора";
                        tRow.дата_с = начало;
                        tRow.договор = true;
                        tRow.оплачен = true;

                    }
                }
            }
        }
    }
}
