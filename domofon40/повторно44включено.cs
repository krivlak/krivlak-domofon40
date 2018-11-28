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
    public partial class повторно44включено : Form
    {
        public повторно44включено()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        List<temp> tempList = new List<temp>();
        private void повторно44включено_Load(object sender, EventArgs e)
        {
            var query = de.отключения
                                      .Where(n => n.услуги.вид_услуги == клВид_услуги.вид_услуги)
                                      .Where(n => n.дата_с >= клПериод.дата_с)
                                      .Where(n => n.дата_с <= клПериод.дата_по)
                                      .OrderBy(n => n.дата_с)
                                      .ThenBy(n => n.мастер)
                                      .ToArray();



            foreach (var oRow in query)
            {
                oRow.дата_по = null;
            }

            var query2 = de.повторы
                           .Where(n => n.услуги.вид_услуги == клВид_услуги.вид_услуги)
                           .OrderBy(n => n.дата_с)
                           .ToArray();

            foreach (var oRow in query)
            {
                foreach (var pRow in query2
                    .Where(n => n.клиент == oRow.клиент)
                    .Where(n => n.услуга == oRow.услуга))
                {
                    if (oRow.дата_с <= pRow.дата_с)
                    {
                        oRow.дата_по = pRow.дата_с;
                    }
                }

            }
            tempList = query
                .GroupBy(n => new { n.услуги, n.сотрудники })
                .Select(n => new temp
                {
                    услуга = n.Key.услуги.услуга,
                    наимен_услуги = n.Key.услуги.обозначение,
                     мастер =  n.Key.сотрудники.сотрудник,
                      фио = n.Key.сотрудники.фио,
                       должность =  n.Key.сотрудники.должность,
                        отключений= n.Count(),
                         повторов=n.Count(p=>p.дата_по !=null),
                          договоров=0
                          
                }).ToList();
            bindingSource1.DataSource = tempList;
        }
        class temp
        {
            public Guid услуга { get; set; }
            public Guid мастер { get; set; }
            public string должность { get; set; }
            public string фио { get; set; }
            public int отключений { get; set; }
            public int повторов { get; set; }
            public int договоров { get; set; }
            public string наимен_услуги { get; set; }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Word.Application oWord = new Word.Application();

            string curDir = System.IO.Directory.GetCurrentDirectory();

            object шаблон = curDir + @"\отключено1период.dot";
            if (!System.IO.File.Exists(шаблон.ToString()))
            {
                MessageBox.Show("Нет файла " + шаблон.ToString());
                return;
            }

     

            string наименФилиала = de.филиалы
                .OrderBy(n => n.порядок)
                .First().наимен;

            Word.Document o = oWord.Documents.Add(Template: шаблон);
            // oWord.Application.Visible = true;
            o.Tables[1].Cell(1, 1).Range.Text = "Подключения отключеных с";
            o.Tables[1].Cell(1, 2).Range.Text = клПериод.дата_с.ToLongDateString();
            o.Tables[1].Cell(1, 3).Range.Text = "по " + клПериод.дата_по.ToLongDateString();

            o.Tables[1].Cell(2, 1).Range.Text = клВид_услуги.наимен;
            o.Tables[1].Cell(2, 2).Range.Text = наименФилиала;
            o.Tables[1].Cell(2, 3).Range.Text = DateTime.Today.ToLongDateString();



            int j = 1;

            foreach (temp kRow in tempList)
            //                .Where(n => n.покрасить))
            {
                j++;
                // o.Tables[4].Cell(j, 1).Range.Text = kRow.подъезд.ToString("0;#;#");
                o.Tables[2].Cell(j, 1).Range.Text = kRow.наимен_услуги;
                o.Tables[2].Cell(j, 2).Range.Text = kRow.фио;
                o.Tables[2].Cell(j, 3).Range.Text = kRow.должность;
                o.Tables[2].Cell(j, 4).Range.Text = kRow.договоров.ToString("0;#;#");
                o.Tables[2].Cell(j, 5).Range.Text = kRow.отключений.ToString("0;#;#");
                o.Tables[2].Cell(j, 6).Range.Text = kRow.повторов.ToString("0;#;#");

                o.Tables[2].Rows.Add();


            }
            oWord.Application.Visible = true;
            Cursor = Cursors.Default;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {

                temp uRow = bindingSource1.Current as temp;
                клМастер.мастер = uRow.мастер;
                клМастер.фио = uRow.фио;
                клУслуга.услуга = uRow.услуга;
                клУслуга.наимен = uRow.наимен_услуги;
                if (клМастер.мастер != Guid.Empty)
                {
                    Cursor = Cursors.WaitCursor;
                    клМастер.изменен = false;
                    подробности44откл формаПодробности = new подробности44откл();
                    формаПодробности.Text = "Отключения " + клУслуга.наимен + "   " + клМастер.фио;
                    формаПодробности.ShowDialog();
                    //if (клМастер.изменен)
                    //{
                    //    обновить();
                    //}
                    Cursor = Cursors.Default;
                }

            }

        }
    }
}
