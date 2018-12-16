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
        
        }

     

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
        }
     
    
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

     

        
        private void заполнить()
        {
       
            foreach (var gg in de.поселки.OrderBy(n => n.порядок))
            {
               
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
                              

                            }
                            else
                            {
                                TreeNode node3 = node2.Nodes.Add("кв. "
                                    + kk.квартира.ToString().PadRight(3) + " "
                                    + kk.фамилия.Trim() + " "
                                    + kk.имя.Trim() + " "
                                    + kk.отчество.Trim());
                                node3.Tag = kk;
                                
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
            treeView1.Select();
         
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
        
            клКлиент.выбран = false;
            сведения_о_клиенте сведенияКлиента = new сведения_о_клиенте();
            сведенияКлиента.Text = "сведения о " + клКлиент.deRow.адрес + " " + клКлиент.deRow.фио;
            сведенияКлиента.bindingSource1.DataSource = клКлиент.deRow;
            
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

           

        }


    }
}
