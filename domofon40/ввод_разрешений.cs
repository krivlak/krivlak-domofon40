using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Word = Microsoft.Office.Interop.Word;

// уберем listTemp0;

namespace domofon40
{
    public partial class ввод_разрешений : Form
    {
        public ввод_разрешений()
        {
            InitializeComponent();
        }

     //   List<temp> listTemp0 = new List<temp>();
        List<temp> listTemp = new List<temp>();
        List<комбо> listКомбо = new List<комбо>();

        domofon14Entities de = new domofon14Entities();
       // Dictionary<Guid, temp> dic0;
        RegexUtilities ru = new RegexUtilities();
        private void ввод_разрешений_Load(object sender, EventArgs e)
        {
          //  DateTime dt =new DateTime.CurrentDateTime();
            string sqlComanda = "список_разрешений";

          //  object[] параметры = new object[1];
            //.object.параметры[0] ="@услуга= клУслуга.услуга;
            listTemp = de.Database.SqlQuery<temp>(sqlComanda).ToList();
            //var ee = de.Database.SqlQuery<temp>(sqlComanda);

            ////MessageBox.Show(ee.Count().ToString());
            //foreach (temp tRow in ee)
            //{
            //    listTemp0.Add(tRow);
            //}
//            dic0 = listTemp0.ToDictionary(n => n.разрешение);
            //      MessageBox.Show(listTemp.Count.ToString());
//            listTemp = listTemp0.OrderBy(n => n.дата_с).ToList();
            bindingSource1.DataSource = listTemp;
            bindingSource1.MoveLast();
            заполнить_комбо();
            comboBox1.SelectedValueChanged += comboBox1_SelectedValueChanged;
        }

        void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            int строка = (int)comboBox1.SelectedValue;
            switch (строка)
            {
                case 1:
                    listTemp.Sort((a, b) => a.дата_с.CompareTo(b.дата_с));
//                    listTemp = listTemp0.OrderBy(n => n.дата_с).ToList();
                    break;
                case 2:
  //                  listTemp = listTemp0.OrderBy(n => n.фио).ToList();
                    listTemp.Sort((a, b) => a.фио.CompareTo(b.фио));  
                    break;
                //case 3:
                      
                //поселкиЛист.Sort((a, b) => a.порядок.CompareTo(b.порядок));
                    //listTemp = listTemp0
                    //    .OrderBy(n => n.наимен_улицы)
                    //    .ThenBy(n => n.номер_дома)
                    //    .ThenBy(n => n.корпус)
                    //    .ThenBy(n => n.квартира)
                    //    .ThenBy(n => n.ввод)
                    //    .ToList();


                    //break;
                case 4:
    //                listTemp = listTemp0.OrderBy(n => n.номер).ToList();
                    listTemp.Sort((a, b) => a.номер.CompareTo(b.номер));
                    break;
            }
        //    bindingSource1.DataSource = listTemp;
            dataGridView1.Refresh();
        }


        partial class temp
        {
            public System.Guid разрешение { get; set; }
            public Guid клиент { get; set; }
            public System.DateTime дата_с { get; set; }
            public int номер { get; set; }
            public Nullable<System.DateTime> дата_по { get; set; }
            public string телефон { get; set; }
            public string эл_почта { get; set; }

            //            public string адрес { get; set; }
            public string фио { get; set; }
            public string наимен_улицы { get; set; }
            public int номер_дома { get; set; }
            public string корпус { get; set; }
            public int квартира { get; set; }
            public int ввод { get; set; }

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
            //комбо нК3 = new комбо();
            //нК3.позиция = 3;
            //нК3.наим = "по адресу";
            //listКомбо.Add(нК3);

            комбо нК4 = new комбо();
            нК4.позиция = 4;
            нК4.наим = "по номеру";
            listКомбо.Add(нК4);

            comboBox1.DataSource = listКомбо;
            comboBox1.DisplayMember = "наим";
            comboBox1.ValueMember = "позиция";
            comboBox1.SelectedValue = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            клКлиент.выбран = false;
            выбор_клиента ВыборКлиента = new выбор_клиента();
            ВыборКлиента.ShowDialog();
            if (клКлиент.выбран)
            {
                Guid[] кодыКлиентов = de.разрешения
                    .Select(n => n.клиент).ToArray();

                if (кодыКлиентов.Contains(клКлиент.клиент))
                {
                    MessageBox.Show(клКлиент.deRow.фио + " уже есть разрешение");
                    int строка = listTemp.FindIndex(n => n.клиент == клКлиент.клиент);
                    if (строка > -1)
                    {
                        bindingSource1.Position = строка;
                    }
                    Cursor = Cursors.Default;
                    return;
                }

                int махНомер = 0;
                if (de.разрешения.Any())
                {
                    махНомер = de.разрешения.Max(n => n.номер);
                }

                клРазрешение.клиент = клКлиент.клиент;
                клРазрешение.разрешение = Guid.NewGuid();
                //клРазрешение.телефон = "9505564673";
                //клРазрешение.эл_почта = "dma@intess.ru";
                клРазрешение.все_телефоны = клКлиент.deRow.телефон;

                клРазрешение.телефон = "";
                клРазрешение.эл_почта = "";
                найти_сотовый();
                найти_почту();
                клРазрешение.дата_с = DateTime.Now;
                клРазрешение.дата_по = null;



                клРазрешение.выбран = false;
                сотовый_мыло вводСотового = new сотовый_мыло();
                вводСотового.Text = "Разрешение на отправку смс от " + клКлиент.deRow.фио;

                вводСотового.ShowDialog();
                if (клРазрешение.выбран)
                {

                    разрешения NewRow = new разрешения();
                    NewRow.разрешение = клРазрешение.разрешение;
                    NewRow.клиент = клРазрешение.клиент;
                    NewRow.номер = махНомер + 1;
                    NewRow.дата_с = клРазрешение.дата_с;
                    NewRow.дата_по = клРазрешение.дата_по;
                    NewRow.телефон = клРазрешение.телефон;
                    NewRow.эл_почта = клРазрешение.эл_почта;
                    de.разрешения.Add(NewRow);
                    try
                    {
                        de.SaveChanges();
                        temp nRow = new temp();
                        nRow.разрешение = клРазрешение.разрешение;
                        nRow.клиент = клРазрешение.клиент;
                        nRow.номер = махНомер + 1;
                        nRow.дата_с = клРазрешение.дата_с;
                        nRow.дата_по = клРазрешение.дата_по;
                        nRow.телефон = клРазрешение.телефон;
                        nRow.эл_почта = клРазрешение.эл_почта;
                        nRow.ввод = клКлиент.deRow.ввод;
                        nRow.квартира = клКлиент.deRow.квартира;
                        nRow.корпус = клКлиент.deRow.дома.корпус;
                        nRow.наимен_улицы = клКлиент.deRow.дома.улицы.наимен;
                        nRow.номер_дома = клКлиент.deRow.дома.номер;
                        nRow.фио = клКлиент.deRow.фио;
      //                  listTemp0.Add(nRow);
        //                listTemp = listTemp0.OrderBy(n => n.дата_с).ToList();
       //                 bindingSource1.DataSource = listTemp;
       //                 int строка = listTemp.FindIndex(n => n.разрешение == клРазрешение.разрешение);
                        int строка = bindingSource1.Add(nRow);
                        if (строка > -1)
                        {
                            bindingSource1.Position = строка;
                        }

                    }
                    catch
                    {
                        MessageBox.Show("Ошибка записи...");
                    }
                }
                Cursor = Cursors.Default;

            }

        }

        private void найти_сотовый()
        {
            string pattern = @"\b\d{10}\b";
            клРазрешение.телефон = "";
            string строка_телефон = клРазрешение.все_телефоны;

            строка_телефон = строка_телефон.Replace("-", "");

            foreach (Match match in Regex.Matches(строка_телефон, pattern))
            {
                клРазрешение.телефон = match.Value;
            }

                 pattern = @"\b\d{11}\b";
             foreach (Match match in Regex.Matches(строка_телефон, pattern))
             {
                 string ss = match.Value;
                 клРазрешение.телефон = ss.Remove(0, 1);

             }
        }
        private void найти_почту()
        {

            клРазрешение.эл_почта = "";
            string[] aStr = клРазрешение.все_телефоны.Split(' ');
            foreach (string s1 in aStr)
            {
                if (ru.IsValidEmail(s1))
                {
                    клРазрешение.эл_почта = s1;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count == 0)
            {
                return;
            }
            temp tRow = bindingSource1.Current as temp;
            var delRow = de.разрешения
                .Where(n => n.разрешение == tRow.разрешение).ToArray();
            foreach (разрешения dRow in delRow)
            {
                de.разрешения.Remove(dRow);
            }
            try
            {
                de.SaveChanges();
                bindingSource1.RemoveCurrent();
                //bindingSource1.MoveLast();
                //if (dic0.ContainsKey(tRow.разрешение))
                //{
                //    dic0.Remove(tRow.разрешение);
                //}
            }
            catch
            {
                MessageBox.Show("Сбой записи");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count == 0)
            {
                return;
            }

            temp tRow = bindingSource1.Current as temp;

            клРазрешение.клиент = tRow.клиент;
            клРазрешение.разрешение = tRow.разрешение;
            клРазрешение.телефон = tRow.телефон;
            клРазрешение.эл_почта = tRow.эл_почта;
            //  клРазрешение.все_телефоны = клКлиент.deRow.телефон;

            //клРазрешение.телефон = "";
            //клРазрешение.эл_почта = "";
            //найти_сотовый();
            //найти_почту();
            клРазрешение.дата_с = tRow.дата_с;
            клРазрешение.дата_по = tRow.дата_по;



            клРазрешение.выбран = false;
            сотовый_мыло вводСотового = new сотовый_мыло();
            вводСотового.Text = "Разрешение № " + tRow.номер.ToString() + " от " + tRow.дата_с.ToShortDateString() + " " + tRow.фио;
            вводСотового.ShowDialog();
            if (клРазрешение.выбран)
            {
                разрешения uRow = de.разрешения.Single(n => n.разрешение == клРазрешение.разрешение);
                uRow.дата_по = клРазрешение.дата_по;
                uRow.дата_с = клРазрешение.дата_с;
                uRow.телефон = клРазрешение.телефон;
                uRow.эл_почта = клРазрешение.эл_почта;
                try
                {
                    de.SaveChanges();

                    tRow.дата_по = клРазрешение.дата_по;
                    tRow.дата_с = клРазрешение.дата_с;
                    tRow.телефон = клРазрешение.телефон;
                    tRow.эл_почта = клРазрешение.эл_почта;
            //        temp t0Row = listTemp0.Single(n => n.разрешение == tRow.разрешение);
                    //t0Row.дата_по = клРазрешение.дата_по;
                    //t0Row.дата_с = клРазрешение.дата_с;
                    //t0Row.телефон = клРазрешение.телефон;
                    //t0Row.эл_почта = клРазрешение.эл_почта;
                    dataGridView1.Refresh();
                }
                catch
                {
                    MessageBox.Show("Сбой записи...");
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count == 0)
            {
                return;
            }

            temp tRow = bindingSource1.Current as temp;
            клРазрешение.клиент = tRow.клиент;
            клРазрешение.телефон = tRow.телефон;
            клРазрешение.эл_почта = tRow.эл_почта;

            Word.Application oWord = new Word.Application();

            string curDir = System.IO.Directory.GetCurrentDirectory();

            object шаблон = curDir + @"\анкета.dot";
            if (!System.IO.File.Exists(шаблон.ToString()))
            {
                MessageBox.Show("Нет файла " + шаблон.ToString());
                return;
            }

            клиенты uRow = de.клиенты.Single(n => n.клиент == клРазрешение.клиент);

            Word.Document o = oWord.Documents.Add(Template: шаблон);
            oWord.Application.Visible = true;

            if (o.Bookmarks.Exists("номер"))
            {
                o.Bookmarks["номер"].Range.Text = tRow.номер.ToString();
            }
            if (o.Bookmarks.Exists("дата"))
            {
                o.Bookmarks["дата"].Range.Text = DateTime.Today.ToShortDateString();
            }
            if (o.Bookmarks.Exists("Имя"))
            {
                o.Bookmarks["Имя"].Range.Text = uRow.имя;
            }
            if (o.Bookmarks.Exists("Фамилия"))
            {
                o.Bookmarks["Фамилия"].Range.Text = uRow.фамилия;
            }

            if (o.Bookmarks.Exists("Отчество"))
            {
                o.Bookmarks["Отчество"].Range.Text = uRow.отчество;
            }

            string адрес_клиента = tRow.наимен_улицы.Trim() + " дом " + tRow.номер_дома.ToString();
            if (tRow.корпус != String.Empty)
            {
                адрес_клиента += " корпус " + tRow.корпус.Trim();
            }
            адрес_клиента += " кв. " + tRow.квартира.ToString();
            if (o.Bookmarks.Exists("адрес"))
            {
                o.Bookmarks["адрес"].Range.Text = "Свердловская обл., г. Березовский, " + адрес_клиента;
            }
            if (o.Bookmarks.Exists("телефон"))
            {
                o.Bookmarks["телефон"].Range.Text = клРазрешение.телефон;
            }
            if (o.Bookmarks.Exists("эл_почта"))
            {
                o.Bookmarks["эл_почта"].Range.Text = клРазрешение.эл_почта;
            }


            oWord.Application.Visible = true;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string текст = textBox1.Text.Trim().ToUpper();
            if (текст != string.Empty)
            {
                int строка = listTemp.FindIndex(n => n.фио.ToUpper().StartsWith(текст));

                if (строка > -1)
                {
                    bindingSource1.Position = строка;
                    dataGridView1.FirstDisplayedScrollingRowIndex = строка;
                }
            }

        }


    }
}
