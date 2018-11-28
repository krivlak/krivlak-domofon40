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
    public partial class список_шаблонов : Form
    {
        public список_шаблонов()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        private void список_шаблонов_Load(object sender, EventArgs e)
        {
         //   de.начало.Load();
            de.шаблоны
                .OrderBy(n => n.наимен)
                .Load();
            bindingSource1.DataSource = de.шаблоны.Local.ToBindingList();
            bindingSource1.ListChanged += bindingSource1_ListChanged;
            FormClosing += список_шаблонов_FormClosing;
            dataGridView1.CellMouseClick += dataGridView1_CellMouseClick;
        }

        void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button== System.Windows.Forms.MouseButtons.Right)
            {

                if (dataGridView1.Columns[e.ColumnIndex]==путьColumn)
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    string curDir = System.IO.Directory.GetCurrentDirectory();

                    string шаблон = curDir + @"\договор_теле.dot";



                    шаблоны uRow = bindingSource1.Current as шаблоны;

                    if (uRow.путь.Trim().Length > 0)
                    {
                        шаблон = curDir + @"\" + uRow.путь.Trim();
                    }

                    openFileDialog1.CheckFileExists = true;
                    openFileDialog1.CheckPathExists = true;
                    openFileDialog1.InitialDirectory = curDir;
                    openFileDialog1.Title = "Выберите щаблон для договора ";
                    openFileDialog1.FileName = шаблон;
                    DialogResult dr = openFileDialog1.ShowDialog();
                    if (dr == System.Windows.Forms.DialogResult.OK)
                    {
                        System.IO.FileInfo fi = new System.IO.FileInfo(openFileDialog1.FileName);

                        uRow.путь = fi.Name;
                        label1.Visible = true;
                    }

                }
            }

        }

        void список_шаблонов_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (label1.Visible)
            {
                de.SaveChanges();
            }
        }

        void bindingSource1_ListChanged(object sender, ListChangedEventArgs e)
        {
            label1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            шаблоны uRow = bindingSource1.Current as шаблоны;

            Word.Application oWord = new Word.Application();

            string curDir = System.IO.Directory.GetCurrentDirectory();

            object шаблон = curDir + @"\" + uRow.путь.Trim();
            if (!System.IO.File.Exists(шаблон.ToString()))
            {
                MessageBox.Show("Нет файла " + шаблон.ToString());
                return;
            }

            Word.Document o = oWord.Documents.Open(FileName: шаблон);
            oWord.Application.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            шаблоны newRow = new шаблоны();
            //newRow.шаблон = Guid.NewGuid();
            newRow.наимен = "Новый шаблон...";
            newRow.путь = "";
            int строка = bindingSource1.Add(newRow);
            bindingSource1.Position = строка;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Count > 0)
            {
                bindingSource1.RemoveCurrent();
            }
        }

     
    }
}
