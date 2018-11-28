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
    public partial class оплата_подъезда : Form
    {
        public оплата_подъезда()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        List<temp> tempList = new List<temp>();
        List<temp2> temp2List = new List<temp2>();
        List<temp3> temp3List = new List<temp3>();
        int[] аТариф = new int[13];
        Dictionary<Guid, temp> tempDict = new Dictionary<Guid, temp>();

     //   DataGridViewColumn[] аCol =  { M1Column, M2Column, M3Column, M4Column, M5Column, M6Column, M7Column, M8Column, M9Column, M10Column, M11Column, М12Column };
        string[] аCol = { "M1Column", "M2Column", "M3Column", "M4Column", "M5Column", "M6Column", "M7Column", "M8Column", "M9Column", "M10Column", "M11Column", "M12Column" };

        private void оплата_подъезда_Load(object sender, EventArgs e)
        {
            try
            {
                comboBox1.DataSource = de.виды_оплат.OrderBy(n => n.порядок).ToList();
                заполнить_начислено();
                присвоить_tag();
                обновить_дом();
                initRead();
                клСетка.задать_ширину(dataGridView1);
                имяTextBox.DataBindings.Add("Text", bindingSource1, "имя");
                отчествоTextBox.DataBindings.Add("Text", bindingSource1, "отчество");
                телефонTextBox.DataBindings.Add("Text", bindingSource1, "телефон");
                прим0TextBox.DataBindings.Add("Text", bindingSource1, "прим0");
                dataGridView1.Focus();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Сбой загрузки " + ex.Message);
            }

            dataGridView1.CellMouseClick += DataGridView1_CellMouseClick;
            temp.Moving += Temp_Moving;
            FormClosed += Оплата_подъезда_FormClosed;
            dataGridView1.EditingControlShowing += DataGridView1_EditingControlShowing;
            dataGridView1.DataError += DataGridView1_DataError;
            dataGridView1.CellValidating += DataGridView1_CellValidating;
        }

        private void DataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string CellName = dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].Name;

            if (аCol.Contains(CellName))
            {
               if(e.FormattedValue==null || e.FormattedValue.ToString()=="")
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                }
            }
        }

        private void DataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Ошибка ввода");
        }

        private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            string CellName = dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].Name;

            e.Control.KeyPress -= new KeyPressEventHandler(Control_KeyPress);

            if (аCol.Contains(CellName))
            {
                e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
            }

        }

        void Control_KeyPress(object sender, KeyPressEventArgs pressE)
        {
            //            клKey.decimal_KeyPress(sender, pressE);
            клKey.int_KeyPress(sender, pressE);

        }

        private void Оплата_подъезда_FormClosed(object sender, FormClosedEventArgs e)
        {
            temp.Moving -= Temp_Moving;
        }

        private void Temp_Moving(temp obj)
        {
            foreach(temp3 delTemp in temp3List)
            {
                if (delTemp.месяц == obj.месяц && delTemp.клиент == obj.клиент)
                    temp3List.Remove(delTemp);

            }
            int сумма = obj.GetField(obj.месяц);
            if (сумма>0)
            {
                temp3 newTemp = new temp3()
                {
                     клиент= obj.клиент,
                      месяц=obj.месяц,
                       оплачено=сумма 
                };
                temp3List.Add(newTemp);

            }

            int заВсех = 0;
            if(temp3List.Any())
            {
                заВсех = temp3List.Sum(n => n.оплачено);
            }
            textBox1.Text = заВсех.ToString();
            //if (temp3List.Where(n=>n.клиент==obj.клиент).Any(n=>n.месяц==obj.месяц))
            //{
            //    temp3 delTemp = temp3List.Where(n => n.клиент == obj.клиент).First(n => n.месяц == obj.месяц);
            //    temp3List.Remove(delTemp);
            //}
        }

        private void DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ////  как отменить случайный счелчек?
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {


                int? номерМесяца = dataGridView1.Columns[e.ColumnIndex].Tag as int?;
                if (номерМесяца != null)
                {
                    dataGridView1.CurrentCell =
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

                    bool другаяОплата = (bool)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag;
                    if (!другаяОплата)
                    {

                        temp uRow = bindingSource1.Current as temp;
                     //   string поле = "M" + номерМесяца.Value.ToString();

//                        uRow.SetField<int>(поле, аТариф[номерМесяца.Value - 1]);
                        uRow.SetFild(номерМесяца.Value, аТариф[номерМесяца.Value - 1]);
                        //  dataGridView1.CurrentCell.Style.ForeColor = Color.Red;

                    }
                }

            }

        }

        private void initRead()
        {
            foreach (DataGridViewRow uRow in dataGridView1.Rows)
            {
                foreach (DataGridViewCell uCell in uRow.Cells)
                {

                    //if (аCol.Contains(dataGridView1.Columns[uCell.ColumnIndex].Name))
                    if (аCol.Contains(uCell.OwningColumn.Name))
                    {
                        if ((int)uCell.Value > 0)
                        {
                           
                            uCell.Tag = true;

                            uCell.ReadOnly = true;
                        }
                        else
                        {
                            uCell.Style.ForeColor = Color.Red;
                            uCell.Style.BackColor = Color.LightGreen;
                            uCell.Tag = false;
                            uCell.ReadOnly = false;
                    //        Console.WriteLine(uCell.OwningColumn.Name);
                        }
                    }
                }
            }
        }

        class temp
        {
           public temp()
            {
                aM = new int[13];
            }
            public int год { set; get; }
            public int месяц { set; get; }
            public int M1
            {
                get { return aM[1]; }
                set { aM[1] = value; }
            }
            public int M2
            {
                get { return aM[2]; }
                set { aM[2] = value; }
            }
            public int M3
            {
                get { return aM[3]; }
                set { aM[3] = value; }
            }
            public int M4
            {
                get { return aM[4]; }
                set { aM[4] = value; }
            }
            public int M5
            {
                get { return aM[5]; }
                set { aM[5] = value; }
            }
            public int M6
            {
                get { return aM[6]; }
                set { aM[6] = value; }
            }
            public int M7
            {
                get { return aM[7]; }
                set { aM[7] = value; }
            }
            public int M8
            {
                get { return aM[8]; }
                set { aM[8] = value; }
            }
            public int M9
            {
                get { return aM[9]; }
                set { aM[9] = value; }
            }
            public int M10
            {
                get { return aM[10]; }
                set { aM[10] = value; }
            }
            public int M11
            {
                get { return aM[11]; }
                set { aM[11] = value; }
            }
            public int M12
            {
                get { return aM[12]; }
                set {  aM[12] = value; }
            }
           
            int[] aM;
          
            public Guid услуга { set; get; }
            public string наимен_услуги { set; get; }
            public Guid клиент { set; get; }
            public string фио { set; get; }
            public string Имя { set; get; }
            public string Отчество { set; get; }
            public int подъезд { set; get; }
            public int квартира { set; get; }
            public int ввод { set; get; }
            public bool цвет { set; get; }
            public string прим { set; get; }
            public int мГод { set; get; }
            public int мМесяц { set; get; }
            public Guid дом { set; get; }
            public DateTime? подключен { set; get; }
            public DateTime? отключен { set; get; }
            public DateTime? повтор { set; get; }
            public string прим0 { set; get; }
            public string телефон { set; get; }
            public int долг_мес { set; get; }

            public bool должник { set; get; }
            public bool льгота { set; get; } = false;

            public void SetFild(int месяц0, int сумма)
            {
                aM[месяц0] = сумма;
                if (Moving != null)
                {
                    месяц = месяц0;
                    Moving(this);
                }
            }

            public int GetField(int месяц)
            {
                return aM[месяц];
            }

            public static event Action<temp> Moving;

        }

        class temp2
        {
            public temp2()
            {
                aM = new int[13];
            }
            public int год
            {
                get { return aM[0]; }
                set { aM[0] = value; }
            }

            public int M1
            {
                get { return aM[1]; }
                set { aM[1] = value; }
            }
            public int M2
            {
                get { return aM[2]; }
                set { aM[2] = value; }
            }
            public int M3
            {
                get { return aM[3]; }
                set { aM[3] = value; }
            }
            public int M4
            {
                get { return aM[4]; }
                set { aM[4] = value; }
            }
            public int M5
            {
                get { return aM[5]; }
                set { aM[5] = value; }
            }
            public int M6
            {
                get { return aM[6]; }
                set { aM[6] = value; }
            }
            public int M7
            {
                get { return aM[7]; }
                set { aM[7] = value; }
            }
            public int M8
            {
                get { return aM[8]; }
                set { aM[8] = value; }
            }
            public int M9
            {
                get { return aM[9]; }
                set { aM[9] = value; }
            }
            public int M10
            {
                get { return aM[10]; }
                set { aM[10] = value; }
            }
            public int M11
            {
                get { return aM[11]; }
                set { aM[11] = value; }
            }
            public int M12
            {
                get { return aM[12]; }
                set { aM[12] = value; }
            }

            int[] aM;

            public void SetFild(int месяц, int сумма)
            {
                aM[месяц] = сумма;
            }

            public int GetField(int месяц)
            {
                return aM[месяц];
            }

        }

        class temp3
        {
            public Guid клиент { get; set; }
            public int месяц { get; set; }
            public int оплачено { get; set; }
        }
   
        void заполнить_начислено()
        {
       
            temp2 newTemp2 = new temp2();
           newTemp2.год = клМесяц.год;
            foreach(цены uRow in de.цены
                .Where(n=>n.год==клМесяц.год)
                .Where(n=>n.услуга==клУслуга.услуга))
            {
                аТариф[uRow.месяц - 1] = (int)uRow.стоимость;
                newTemp2.SetFild(uRow.месяц, uRow.стоимость);
            }
            temp2List.Add(newTemp2);
            bindingSource2.DataSource = temp2List;
        }
        private void присвоить_tag()
        {
            for (int i = 1; i < 13; i++)
            {
                string поле = "M" + i.ToString().Trim() + "Column";
                dataGridView1.Columns[поле].Tag = i;

            }
        }

        private void обновить_дом()
        {

     //       bool yy = false;

            foreach (var uRow in de.клиенты
                .Where(n => n.дом == клДом.дом)
                .Where(n => n.подъезд == клПодъезд.подъезд)
                .OrderBy(n => n.квартира)
                .ThenBy(n => n.ввод))
            {

                //  int i = 0;

                temp NewRow = new temp();


                NewRow.подъезд = uRow.подъезд;
                NewRow.квартира = uRow.квартира;
                NewRow.ввод = uRow.ввод;
                NewRow.клиент = uRow.клиент;
                NewRow.фио = uRow.фио;
                NewRow.Имя = uRow.имя;
                NewRow.Отчество = uRow.отчество;
                NewRow.телефон = uRow.телефон;
                NewRow.прим0 = uRow.прим;



                var qПрим = uRow.примечания.Where(n => n.услуга == клУслуга.услуга);
                if (qПрим.Any())
                {
                    примечания pRow = qПрим.First();
                    NewRow.прим += pRow.прим.Trim();
                }

                var qДог = uRow.подключения.Where(n => n.услуга == клУслуга.услуга);

                if (qДог.Any())
                {
                    DateTime maxData = qДог.Max(p => p.дата_с);
                    NewRow.подключен = maxData;
                }

                var qОткл = uRow.отключения.Where(n => n.услуга == клУслуга.услуга);

                if (qОткл.Any())
                {
                    DateTime maxData = qОткл.Max(p => p.дата_с);
                    NewRow.отключен= maxData;
                }

                var qЛьгота = uRow.льготы.Where(n => n.услуга == клУслуга.услуга);

                if (qЛьгота.Any())
                {
                    //      DateTime maxData = qЛьгота.Max(p => p.дата_с);
                    //  NewRow.прим += " Льгота " + maxData.ToShortDateString();
                    NewRow.льгота = true;
                }

                var qПовт = uRow.повторы.Where(n => n.услуга == клУслуга.услуга);

                if (qПовт.Any())
                {
                    DateTime maxData = qПовт.Max(p => p.дата_с);
                    NewRow.повтор= maxData;
                }



                tempList.Add(NewRow);
            }

            tempDict = tempList.ToDictionary(n => n.клиент);



            ///////////////////////
            //var абоненты = dsПодъезд1.абоненты1дома.ToDictionary(n => n.клиент);
            //DsПодъезд.абоненты1домаRow tRow;

           


            var queryMax = de.оплачено
                 .Where(n => n.услуга == клУслуга.услуга)
                .Where(n => n.оплаты.клиенты.дом == клДом.дом)
                 .Where(n => n.оплаты.клиенты.подъезд == клПодъезд.подъезд)
                .GroupBy(n => n.оплаты.клиент)
                .Select(n => new
                {
                    клиент = n.Key,
                    maxGM = n.Max(m => m.год * 100 + m.месяц)
                });


            foreach (var yRow in queryMax)
            {
                var ключ = yRow.клиент;

                if (tempDict.ContainsKey(ключ))
                {
                    tempDict[ключ].мГод = (int)(yRow.maxGM / 100);
                    tempDict[ключ].мМесяц = yRow.maxGM - tempDict[ключ].мГод * 100;
                }
            }

            // заполнение оплачено при помощи вспомогательного поля aM в temp
            foreach (оплачено oRow in de.оплачено
                .Where(n => n.услуга == клУслуга.услуга)
               .Where(n => n.год == клМесяц.год)
               .Where(n => n.оплаты.клиенты.дом == клДом.дом)
               .Where(n => n.оплаты.клиенты.подъезд == клПодъезд.подъезд))
            {
                var ключ = oRow.оплаты.клиент;

                if (tempDict.ContainsKey(ключ))
                {
                    temp tRow = tempDict[ключ];
                    tRow.SetFild(oRow.месяц, oRow.сумма);
                  
                }
            }

            bindingSource1.DataSource = tempList;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            виды_оплат vRow = comboBox1.SelectedItem as виды_оплат;
            Guid кодВидаОплаты = vRow.вид_оплаты;

            var клиентыЛист = temp3List
                .Where(n=>n.оплачено>0)
                .GroupBy(n => n.клиент)
                .Select(n=>n.Key).ToList();

            foreach(temp3 tRow in temp3List)
            {
                foreach(оплачено delRow in de.оплачено
                    .Where(n=>n.год==клМесяц.год)
                    .Where(n=>n.месяц==tRow.месяц)
                    .Where(n=>n.услуга==клУслуга.услуга)
                    .Where(n=>n.оплаты.клиент==tRow.клиент))
                {
                    de.оплачено.Remove(delRow);
                }
                de.SaveChanges();

            }
            int maxNum = 0;
            if (de.оплаты.Any())
            {
                maxNum = de.оплаты.Max(n => n.номер);
            }

            foreach(Guid kRow in клиентыЛист)
            {
                maxNum++;
                оплаты newOp = new оплаты()
                {
                    дата = клКалендарь.дата.Value,
                    клиент = kRow,
                    номер = maxNum,
                    оплата = Guid.NewGuid(),
                    сотрудник = клСотрудник.сотрудник,
                    вид_оплаты = кодВидаОплаты
                };

                de.оплаты.Add(newOp);
                foreach (temp3 tRow in temp3List.Where(n=>n.клиент==kRow))
                {
                    if(tRow.оплачено>0)
                    {
                        оплачено newMez = new оплачено()
                        {
                            год = клМесяц.год,
                            оплата = newOp.оплата,
                            месяц = tRow.месяц,
                            сумма = tRow.оплачено,
                            услуга = клУслуга.услуга
                        };
                        de.оплачено.Add(newMez);
                    }
                }
            }
            try
            {
                de.SaveChanges();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка записи " + ex.Message);
            }
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count>0)
            {
                temp tRow = bindingSource1.Current as temp;
                клКлиент.клиент = tRow.клиент;
                клКлиент.deRow = de.клиенты.Single(n => n.клиент == клКлиент.клиент);
                оплаченные1просмотр оплПросмотр = new оплаченные1просмотр();
                оплПросмотр.Text = $"Оплаты {клКлиент.фио}  {клКлиент.адрес}  ";
                оплПросмотр.ShowDialog();
                dataGridView1.Focus();
            }
        }
    }
}
