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
    public partial class отключено1период : Form
    {
        public отключено1период()
        {
            InitializeComponent();
        }
        BindingList<temp> tempList = new BindingList<temp>();
        domofon40.domofon14Entities de;
        private void отключено1период_Load(object sender, EventArgs e)
        {
            this.Text = "Число отключений и подключений за период с " + клПериод.дата_с.ToLongDateString() + " по " + клПериод.дата_по.ToLongDateString();
            обновить();
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;

        }

        void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (
              dataGridView1.Rows[e.RowIndex].Cells["мастерColumn"].Value.ToString().Trim() == "Всего")
            {
                e.CellStyle.BackColor = Color.DarkTurquoise;
            }
        }


        private void обновить()
        {
            de = new domofon14Entities();
            tempList.Clear();
            foreach (услуги yRow in de.услуги
        .Where(n => n.вид_услуги == клВид_услуги.вид_услуги)
        .OrderBy(n => n.порядок))
            {
                foreach (сотрудники sRow in de.сотрудники
                                                   .OrderBy(n => n.порядок))
                {
                    int повторов = sRow.повторы
                                       .Where(n => n.дата_с >= клПериод.дата_с)
                                       .Where(n => n.дата_с <= клПериод.дата_по)
                                       .Count(n => n.услуга == yRow.услуга);

                    int отключений = sRow.отключения
                                         .Where(n => n.дата_с >= клПериод.дата_с)
                                         .Where(n => n.дата_с <= клПериод.дата_по)
                                         .Count(n => n.услуга == yRow.услуга);

                    int договоров = sRow.подключения
                                         .Where(n => n.дата_с >= клПериод.дата_с)
                                         .Where(n => n.дата_с <= клПериод.дата_по)
                                         .Count(n => n.услуга == yRow.услуга);

                    if (повторов > 0 || отключений > 0 || договоров > 0)
                    {
                        //  DsTemp.отключенийRow NewRow = dsTemp.отключений.NewотключенийRow();
                        temp NewRow = new temp();
                        NewRow.услуга = yRow.услуга;
                        NewRow.мастер = sRow.сотрудник;
                        NewRow.должность = sRow.должность;
                        NewRow.фио = sRow.фио;
                        NewRow.отключено = отключений;
                        NewRow.повторно = повторов;
                        NewRow.подключено = договоров;
                        NewRow.наимен_услуги = yRow.обозначение;
                        tempList.Add(NewRow);
                    }
                }
            }

            var queryAll = tempList
                                 .GroupBy(n => new { n.услуга, n.наимен_услуги })
                                 .Select(n => new
                                 {
                                     n.Key.услуга,
                                     n.Key.наимен_услуги,
                                     откл = n.Sum(p => p.отключено),
                                     повтор = n.Sum(p => p.повторно),
                                     договоров = n.Sum(p => p.подключено)
                                 });

            foreach (var aRow in queryAll)
            {
                temp NewRow = new temp();
                NewRow.услуга = aRow.услуга;
                NewRow.мастер = Guid.Empty;
                NewRow.должность = "";
                NewRow.фио = "Всего";
                NewRow.отключено = aRow.откл;
                NewRow.повторно = aRow.повтор;
                NewRow.подключено = aRow.договоров;
                NewRow.наимен_услуги = aRow.наимен_услуги;

                tempList.Add(NewRow);
            }

            bindingSource1.DataSource = tempList;
            dataGridView1.DataSource = bindingSource1;
            dataGridView1.Refresh();
            dataGridView1.Focus();
        }


        class temp
        {
            public Guid услуга { get; set; }
            public Guid мастер { get; set; }
            public string наимен_услуги { get; set; }
            public string фио { get; set; }
            public string должность { get; set; }
            public int подключено { get; set; }
            public int отключено { get; set; }
            public int повторно { get; set; }


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

            //            domofon10.DataClasses1DataContext dc = new DataClasses1DataContext();

            string наименФилиала = de.филиалы
                .OrderBy(n => n.порядок)
                .First().наимен;

            Word.Document o = oWord.Documents.Add(Template: шаблон);
            // oWord.Application.Visible = true;
            o.Tables[1].Cell(1, 1).Range.Text = "Переключения с";
            o.Tables[1].Cell(1, 2).Range.Text = клПериод.дата_с.ToLongDateString();
            o.Tables[1].Cell(1, 3).Range.Text = "по " + клПериод.дата_по.ToLongDateString();

            o.Tables[1].Cell(2, 1).Range.Text = клВид_услуги.наимен;
            o.Tables[1].Cell(2, 2).Range.Text = наименФилиала;
            o.Tables[1].Cell(2, 3).Range.Text = DateTime.Today.ToLongDateString();



            int j = 1;

            foreach (temp kRow in tempList)
            {
                j++;
                o.Tables[2].Cell(j, 1).Range.Text = kRow.наимен_услуги;
                o.Tables[2].Cell(j, 2).Range.Text = kRow.фио;
                o.Tables[2].Cell(j, 3).Range.Text = kRow.должность;
                o.Tables[2].Cell(j, 4).Range.Text = kRow.подключено.ToString("0;#;#");
                o.Tables[2].Cell(j, 5).Range.Text = kRow.отключено.ToString("0;#;#");
                o.Tables[2].Cell(j, 6).Range.Text = kRow.повторно.ToString("0;#;#");

                o.Tables[2].Rows.Add();


            }
            oWord.Application.Visible = true;
            Cursor = Cursors.Default;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {

                temp uRow = bindingSource1.Current as temp;
                клМастер.мастер = uRow.мастер;
                клМастер.фио = uRow.фио;
                клУслуга.услуга = uRow.услуга;
                клУслуга.наимен = uRow.наимен_услуги;

            
                    Cursor = Cursors.WaitCursor;
                    клМастер.изменен = false;
                    подробности44договор формаПодробности = new подробности44договор();
                    формаПодробности.Text = "Подключения по договору  " + клУслуга.наимен + "   " + клМастер.фио;
                    формаПодробности.ShowDialog();
                    if (клМастер.изменен)
                    {
                        обновить();
                    }
                    Cursor = Cursors.Default;
              
            }
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
                
                Cursor = Cursors.WaitCursor;
                клМастер.изменен = false;
                подробности44отк формаПодробности = new подробности44отк();
                формаПодробности.Text = "Отключения  " + клУслуга.наимен + "   " + клМастер.фио;
                формаПодробности.ShowDialog();
                if (клМастер.изменен)
                {
                    обновить();
                }
                Cursor = Cursors.Default;
              
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {

                temp uRow = bindingSource1.Current as temp;
                клМастер.мастер = uRow.мастер;
                клМастер.фио = uRow.фио;
                клУслуга.услуга = uRow.услуга;
                клУслуга.наимен = uRow.наимен_услуги;

                //if (клМастер.мастер != Guid.Empty)
                //{
                Cursor = Cursors.WaitCursor;
                клМастер.изменен = false;
                подробности44повтор формаПодробности = new подробности44повтор();
                формаПодробности.Text = "Повторные подключения   " + клУслуга.наимен + "   " + клМастер.фио;
                формаПодробности.ShowDialog();
                if (клМастер.изменен)
                {
                    обновить();
                }
                Cursor = Cursors.Default;
                //}
            }


        }
    }
}
