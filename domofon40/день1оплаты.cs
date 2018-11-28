using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Word = Microsoft.Office.Interop.Word;
using System.IO;

namespace domofon40
{
    public partial class день1оплаты : Form
    {
        public день1оплаты()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de;
        //      List<temp> tempList ;
        List<temp> tempList = new List<temp>();
        List<temp2> temp2List = new List<temp2>();
        List<квитанция> квитанцияЛист = new List<квитанция>();
        private void день1оплаты_Load(object sender, EventArgs e)
        {
            de = new domofon14Entities();
            try
            {


                string curDir = System.IO.Directory.GetCurrentDirectory();

                string шаблон = curDir + @"\день1оплаты.sql";

                if (!System.IO.File.Exists(шаблон.ToString()))
                {
                    MessageBox.Show("Нет файла " + шаблон.ToString());
                    Cursor = Cursors.Default;
                    return;
                }
                StreamReader sr = new StreamReader(шаблон, Encoding.Default);

                string запрос = sr.ReadToEnd();
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("declare @сотрудник  uniqueidentifier ='" + клСотрудник.сотрудник.ToString() + "';");
                sb.AppendLine("declare @дата  datetime ='" + клКалендарь.дата.Value.ToShortDateString() + "';");
                sb.AppendLine(запрос);

                string sqlString = sb.ToString();
            //    MessageBox.Show(sqlString);


                tempList = de.Database.SqlQuery<temp>(sqlString).ToList();
                //tempList = de.Database.SqlQuery<temp>("день1оплаты @сотрудник= @p0, @дата = @p1", клСотрудник.сотрудник, клКалендарь.дата.Value).ToList();
            }
            catch (Exception ex)
            {
                //  tempList = new List<temp>();
                MessageBox.Show("Ошибка загрузки " + ex.Message);
            }


            bindingSource1.DataSource = tempList;
            bindingSource1.MoveLast();
            клСетка.задать_ширину(dataGridView1);
            заполнить2услуги();
            пересчет();
            dataGridView1.Focus();
            телефонTextBox.DataBindings.Add("Text", bindingSource1, "телефон");
            прим0TextBox.DataBindings.Add("Text", bindingSource1, "прим0");
            звонокTextBox.DataBindings.Add("Text", bindingSource1, "звонок");

            bindingSource1.PositionChanged += bindingSource1_PositionChanged;
            dataGridView1.CellMouseClick += dataGridView1_CellMouseClick;

            налTextBox.KeyPress += налTextBox_KeyPress;

            налTextBox.TextChanged += налTextBox_TextChanged;

            //прим0TextBox.Validated += Прим0TextBox_Validated;
            //телефонTextBox.Validated += ТелефонTextBox_Validated;
            temp.Moving += Temp_Moving;
            FormClosing += День1оплаты_FormClosing;

        }

        private void День1оплаты_FormClosing(object sender, FormClosingEventArgs e)
        {
            temp.Moving -= Temp_Moving;
        }

        private void Temp_Moving(temp obj)
        {
            //if (obj.поле == "прим")
            //{
            //    примечания[] aRows = de.примечания.Where(n => n.клиент == obj.клиент && n.услуга == obj.услуга).ToArray();
            //    foreach (примечания delRow in aRows)
            //    {
            //        de.примечания.Remove(delRow);
            //    }
            //    de.SaveChanges();

            //    if (obj.прим != null)
            //    {
            //        if (obj.прим.Trim() != String.Empty)
            //        {
            //            примечания newRow = new примечания()
            //            {
            //                клиент = obj.клиент,
            //                прим = obj.прим,
            //                услуга = obj.услуга
            //            };
            //            de.примечания.Add(newRow);

            //        }
            //    }
            //}
            if (obj.поле == "прим0")
            {
                клиенты kRow = de.клиенты.Single(n => n.клиент == obj.клиент);
                kRow.прим = obj.прим0;
            }

            if (obj.поле == "телефон")
            {
                клиенты kRow = de.клиенты.Single(n => n.клиент == obj.клиент);
                kRow.телефон = obj.телефон;
            }

            try
            {
                de.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сбой записи " + ex.Message);
            }

        }


        private void ТелефонTextBox_Validated(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
                temp tRow = bindingSource1.Current as temp;
                клиенты kRow = de.клиенты.Single(n => n.клиент == tRow.клиент);
                kRow.телефон = tRow.телефон;
                de.SaveChanges();
                tempList.FindAll(n => n.клиент == tRow.клиент).ForEach(n => n.телефон = tRow.телефон);
            }
        }

        private void Прим0TextBox_Validated(object sender, EventArgs e)
        {
            //  Console.WriteLine("Прим0TextBox_Validated");
            if (bindingSource1.Count > 0)
            {
                temp tRow = bindingSource1.Current as temp;
                клиенты kRow = de.клиенты.Single(n => n.клиент == tRow.клиент);
                kRow.прим = tRow.прим0;
                de.SaveChanges();
                tempList.FindAll(n => n.клиент == tRow.клиент).ForEach(n => n.прим0 = tRow.прим0);
            }

        }



        void обновить()
        {
            bindingSource1.PositionChanged -= bindingSource1_PositionChanged;
            de = new domofon14Entities();
            try
            {
                string sqlString = "exec все1оплаты @сотрудник='" + клСотрудник.сотрудник.ToString() + "'";
                tempList = de.Database.SqlQuery<temp>(sqlString).ToList();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            bindingSource1.DataSource = tempList;
            bindingSource1.MoveLast();
            заполнить2услуги();

            bindingSource1.PositionChanged += bindingSource1_PositionChanged;
        }

        void налTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            клKey.int_KeyPress(sender, e);
        }
        void налTextBox_TextChanged(object sender, EventArgs e)
        {
            int всего = 0;
            int наличными = 0;
            if (Int32.TryParse(налTextBox.Text, out наличными) && Int32.TryParse(textBox1.Text, out всего))
            {
                if (всего <= наличными)
                {
                    сдачаTextBox3.Text = (наличными - всего).ToString();
                }
                else
                {
                    сдачаTextBox3.Text = "";
                }
            }
            else
            {
                сдачаTextBox3.Text = "";
            }
            сдачаTextBox3.Refresh();
        }
        void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                temp tRow = bindingSource1.Current as temp;

                if (dataGridView1.Columns[e.ColumnIndex] == менеджерColumn)
                {
                    клСотрудник.сотрудник = tRow.сотрудник;
                    клСотрудник.выбран = false;
                    выбор_кассира выборКассира = new выбор_кассира();
                    выборКассира.ShowDialog();



                    if (клСотрудник.выбран)
                    {
                        tRow.сотрудник = клСотрудник.сотрудник;
                        tRow.менеджер = клСотрудник.deRow.фио;

                        dataGridView1.Refresh();
                        //label1.Visible = true;
                        //de.SaveChanges();
                        string sqlString = "update оплаты set сотрудник =@сотрудник where оплата =@оплата";
                        SqlParameter[] aPar = new SqlParameter[2];
                        aPar[0] = new SqlParameter("@сотрудник", tRow.сотрудник);
                        aPar[1] = new SqlParameter("@оплата", tRow.оплата);
                        try
                        {
                            int строк = de.Database.ExecuteSqlCommand(sqlString, aPar);
                            if (строк < 1)
                            {
                                MessageBox.Show("Ошибка записи " + строк.ToString());
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }

                }


                if (dataGridView1.Columns[e.ColumnIndex] == вид_оплатыColumn)
                {
                    клВид_оплаты.вид_оплаты = tRow.вид_оплаты;
                    клВид_оплаты.выбран = false;
                    выбор_вида_оплат выборКассира = new выбор_вида_оплат();
                    выборКассира.ShowDialog();



                    if (клВид_оплаты.выбран || выборКассира.DialogResult== DialogResult.OK)
                    {
                        tRow.вид_оплаты = клВид_оплаты.вид_оплаты;
                        tRow.наимен_вида = клВид_оплаты.deRow.наимен;

                        dataGridView1.Refresh();
                        //label1.Visible = true;
                        //de.SaveChanges();
                        string sqlString = "update оплаты set вид_оплаты =@вид_оплаты where оплата =@оплата";
                        SqlParameter[] aPar = new SqlParameter[2];
                        aPar[0] = new SqlParameter("@вид_оплаты", tRow.вид_оплаты);
                        aPar[1] = new SqlParameter("@оплата", tRow.оплата);
                        try
                        {
                            int строк = de.Database.ExecuteSqlCommand(sqlString, aPar);
                            if (строк < 1)
                            {
                                MessageBox.Show("Ошибка записи " + строк.ToString());
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }

                }
                if (dataGridView1.Columns[e.ColumnIndex] == датаColumn)
                {

                    клКалендарь.дата = tRow.дата;
                    клКалендарь.выбран = false;
                    календарь выборДаты = new календарь();
                    выборДаты.button3.Visible = false;
                    выборДаты.ShowDialog();
                    if (клКалендарь.выбран)
                    {
                        tRow.дата = клКалендарь.дата.Value;
                        label1.Visible = true;
                        dataGridView1.Refresh();
                        //  de.SaveChanges();

                        string sqlString = "update оплаты set дата =@дата where оплата =@оплата";
                        SqlParameter[] aPar = new SqlParameter[2];
                        aPar[0] = new SqlParameter("@дата", tRow.дата);
                        aPar[1] = new SqlParameter("@оплата", tRow.оплата);
                        try
                        {
                            int строк = de.Database.ExecuteSqlCommand(sqlString, aPar);
                            if (строк < 1)
                            {
                                MessageBox.Show("Ошибка записи " + строк.ToString());
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }

                }
            }
        }


        void bindingSource1_PositionChanged(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
                заполнить2услуги();
                пересчет();
            }
        }
        void пересчет()
        {
            if (bindingSource1.Count > 0)
            {
                int сумма = 0;
                temp tRow = bindingSource1.Current as temp;
                сумма = tempList.Where(n => n.дата == tRow.дата).Sum(n => n.оплатить);
                textBox2.Text = сумма.ToString();
            }
        }



        class temp2
        {
            public Guid услуга { get; set; }
            public string наимен { get; set; }
            public int месяцев { get; set; }
            public int сумма { get; set; }
            public string договор { get; set; }


        }

        class temp
        {
            public Guid оплата { get; set; }
            public int номер { get; set; }
            public Guid клиент { get; set; }
            public DateTime дата { get; set; }
            public Guid сотрудник { get; set; }
            public string адрес { get; set; }
            public string фио { get; set; }
            public int оплатить { get; set; }
            public string менеджер { get; set; }
          //  public string прим0 { get; set; }
          //  public string телефон { get; set; }
            public DateTime? звонок { get; set; }
            public Guid вид_оплаты { get; set; }
            public string наимен_вида { get; set; }

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
            string Прим0;
            public string прим0
            {

                get
                {
                    return Прим0;
                }

                set
                {
                    Прим0 = value;
                    if (Moving != null)
                    {
                        поле = "прим0";
                        Moving(this);
                    }


                }

            }
            string Телефон;
            public string телефон
            {
                get
                {
                    return Телефон;
                }
                set
                {
                    Телефон = value;
                    if (Moving != null)
                    {
                        поле = "телефон";
                        Moving(this);
                    }
                }
            }

            public string поле { get; set; }
            public static event Action<temp> Moving;

        }

        class квитанция
        {
            public Guid услуга { get; set; }
            public string наимен_услуги { get; set; }
            public int тариф { get; set; }
            public string месяцы { get; set; }
            public int сумма { get; set; }
            public int год { get; set; }
            public string начало { get; set; }
            public string конец { get; set; }
            public string период { get; set; }
            public int зарплата { get; set; }
            public int материалы { get; set; }
            public int наряд { get; set; }
            public string прейскурант { get; set; }
            public string фио_мастера { get; set; }

        }


        private void заполнить_услуги()
        {
            int мСумма = 0;
            temp2List.Clear();
            if (bindingSource1.Count > 0)
            {
                try
                {
                    temp uRow = (temp)bindingSource1.Current;


                    List<temp2> query = de.оплачено
                        .Where(n => n.оплата == uRow.оплата)
                        .OrderBy(n => n.услуги.порядок)
                       .GroupBy(n => n.услуги)
                       .Select(n => new temp2
                       {
                           услуга = n.Key.услуга,
                           наимен = n.Key.наимен,
                           месяцев = n.Count(),
                           сумма = n.Sum(p => p.сумма)
                       }).ToList();

                    List<temp2> query2 = de.опл_работы
                         .Where(n => n.оплата == uRow.оплата)
                         .OrderBy(n => n.работы.порядок)
                         .Select(n => new temp2
                         {
                             услуга = n.работа,
                             наимен = n.работы.наимен,
                             месяцев = 0,
                             сумма = (int)n.стоимость,
                             договор = n.сотрудники.фио
                         }).ToList();

                    List<temp2> query3 = de.возврат
                     .Where(n => n.оплата == uRow.оплата)
                     .OrderBy(n => n.услуги.порядок)
                    .GroupBy(n => n.услуги)
                    .Select(n => new temp2
                    {
                        услуга = n.Key.услуга,
                        наимен = " Возврат " + n.Key.наимен,
                        месяцев = n.Count(),
                        сумма = n.Sum(p => -p.сумма)
                    }).ToList();

                    Guid КодКлиента2 = uRow.клиент;



                    foreach (temp2 newRow in query)
                    {
                        temp2List.Add(newRow);
                    }
                    foreach (temp2 newRow in query2)
                    {
                        temp2List.Add(newRow);
                    }
                    foreach (temp2 newRow in query3)
                    {
                        temp2List.Add(newRow);
                    }


                    //temp2List = query.Concat(query2).ToList();
                    if (temp2List.Any())
                    {
                        мСумма = temp2List.Sum(n => n.сумма);
                    }




                    if (uRow.оплатить != мСумма)
                    {
                        uRow.оплатить = мСумма;
                    }




                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка " + ex.Message);

                }
            }
            textBox1.Text = мСумма.ToString();
            bindingSource2.DataSource = null;
            bindingSource2.DataSource = temp2List;
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = bindingSource2;
            bindingSource2.MoveLast();
            dataGridView2.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
                temp uRow = bindingSource1.Current as temp;
                Guid кодОплаты = uRow.оплата;
                DialogResult xy = MessageBox.Show("Удалить оплату   " + uRow.адрес, uRow.фио, MessageBoxButtons.YesNo);
                if (xy == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        de.Database.ExecuteSqlCommand("delete from оплаты where оплата=@p0", uRow.оплата);
                        bindingSource1.RemoveCurrent();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка удаления " + ex.Message);
                    }
                }

            }
            dataGridView1.Focus();

        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
                //   записать();
                temp uRow = bindingSource1.Current as temp;
                клОплата.оплата = uRow.оплата;
                клОплата.дата = uRow.дата;
                клОплата.номер = uRow.номер;
                клОплата.deRow = de.оплаты.Single(n => n.оплата == клОплата.оплата);
                клКлиент.клиент = uRow.клиент;
                клУслуга.выбран = false;
                int строка = bindingSource1.Position;
                выбор4услуги выборУслуги = new выбор4услуги();
                выборУслуги.ShowDialog();
                if (клУслуга.выбран)
                {
                    Cursor = Cursors.WaitCursor;
                    возврат1месяца оплаченыеМесяца = new возврат1месяца();
                    оплаченыеМесяца.Text = "Возврат " + клУслуга.deRow.наимен + " " + uRow.адрес;
                    оплаченыеМесяца.ShowDialog();

                    заполнить2услуги();
                    пересчет();
                    dataGridView1.Refresh();
                    Cursor = Cursors.Default;
                }

            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {

                temp uRow = bindingSource1.Current as temp;
                клОплата.оплата = uRow.оплата;
                клОплата.дата = uRow.дата;
                клОплата.номер = uRow.номер;
                клОплата.выбран = false;
                клОплата.сотрудник = uRow.сотрудник;
                клКлиент.клиент = uRow.клиент;

                Cursor = Cursors.WaitCursor;
                опл1работ оплатаРабот = new опл1работ();

                оплатаРабот.Text = "Оплаты за работы " + клКлиент.фио;
                оплатаРабот.ShowDialog();
                if (клОплата.выбран)
                {
                    заполнить2услуги();
                    пересчет();
                    dataGridView1.Refresh();
                }
                Cursor = Cursors.Default;
            }
            dataGridView1.Focus();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
                temp uRow = bindingSource1.Current as temp;
                клОплата.оплата = uRow.оплата;
                клОплата.дата = uRow.дата;
                клОплата.номер = uRow.номер;
                клОплата.deRow = de.оплаты.Single(n => n.оплата == клОплата.оплата);
                клКлиент.клиент = uRow.клиент;
                клУслуга.выбран = false;
                выбор4услуги выборУслуги = new выбор4услуги();
                выборУслуги.ShowDialog();
                if (клУслуга.выбран)
                {
                    Cursor = Cursors.WaitCursor;
                    оплаченые1месяца оплаченыеМесяца = new оплаченые1месяца();
                    оплаченыеМесяца.ShowDialog();
                    заполнить2услуги();
                    пересчет();
                    dataGridView1.Refresh();
                    Cursor = Cursors.Default;
                }
            }
            dataGridView1.Focus();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
                temp uRow = bindingSource1.Current as temp;
           
                int строка = bindingSource1.Position;
                клПериод.дата_с = uRow.дата;
                клПериод.дата_по = uRow.дата;
                Cursor = Cursors.WaitCursor;

                выбор_реестра формаОтчет = new выбор_реестра();
                формаОтчет.Text = "Отчет за " + клПериод.дата_с.ToLongDateString();
                формаОтчет.ShowDialog();
                Cursor = Cursors.Default;

            }
            dataGridView1.Focus();


            //if (bindingSource1.Count > 0)
            //{
            //    temp uRow = bindingSource1.Current as temp;
            //    клОплата.оплата = uRow.оплата;
            //    клОплата.deRow = de.оплаты.Single(n => n.оплата == клОплата.оплата);
            //    клКлиент.клиент = uRow.клиент;

            //    клУслуга.выбран = false;
            //    int строка = bindingSource1.Position;

            //    клРеестр.дата = uRow.дата.Date;
            //    клРеестр.фио_менеджера = uRow.менеджер;
            //    клРеестр.вид_оплаты = uRow.вид_оплаты;
            //    клРеестр.наименВидаОплаты = uRow.наимен_вида;
            //    клРеестр.выбран = false;
            //    клВид_услуги.выбран = false;
            //    выбор_вида_услуги выборВида = new выбор_вида_услуги();
            //    выборВида.ShowDialog();
            //    if (клВид_услуги.выбран)
            //    {
            //        выбор_вида_оплат видаОплат = new выбор_вида_оплат();
            //        видаОплат.ShowDialog();
            //        if (видаОплат.DialogResult == DialogResult.OK)
            //        {
            //            клРеестр.вид_оплаты = клВид_оплаты.вид_оплаты;
            //            клРеестр.наименВидаОплаты = клВид_оплаты.наимен;
            //            Cursor = Cursors.WaitCursor;
            //            реестр_услуг формаРеестр = new реестр_услуг();
            //            формаРеестр.Text = "Реестр за " + клРеестр.дата.ToLongDateString() + "  ";
            //            формаРеестр.Text += " " + клВид_услуги.наимен.Trim();
            //            формаРеестр.Text += " " + клРеестр.наименВидаОплаты.Trim();

            //            string наименФилиала = de.филиалы
            //                .OrderBy(n => n.порядок)
            //                .First().наимен;
            //            формаРеестр.Text += " по филиалу " + наименФилиала;

            //            формаРеестр.ShowDialog();
            //            Cursor = Cursors.Default;
            //        }
            //    }
            //}

        }

        private void button8_Click(object sender, EventArgs e)
        {
            temp uRow = bindingSource1.Current as temp;

            клОплата.оплата = uRow.оплата;
            de = new domofon14Entities();

            //        domofon10.DataClasses1DataContext db1 = new DataClasses1DataContext();

            //int номерКвитанции = 0;
            //if (db1.опл_работы
            //    .Any(n => n.оплата == клОплата.оплата))
            //{
            //    номерКвитанции = db1.опл_работы
            //    .Where(n => n.оплата == клОплата.оплата)
            //    .Max(n => n.код);
            //}

            //        var yRow = db1.опл_работы
            //.Where(n => n.оплата == клОплата.оплата)
            //.GroupBy(n => n.работа1)
            //.Select(n => new { n.Key, цена = n.Max(z => z.стоимость), сумма = n.Sum(z => z.оплачено) });

            var query = de.опл_работы
     .Where(n => n.оплата == клОплата.оплата)
     .OrderBy(n => n.работы.порядок);

            квитанцияЛист.Clear();

            foreach (var kRow in query)
            {
                квитанция NewRow = new квитанция();
                NewRow.услуга = kRow.работа;
                NewRow.наимен_услуги = kRow.работы.наимен.Trim();
                NewRow.прейскурант = kRow.работы.прейскурант.Trim();
                NewRow.сумма = kRow.стоимость;
                NewRow.материалы = (int)kRow.ст_материалов;
                NewRow.зарплата = (int)NewRow.сумма - NewRow.материалы;
                NewRow.фио_мастера = kRow.сотрудники.фио;
                квитанцияЛист.Add(NewRow);
            }


            Word.Application oWord = new Word.Application();

            string curDir = System.IO.Directory.GetCurrentDirectory();

            object шаблон = curDir + @"\квитанция3работы.dot";
            if (!System.IO.File.Exists(шаблон.ToString()))
            {
                MessageBox.Show("Нет файла " + шаблон.ToString());
                return;
            }

            клФирма.init();
            клФилиал.init();

            Word.Document o = oWord.Documents.Add(Template: шаблон);
            o.Bookmarks["менеджер"].Range.Text = uRow.менеджер;
            o.Bookmarks["менеджер2"].Range.Text = uRow.менеджер;

            o.Bookmarks["дата"].Range.Text = uRow.дата.ToLongDateString();
            o.Bookmarks["дата2"].Range.Text = uRow.дата.ToLongDateString();

            o.Bookmarks["филиал"].Range.Text = клФилиал.наимен;
            o.Bookmarks["адрес_филиала"].Range.Text = клФилиал.адрес.Trim();
            o.Bookmarks["телефон_филиала"].Range.Text = клФилиал.deRow.телефон.Trim();

            o.Bookmarks["филиал2"].Range.Text = клФилиал.наимен;
            o.Bookmarks["адрес2филиала"].Range.Text = клФилиал.адрес.Trim();
            o.Bookmarks["телефон2филиала"].Range.Text = клФилиал.deRow.телефон.Trim();


            o.Bookmarks["номер_квитанции"].Range.Text = uRow.номер.ToString();
            o.Bookmarks["номер2квитанции"].Range.Text = uRow.номер.ToString();

            o.Bookmarks["фио"].Range.Text = uRow.фио;


            o.Bookmarks["адрес"].Range.Text = uRow.адрес;

            o.Bookmarks["фио2"].Range.Text = uRow.фио;
            o.Bookmarks["адрес2"].Range.Text = uRow.адрес;

            o.Bookmarks["наимен_фирмы"].Range.Text = клФирма.deRow.наимен.Trim();
            o.Bookmarks["наимен2фирмы"].Range.Text = клФирма.deRow.наимен.Trim();
            o.Bookmarks["инн"].Range.Text = "ИНН " + клФирма.deRow.инн.Trim();
            o.Bookmarks["инн2"].Range.Text = "ИНН " + клФирма.deRow.инн.Trim();
            o.Bookmarks["кпп"].Range.Text = "КПП " + клФирма.deRow.код.Trim();
            o.Bookmarks["кпп2"].Range.Text = "КПП " + клФирма.deRow.код.Trim();
            o.Bookmarks["расчетный_счет"].Range.Text = "р/с " + клФирма.deRow.р_счет.Trim();
            o.Bookmarks["расчетный2счет"].Range.Text = "р/с " + клФирма.deRow.р_счет.Trim();
            o.Bookmarks["наимен_банка"].Range.Text = " " + клФирма.deRow.банк.Trim();
            o.Bookmarks["наимен2банка"].Range.Text = " " + клФирма.deRow.банк.Trim();
            o.Bookmarks["город"].Range.Text = клФирма.deRow.город.Trim();
            o.Bookmarks["город2"].Range.Text = клФирма.deRow.город.Trim();
            o.Bookmarks["кор_счет"].Range.Text = "к/с " + клФирма.deRow.к_счет.Trim();
            o.Bookmarks["кор2счет"].Range.Text = "к/с " + клФирма.deRow.к_счет.Trim();
            o.Bookmarks["адрес_фирмы"].Range.Text = клФирма.deRow.адрес.Trim();
            o.Bookmarks["адрес2фирмы"].Range.Text = клФирма.deRow.адрес.Trim();


            int j = 1;
            decimal итого = 0;
            foreach (квитанция kRow in квитанцияЛист)
            {
                j++;
                o.Tables[5].Cell(j, 1).Range.Text = kRow.наряд.ToString("0;#;#");

                o.Tables[5].Cell(j, 2).Range.Text = kRow.прейскурант;
                o.Tables[5].Cell(j, 3).Range.Text = kRow.наимен_услуги.Trim() + "  мастер " + kRow.фио_мастера.Trim();
                //  o.Tables[5].Cell(j, 4).Range.Text = kRow.материалы.ToString("0.00;#;#");
                o.Tables[5].Cell(j, 4).Range.Text = kRow.сумма.ToString("0.00;#;#");
                o.Tables[5].Rows.Add();
                итого += kRow.сумма;

                o.Tables[11].Cell(j, 1).Range.Text = kRow.наряд.ToString("0;#;#");

                o.Tables[11].Cell(j, 2).Range.Text = kRow.прейскурант;
                o.Tables[11].Cell(j, 3).Range.Text = kRow.наимен_услуги.Trim() + "  мастер " + kRow.фио_мастера.Trim();
                o.Tables[11].Cell(j, 4).Range.Text = kRow.материалы.ToString("0.00;#;#");
                o.Tables[11].Cell(j, 5).Range.Text = kRow.сумма.ToString("0.00;#;#");
                o.Tables[11].Rows.Add();
            }
            o.Tables[5].Cell(j + 1, 4).Range.Text = итого.ToString("0.00");
            o.Tables[11].Cell(j + 1, 5).Range.Text = итого.ToString("0.00");


            клTemp.Caption = o.ActiveWindow.Caption;
            oWord.Application.Visible = true;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
                temp uRow = bindingSource1.Current as temp;
                клОплата.оплата = uRow.оплата;
                //   domofon10.DataClasses1DataContext db1 = new DataClasses1DataContext();
                de = new domofon14Entities();

                string[] aMez = de.месяцы
                   .OrderBy(n => n.месяц)
                   .Select(n => n.наимен)
                   .ToArray();

                var услугиQuery = de.оплачено
                        .Where(n => n.оплата == клОплата.оплата)
                        .GroupBy(n => new { n.услуги, n.год, n.сумма })
                        .Select(n => new
                        {
                            n.Key.услуги,
                            n.Key.услуги.наимен,
                            n.Key.услуги.порядок,
                            цена = n.Key.сумма,
                            сумма = n.Sum(p => p.сумма),
                            n.Key.год,
                            minMez = n.Min(p => p.месяц),
                            maxMez = n.Max(p => p.месяц)
                        })
                        .OrderBy(n => n.порядок);




                //dsТабель1.квитанция.Clear();
                квитанцияЛист.Clear();
                foreach (var kRow in услугиQuery)
                {
                    //  dsТабель1.за_месяца.Clear();
                    //           за_месяцЛист.Clear();

                    //                dsТабель.квитанцияRow NewRow = dsТабель1.квитанция.NewквитанцияRow();
                    квитанция NewRow = new квитанция();


                    NewRow.услуга = kRow.услуги.услуга;
                    NewRow.наимен_услуги = kRow.наимен;
                    NewRow.тариф = kRow.цена;
                    NewRow.месяцы = "";
                    NewRow.начало = aMez[kRow.minMez - 1];
                    if (kRow.maxMez > kRow.minMez)
                    {
                        NewRow.конец = aMez[kRow.maxMez - 1];
                    }
                    NewRow.сумма = kRow.сумма;
                    NewRow.год = kRow.год;
                    квитанцияЛист.Add(NewRow);

                    //dsТабель1.квитанция.Rows.Add(NewRow);
                }


                Word.Application oWord = new Word.Application();

                string curDir = System.IO.Directory.GetCurrentDirectory();

                object шаблон = curDir + @"\квитанция.dot";
                if (!System.IO.File.Exists(шаблон.ToString()))
                {
                    MessageBox.Show("Нет файла " + шаблон.ToString());
                    return;
                }


                клФирма.init();
                клФилиал.init();

                Word.Document o = oWord.Documents.Add(Template: шаблон);
                //  oWord.Application.Visible = true;
                o.Bookmarks["вид_оплаты"].Range.Text = uRow.наимен_вида;
                o.Bookmarks["вид_оплаты2"].Range.Text = uRow.наимен_вида;

                o.Bookmarks["менеджер"].Range.Text = uRow.менеджер;
                o.Bookmarks["менеджер2"].Range.Text = uRow.менеджер;

                o.Bookmarks["дата"].Range.Text = uRow.дата.ToLongDateString();
                o.Bookmarks["дата2"].Range.Text = uRow.дата.ToLongDateString();

                o.Bookmarks["филиал"].Range.Text = клФилиал.наимен;
                o.Bookmarks["адрес_филиала"].Range.Text = клФилиал.адрес.Trim();
                o.Bookmarks["телефон_филиала"].Range.Text = клФилиал.deRow.телефон.Trim();

                o.Bookmarks["филиал2"].Range.Text = клФилиал.наимен;
                o.Bookmarks["адрес2филиала"].Range.Text = клФилиал.адрес.Trim();
                o.Bookmarks["телефон2филиала"].Range.Text = клФилиал.deRow.телефон.Trim();


                o.Bookmarks["номер_квитанции"].Range.Text = uRow.номер.ToString();
                o.Bookmarks["номер2квитанции"].Range.Text = uRow.номер.ToString();

                o.Bookmarks["фио"].Range.Text = uRow.фио;
                //string адрес_абонента = "ул. " + uRow.наимен_улицы.Trim()
                //    + "   д. " + uRow.номер_дома.Trim() + " "
                //    + uRow.корпус.Trim()
                //    + " кв. " + uRow.квартира.Trim();
                string адрес_абонента = uRow.адрес;

                //if (uRow.ввод > 0)
                //{
                //    адрес_абонента += " ввод " + uRow.клиенты.ввод.ToString();
                //}

                o.Bookmarks["адрес"].Range.Text = адрес_абонента;

                o.Bookmarks["фио2"].Range.Text = uRow.фио;
                o.Bookmarks["адрес2"].Range.Text = адрес_абонента;

                o.Bookmarks["наимен_фирмы"].Range.Text = клФирма.deRow.наимен.Trim();
                o.Bookmarks["наимен2фирмы"].Range.Text = клФирма.deRow.наимен.Trim();
                o.Bookmarks["инн"].Range.Text = "ИНН " + клФирма.deRow.инн.Trim();
                o.Bookmarks["инн2"].Range.Text = "ИНН " + клФирма.deRow.инн.Trim();
                o.Bookmarks["кпп"].Range.Text = "КПП " + клФирма.deRow.код.Trim();
                o.Bookmarks["кпп2"].Range.Text = "КПП " + клФирма.deRow.код.Trim();
                o.Bookmarks["расчетный_счет"].Range.Text = "р/с " + клФирма.deRow.р_счет.Trim();
                o.Bookmarks["расчетный2счет"].Range.Text = "р/с " + клФирма.deRow.р_счет.Trim();
                o.Bookmarks["наимен_банка"].Range.Text = " " + клФирма.deRow.банк.Trim();
                o.Bookmarks["наимен2банка"].Range.Text = " " + клФирма.deRow.банк.Trim();
                o.Bookmarks["город"].Range.Text = клФирма.deRow.город.Trim();
                o.Bookmarks["город2"].Range.Text = клФирма.deRow.город.Trim();
                o.Bookmarks["кор_счет"].Range.Text = "к/с " + клФирма.deRow.к_счет.Trim();
                o.Bookmarks["кор2счет"].Range.Text = "к/с " + клФирма.deRow.к_счет.Trim();
                o.Bookmarks["адрес_фирмы"].Range.Text = клФирма.deRow.адрес.Trim();
                o.Bookmarks["адрес2фирмы"].Range.Text = клФирма.deRow.адрес.Trim();


                int j = 1;
                decimal итого = 0;
                foreach (квитанция kRow in квитанцияЛист)
                {
                    string текст1 = kRow.начало + " - " + kRow.конец + " " + kRow.год.ToString();
                    j++;
                    o.Tables[5].Cell(j, 1).Range.Text = kRow.наимен_услуги;
                    o.Tables[5].Cell(j, 2).Range.Text = kRow.тариф.ToString("0.00;#;#");
                    o.Tables[5].Cell(j, 3).Range.Text = текст1;
                    o.Tables[5].Cell(j, 4).Range.Text = kRow.сумма.ToString("0.00");
                    o.Tables[5].Rows.Add();
                    итого += kRow.сумма;

                    o.Tables[11].Cell(j, 1).Range.Text = kRow.наимен_услуги;
                    o.Tables[11].Cell(j, 2).Range.Text = kRow.тариф.ToString("0.00;#;#");
                    o.Tables[11].Cell(j, 3).Range.Text = текст1;
                    o.Tables[11].Cell(j, 4).Range.Text = kRow.сумма.ToString("0.00");
                    o.Tables[11].Rows.Add();
                }
                o.Tables[5].Cell(j + 1, 4).Range.Text = итого.ToString("0.00");
                o.Tables[11].Cell(j + 1, 4).Range.Text = итого.ToString("0.00");


                клTemp.Caption = o.ActiveWindow.Caption;
                oWord.Application.Visible = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            клКлиент.выбран = false;
            новый_клиент новыйКлиент = new новый_клиент();
            новыйКлиент.ShowDialog();
            Cursor = Cursors.Default;
            if (клКлиент.выбран)
            {
                виды_оплат vRow = de.виды_оплат.OrderBy(n => n.порядок).First();

                int maxNum = 0;
                if (de.оплаты.Count() > 0)
                {
                    maxNum = de.оплаты.Max(n => n.номер);
                }
                temp NewRow = new temp()
                {
                    дата = DateTime.Today,
                    клиент = клКлиент.клиент,
                    адрес = клКлиент.deRow.адрес,
                    фио = клКлиент.deRow.фио,
                    сотрудник = клСотрудник.сотрудник,
                    менеджер = клСотрудник.deRow.фио,
                    телефон = клКлиент.deRow.телефон,
                    прим0 = клКлиент.deRow.прим,
                    номер = maxNum + 1,
                    оплата = Guid.NewGuid(),
                    вид_оплаты = vRow.вид_оплаты,
                    наимен_вида = vRow.наимен,
                     
                };
                //temp NewRow = new temp();
                //NewRow.дата = DateTime.Today;
                //NewRow.клиент = клКлиент.клиент;
                //NewRow.адрес = клКлиент.deRow.адрес;
                //NewRow.фио = клКлиент.deRow.фио;
                //NewRow.сотрудник = клСотрудник.сотрудник;
                //NewRow.менеджер = клСотрудник.deRow.фио;
                //NewRow.телефон = клКлиент.deRow.телефон;
                //NewRow.прим0 = клКлиент.deRow.прим;
                //NewRow.номер = maxNum + 1;
                //NewRow.оплата = Guid.NewGuid();
                //NewRow.вид_оплаты = vRow.вид_оплаты;
                //NewRow.наимен_вида = vRow.наимен;

                int строка = bindingSource1.Add(NewRow);
                bindingSource1.Position = строка;


                string sqlString = "insert into  оплаты (оплата, номер , дата, клиент, сотрудник, вид_оплаты ) "
                    + " values( @оплата, @номер, @дата, @клиент, @сотрудник, @вид_оплаты )";

                SqlParameter[] aPar = new SqlParameter[6];
                aPar[0] = new SqlParameter("@оплата", NewRow.оплата);
                aPar[1] = new SqlParameter("@номер", NewRow.номер);
                aPar[2] = new SqlParameter("@дата", NewRow.дата);
                aPar[3] = new SqlParameter("@клиент", NewRow.клиент);
                aPar[4] = new SqlParameter("@сотрудник", NewRow.сотрудник);
                aPar[5] = new SqlParameter("@вид_оплаты", NewRow.вид_оплаты);

                try
                {
                    int строк = de.Database.ExecuteSqlCommand(sqlString, aPar);
                    if (строк < 1)
                    {
                        MessageBox.Show("Ошибка записи " + строк.ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            dataGridView1.Focus();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            temp uRow = bindingSource1.Current as temp;
            клКлиент.клиент = uRow.клиент;
            клКлиент.выбран = false;
            клКлиент.deRow = de.клиенты.Single(n => n.клиент == клКлиент.клиент);
            сведения_о_клиенте сведенияКлиента = new сведения_о_клиенте();
            сведенияКлиента.Text = "сведения о " + клКлиент.deRow.адрес + " " + uRow.фио;
            сведенияКлиента.ShowDialog();
            de = new domofon14Entities();
            клиенты kRow = de.клиенты.Single(n => n.клиент == клКлиент.клиент);
            foreach (temp tRow in tempList.Where(n => n.клиент == клКлиент.клиент))
            {
                tRow.фио = kRow.фио;
                tRow.прим0 = kRow.прим;
                tRow.телефон = kRow.телефон;
            }

            int строка = bindingSource1.Position;
            bindingSource1.MoveFirst();
            bindingSource1.Position = строка;

            телефонTextBox.Refresh();
            прим0TextBox.Refresh();
            dataGridView1.Focus();

        }

        private void button15_Click(object sender, EventArgs e)
        {
            клОплата.изменено = false;
            клУслуга.выбран = false;
            выбор_услуги ВыборУслуги = new выбор_услуги();
            ВыборУслуги.ShowDialog();
            if (клУслуга.выбран || ВыборУслуги.DialogResult== DialogResult.OK)
            {
                клМесяц.выбран = false;
                выбор_года ВыборГода = new выбор_года();
                ВыборГода.ShowDialog();
                if (клМесяц.выбран || ВыборГода.DialogResult== DialogResult.OK)
                {
                    клДом.выбран = false;
                    выбор_дома ВыборДома = new выбор_дома();
                    ВыборДома.ShowDialog();
                    if (клДом.выбран || ВыборДома.DialogResult== DialogResult.OK)
                    {
                        клПодъезд.выбран = false;
                        выбор_подъезда ВыборПодъезда = new выбор_подъезда();
                        ВыборПодъезда.ShowDialog();
                        if (клПодъезд.выбран || ВыборПодъезда.DialogResult== DialogResult.OK)
                        {
                            Cursor = Cursors.WaitCursor;
                            оплата_подъезда ОплатаПодъезда = new оплата_подъезда();
                            //      ОплатаПодъезда.dataSet1 = dataSet;
                            ОплатаПодъезда.Text = "Оплата подъезда " + клПодъезд.подъезд.ToString()
                            + " дом №" + клДом.deRow.номер.ToString()
                            + клДом.deRow.корпус
                            + " улица " + клДом.deRow.улицы.наимен;
                            ОплатаПодъезда.ShowDialog();

                            //                          обновить();
                            bindingSource1.MoveLast();
                            dataGridView1.Focus();


                            Cursor = Cursors.Default;
                        }
                    }
                }
            }

        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
                temp uRow = bindingSource1.Current as temp;
                клОплата.оплата = uRow.оплата;

                de = new domofon14Entities();


                Word.Application oWord = new Word.Application();

                string curDir = System.IO.Directory.GetCurrentDirectory();

                object шаблон = curDir + @"\расходник.dot";
                if (!System.IO.File.Exists(шаблон.ToString()))
                {
                    MessageBox.Show("Нет файла " + шаблон.ToString());
                    return;
                }

                клФирма.init();
                клФилиал.init();

                Word.Document o = oWord.Documents.Add(Template: шаблон);
                if (o.Bookmarks.Exists("кассир"))
                    o.Bookmarks["кассир"].Range.Text = uRow.менеджер;

                if (o.Bookmarks.Exists("дата"))
                    o.Bookmarks["дата"].Range.Text = uRow.дата.ToLongDateString();
                if (o.Bookmarks.Exists("филиал"))
                    o.Bookmarks["филиал"].Range.Text = клФилиал.наимен;

                //if (de.возврат.Any(n => n.оплата == клОплата.оплата))
                //{
                //    int СуммаВозврата = de.возврат
                //        .Where(n => n.оплата == клОплата.оплата)
                //        .Sum(n => n.сумма);

                //    o.Bookmarks["сумма"].Range.Text = СуммаВозврата.ToString();
                //}
                if (de.возврат.Any(n => n.оплата == клОплата.оплата) || de.воз_работы.Any(n => n.оплата == клОплата.оплата))
                {
                    int СуммаВозврата = de.возврат
                       .Where(n => n.оплата == клОплата.оплата)
                       .Sum(n => n.сумма);

                    int ВозвратРаботы = de.воз_работы
                       .Where(n => n.оплата == клОплата.оплата)
                       .Sum(n => n.сумма);

                    СуммаВозврата += ВозвратРаботы;

                    //  MessageBox.Show(прописью.буквами(СуммаВозврата));
                    if (o.Bookmarks.Exists("сумма"))
                        o.Bookmarks["сумма"].Range.Text = СуммаВозврата.ToString();
                    if (o.Bookmarks.Exists("выдано_прописью"))
                        o.Bookmarks["выдано_прописью"].Range.Text = прописью.буквами(СуммаВозврата) + "____";


                }


                if (o.Bookmarks.Exists("номер"))
                    o.Bookmarks["номер"].Range.Text = uRow.номер.ToString();
                if (o.Bookmarks.Exists("фио"))
                    o.Bookmarks["фио"].Range.Text = uRow.фио;

                oWord.Application.Visible = true;
                //}
                //else
                //{
                //    MessageBox.Show("В оплате нет возврата");
                //}
            }

        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
                temp uRow = bindingSource1.Current as temp;
                клРеестр.дата = uRow.дата;
                сумма_по_видам обзорФорма = new сумма_по_видам();
                обзорФорма.Text = "Суммы за " + клКалендарь.дата.Value.ToShortDateString() + "  " + клСотрудник.фио;
                обзорФорма.ShowDialog();
            }
            dataGridView1.Focus();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
                выбор_вида_оплат видыОплат = new выбор_вида_оплат();
                видыОплат.ShowDialog();
                if (видыОплат.DialogResult == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    temp uRow = bindingSource1.Current as temp;
                    клПериод.дата_с = uRow.дата;
                    клПериод.дата_по = uRow.дата;
                    реестр_работ формаАнализ = new реестр_работ();
                    формаАнализ.Text = "Реестр оплаченых работ за "
                        + клПериод.дата_с.ToLongDateString() + "  "
                        + клПериод.дата_по.ToLongDateString() + " менеджер  "
                        + клСотрудник.фио
                        + " вид оплаты " + клВид_оплаты.наимен;
                    формаАнализ.ShowDialog();
                    Cursor = Cursors.Default;
                }
            }
            dataGridView1.Focus();
        }

        private void заполнить2услуги()
        {
            int мСумма = 0;
            temp2List.Clear();

            if (bindingSource1.Count > 0)
            {
                try
                {

                    temp uRow = (temp)bindingSource1.Current;

                    string curDir = System.IO.Directory.GetCurrentDirectory();

                    string шаблон = curDir + @"\заполнить_услуги.sql";

                    if (!System.IO.File.Exists(шаблон.ToString()))
                    {
                        MessageBox.Show("Нет файла " + шаблон.ToString());
                        Cursor = Cursors.Default;
                        return;
                    }
                    StreamReader sr = new StreamReader(шаблон, Encoding.Default);

                    string запрос = sr.ReadToEnd();
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("declare @оплата  uniqueidentifier ='" + uRow.оплата.ToString() + "';");
                    sb.AppendLine(запрос);

                    string sqlString = sb.ToString();


                    temp2List = de.Database.SqlQuery<temp2>(sqlString).ToList();


                    //temp uRow = (temp)bindingSource1.Current;
                    //temp2List = de.Database.SqlQuery<temp2>("заполнить_услуги @оплата = @p0", uRow.оплата).ToList();

                    if (temp2List.Any())
                    {
                        мСумма = temp2List.Sum(n => n.сумма);
                    }

                    if (uRow.оплатить != мСумма)
                    {
                        uRow.оплатить = мСумма;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
            textBox1.Text = мСумма.ToString();
            bindingSource2.DataSource = null;
            bindingSource2.DataSource = temp2List;
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = bindingSource2;
            bindingSource2.MoveLast();
            dataGridView2.Refresh();
            налTextBox.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {

                temp uRow = bindingSource1.Current as temp;
                клОплата.оплата = uRow.оплата;
                клОплата.дата = uRow.дата;
                клОплата.номер = uRow.номер;
                клОплата.deRow = de.оплаты.Single(n => n.оплата == клОплата.оплата);
                клКлиент.клиент = uRow.клиент;
                клУслуга.выбран = false;
                int строка = bindingSource1.Position;
                Cursor = Cursors.WaitCursor;
                возврат1работ оплатаРабот = new возврат1работ();

                оплатаРабот.Text = $"Возвраты за работы {клКлиент.адрес}   {клКлиент.фио}";

                оплатаРабот.ShowDialog();
                if (клОплата.выбран)
                {
                    заполнить2услуги();
                    пересчет();
                    dataGridView1.Refresh();
                }
                Cursor = Cursors.Default;
            }
        }
    }

}
