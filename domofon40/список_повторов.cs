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
    public partial class список_повторов : Form
    {
        public список_повторов()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();

        private void список_повторов_Load(object sender, EventArgs e)
        {
            de.сотрудники.Load();
            de.клиенты.Load();
            de.услуги.Load();
            de.повторы
                .OrderBy(n => n.дата_с)
                .Load();

            try
            {
                
                bindingSource1.DataSource = de.повторы.Local.ToBindingList();
                bindingSource1.Sort = "дата_с";
                bindingSource1.MoveLast();
                клСетка.задать_ширину(dataGridView1);
                
            }
            catch
            {
                MessageBox.Show("Сбой загрузки");
            }
            примColumn.DefaultCellStyle.NullValue = "null";
            примColumn.DefaultCellStyle.DataSourceNullValue = "";

            bindingSource1.ListChanged += bindingSource1_ListChanged;
            FormClosing += повторы1клиента_FormClosing;
            dataGridView1.CellMouseClick += dataGridView1_CellMouseClick;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;

        }

       

        void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] == примColumn)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
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
        void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                повторы tRow = bindingSource1.Current as повторы;
                if (dataGridView1.Columns[e.ColumnIndex] == мастерColumn)
                {
                    клМастер.мастер = tRow.мастер;
                    клМастер.выбран = false;
                    выбор_мастера ВыборМастера = new выбор_мастера();
                    ВыборМастера.ShowDialog();
                    if (клМастер.выбран)
                    {
                        tRow.мастер = клМастер.мастер;
                        if (de.Entry(tRow).State == EntityState.Unchanged)
                        {
                            de.Entry(tRow).State = EntityState.Modified;
                        }

                        dataGridView1.Refresh();
                        label1.Visible = true;
                    }

                }
                if (dataGridView1.Columns[e.ColumnIndex] == услугиColumn)
                {
                    клУслуга.услуга = tRow.услуга;
                    клУслуга.выбран = false;
                    выбор_услуги Выборуслуги = new выбор_услуги();
                    Выборуслуги.ShowDialog();
                    if (клУслуга.выбран)
                    {
                        tRow.услуга = клУслуга.услуга;
                        if (de.Entry(tRow).State == EntityState.Unchanged)
                        {
                            de.Entry(tRow).State = EntityState.Modified;
                        }
                        dataGridView1.Refresh();
                        label1.Visible = true;
                    }

                }
                if (dataGridView1.Columns[e.ColumnIndex] == датаColumn)
                {

                    клКалендарь.дата = tRow.дата_с;
                    клКалендарь.выбран = false;
                    календарь выборДаты = new календарь();
                    выборДаты.button3.Visible = false;
                    выборДаты.ShowDialog();
                    if (клКалендарь.выбран)
                    {
                        tRow.дата_с = клКалендарь.дата.Value;
                        label1.Visible = true;
                        dataGridView1.Refresh();
                    }

                }
            }
        }

        void повторы1клиента_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (label1.Visible)
            {
                try
                {
                    de.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Сбой записи" + ex.Message);
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
            клКлиент.выбран = false;
            выбор_клиента выборКлиента = new выбор_клиента();
            выборКлиента.ShowDialog();
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

                        повторы NewRow = new повторы();
                        NewRow.дата_с = DateTime.Today;
                        NewRow.клиент = клКлиент.клиент;
                        NewRow.мастер = клМастер.мастер;
                        NewRow.услуга = клУслуга.услуга;
                        NewRow.прим = "";
                        NewRow.подключение = Guid.NewGuid();

                        int строка = bindingSource1.Add(NewRow);
                        bindingSource1.Position = строка;



                    }
                }
            }
            dataGridView1.Focus();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
                bindingSource1.RemoveCurrent();
                bindingSource1.MoveLast();
            }
            dataGridView1.Focus();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            записать();

            повторы uRow = bindingSource1.Current as повторы;
            клУслуга.услуга = uRow.услуга;
            клУслуга.наимен = uRow.услуги.наимен;
            клКлиент.клиент = uRow.клиент;
            клКлиент.deRow = uRow.клиенты;
            клУслуга.deRow = uRow.услуги;
            клКлиент.фио = uRow.сотрудники.фио;


            оплаченные1просмотр формаОплатить = new оплаченные1просмотр();
            формаОплатить.Text = "Оплаты за " + клУслуга.наимен.Trim() + " " + клКлиент.фио;
            формаОплатить.ShowDialog();



            Cursor = Cursors.Default;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0 && de.повторы.Local.Any(n => n.в_задание))
            {
                повторы tRow = bindingSource1.Current as повторы;
               

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
                          
                            Table table1 = tables.ElementAt(0);
                            Table table2 = tables.ElementAt(1);

                       
                        string текст = "Задание на повторное подключение  ";
                          
                            клXML.ChangeTextInCell(table1, 0, 0, текст + "    " + DateTime.Today.ToLongDateString());

                            TableRow lastRow = table2.Elements<TableRow>().Last();

                           

                            int j = 0;

                            foreach (повторы kRow in de.повторы.Local
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
                           


                        }
                    }

                    catch
                    {
                        MessageBox.Show("Закройте файл Word...");
                        return;
                    }



                    клTemp.закрытьWord();


                    клXML.просмотрWord(tempFile);
               // }
            }
            else
            {
                MessageBox.Show("Выберите адреса для подключения");
            }
            dataGridView1.Focus();
            Cursor = Cursors.Default;

        }
    }
}
