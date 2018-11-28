using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Entity;

namespace domofon40
{
    public partial class список_сотрудников : Form
    {
        public список_сотрудников()
        {
            InitializeComponent();
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
        }

        domofon40.domofon14Entities de = new domofon14Entities();
     
        BindingList<сотрудники> сотрудникиБинд = new BindingList<сотрудники>();
        private void список_сотрудников_Load(object sender, EventArgs e)
        {
            de.сотрудники
                .OrderBy(n => n.порядок)
                .Load();

            сотрудникиБинд = de.сотрудники.Local.ToBindingList();
            bindingSource1.DataSource = сотрудникиБинд;

            фамилияColumn.DefaultCellStyle.NullValue = "null";
            ОтчествоColumn.DefaultCellStyle.NullValue = "null";
            имяColumn.DefaultCellStyle.NullValue = "null";
            должностьColumn.DefaultCellStyle.NullValue = "null";
            фамилияColumn.DefaultCellStyle.DataSourceNullValue = "";
            имяColumn.DefaultCellStyle.DataSourceNullValue = "";
            ОтчествоColumn.DefaultCellStyle.DataSourceNullValue = "";

            bindingSource1.ListChanged += bindingSource1_ListChanged;
        //    сотрудникиБинд.ListChanged += сотрудникиБинд_ListChanged;
          
            FormClosing += список_сотрудников_FormClosing;
            dataGridView1.CellValidating += dataGridView1_CellValidating;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            dataGridView1.CellMouseClick += DataGridView1_CellMouseClick;
        }

        private void DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                сотрудники uRow = bindingSource1.Current as сотрудники;
                if (dataGridView1.Columns[e.ColumnIndex] == уволенColumn)
                {

                    клКалендарь.дата = uRow.уволен;
                    клКалендарь.выбран = false;
                    календарь выборДаты = new календарь();
                    //                    выборДаты.button3.Visible = false;
                    выборДаты.ShowDialog();
                    if (клКалендарь.выбран)
                    {
                        if (клКалендарь.isNull)
                        {
                            uRow.уволен = null;
                        }
                        else
                        {
                            uRow.уволен = клКалендарь.дата.Value;
                        }
                        label1.Visible = true;
                    }

                }
            }
        }

        void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewTextBoxColumn[] aCol =  { должностьColumn, имяColumn, ОтчествоColumn };
            //       if (dataGridView1.Columns[e.ColumnIndex] == должностьColumn)
            if (aCol.Contains(dataGridView1.Columns[e.ColumnIndex]))
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                }
            }

        }

        void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex]==фамилияColumn)
            {
                if (e.FormattedValue.ToString().Trim()=="")
                {
                    MessageBox.Show("Фамилия не может быть пустой");
                    e.Cancel = true;
                }
            }
        }

        void список_сотрудников_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataGridView1.EndEdit();
            bindingSource1.EndEdit();
            //foreach (сотрудники uRow in сотрудникиБинд)
            //{
            //    EntityState es =de.Entry(uRow).State;
            //    if (es == EntityState.Added || es == EntityState.Deleted || es == EntityState.Modified)
            //    {
            //        label1.Visible = true;
            //    }
            //}
            

            if (label1.Visible)
            {
                try
                {
                  int записано_строк =  de.SaveChanges();
       //           Console.WriteLine(записано_строк);
                }
                catch
                {
                    MessageBox.Show("Сбой записи...");
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
            int maxPor = 0;
            if (de.сотрудники.Any())
            {
                maxPor = de.сотрудники.Max(n => n.порядок);
            }
            сотрудники NewRow = new сотрудники();
            Guid NewKod = Guid.NewGuid();
            NewRow.сотрудник = NewKod;
        //    NewRow.фио = "";
            NewRow.порядок = maxPor + 1;
            NewRow.должность = "";
            NewRow.имя = "";
            NewRow.кассир = false;
            NewRow.отчество = "";
            NewRow.принят = null;
            NewRow.уволен = null;
            NewRow.фамилия = "Новый сотрудник";

            //    de.сотрудники.Add(NewRow);
            int строка = bindingSource1.Add(NewRow);
            bindingSource1.Position = строка;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count>0)
            {
                сотрудники vRow =bindingSource1.Current as сотрудники ;
              

                if (vRow.опл_работы.Any() 
                    || vRow.оплаты.Any() 
                    || vRow.отключения.Any() 
                    || vRow.повторы.Any()
                    || vRow.подключения.Any()
                    )
                {
                    MessageBox.Show("Сотркдник есть в таблицах");
                    return;
                }
                else
                {
                    bindingSource1.RemoveCurrent();
                }
            }
            dataGridView1.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
                сотрудники oldRow = bindingSource1.Current as сотрудники;
               // int oldPor = oldRow.порядок;
                if (bindingSource1.Position > 0)
                {
                    bindingSource1.MovePrevious();

                    сотрудники lastRow = bindingSource1.Current as сотрудники;
                    //int lastPor = lastRow.порядок;
                    //oldRow.порядок = lastPor;
                    //lastRow.порядок = oldPor;
                    (oldRow.порядок, lastRow.порядок) = (lastRow.порядок, oldRow.порядок);
                    // сотрудникиЛист.Sort((a, b) => a.порядок.CompareTo(b.порядок));
                    bindingSource1.Sort = "порядок";
                    //         сотрудникиDataGridView.Refresh();
                    //                label1.Visible = true;
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
                сотрудники oldRow = bindingSource1.Current as сотрудники;

             //   int oldPor = oldRow.порядок;
                if (bindingSource1.Position < bindingSource1.Count - 1)
                {
                    bindingSource1.MoveNext();
                    сотрудники lastRow = bindingSource1.Current as сотрудники;
                    //int lastPor = lastRow.порядок;
                    //oldRow.порядок = lastPor;
                    //lastRow.порядок = oldPor;
                    (oldRow.порядок, lastRow.порядок) = (lastRow.порядок, oldRow.порядок);
                    //        сотрудникиЛист.Sort((a, b) => a.порядок.CompareTo(b.порядок));
                    bindingSource1.Sort = "порядок";

                    //    label1.Visible = true;

                }
            }
        }
    }
}
