using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Entity;
using Word = Microsoft.Office.Interop.Word;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;


namespace domofon40
{
    public partial class список_договоров : Form
    {
        public список_договоров()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
       
        BindingList<подключения> подключенияЛист = new BindingList<подключения>();
        int maxNum = 0;
        private void список_договоров_Load(object sender, EventArgs e)
        {
            try
            {

                de.сотрудники.OrderBy(n=>n.порядок).Load();
                de.клиенты.Load();
                de.услуги.Load();

                de.подключения
                   .OrderBy(n => n.дата_дог)
                   .Load();

                подключенияЛист = de.подключения.Local.ToBindingList();
             

                bindingSource1.DataSource = подключенияЛист;
                bindingSource1.MoveLast();
              //  comboBox1.DataSource = de.сотрудники.Local;
                клСетка.задать_ширину(dataGridView1);
                //maxNum = 0;
                //if(de.подключения.Local.Any())
                //{
                //    maxNum = de.подключения.Local.Max(n => n.номер_пп);
                //}
                //label4.Text = maxNum.ToString();
                последний_номер();
                //if (bindingSource1.Count > 0)
                //{
                //    подключения tRow = bindingSource1.Current as подключения;
                //    comboBox1.SelectedItem = tRow.сотрудники;
                //}

                bindingSource1.ListChanged += bindingSource1_ListChanged;
                FormClosing += договора1клиента_FormClosing;
                dataGridView1.CellMouseClick += dataGridView1_CellMouseClick;
             //   bindingSource1.PositionChanged += BindingSource1_PositionChanged;

            }
            catch
            {
                MessageBox.Show("Сбой загрузки..");
            }

        }

   
   

        void последний_номер()
        {
            maxNum = 0;
            if (de.подключения.Local.Any())
            {
                maxNum = de.подключения.Local.Max(n => n.номер_пп);
            }
            label4.Text = maxNum.ToString();
        }

        void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (dataGridView1.Columns[e.ColumnIndex] == датаColumn)
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    подключения uRow = bindingSource1.Current as подключения;
                    клКалендарь.выбран = false;
                    клКалендарь.дата = uRow.дата_дог;
                    календарь выборДаты = new календарь();
                    выборДаты.button3.Visible = false;
                    выборДаты.ShowDialog();
                    if (клКалендарь.выбран)
                    {
                        uRow.дата_дог = клКалендарь.дата.Value;
                        dataGridView1.Refresh();

                        label1.Visible = true;
                    }

                }
                if (dataGridView1.Columns[e.ColumnIndex] == дата_сColumn)
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    подключения uRow = bindingSource1.Current as подключения;
                    клКалендарь.выбран = false;
                    клКалендарь.дата = uRow.дата_с;
                    календарь выборДаты = new календарь();
                    выборДаты.button3.Visible = false;
                    выборДаты.ShowDialog();
                    if (клКалендарь.выбран)
                    {
                        uRow.дата_с = клКалендарь.дата.Value;
                        dataGridView1.Refresh();
                        label1.Visible = true;
                    }

                }
                if (dataGridView1.Columns[e.ColumnIndex] == мастерColumn)
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    подключения uRow = bindingSource1.Current as подключения;
                    клМастер.мастер = uRow.мастер;
                    клМастер.выбран = false;
                    выбор_мастера выборМастера = new выбор_мастера();
                    выборМастера.ShowDialog();
                    if (клМастер.выбран)
                    {
                        uRow.мастер = клМастер.мастер;
                        if (de.Entry(uRow).State == EntityState.Unchanged)
                        {
                            de.Entry(uRow).State = EntityState.Modified;
                            // не работает в добавленой строке.
                        }
                        dataGridView1.Refresh();
                        label1.Visible = true;

                    }
                }

            }
        }

        void договора1клиента_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (label1.Visible)
            {
                try
                {
                    de.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Сбой записи " + ex.Message);
                }
            }
        }
        void записать()
        {
            if (label1.Visible)
            {
                try
                {
                    de.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Сбой записи " + ex.Message);
                }
            }
        }

        void bindingSource1_ListChanged(object sender, ListChangedEventArgs e)
        {
            label1.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            клКлиент.выбран = false;
            выбор_клиента ВыборКлиента = new выбор_клиента();
            ВыборКлиента.ShowDialog();
            if (клКлиент.выбран)
            {
                клУслуга.выбран = false;
                выбор_услуги ВыборУслуги = new выбор_услуги();
                ВыборУслуги.ShowDialog();
                if (клУслуга.выбран)
                {
                    клМастер.выбран = false;
                    выбор_бригады выборМастера = new выбор_бригады();
                    выборМастера.Text = "Выберите мастера";
                    выборМастера.ShowDialog();
                    if (клМастер.выбран)
                    {
                        int maxNum = 0;
                        if (de.подключения.Local.Any())
                        {
                            maxNum = de.подключения.Local.Max(n => n.номер_пп);
                        }
                        подключения NewRow = new подключения();
                        NewRow.дата_дог = DateTime.Today;
                        NewRow.дата_с = DateTime.Today;
                        NewRow.клиент = клКлиент.клиент;
                        NewRow.мастер = клМастер.мастер;
                        NewRow.номер_дог = "";
                        NewRow.номер_пп = maxNum + 1;
                        NewRow.услуга = клУслуга.услуга;
                        NewRow.подключение = Guid.NewGuid();
                        int строка = bindingSource1.Add(NewRow);
                        bindingSource1.Position = строка;

                    }
                }
            }
            Cursor = Cursors.Default;
            последний_номер();
            dataGridView1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {

                bindingSource1.RemoveCurrent();
                bindingSource1.MoveLast();
                
            }
            последний_номер();
            dataGridView1.Refresh();
            dataGridView1.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            клШаблон.выбран = false;
            выбор_шаблона выборШаблона = new выбор_шаблона();
            выборШаблона.ShowDialog();
            if (клШаблон.выбран)
            {

                try
                {
                    подключения uRow = bindingSource1.Current as подключения;

                    Word.Application oWord = new Word.Application();

                    string curDir = System.IO.Directory.GetCurrentDirectory();

                    //object шаблон = curDir + @"\Договор_домофон.dot";
                    string шаблон = curDir + @"\" + клШаблон.путь.Trim();
                    if (!System.IO.File.Exists(шаблон.ToString()))
                    {
                        MessageBox.Show("Нет файла " + шаблон.ToString());
                        return;
                    }

                    Word.Document o = oWord.Documents.Add(Template: шаблон);
                    //  oWord.Application.Visible = true;
                    if (o.Bookmarks.Exists("номер1"))
                        o.Bookmarks["номер1"].Range.Text = uRow.номер_дог.Trim() + uRow.номер_пп.ToString();
                    if (o.Bookmarks.Exists("номер2"))
                        o.Bookmarks["номер2"].Range.Text = uRow.номер_дог.Trim() + uRow.номер_пп.ToString();
                    if (o.Bookmarks.Exists("номер3"))
                        o.Bookmarks["номер3"].Range.Text = uRow.номер_дог.Trim() + uRow.номер_пп.ToString();
                    if (o.Bookmarks.Exists("номер4"))
                        o.Bookmarks["номер4"].Range.Text = uRow.номер_дог.Trim() + uRow.номер_пп.ToString();
                    if (o.Bookmarks.Exists("дата1"))
                        o.Bookmarks["дата1"].Range.Text = uRow.дата_дог.ToLongDateString();
                    if (o.Bookmarks.Exists("дата2"))
                        o.Bookmarks["дата2"].Range.Text = uRow.дата_дог.ToLongDateString();
                    if (o.Bookmarks.Exists("дата3"))
                        o.Bookmarks["дата3"].Range.Text = uRow.дата_дог.ToLongDateString();
                    if (o.Bookmarks.Exists("дата4"))
                        o.Bookmarks["дата4"].Range.Text = uRow.дата_дог.ToLongDateString();
                    if (o.Bookmarks.Exists("фио1"))
                        o.Bookmarks["фио1"].Range.Text = " " + uRow.клиенты.фамилия.Trim()
                        + " " + uRow.клиенты.имя.Trim()
                        + " " + uRow.клиенты.отчество.Trim();
                    if (o.Bookmarks.Exists("фио2"))
                        o.Bookmarks["фио2"].Range.Text = " " + uRow.клиенты.фамилия.Trim()
                        + " " + uRow.клиенты.имя.Trim()
                        + " " + uRow.клиенты.отчество.Trim();
                    //string наименКорпуса = "";
                    //if (uRow.корпус.Trim().Length == 0)
                    //{
                    //}
                    //else
                    //{
                    //    наименКорпуса = " корпус " + uRow.корпус.Trim();
                    //}
                    if (o.Bookmarks.Exists("адрес1"))
                        o.Bookmarks["адрес1"].Range.Text = " " + uRow.адрес.Trim();
                    //+ " дом " + uRow.номер.ToString().Trim()
                    //+ наименКорпуса
                    //+ " квартира " + uRow.квартира.ToString().Trim();

                    if (o.Bookmarks.Exists("адрес2"))
                        o.Bookmarks["адрес2"].Range.Text = " " + uRow.адрес.Trim();
                    //+ " дом " + uRow.номер.ToString().Trim()
                    //+ наименКорпуса
                    //+ " квартира " + uRow.квартира.ToString().Trim();

                    if (o.Bookmarks.Exists("телефон1"))
                        o.Bookmarks["телефон1"].Range.Text = " " + uRow.клиенты.телефон.Trim();
                    if (o.Bookmarks.Exists("телефон2"))
                        o.Bookmarks["телефон2"].Range.Text = " " + uRow.клиенты.телефон.Trim();

                    клTemp.Caption = o.ActiveWindow.Caption;
                    oWord.Application.Visible = true;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Сбой " + ex.Message);
                }
            }
            dataGridView1.Focus();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //   if (comboBox1.SelectedIndex < 0)
            //   {
            //       MessageBox.Show("Выберите мастера...");
            //       comboBox1.Focus();
            //       return;
            //   }
            ////   string КодМастера = comboBox1.SelectedValue.ToString();
            //   сотрудники sRow = comboBox1.SelectedItem as сотрудники;

            if (bindingSource1.Count > 0 && de.подключения.Local.Any(n => n.в_задание))
            {
                подключения tRow = bindingSource1.Current as подключения;
                //клМастер.мастер = tRow.мастер;
                //клМастер.выбран = false;
                //выбор_бригады выборМастера = new выбор_бригады();
                //выборМастера.Text = "Выберите мастера";
                //выборМастера.ShowDialog();
                //if (клМастер.выбран || выборМастера.DialogResult == DialogResult.OK)
                //{


                //    foreach (подключения uRow in de.подключения.Local
                //    .Where(n => n.в_задание))
                //    {
                //        uRow.мастер = клМастер.мастер;
                //        uRow.сотрудники = de.сотрудники.Local.Single(n => n.сотрудник == клМастер.мастер);
                //    }
                //    dataGridView1.Refresh();

                    Cursor = Cursors.WaitCursor;

                    string curDir = System.IO.Directory.GetCurrentDirectory();

                    string шаблон = curDir + @"\задание_договор.docx";

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
                            //  int строкаРаб = 0;

                            var tables = package.MainDocumentPart.Document.Body.Elements<Table>();
                            //Table table1 = tables.First();
                            //Table table2 = tables.Last();
                            Table table1 = tables.ElementAt(0);
                            Table table2 = tables.ElementAt(1);

                        //string фио = de.сотрудник.Single(n => n.сотрудник1 == КодМастера).фио;
                        //string должность = de.сотрудник.Single(n => n.сотрудник1 == КодМастера).должность;

                        string текст = "Задание на подключение согласно договора";
                           // + клМастер.deRow.должность.Trim() + "    " + клМастер.deRow.фио;
                            клXML.ChangeTextInCell(table1, 0, 0, текст + "    " + DateTime.Today.ToLongDateString());

                            TableRow lastRow = table2.Elements<TableRow>().Last();

                            //var queryTemp = dsTemp.квартиры.ToArray();
                            //if (checkBox2.Checked)
                            //{
                            //    queryTemp = queryTemp
                            //        .Where(n => n.отключить || n.подключить || n.повторно).ToArray();
                            //}

                            int j = 0;

                            foreach (подключения kRow in de.подключения.Local
                       .Where(n => n.в_задание))
                            {
                                j++;
                                TableRow newRow1 = lastRow.Clone() as TableRow;


                                table2.AppendChild<TableRow>(newRow1);


                                клXML.ChangeTextInCell(table2, j, 0, kRow.адрес);

                                клXML.ChangeTextInCell(table2, j, 1, kRow.клиенты.фио);

                                клXML.ChangeTextInCell(table2, j, 2, kRow.клиенты.телефон);
                                клXML.ChangeTextInCell(table2, j, 3, kRow.услуги.обозначение);

                                if (kRow.в_задание)
                                {
                                    клXML.ChangeTextInCell(table2, j, 4, "V");
                                }
                                else
                                {
                                    клXML.ChangeTextInCell(table2, j, 4, "");
                                }



                            }


                            j++;
                            клXML.ChangeTextInCell(table2, j, 0, "Всего");
                            клXML.ChangeTextInCell(table2, j, 1, "квартир");
                            клXML.ChangeTextInCell(table2, j, 2, (j - 1).ToString());
                            клXML.ChangeTextInCell(table2, j, 3, "");
                            клXML.ChangeTextInCell(table2, j, 4, "");
                            //клXML.ChangeTextInCell(table2, j, 5, "");
                            //клXML.ChangeTextInCell(table2, j, 6, "");
                            //клXML.ChangeTextInCell(table2, j, 7, "");


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
            else
            {
                MessageBox.Show("Отметьте адреса для подключения");
            }
            dataGridView1.Focus();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            записать();

           подключения uRow = bindingSource1.Current as подключения ;
            клУслуга.услуга = uRow.услуга;
            клУслуга.наимен = uRow.услуги.наимен;
            клКлиент.клиент = uRow.клиент;
            клКлиент.deRow = uRow.клиенты;
            клУслуга.deRow = uRow.услуги;
            клКлиент.фио = uRow.сотрудники.фио;


            оплаченные1просмотр формаОплатить = new оплаченные1просмотр();
            формаОплатить.Text = "Оплаты за " + клУслуга.наимен.Trim() + " " + клКлиент.фио;
            формаОплатить.ShowDialog();

            dataGridView1.Focus();

            Cursor = Cursors.Default;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //клШаблон.выбран = false;
            //выбор_шаблона выборШаблона = new выбор_шаблона();
            //выборШаблона.ShowDialog();
            //if (клШаблон.выбран)
            try
            {


//                подключения uRow = bindingSource1.Current as подключения;

                Word.Application oWord = new Word.Application();

                string curDir = System.IO.Directory.GetCurrentDirectory();

                //object шаблон = curDir + @"\Договор_домофон.dot";
                string шаблон = curDir + @"\инструкция.dot" ;
                if (!System.IO.File.Exists(шаблон.ToString()))
                {
                    MessageBox.Show("Нет файла " + шаблон.ToString());
                    return;
                }

                Word.Document o = oWord.Documents.Add(Template: шаблон);
                oWord.Application.Visible = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Сбой " + ex.Message);
            }
            dataGridView1.Focus();
        }
    }
}
