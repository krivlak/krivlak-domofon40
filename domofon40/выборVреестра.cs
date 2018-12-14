using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace domofon40
{
    public partial class выборVреестра : Form
    {
        public выборVреестра()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        List<temp> tempList = new List<temp>();
        private void выборVреестра_Load(object sender, EventArgs e)
        {
            var query1 = de.оплачено.Where(n => n.оплаты.дата >= клПериод.дата_с && n.оплаты.дата <= клПериод.дата_по)
                      .GroupBy(n => new { n.оплаты.дата, n.услуги.виды_услуг, n.оплаты.сотрудники, n.оплаты.виды_оплат })
                      .Select(n => new
                      {
                          n.Key,
                          сумма = n.Sum(p => p.сумма)

                      }).ToList();
            var query2 = de.возврат.Where(n => n.оплаты.дата >= клПериод.дата_с && n.оплаты.дата <= клПериод.дата_по)
                             .GroupBy(n => new { n.оплаты.дата, n.услуги.виды_услуг, n.оплаты.сотрудники, n.оплаты.виды_оплат })
                             .Select(n => new
                             {
                                 n.Key,
                                 сумма = n.Sum(p => p.сумма)

                             }).ToList();
            query1.AddRange(query2);


            tempList = query1.GroupBy(n => n.Key)
                  .Select(n => new temp()
                  {
                      дата = n.Key.дата,
                      вид_услуги = n.Key.виды_услуг.вид_услуги,
                      наимен_вида_услуги = n.Key.виды_услуг.наимен,
                      сотрудник = n.Key.сотрудники.сотрудник,
                       порядок = n.Key.сотрудники.порядок,
                      фио = n.Key.сотрудники.фио.Trim(),
                      вид_оплаты = n.Key.виды_оплат.вид_оплаты,

                      наимен_вида_оплаты = n.Key.виды_оплат.наимен,
                      сумма = n.Sum(p => p.сумма)

                  }).OrderBy(n => n.дата)
                  .ThenBy(n=>n.порядок)
                  .ToList();

            var query3 = tempList.GroupBy(n => n.дата)
                .Select(n => new { дата = n.Key, сумма = n.Sum(p => p.сумма) });
            foreach (var rRow in query3)
            {
                tempList.FindAll(n => n.дата == rRow.дата).ForEach(n => n.за_день = rRow.сумма);
            }


            bindingSource1.DataSource = tempList.OrderBy(n => n.дата);
            клСетка.задать_ширину(dataGridView1);
            bindingSource1.MoveLast();
            dataGridView1.Focus();

        }

        class temp
        {
            public DateTime дата { get; set; }
            public Guid вид_услуги { get; set; }
            public Guid вид_оплаты { get; set; }
            public Guid сотрудник { get; set; }
            public int порядок { get; set; }
            public string наимен_вида_услуги { get; set; }
            public string фио { get; set; }
            public string наимен_вида_оплаты { get; set; }
            public int сумма { get; set; }
            public int за_услуги { get; set; }
            public int за_оплаты { get; set; }
            public int за_сотрудника { get; set; }
            public int за_день { get; set; }
            public bool выбран { get; set; }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
                temp uRow = bindingSource1.Current as temp;
                клРеестр.дата = uRow.дата.Date;
                клСотрудник.сотрудник = uRow.сотрудник;
                клСотрудник.фио = uRow.фио;

                клРеестр.менеджер = uRow.сотрудник;
                клРеестр.фио_менеджера = uRow.фио;
                клРеестр.вид_оплаты = uRow.вид_оплаты;
                клРеестр.наименВидаОплаты = uRow.наимен_вида_оплаты;
                клВид_услуги.вид_услуги = uRow.вид_услуги;
                клВид_услуги.наимен = uRow.наимен_вида_услуги;
                реестр_услуг формаРеестр = new реестр_услуг();
                формаРеестр.Text = "Реестр за " + клРеестр.дата.ToLongDateString() + "  ";
                формаРеестр.Text += " " + клВид_услуги.наимен.Trim();
                формаРеестр.Text += " " + клРеестр.наименВидаОплаты.Trim();

                string наименФилиала = de.филиалы
                    .OrderBy(n => n.порядок)
                    .First().наимен;
                формаРеестр.Text += " по филиалу " + наименФилиала;
                формаРеестр.Text += " менеджер " + клСотрудник.фио;

                формаРеестр.ShowDialog();
                Cursor = Cursors.Default;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            //    Word.Application oWord = new Word.Application();

            string curDir = System.IO.Directory.GetCurrentDirectory();

            string шаблон = curDir + @"\выбор_реестра.docx";

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

            string наименФилиала = de.филиалы
                .OrderBy(n => n.порядок)
                .First().наимен;

            try
            {
                using (WordprocessingDocument package = WordprocessingDocument.Open(tempFile, true))
                {

                    var tables = package.MainDocumentPart.Document.Body.Elements<Table>();
                    Table table0 = tables.First();
                    //   Table table1 = tables.ElementAt(1);
                    Table table2 = tables.Last();


                    клXML.ChangeTextInCell(table0, 0, 0, "Оплаты");
                    клXML.ChangeTextInCell(table0, 0, 1, наименФилиала);
                    клXML.ChangeTextInCell(table0, 0, 2, DateTime.Today.ToShortDateString());

                    клXML.ChangeTextInCell(table0, 1, 0, "За период");
                    клXML.ChangeTextInCell(table0, 1, 1, клПериод.дата_с.ToShortDateString());
                    клXML.ChangeTextInCell(table0, 1, 2, клПериод.дата_с.ToShortDateString());

                    //Table table = package.MainDocumentPart.Document.Body.ChildElements.Last<Table>();
                    TableRow lastRow = table2.Elements<TableRow>().Last();






                    int строк = tempList.Count(n=>n.выбран);
                    for (int s = 1; s <= строк; s++)
                    {
                        TableRow newRow = lastRow.Clone() as TableRow;
                        table2.AppendChild<TableRow>(newRow);
                    }

                    int всего = 0;
                    int j = 0;
                    foreach (temp rRow in tempList.Where(n=>n.выбран))
                    {
                        j++;
                        клXML.ChangeTextInCell(table2, j, 0, rRow.дата.ToShortDateString());
                        клXML.ChangeTextInCell(table2, j, 1, rRow.наимен_вида_услуги);
                        клXML.ChangeTextInCell(table2, j, 2, rRow.фио);
                        клXML.ChangeTextInCell(table2, j, 3, rRow.наимен_вида_оплаты);
                        клXML.ChangeTextInCell(table2, j, 4, rRow.сумма.ToString());
                        клXML.ChangeTextInCell(table2, j, 5, rRow.за_день.ToString());
                        всего += rRow.сумма;
                    }
                    клXML.ChangeTextInCell(table2, j + 1, 1, "Всего ");
                    клXML.ChangeTextInCell(table2, j + 1, 2, " за период");
                    клXML.ChangeTextInCell(table2, j + 1, 4, всего.ToString());

                }
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

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
