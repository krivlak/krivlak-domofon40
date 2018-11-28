using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Entity;
using System.IO;

namespace domofon40
{
    public partial class история_тарифов : Form
    {
        public история_тарифов()
        {
            InitializeComponent();
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
        }

        domofon40.domofon14Entities de = new domofon14Entities();
        List<temp> tempList = new List<temp>();
        private void история_тарифов_Load(object sender, EventArgs e)
        {
            try
            {
                string curDir = System.IO.Directory.GetCurrentDirectory();

                string шаблон = curDir + @"\ввод_тарифов.sql";

                if (!System.IO.File.Exists(шаблон.ToString()))
                {
                    MessageBox.Show("Нет файла " + шаблон.ToString());
                    Cursor = Cursors.Default;
                    return;
                }
                StreamReader sr = new StreamReader(шаблон, Encoding.Default);

                string запрос = sr.ReadToEnd();
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("declare @услуга  uniqueidentifier ='" + клУслуга.услуга.ToString() + "';");
                sb.AppendLine(запрос);

                string sqlString = sb.ToString();


                tempList = de.Database.SqlQuery<temp>(sqlString).ToList();

                //de.цены
                //    .Where(n => n.услуга == клУслуга.услуга)
                //    .Load();

                //      string команда = "ввод_тарифов @услуга ='" + клУслуга.услуга.ToString() + "'";
              //  tempList = de.Database.SqlQuery<temp>("ввод_тарифов @услуга = @p0", клУслуга.услуга).ToList();
                bindingSource1.DataSource = tempList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка соединения {ex.Message}");
            }
            int tgggg = DateTime.Today.Year;
            int tmm = DateTime.Today.Month;
            int строка = 0;
            try
            {
                строка = tempList.FindIndex(n => n.год == tgggg && n.месяц == tmm);
            }
            catch
            { }
            bindingSource1.Position = строка;
            int видна = dataGridView1.FirstDisplayedScrollingRowIndex;
          //  dataGridView1.FirstDisplayedScrollingRowIndex = видна + 12 - tmm;
            dataGridView1.FirstDisplayedScrollingRowIndex = строка - 12 ; // +- 12 строк видно
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
       //     bindingSource1.ListChanged += bindingSource1_ListChanged;
            dataGridView1.EditingControlShowing += dataGridView1_EditingControlShowing;
        //    FormClosing += ввод_тарифов_FormClosing;
            dataGridView1.CellEndEdit += DataGridView1_CellEndEdit;
        }

        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] == тарифColumn)
            {
                try
                {
                    записать_строку();
                    //temp tRow = bindingSource1.Current as temp;
                    //de.Database.ExecuteSqlCommand("delete from цены where год =@p0 and  месяц = @p1 and услуга =  @p2 ", tRow.год, tRow.месяц, клУслуга.услуга);
                    //if (tRow.тариф > 0)
                    //{
                    //    de.Database.ExecuteSqlCommand("insert into цены (год,месяц, услуга, стоимость) values( @p0 , @p1, @p2 , @p3)", tRow.год, tRow.месяц, клУслуга.услуга, tRow.тариф);
                    //}
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Сбой записи " + ex.Message);
                }
            }
        }

        //void ввод_тарифов_FormClosing(object sender, FormClosingEventArgs e)
        //{

        //    bindingSource1.EndEdit();
        //    dataGridView1.EndEdit();
        //    if (label1.Visible)
        //    {
        //        Cursor = Cursors.WaitCursor;
        //        //цены[] delRows = de.цены
        //        //    .Where(n => n.услуга == клУслуга.услуга)
        //        //    .ToArray();
        //        //de.цены.RemoveRange(delRows);

        //        de.цены.Local.Clear();

        //        foreach (temp tRow in tempList.Where(n => n.тариф > 0))
        //        {
        //            цены NewRow = new цены();
        //            NewRow.услуга = клУслуга.услуга;
        //            NewRow.год = tRow.год;
        //            NewRow.месяц = tRow.месяц;
        //            NewRow.стоимость = tRow.тариф;
        //            de.цены.Add(NewRow);
        //        }
        //        try
        //        {
        //            de.SaveChanges();
        //        }
        //        catch
        //        {
        //            MessageBox.Show("Сбой записи");
        //        }
        //        Cursor = Cursors.Default;
        //    }
        //}

        void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Control_KeyPress);
            string CellName = dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].Name;
            if (CellName == "тарифColumn")
            {
                e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
            }
        }
        void Control_KeyPress(object sender, KeyPressEventArgs pressE)
        {
            // только положительные
            клKey.int_KeyPress(sender, pressE);
        }

        //void bindingSource1_ListChanged(object sender, ListChangedEventArgs e)
        //{
        //    //   изменено = true;
        //    label1.Visible = true;
        //}

        void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int номерГода = (int)dataGridView1.Rows[e.RowIndex].Cells["годColumn"].Value;
            if (номерГода % 2 == 0)
            {
                e.CellStyle.ForeColor = Color.Blue;
            }
        }

        partial class temp
        {
            public int год { get; set; }
            public int месяц { get; set; }
            public string наимен { get; set; }
            public int тариф { get; set; }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            int новыйТариф =(int) numericUpDown1.Value;
            int строк = dataGridView1.SelectedRows.Count;
            if (новыйТариф >= 0)
            {

                if (dataGridView1.SelectedRows.Count > 0)
                {
                    System.Windows.Forms.DataGridViewRow[] sRow = new DataGridViewRow[строк];
                    dataGridView1.SelectedRows.CopyTo(sRow,0);
                    sRow = sRow.Reverse().ToArray();
                    int j = 0;
                    foreach (System.Windows.Forms.DataGridViewRow uRow in sRow)
                    {
                        j++;
                       
                        
                            dataGridView1.CurrentCell = dataGridView1.Rows[uRow.Index].Cells[2];
                            uRow.Cells["тарифColumn"].Value = новыйТариф;
                       // uRow.Cells["тарифColumn"].Value = j;
                        записать_строку();
                              
                        
                          //  tempList[uRow.Index].тариф = (int)numericUpDown1.Value;
                     //  }
                    }
                    dataGridView1.Refresh();
                    //    изменено = true;
                 //   label1.Visible = true;
                }
                else
                {
                    MessageBox.Show("Преварительно выберите строки с месяцами...");
                }
            }
            else
            {
                MessageBox.Show("Введите новый тариф ...");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        void записать_строку()
        {
            temp tRow = bindingSource1.Current as temp;
          
            de.Database.ExecuteSqlCommand("delete from цены where год =@p0 and  месяц = @p1 and услуга =  @p2 ", tRow.год, tRow.месяц, клУслуга.услуга);
            if (tRow.тариф > 0)
            {
                de.Database.ExecuteSqlCommand("insert into цены (год,месяц, услуга, стоимость) values( @p0 , @p1, @p2 , @p3)", tRow.год, tRow.месяц, клУслуга.услуга, tRow.тариф );
            }
        }
    }
}
