using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Linq;
using System.Data.Linq.Mapping;
namespace domofon40
{
    public partial class проба_соединения : Form
    {
        public проба_соединения()
        {
            InitializeComponent();
        }
        domofon40.domofon14Entities de = new domofon14Entities();
        private void button1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(Properties.Settings.Default.domofon14ConnectionString))
            {


                string командаАрхив = @"select * from поселки";
                IDbCommand command = new System.Data.SqlClient.SqlCommand(командаАрхив);
                command.Connection = conn;
                conn.Open();
                IDataReader reader = command.ExecuteReader();
              while (reader.Read())
              {
                  Console.WriteLine(" порядок:{0} наимен {1} ", reader.GetInt32(2), reader.GetString(1));
              }
              Console.ReadLine();
              
            }

            Cursor = Cursors.Default;
        }

        private void button2_Click(object sender, EventArgs e)
        {
         //   List<string> лист = new List<string>();

            //var query = (from n in de.улицы
            //             where (n.дома.Count > 10)
            //             orderby n.порядок, n.наимен
            //             select n)
            //            .Take(2);

            //int минДомов = (from n in de.улицы
            //                select n).Min(n => n.дома.Count);

            //var query = from n in de.улицы
            //            where (n.дома.Count > минДомов+2)
            //             orderby n.порядок, n.наимен
            //             select n;

            //var query = from n in de.улицы
            //            where n.дома.Count > 4
            //            select n
            //                into p
            //                where p.порядок > 2
            //                orderby p.порядок
            //                select p;

            //var query0 = from n in de.улицы
            //            where n.дома.Count > 4
            //            select n;

            //var query = from n in query0
            //    where n.порядок > 2
            //            orderby n.порядок
            //            select n;
            var query = from n in de.улицы
           let домов = n.дома.Count
               where домов > 4
                        orderby n.наимен
                        select n;

            dataGridView1.DataSource = query.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //   List<string> лист = new List<string>();

            //var query = from n in de.улицы
            //            where (n.дома.Count > 10)
            //            orderby n.наимен
            //            select n;

            //int минДомов = de.улицы.Min(p => p.дома.Count);
            //var query = de.улицы
            //    .Where(n => n.дома.Count > минДомов + 2)
            //    .OrderBy(n => n.наимен)
            //    .Select(n => n);

            var query = de.улицы
                .OrderBy(n => n.наимен)
                .Select(n => new temp { домов = n.дома.Count, наимен = n.наимен });


            //foreach (var uRow in query)
            //{
            //    Console.WriteLine(uRow.наимен);
            //}



            dataGridView1.DataSource = query.ToList();
        }
        class temp
        {
            public int домов { get; set; }
            public string наимен { get; set; }
        }

        //[Table]
        //class проспект
        //{
        //    [Column]
        //    public Guid улица;
        //    [Column]
        //    public string наимен;
        //}

        private void button4_Click(object sender, EventArgs e)
        {
           
            //domofon40.DataClasses1DataContext dc = new DataClasses1DataContext();
            //Table<улицы> проспекты = dc.GetTable<улицы>();

            //dataGridView1.DataSource = проспекты;

            //List<улицы> улицыЛист = de.улицы.ToList();
            //// разделить чтобы выполнить
            //var query = улицыЛист
            //    .Select(n => Math.Log(n.порядок));
            
            //var query2 = улицыЛист
            //    .Select(n =>n.домов);

            //foreach (double uRow in query)
            //{
            //    Console.WriteLine(uRow);
            //}

            //foreach (double uRow in query2)
            //{
            //    Console.WriteLine(uRow);
            //}

            //var query3 = de.улицы
            //    .Select(n => n.домов);

            //foreach (double uRow in query3)
            //{
            //    Console.WriteLine(uRow);
            //}

         //var query=   de.улицы
         //       .Select(n => new проспект { улица = n.улица, наимен = n.наимен });

         //dataGridView1.DataSource = query.ToList();
            //Table<проспект> проспекты = new Table<проспект>();

            //foreach (улицы uRow in de.улицы)
            //{
            //    проспект newRow = new проспект();
            //    newRow.улица = uRow.улица;
            //    newRow.наимен = uRow.наимен;
            //    проспекты.InsertOnSubmit(newRow);
            //}
            //dataGridView1.DataSource = проспекты;
            // что то есть ,
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //var query = from n in de.улицы
            //            let домов = n.дома.Count
            //            where домов > 10
            //            select n;
            //клДом.выбран = false;
            //выбор_дома выборДома = new выбор_дома();
            //выборДома.ShowDialog();
            //if (клДом.выбран)
            //{

            var query = from n in de.улицы
                        let дома = n.дома
                        let maxN = дома.Max(p => p.номер)
                        where maxN > 20
                        select new {улица= n.наимен, махДом=maxN };


                dataGridView1.DataSource = query.ToList();
            //}
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var query = de.услуги.SqlQuery("select * from услуги").AsNoTracking();

            dataGridView1.DataSource = query.ToList();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var query0 = de.улицы.OrderBy(n => n.наимен).ToList();
       //     int[] query0 =  {3,4,5,6,7};

            var query = query0.Select((n, i) => new { n.наимен, i });
            //var query = from n in query0 
            //            select (n , i) 

            dataGridView1.DataSource = query.ToList();


        }

        Func<int , int> мояФункция = (a) => DateTime.Today.Year+a;


       

        private void button8_Click(object sender, EventArgs e)
        {
            //int? a = null;

            //MessageBox.Show((a ?? 44).ToString());

          //  int? a = null;
            string  str = null ;
            int? длина = str?.Length;
            MessageBox.Show((длина ?? 0).ToString());
            MessageBox.Show($"аргумент {nameof(str)} равен null");
            // составление выполнимых строк?
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //var query = de.виды_оплат.First()(n => (n.наимен, n.порядок));

            //var query = from n in de.виды_оплат
            //      select (n.порядок, n.наимен);
            var query = de.виды_оплат
                .ToList()
                //.Select(n => Tuple.Create(n.порядок, n.наимен))
                .Select(n =>new { кортеж=(n.порядок,  n.наимен), n.вид_оплаты })
                .ToList();

            foreach(var uRow in query)
            {
                Console.Write(uRow.кортеж.Item1.ToString() + " ");
                Console.WriteLine(uRow.кортеж.Item2);
                Console.Write(uRow.кортеж.порядок.ToString() + " ");
                Console.WriteLine(uRow.кортеж.наимен);
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            //var query = de.оплачено
            //    .ToList()
            //    .GroupBy(n => (n.услуга, n.оплаты.клиент))
            //    .Select(n => (n.Key.клиент, n.Key.услуга, сумма: n.Sum(p => p.сумма)));

            //foreach (var uRow in query)
            //{
            //    Console.Write(uRow.сумма.ToString() + " ");
            //    Console.Write(uRow.клиент);
            //    Console.WriteLine(uRow.услуга);
            //}
        }
    }
}
