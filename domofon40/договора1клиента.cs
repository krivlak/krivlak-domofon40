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

namespace domofon40
{
    public partial class договора1клиента : Form
    {
        public договора1клиента()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        //List<temp> tempList = new List<temp>();
        BindingList<подключения> подключенияЛист = new BindingList<подключения>();
    //   List<подключения> подключенияЛист = new List<подключения>();
        private void договора1клиента_Load(object sender, EventArgs e)
        {
            try
            {
                de.сотрудники.Load();
                de.услуги.Load();
                de.подключения
                   .Where(n => n.клиент == клКлиент.клиент)
                   .OrderBy(n => n.дата_дог)
                   .Load();

                подключенияЛист = de.подключения.Local.ToBindingList();
                //подключенияЛист = de.подключения
                //   .Where(n => n.клиент == клКлиент.клиент)
                //   .OrderBy(n => n.дата_дог)
                //   .ToList();

                bindingSource1.DataSource = подключенияЛист;
                bindingSource1.MoveLast();
                bindingSource1.ListChanged += bindingSource1_ListChanged;
                FormClosing += договора1клиента_FormClosing;
                dataGridView1.CellMouseClick += dataGridView1_CellMouseClick;
                клСетка.задать_ширину(dataGridView1);
            }
            catch
            {
                MessageBox.Show("Сбой загрузки..");
            }
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
                catch(Exception ex)
                {
                    MessageBox.Show("Сбой записи " + ex.Message);
                }
            }
        }

        void bindingSource1_ListChanged(object sender, ListChangedEventArgs e)
        {
            label1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            клУслуга.выбран = false;
            выбор_услуги ВыборУслуги = new выбор_услуги();
            ВыборУслуги.ShowDialog();
            if (клУслуга.выбран)
            {
                клМастер.выбран = false;
                выбор_бригады выборМастера = new выбор_бригады();
                выборМастера.ShowDialog();
                if (клМастер.выбран)
                {
                    int[] aa = new int[2];
                    aa[0] = 0;
                    aa[1] = 0;
                    int maxNum = 0;
                    if (de.подключения.Any())
                    {
                        maxNum = de.подключения.Max(n => n.номер_пп);
                        aa[0] = maxNum;
                    }
                    if (de.подключения.Local.Any())
                    {
                        maxNum = de.подключения.Local.Max(n => n.номер_пп);
                        aa[1] = maxNum;
                    }
                    maxNum = aa.Max();
                    
                    подключения NewRow = new подключения();
                    NewRow.дата_дог = DateTime.Today;
                    NewRow.дата_с = DateTime.Today;
                    NewRow.клиент = клКлиент.клиент;
                    NewRow.мастер = клМастер.мастер;
                    NewRow.номер_дог = "";
                    NewRow.номер_пп = maxNum+1;
                    NewRow.услуга = клУслуга.услуга;
                    NewRow.подключение = Guid.NewGuid();
                    int строка = bindingSource1.Add(NewRow);
                    bindingSource1.Position = строка;

                }
            }
        }

  //      public partial class temp
  //      {
  //          public System.Guid подключение { get; set; }
  //          public System.Guid клиент { get; set; }
  //          public System.DateTime дата_с { get; set; }
  ////          public Nullable<System.DateTime> дата_по { get; set; }
  //          public System.Guid услуга { get; set; }
  //     //     public string номер_дог { get; set; }
  //          public System.DateTime дата_дог { get; set; }
  //          public int номер_пп { get; set; }
  //          public System.Guid мастер { get; set; }

  //          public string фио_мастера  { get; set; }
  //          public string наимен_услуги { get; set; }
         
  //      }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count>0)
            {
             
                    bindingSource1.RemoveCurrent();
                    bindingSource1.MoveLast();
                    dataGridView1.Focus();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            клШаблон.выбран = false;
            выбор_шаблона выборШаблона = new выбор_шаблона();
            выборШаблона.ShowDialog();
            if (клШаблон.выбран)
            {

                //DataSet.подключенияRow uRow = (подключенияBindingSource.Current as DataRowView).Row as DataSet.подключенияRow;

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
                    o.Bookmarks["фио1"].Range.Text = " " + клКлиент.deRow.фамилия.Trim()
                    + " " + клКлиент.deRow.имя.Trim()
                    + " " + клКлиент.deRow.отчество.Trim();
                if (o.Bookmarks.Exists("фио2"))
                    o.Bookmarks["фио2"].Range.Text = " " + клКлиент.deRow.фамилия.Trim()
                    + " " + клКлиент.deRow.имя.Trim()
                    + " " + клКлиент.deRow.отчество.Trim();
                //string наименКорпуса = "";
                //if (uRow.корпус.Trim().Length == 0)
                //{
                //}
                //else
                //{
                //    наименКорпуса = " корпус " + uRow.корпус.Trim();
                //}
                if (o.Bookmarks.Exists("адрес1"))
                    o.Bookmarks["адрес1"].Range.Text = " " + клКлиент.deRow.адрес.Trim();
                //+ " дом " + uRow.номер.ToString().Trim()
                //+ наименКорпуса
                //+ " квартира " + uRow.квартира.ToString().Trim();

                if (o.Bookmarks.Exists("адрес2"))
                    o.Bookmarks["адрес2"].Range.Text = " " + клКлиент.deRow.адрес.Trim();
                //+ " дом " + uRow.номер.ToString().Trim()
                //+ наименКорпуса
                //+ " квартира " + uRow.квартира.ToString().Trim();

                if (o.Bookmarks.Exists("телефон1"))
                    o.Bookmarks["телефон1"].Range.Text = " " + клКлиент.deRow.телефон.Trim();
                if (o.Bookmarks.Exists("телефон2"))
                    o.Bookmarks["телефон2"].Range.Text = " " + клКлиент.deRow.телефон.Trim();

                клTemp.Caption = o.ActiveWindow.Caption;
                oWord.Application.Visible = true;
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {


                //                подключения uRow = bindingSource1.Current as подключения;

                Word.Application oWord = new Word.Application();

                string curDir = System.IO.Directory.GetCurrentDirectory();

                //object шаблон = curDir + @"\Договор_домофон.dot";
                string шаблон = curDir + @"\инструкция.dot";
                if (!System.IO.File.Exists(шаблон.ToString()))
                {
                    MessageBox.Show("Нет файла " + шаблон.ToString());
                    return;
                }

                Word.Document o = oWord.Documents.Add(Template: шаблон);
                oWord.Application.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сбой " + ex.Message);
            }
            dataGridView1.Focus();
        }
    }
}
