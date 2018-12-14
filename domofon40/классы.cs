using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Reflection;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

namespace domofon40
{
    class клСетка
    {
        public static void задать_ширину(DataGridView dataGridView1)
        {
            int j = 0;
     
            foreach (DataGridViewColumn  col in dataGridView1.Columns)
            {
                if (col.Visible)
                {
                    j++;
                }
            }
            int столбцов = j;

            int[] aW = new int[столбцов];
            int i = 0;
            foreach (DataGridViewColumn tCol in dataGridView1.Columns)
            {
                if (tCol.Visible)
                {
                    aW[i] = tCol.Width;
                    i++;
                }
            }
            double сумма = aW.Sum();
            double ширина = Screen.PrimaryScreen.WorkingArea.Width - 60;
            double поправка = ширина / сумма;
            i = 0;
            foreach (DataGridViewColumn tCol in dataGridView1.Columns)
            {
                if (tCol.Visible)
                {
                    double ss = aW[i] * поправка;
                    tCol.Width = (int)ss;
                    i++;
                }
            }
            dataGridView1.Refresh();
        }
    }

    class клШаблон
    {
        public static string путь = "";
        public static bool выбран = false;
    }
    class клФирма
    {
        public static bool выбран = false;

        public static Guid фирма = Guid.Empty;
        public static string наимен = "";
        public static string адрес = "";
        public static фирмы deRow = null;

        public static void init()
        {
            domofon40.domofon14Entities de = new domofon14Entities();

            if (de.фирмы.Count() > 0)
            {
                фирмы dd = de.фирмы
                    .OrderBy(n => n.порядок)
                    .First();
                фирма = dd.фирма;
                deRow = dd;
                наимен = dd.наимен;
                адрес = dd.адрес;
            }
        }

    }
    class клФилиал
    {
        public static bool выбран = false;
        public static филиалы deRow = null;
        public static Guid филиал = Guid.Empty;
        public static string наимен = "";
        public static string адрес = "";

        public static void init()
        {
            domofon40.domofon14Entities de = new domofon14Entities();
            филиалы dd = de.филиалы
                .OrderBy(n => n.порядок)
                .First();
            филиал = dd.филиал;
            deRow = dd;
            наимен = dd.наимен;
            адрес = dd.адрес;
        }
    }
    class клУслуга
    {
        public static Guid услуга = Guid.Empty;
        public static bool выбран = false;
        public static string наимен = "";
        //        public static услуга dcRow = null;
        //      public static DataSet.услугаRow dsRow = null;
        public static bool подключена = false;
        public static string обозначение = "";
        public static int порядок = 0;
        public static услуги deRow = null;
        public static int долг_руб = 0;

        public static Dictionary<Guid, bool> dictУслуг = new Dictionary<Guid, bool>();
        public static void заполнить_услуги()
        {
            domofon40.domofon14Entities de = new domofon14Entities();


            foreach (услуги uRow in de.услуги
                .OrderBy(n => n.виды_услуг.порядок)
                .ThenBy(n => n.порядок))
            {
                dictУслуг.Add(uRow.услуга, true);
            }
        }


    }
    class клУлица
    {
        public static Guid улица = Guid.Empty;
        public static bool выбран = false;
        public static string наимен = "";
        public static улицы deRow = null;
        //    public static DataSet.улицаRow dsRow = null;
    }
    class клСотрудник
    {
        public static Guid сотрудник = Guid.Empty;
        public static сотрудники deRow = null;
        public static string фио = "";
        public static bool выбран = false;

    }
    class клКассир
    {
        public static Guid сотрудник = Guid.Empty;
        public static сотрудники deRow = null;
        public static string фио = "";
        public static bool выбран = false;

    }
    class клСообщение
    {
        public static Guid клиент = Guid.Empty;
        public static bool отправлен = false;
        public static string текст = "";
        public static string код = "";
        public static DateTime? дата = null;
        public static string телефон = "";
        public static decimal баланс = 0;
        public static decimal старый_баланс = 0;
        public static decimal стоимость = 0;
        public static int лимит = 0;
        public static int сообщений_за_день = 0;
        public static int длина_сообщения = 0;
        public static int русских = 0;
        public static int латинских = 0;
        public static bool программисту = true;


    }
    class клРазрешение
    {
        public static Guid разрешение = Guid.NewGuid();
        public static Guid клиент = Guid.Empty;
        public static string телефон = "";
        public static string эл_почта = "";
        public static DateTime дата_с = DateTime.Today;
        public static DateTime? дата_по = null;
        public static bool выбран = false;
        public static string все_телефоны = "";
        public static int номер = 0;
    }
    class клРабота
    {
        public static Guid работа = Guid.Empty;
        public static bool выбран = false;
        public static string наимен = "";
        public static работы deRow = null;

    }
    class клПоселок
    {
        public static Guid поселок = Guid.Empty;
        public static bool выбран = false;
        public static string наимен = "";
        public static поселки deRow = null;
        // public static DataSet.поселокRow dsRow = null;
    }
    class клПодъезд
    {
        //public static Guid дом = Guid.Empty;
        public static int подъезд = 0;
        public static bool выбран = false;
    }
    class клПериод
    {
        public static DateTime дата_с = DateTime.Today;
        public static DateTime дата_по = DateTime.Today;
        public static bool выбран = false;
    }

    class клОплата
    {
        public static Guid оплата = Guid.Empty;
        public static bool выбран = false;
        //        public static string наимен = "";
        public static оплаты deRow = null;
        //   public static DataSet.оплатаRow dsRow = null;
        // public static DataSet dataSet = null;
        public static bool изменено = false;
        public static bool новая = false;
        public static DateTime дата = DateTime.Today;
        public static Guid сотрудник = Guid.Empty;
        public static int номер = 0;
    }
    class клНачало
    {
        public static DateTime начало = DateTime.Today;
        public static int месяцНачало = 0;
        public static int годНачало = 0;
    }
    class клМыло
    {
        public static string телефон0 = "";
        public static Guid клиент = Guid.Empty;
        public static bool отправлен = false;
        public static string тема = "";
        public static string текст = "";
        public static DateTime? дата = null;
        public static string email = "";
        public static int длина_сообщения = 0;
        public static bool программисту = true;
    }
    class клМесяц
    {
        public static int год = System.DateTime.Today.Year;
        public static int месяц = System.DateTime.Today.Month;
        public static string наимен = "";
        public static System.Boolean выбран = false;
        public static string[] аНаимен = { "за год", "январь", "февраль", "март", "апрель", "май", "июнь", "июль", "август", "сентябрь", "октябрь", "ноябрь", "декабрь" };

    }
    class клМастер
    {
        public static Guid мастер = Guid.Empty;
        public static сотрудники deRow = null;
        public static string фио = "";
        public static string фамилия = "";
        public static bool выбран = false;
        public static string должность = "";
        public static bool изменен = false;
    }

    class клКлиент
    {
        public static Guid клиент = Guid.Empty;
        public static bool выбран = false;
        public static string фио = "";
      
        public static string Фамилия = "";
        public static string Имя = "";
        public static string Отчество = "";
        public static string наимен_поселка = "";
        public static string наимен_улицы = "";
        public static int дом = 0;
        public static string корпус = "";
        public static int квартира = 0;
        public static string телефон = "";
        public static bool есть_договор = false;
        public static string адрес = "";
        public static bool изменен = false;
        public static клиенты deRow = null;

      


    }


    class клКалендарь
    {
        public static DateTime? дата = DateTime.Today;
        public static bool isNull = false;
        public static bool выбран = false;
    }
    class клДом
    {
        public static Guid дом = Guid.Empty;
        public static bool выбран = false;
        public static string прим = "";
        public static int номер = 0;
        public static string корпус = "";
        public static дома deRow = null;
        //  public static DataSet.домRow dsRow = null;
    }
    class клВид_услуги
    {
        public static Guid вид_услуги = Guid.Empty;
        public static bool выбран = false;
        public static виды_услуг deRow = null;
        //        public static DataSet1.вид_услугиRow dsRow=null;
        public static string наимен = "";
        public static DateTime дата = DateTime.Today;

        public static Dictionary<Guid, bool> dictУслуг = new Dictionary<Guid, bool>();
        public static void заполнить_услуги()
        {


            domofon40.domofon14Entities de = new domofon14Entities();
            foreach (услуги uRow in de.услуги
                .OrderBy(n => n.порядок))
            {
                dictУслуг.Add(uRow.услуга, true);
            }
        }
    }

    class клВид_оплаты
    {
        public static Guid вид_оплаты = Guid.Empty;
        public static bool выбран = false;
        public static виды_оплат deRow = null;
        public static string наимен = "";

        
    }

    class клРеестр
    {
        public static DateTime дата = DateTime.Today;
        public static услуги[] аУслуги = null;
        public static bool выбран = false;
        public static string фио_менеджера = "";
        public static Guid менеджер = Guid.Empty;
        public static Guid вид_оплаты = Guid.Empty;
        public  static string наименВидаОплаты = "";

    }

    class клСервер
    {


        public static string сервер = "";

        static void GetИмяСервера()
        {
            string curDir = System.IO.Directory.GetCurrentDirectory();

            string sFile = curDir + @"\сервер.ini";

            клConfigRead oCfg = new клConfigRead();
            oCfg.read(sFile);

            string сервер0 = oCfg.get_string("сервер".ToUpper());
            сервер =сервер0.Replace(@"\\",@"\");
         //   MessageBox.Show(сервер);  
            //            string КодПользователя = oCfg.get_string("пользователь".ToUpper());
            //          клПользователь.пользователь = КодПользователя;
            //  MessageBox.Show(клПользователь.пользователь);

            //this.sUrl = oCfg.get_string("url".ToUpper());
            //this.sProxy = oCfg.get_string("proxy".ToUpper());
            //this.sPath = oCfg.get_string("path".ToUpper());

            oCfg.Dispose();

            //  return КодПользователя;

        }

        public static bool проверкаСоединения()
        {
            GetИмяСервера();
            Ping pingSender = new Ping();
            //            PingReply replu = pingSender.Send("192.168.211.35") ;
            try
            {
                PingReply replu = pingSender.Send(сервер);
                if (replu.Status == IPStatus.Success)
                {
                    //   MessageBox.Show(replu.Status.ToString());
                    return true;

                }
                else
                {
                    //MessageBox.Show(replu.Status.ToString());
                    return false;
                }
            }
            catch
            {
                // MessageBox.Show("Сбой...");
                return false;
            }
        }
    }
    class клЗапуск
    {
        public static Process RunningInstance()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);

            //Проходимся по всем процессам тем-же именем, что и у нашего процесса
            foreach (Process process in processes)
            {
                // если идентификатор процесса не равен нашему...
                if (process.Id != current.Id)
                {
                    //Сверяем имя исполняемого файла запущенного процесса и нашего процесса
                    if (Assembly.GetExecutingAssembly().Location.
                    Replace("/", "\\") == current.MainModule.FileName)
                    {
                        //Возвращаем ссылку на процесс
                        return process;

                    }
                }
            }

            return null;
        }
    }

    public static class ListExtension
    {
        /// <summary>
        /// Преобразование списка данных в таблицу 
        /// </summary>
        /// <typeparam name="T">Тип данных, содержащихся в списке</typeparam>
        /// <param name="list">Список, содержащий некоторые данные</param>
        /// <returns></returns>
        public static DataTable ToTable<T>(this IEnumerable<T> list)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            var table = new DataTable();
            for (var i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    table.Columns.Add(prop.Name, prop.PropertyType.GetGenericArguments()[0]);
                else
                    table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in list)
            {
                for (var i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }
    }

}
