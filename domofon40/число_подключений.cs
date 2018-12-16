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
    public partial class число_подключений : Form
    {
        public число_подключений()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        Dictionary<Guid, temp> tempDic = new Dictionary<Guid, temp>();
        Dictionary<Guid, temp2> temp2Dic = new Dictionary<Guid, temp2>();
        List<temp> tempList = new List<temp>();
        List<temp2> temp2List = new List<temp2>();
        private void число_подключений_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (услуги uRow in de.услуги
                .AsNoTracking()
                .Include("клиенты")
                .OrderBy(n => n.виды_услуг.порядок)
                .ThenBy(n => n.порядок))
                {
                    заполнить_абонентов(uRow);
                    temp newTemp = new temp()
                    {
                        услуга = uRow.услуга,
                        наимен_услуги = uRow.наимен,
                        договоров = temp2List.Count(n => n.договор),
                        льгот = temp2List.Count(n => n.льгота),
                        подключено = uRow.клиенты.Count(),
                        отключено = temp2List.Count(n => n.закрыт),
                        действует = temp2List.Count(n => !n.закрыт)
                    };
                    tempList.Add(newTemp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сбой загрузки {ex.Message}");
            }
            bindingSource1.DataSource = tempList;
        }

        void заполнить_абонентов (услуги deУслуги)
        {
            Guid кодУслуги = deУслуги.услуга;
          
            temp2List.Clear();
            foreach (клиенты uRow in deУслуги.клиенты)
            {
                temp2 newTemp2 = new temp2();
                newTemp2.клиент = uRow.клиент;
                temp2List.Add(newTemp2);
            }
            temp2Dic = temp2List.ToDictionary(n => n.клиент);

            foreach (подключения pRow in de.подключения
            .Where(n => n.услуга == кодУслуги)
            .OrderBy(n => n.дата_с))
            {
                if (temp2Dic.ContainsKey(pRow.клиент))
                {
                    temp2 aRow = temp2Dic[pRow.клиент];
                    aRow.договор = true;
                    aRow.договор_с = pRow.дата_с;
                }
            }

                //if (uRow.подключения.Any(n => n.услуга == кодУслуги))
                //{
                //    newTemp2.договор = true;
                //    newTemp2.договор_с = uRow.подключения.Where(n => n.услуга == кодУслуги).Max(p => p.дата_с);
                //}

            foreach( отключения oRow in de.отключения
                .Where(n => n.услуга == кодУслуги)
                .OrderBy(n => n.дата_с))
            {
                if (temp2Dic.ContainsKey(oRow.клиент))
                {
                    temp2 aRow = temp2Dic[oRow.клиент];
                  
                    aRow.отключен = oRow.дата_с;
                }
            }

            foreach (повторы oRow in de.повторы
              .Where(n => n.услуга == кодУслуги)
              .OrderBy(n => n.дата_с))
            {
                if (temp2Dic.ContainsKey(oRow.клиент))
                {
                    temp2 aRow = temp2Dic[oRow.клиент];

                    aRow.повторы = oRow.дата_с;
                }
            }

            foreach (льготы oRow in de.льготы
                .Where(n => n.услуга == кодУслуги)
                .OrderBy(n => n.дата_с))
            {
                if (temp2Dic.ContainsKey(oRow.клиент))
                {
                    temp2 aRow = temp2Dic[oRow.клиент];

                    aRow.льгота = true;
                }
            }

            foreach( temp2 tRow in temp2List)
            {
                if (tRow.отключен != null && tRow.повторы == null)
                {
                    tRow.закрыт = true;
                }
                if (tRow.отключен != null && tRow.повторы != null)
                {
                    if (tRow.отключен > tRow.повторы)
                    {
                        tRow.закрыт = true;
                    }
                }
            }
        }

        class temp
        {
            public Guid услуга { get; set; }
            public string наимен_услуги { get; set; }
            public int подключено { get; set; }
            public int договоров { get; set; }
            public int отключено { get; set; }
            public int льгот { get; set; }
            public int действует { get; set; }

        }
        class temp2
        {
            public Guid клиент { get; set; }
            public bool договор { get; set; } = false;
            public DateTime договор_с { get; set; } 
            public DateTime отключен { get; set; }
            public DateTime повторы { get; set; }
            public bool закрыт { get; set; } = false;
            public bool льгота { get; set; } = false;
            public DateTime дата_пред { get; set; }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Word.Application oWord = new Word.Application();

                string curDir = System.IO.Directory.GetCurrentDirectory();

                object шаблон = curDir + @"\число55подключений.dot";
                if (!System.IO.File.Exists(шаблон.ToString()))
                {
                    MessageBox.Show("Нет файла " + шаблон.ToString());
                    return;
                }


                string наименФилиала = de.филиалы
                    .OrderBy(n => n.порядок)
                    .First().наимен;

                Word.Document o = oWord.Documents.Add(Template: шаблон);
                //    oWord.Application.Visible = true;

                o.Tables[1].Cell(1, 2).Range.Text = наименФилиала;
                o.Tables[1].Cell(1, 3).Range.Text = DateTime.Today.ToShortDateString();
                int j = 1;

                foreach (temp uRow in tempList)
                {
                    j++;
                    o.Tables[2].Cell(j, 1).Range.Text = uRow.наимен_услуги;
                    o.Tables[2].Cell(j, 2).Range.Text = uRow.подключено.ToString("0;#;#");
                    o.Tables[2].Cell(j, 3).Range.Text = uRow.договоров.ToString("0;#;#");
                    o.Tables[2].Cell(j, 4).Range.Text = uRow.отключено.ToString("0;#;#");
                    o.Tables[2].Cell(j, 5).Range.Text = uRow.действует.ToString("0;#;#");
                    o.Tables[2].Cell(j, 6).Range.Text = uRow.льгот.ToString("0;#;#");
                    //      o.Tables[2].Cell(j, 7).Range.Text = uRow.предупреждений.ToString("0;#;#");
                    o.Tables[2].Rows.Add();
                }

                клTemp.Caption = o.ActiveWindow.Caption;
                oWord.Application.Visible = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ошибка {ex.Message}");
            }

        }
    }
}
