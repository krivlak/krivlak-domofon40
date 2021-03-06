﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.IO;

namespace domofon40
{
    public partial class статистика_дата : Form
    {
        public статистика_дата()
        {
            InitializeComponent();
        }
        List<temp> tempList = new List<temp>();
        domofon40.domofon14Entities de = new domofon14Entities();
        private void статистика_дата_Load(object sender, EventArgs e)
        {
            try
            {
                string curDir = System.IO.Directory.GetCurrentDirectory();

                string шаблон = curDir + @"\статистика1дата.sql";

                if (!System.IO.File.Exists(шаблон.ToString()))
                {
                    MessageBox.Show("Нет файла " + шаблон.ToString());
                    Cursor = Cursors.Default;
                    return;
                }
                StreamReader sr = new StreamReader(шаблон, Encoding.Default);

                string запрос = sr.ReadToEnd();
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("declare @дата datetime ='" + клКалендарь.дата.Value.ToShortDateString() + "';");
                sb.AppendLine(запрос);

                string sqlString = sb.ToString();


                tempList = de.Database.SqlQuery<temp>(sqlString).ToList();
                //string sqlComm = "статистика1дата '" + клКалендарь.дата.Value.ToShortDateString() + "'";
                //tempList = de.Database.SqlQuery<temp>(sqlComm).ToList();

                bindingSource1.DataSource = tempList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        class temp
        {
            public Guid услуга { get; set; }
            public string наимен { get; set; }
            public int договоров { get; set; }
            public int плательщиков { get; set; }
            public int льгот { get; set; }

            public int отключено { get; set; }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Word.Application oWord = new Word.Application();

            string curDir = System.IO.Directory.GetCurrentDirectory();

            object шаблон = curDir + @"\число_подключений.dot";
            if (!System.IO.File.Exists(шаблон.ToString()))
            {
                MessageBox.Show("Нет файла " + шаблон.ToString());
                return;
            }

            //domofon10.DataClasses1DataContext dc = new DataClasses1DataContext();


            string наименФилиала = de.филиалы
                .OrderBy(n => n.порядок)
                .First().наимен;

            Word.Document o = oWord.Documents.Add(Template: шаблон);
            //    oWord.Application.Visible = true;

            o.Tables[1].Cell(1, 2).Range.Text = клКалендарь.дата.Value.ToLongDateString();
            o.Tables[1].Cell(1, 3).Range.Text = DateTime.Today.ToShortDateString();
            o.Tables[1].Cell(1, 4).Range.Text = наименФилиала;
            int j = 1;
            foreach (temp uRow in tempList)
            {
                j++;
                o.Tables[2].Cell(j, 1).Range.Text = uRow.наимен;
                o.Tables[2].Cell(j, 2).Range.Text = uRow.договоров.ToString("0;#;#");
                o.Tables[2].Cell(j, 3).Range.Text = uRow.плательщиков.ToString("0;#;#");
                o.Tables[2].Cell(j, 4).Range.Text = uRow.льгот.ToString("0;#;#");
                o.Tables[2].Cell(j, 5).Range.Text = uRow.отключено.ToString("0;#;#");
                o.Tables[2].Rows.Add();
            }

            клTemp.Caption = o.ActiveWindow.Caption;
            oWord.Application.Visible = true;

        }
    }
}
