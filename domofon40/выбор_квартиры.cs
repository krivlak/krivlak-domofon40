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
    public partial class выбор_квартиры : Form
    {
        public выбор_квартиры()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        List<temp> tempList = new List<temp>();
        Dictionary<Guid, temp> dicTemp = new Dictionary<Guid, temp>();
        private void выбор_квартиры_Load(object sender, EventArgs e)
        {
            заполнить();
            treeView1.AfterSelect += treeView1_AfterSelect;

            прим0TextBox.Validated += Прим0TextBox_Validated;
            телефонTextBox.Validated += ТелефонTextBox_Validated;
            dataGridView1.DataError += DataGridView1_DataError;
            //     FormClosed += Выбор_квартиры_FormClosed;
            //         this.Deactivate += Выбор_квартиры_Deactivate;
            //       this.Activated += Выбор_квартиры_Activated;
            dataGridView1.CellValidated += DataGridView1_CellValidated;
        }

        private void DataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] == нашColumn)
            {
                temp obj = bindingSource1.Current as temp;
                try
                {
                    de.Database.ExecuteSqlCommand("delete from услуги_клиента where услуга=@p0 and клиент = @p1 ", obj.услуга, клКлиент.клиент);

                    if (obj.наш)
                    {
                        de.Database.ExecuteSqlCommand("insert into услуги_клиента (клиент,услуга) values( @p0,@p1)", клКлиент.клиент, obj.услуга);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Сбой записи наш " + ex.Message);
                }
            }
        
            if (dataGridView1.Columns[e.ColumnIndex]==примColumn)
            {
                temp tRow = bindingSource1.Current as temp;
                try
                {
                    de.Database.ExecuteSqlCommand("delete from примечания where услуга=@p0 and клиент = @p1 ", tRow.услуга, клКлиент.клиент);


                    if (tRow.прим != null)
                    {
                        if (tRow.прим.Trim() != String.Empty)
                        {

                            de.Database.ExecuteSqlCommand("insert into примечания (клиент,услуга,прим) values( @p0,@p1,@p2)", клКлиент.клиент, tRow.услуга, tRow.прим);
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Сбой записи прим " + ex.Message);
                }
            }
         //   Console.WriteLine("DataGridView1_CellValidated");
        }

        //private void Выбор_квартиры_Activated(object sender, EventArgs e)
        //{
        //    if(dataGridView1.Enabled)
        //    {
        //        temp.Moving += Temp_Moving;
        //    }
        //}

        //private void Выбор_квартиры_Deactivate(object sender, EventArgs e)
        //{
        //    temp.Moving -= Temp_Moving;
        //}

        //private void Выбор_квартиры_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    temp.Moving -= Temp_Moving;

        //}

        private void DataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex]==примColumn)
            {
                dataGridView1.Rows[e.RowIndex].Cells["примColumn"].Value = "";
            }
        }

        private void ТелефонTextBox_Validated(object sender, EventArgs e)
        {
            клКлиент.deRow.телефон = телефонTextBox.Text.Trim();
            de.Database.ExecuteSqlCommand("update клиенты set телефон= @p0 where клиент = @p1 ", телефонTextBox.Text.Trim(), клКлиент.клиент);
        }

        private void Прим0TextBox_Validated(object sender, EventArgs e)
        {
            клКлиент.deRow.прим = прим0TextBox.Text.Trim();
            de.Database.ExecuteSqlCommand("update клиенты set прим= @p0 where клиент = @p1 ", прим0TextBox.Text.Trim(), клКлиент.клиент);
        }
        void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
     //       temp.Moving -= Temp_Moving;
            очистить();
            panel1.Enabled = false;
            dataGridView1.Enabled = false;
            if (e.Node.Level == 3)
            {
                клКлиент.deRow = (клиенты)e.Node.Tag;
                клКлиент.клиент = клКлиент.deRow.клиент;
                клКлиент.фио = клКлиент.deRow.фио;
                сведения_клиента();
                panel1.Enabled = true;
                dataGridView1.Enabled = true;
            }
            dataGridView1.Refresh();
      //      temp.Moving += Temp_Moving;
            
        }

        //private void Temp_Moving(temp obj)
        //{
        //    if (obj.поле == "прим")
        //    {

        //        try
        //        {
        //            de.Database.ExecuteSqlCommand("delete from примечания where услуга=@p0 and клиент = @p1 ", obj.услуга, клКлиент.клиент);


        //            if (obj.прим != null)
        //            {
        //                if (obj.прим.Trim() != String.Empty)
        //                {

        //                    de.Database.ExecuteSqlCommand("insert into примечания (клиент,услуга,прим) values( @p0,@p1,@p2)", клКлиент.клиент, obj.услуга, obj.прим);
        //                }

        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Сбой записи прим " + ex.Message);
        //        }
        //    }

        //    if (obj.поле == "наш")
        //    {

        //        try
        //        {
        //            de.Database.ExecuteSqlCommand("delete from услуги_клиента where услуга=@p0 and клиент = @p1 ", obj.услуга, клКлиент.клиент);



        //            if (obj.наш)
        //            {

        //                de.Database.ExecuteSqlCommand("insert into услуги_клиента (клиент,услуга) values( @p0,@p1)", клКлиент.клиент, obj.услуга);
        //            }


        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Сбой записи наш " + ex.Message);
        //        }
        //    }

        //}
        void сведения_клиента()
        {
            Cursor = Cursors.WaitCursor;
            звонокTextBox.Text = "";
            if (de.звонки.Any(n => n.клиент == клКлиент.клиент))
            {
                звонокTextBox.Text = de.звонки.Where(n => n.клиент == клКлиент.клиент).Max(n => n.дата).ToShortDateString();
            }
            прим0TextBox.Text = клКлиент.deRow.прим.Trim();
            телефонTextBox.Text = клКлиент.deRow.телефон.Trim();

            tempList.Clear();
       //     string sqlString ="сведения_клиента @клиент='"+клКлиент.клиент.ToString()+"'";
            try
            {
                string curDir = System.IO.Directory.GetCurrentDirectory();

                string шаблон = curDir + @"\сведения_клиента.sql";

                if (!System.IO.File.Exists(шаблон.ToString()))
                {
                    MessageBox.Show("Нет файла " + шаблон.ToString());
                    Cursor = Cursors.Default;
                    return;
                }
                StreamReader sr = new StreamReader(шаблон, Encoding.Default);

                string запрос = sr.ReadToEnd();
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("declare @клиент  uniqueidentifier ='" + клКлиент.клиент.ToString() + "';");
                sb.AppendLine(запрос);

                string sqlString = sb.ToString();


                tempList = de.Database.SqlQuery<temp>(sqlString).ToList();

                //tempList = de.Database.SqlQuery<temp>("сведения_клиента @клиент= @p0 ", клКлиент.клиент).ToList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          

            bindingSource1.DataSource = tempList;
            dataGridView1.Refresh();
            dataGridView1.Focus();

            Cursor = Cursors.Default;
        }

       // private void заполнить_выбор()
       // {
       //     Cursor = Cursors.WaitCursor;
       //     //dsТабель1.выбор.Clear();
       //     tempList.Clear();

       //     прим0TextBox.Text = клКлиент.deRow.прим;

       //     foreach (услуги uRow in de.услуги.OrderBy(n => n.виды_услуг.порядок).ThenBy(n=>n.порядок))
       //     {
       //         //dsТабель.выборRow NewRow = dsТабель1.выбор.NewвыборRow();
       //         temp NewRow = new temp();
       //         NewRow.услуга = uRow.услуга;
       //         NewRow.наимен = uRow.наимен;
       //         if (uRow.клиенты.Any(n => n.клиент == клКлиент.клиент))
       //         {
       //             NewRow.наш = true;
       //         }

       //         if (uRow.примечания.Any(n => n.клиент == клКлиент.клиент))
       //         {
       //             NewRow.прим = uRow.примечания.Last(n => n.клиент == клКлиент.клиент).прим;
       //         }

       //         if (uRow.подключения.Any(n => n.клиент == клКлиент.клиент))
       //         {
       //             NewRow.договор_с = uRow.подключения
       //                 .Where(n => n.клиент == клКлиент.клиент)
       //                 .Max(n => n.дата_с);
       //         }

       //         if (uRow.отключения.Any(n => n.клиент == клКлиент.клиент))
       //         {
       //             NewRow.отключен = uRow.отключения
       //                 .Where(n => n.клиент == клКлиент.клиент)
       //                 .Max(n => n.дата_с);
       //         }

       //         if (uRow.повторы.Any(n => n.клиент == клКлиент.клиент))
       //         {
       //             NewRow.повторно = uRow.повторы
       //                               .Where(n => n.клиент == клКлиент.клиент)
       //                               .Max(n => n.дата_с);
       //         }
       //         if (uRow.льготы.Any(n => n.клиент == клКлиент.клиент))
       //         {
       //             NewRow.прим += " льгота с " + uRow.льготы
       //                  .Where(n => n.клиент == клКлиент.клиент)
       //                  .Max(n=>n.дата_с).ToShortDateString();
       //         }

       //         //int kk = db.услуги_клиента.Count(n => n.клиент == клКлиент.клиент && n.услуга == uRow.услуга1);
       //         //if (kk > 0)
       //         //    NewRow.подключена = true;

       //         tempList.Add(NewRow);
       //         //dsТабель1.выбор.Rows.Add(NewRow);
       //     }
       //     dicTemp = tempList.ToDictionary(n => n.услуга);


       //     //DateTime начало = de.начало.First().начало1;

       //     //var queryДни = de.раб_дней
       //     //    .Where(n => n.клиент == клКлиент.клиент)
       //     //    .Where(n => n.дней > 0)
       //     //.Where(n => n.год < начало.Year || (n.год == начало.Year && n.месяц < начало.Month))
       //     //    .GroupBy(n => n.услуга)
       //     //    .Select(n => new
       //     //    {
       //     //        услуга = n.Key,
       //     //        год100месяц = n.Min(g => g.год * 12 + g.месяц)
       //     //    });

       //     //foreach (var uRow in queryДни)
       //     //{
       //     //    int мГод = (int)(uRow.год100месяц - 2) / 12;
       //     //    int мМесяц = ((uRow.год100месяц - 1) - мГод * 12);
       //     //    dsТабель.выборRow tRow = dsТабель1.выбор.Single(n => n.услуга == uRow.услуга);
       //     //    tRow.год = мГод;
       //     //    tRow.месяц = мМесяц;
       //     //}



       //     var query = de.оплачено
       //         .Where(n => n.оплаты.клиент == клКлиент.клиент)
       //         .GroupBy(n => n.услуга)
       //         .Select(n => new
       //         {
       //             услуга = n.Key,
       //             год100месяц = n.Max(g => g.год * 100 + g.месяц)
       //         });
       //     foreach (var uRow in query)
       //     {
       //         int мГод = (int)uRow.год100месяц / 100;
       //         int мМесяц = (uRow.год100месяц - мГод * 100);
               
       //         if (dicTemp.ContainsKey(uRow.услуга))
       //         {
       //           temp  tRow = dicTemp[uRow.услуга];
       //           tRow.год = мГод;
       //           tRow.месяц = мМесяц;
       //         }
       ////         dsТабель.выборRow tRow = dsТабель1.выбор.Single(n => n.услуга == uRow.услуга);
               
       //     }
       //     if (de.звонки.Any(n=>n.клиент==клКлиент.клиент))
       //     {
       //         звонокTextBox.Text = de.звонки.Where(n => n.клиент == клКлиент.клиент).Max(n => n.дата).ToShortDateString();
       //     }
       //     прим0TextBox.Text = клКлиент.deRow.прим;

       //     bindingSource1.DataSource = tempList;
       //     dataGridView1.Refresh();
       //     dataGridView1.Focus();

       //     Cursor = Cursors.Default;

       // }


        
        private void заполнить()
        {
          //  treeView1.Nodes.Clear();
      //      DataClasses1DataContext db = new DataClasses1DataContext();
            //int j = 0;
            foreach (var gg in de.поселки.OrderBy(n => n.порядок))
            {
                //j++;
                TreeNode node = this.treeView1.Nodes.Add( gg.наимен);
                node.Tag = gg;

                foreach (var mm in gg.улицы.OrderBy(n => n.наимен))
                {
                    TreeNode node1 = node.Nodes.Add(mm.наимен);
                    node1.Tag = mm;
                    foreach (var dd in mm.дома
                        .OrderBy(n => n.номер)
                        .ThenBy(n => n.корпус))
                    {
                        TreeNode node2 = node1.Nodes.Add(dd.номер.ToString().Trim() + " " + dd.корпус.Trim());
                        node2.Tag = dd;
                        foreach (var kk in dd.клиенты
                            .OrderBy(n => n.квартира)
                            .ThenBy(n => n.ввод))
                        {
                            if (kk.ввод > 0)
                            {
                                TreeNode node3 = node2.Nodes.Add("кв. "
                              + kk.квартира.ToString().PadRight(3)
                              + " подк. " + kk.ввод.ToString().PadRight(3)
                              + kk.фамилия.Trim() + " "
                              + kk.имя.Trim() + " "
                              + kk.отчество.Trim());
                                node3.Tag = kk;
                                //if (kk.клиент == клКлиент.клиент)
                                //{
                                //    treeView1.SelectedNode = node3;
                                //}

                            }
                            else
                            {
                                TreeNode node3 = node2.Nodes.Add("кв. "
                                    + kk.квартира.ToString().PadRight(3) + " "
                                    + kk.фамилия.Trim() + " "
                                    + kk.имя.Trim() + " "
                                    + kk.отчество.Trim());
                                node3.Tag = kk;
                                //if (kk.клиент== клКлиент.клиент)
                                //{
                                //    treeView1.SelectedNode = node3;
                                //}
                            }
                        }
                    }
                }

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
   
            treeView1.CollapseAll();
            очистить();
        //    bindingSource1.DataSource = null;
           
            //treeView1.SelectedNode = treeView1.Nodes["1"];
      //      tempList.Clear();

            treeView1.Select();
         //   dataGridView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        void очистить()
        {
            bindingSource1.DataSource = null;
            звонокTextBox.Text = "";
            прим0TextBox.Text = "";
            panel1.Enabled = false;
        }
        class temp
        {
            public Guid услуга { get; set; }
            public string наимен { get; set; }
            public int год { get; set; }
            public int месяц { get; set; }
            public bool наш { get; set; }
            public DateTime? договор_с { get; set; }
            public DateTime? отключен { get; set; }
            public DateTime? повторно { get; set; }
            public string прим { get; set; }

            //bool Наш;
            //public bool наш
            //{
            //    get
            //    {
            //        return Наш;
            //    }
            //    set
            //    {
            //        Наш = value;
            //        if (Moving != null)
            //        {
            //            поле = "наш";
            //            Moving(this);
            //        }
            //    }
            //}

            //string Прим;
            //public string прим
            //{

            //    get
            //    {
            //        return Прим;
            //    }

            //    set
            //    {
            //        Прим = value;
            //        if (Moving != null)
            //        {
            //            поле = "прим";
            //            Moving(this);
            //        }


            //    }

            //}

            //public string поле { get; set; }
            //public static event Action<temp> Moving;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
   
            оплаты1клиент оплатыКлиента = new оплаты1клиент();
            оплатыКлиента.Text = "Оплаты " + клКлиент.deRow.адрес + " " + клКлиент.deRow.фио;
            оплатыКлиента.ShowDialog();

            сведения_клиента();
            treeView1.Focus();
            Cursor = Cursors.Default;
        }

        private void button4_Click(object sender, EventArgs e)
        {
          

            //оплаты uRow = bindingSource1.Current as оплаты;
            //клКлиент.клиент = uRow.клиент;
            клКлиент.выбран = false;
            сведения_о_клиенте сведенияКлиента = new сведения_о_клиенте();
            сведенияКлиента.Text = "сведения о " + клКлиент.deRow.адрес + " " + клКлиент.deRow.фио;
            сведенияКлиента.bindingSource1.DataSource = клКлиент.deRow;
            //  bindingSource1.DataSource = de.клиенты.Local.ToBindingList();
            сведенияКлиента.ShowDialog();
            
            сведения_клиента();

            if (клКлиент.выбран)
            {
                try
                {
                    de.SaveChanges();

                    

                    TreeNode node = treeView1.SelectedNode;
                    клиенты kk = клКлиент.deRow;
                    if (kk.ввод > 0)
                    {
                        node.Text = "кв. "
                                  + kk.квартира.ToString().PadRight(3)
                                  + " подк. " + kk.ввод.ToString().PadRight(3)+ " "
                                  + kk.фамилия.Trim() + " "
                                  + kk.имя.Trim() + " "
                                  + kk.отчество.Trim();
                    }
                    else
                    {
                        node.Text = "кв. "
                             + kk.квартира.ToString().PadRight(3)+" "
                             + kk.фамилия.Trim() + " "
                             + kk.имя.Trim() + " "
                             + kk.отчество.Trim();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
       
           
            treeView1.Focus();
            //клиенты kRow = de.клиенты.Local.Single(n => n.клиент == клКлиент.клиент);
            //de.Entry(kRow).Reload();
            //    de.Entry(uRow).Reload();
            //dataGridView1.Focus();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            клКалендарь.дата = DateTime.Today;
            клКалендарь.выбран = false;
            календарь выборДаты = new календарь();
            выборДаты.button3.Visible = false;
            выборДаты.button1.Text = "Выбор";
            выборДаты.ShowDialog();
            if (клКалендарь.выбран)
            {
                Cursor = Cursors.WaitCursor;

                клПериод.дата_с = клКалендарь.дата.Value;
                клПериод.дата_по = клКалендарь.дата.Value;

                выбор_реестра формаОтчет = new выбор_реестра();
                формаОтчет.Text = "Отчет за " + клПериод.дата_с.ToLongDateString();
                формаОтчет.ShowDialog();

                           }
            Cursor = Cursors.Default;

            //суммы1день суммыДень = new суммы1день();
            //суммыДень.Text = $"Суммы за день  {DateTime.Today.ToLongDateString()}   менеджер { клСотрудник.фио} ";
            //суммыДень.ShowDialog();
            //treeView1.Focus();

        }

        private void treeView1_AfterSelect_1(object sender, TreeViewEventArgs e)
        {

        }
    }
}
