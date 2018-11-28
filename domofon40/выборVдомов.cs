using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace domofon40
{
    public partial class выборVдомов : Form
    {
        public выборVдомов()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        List<дома> домаЛист = new List<дома>();
   //     List<temp> tempList = new List<temp>();
        private void выборVдомов_Load(object sender, EventArgs e)
        {
            домаЛист = de.дома
                .Where(n => n.улица == клУлица.улица)
                .OrderBy(n => n.номер)
                .ThenBy(n => n.корпус)
                .ToList();

            bindingSource1.DataSource = домаЛист;

            //foreach (дома uRow in de.дома
            //    .Where(n=>n.улица==клУлица.улица)
            //    .OrderBy(n=>n.номер)
            //    .ThenBy(n=>n.корпус))
            //{
            //    temp newTemp = new temp;
            //    newTemp.выбран=false;
            //    newTemp.дом=uRow.дом;
            //    newTemp.квартир=uRow.квартир;
            //    newTemp.корпус=uRow.корпус;
            //    newTemp.номер=uRow.номер;
            //    tempList.Add(newTemp);
            //}
            //bindingSource1.DataSource=tempList;

        }
        //class temp
        //{
        //    public Guid дом { get; set; }
        //    public int номер { get; set; }
        //    public string корпус { get; set; }
        //    public bool выбран { get; set; }
        //    public int квартир { get; set; }

        //}

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            this.Validate();
            this.bindingSource1.EndEdit();
            задание1улица формаОтчет = new задание1улица();
            формаОтчет.домаЛист = домаЛист;

            формаОтчет.Text = "Задание на Переключения " + клВид_услуги.наимен + " по улице " + клУлица.наимен;
            формаОтчет.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           if (checkBox1.Checked)
            {
                foreach(дома dRow in домаЛист)
                {
                    dRow.выбран = true;
                }
                checkBox1.Text = "Отменить выделение";
            }
           else
            {
                foreach (дома dRow in домаЛист)
                {
                    dRow.выбран = false;
                }
                checkBox1.Text = "Все дома";
            }
            dataGridView1.Refresh();
            dataGridView1.Focus();
        }
    }
}
