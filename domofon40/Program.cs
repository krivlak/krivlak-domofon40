using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace domofon40
{
    enum тип_сообщения {Нет ,eMail, смс,Телефон };
    enum статус_сообщения { Нет, не_доставлено, в_пути, доставлено}
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
          //  Application.Run(new Form1());

            if (клЗапуск.RunningInstance() != null)
            {
                // Код, который необходимо выполнить если программа уже запущена
            //    Console.WriteLine("Программа уже запущена");
                Application.Run(new уже_запущена());
            }
            else
            {
                Application.Run(new Form1());
            }
        }
    }
}
