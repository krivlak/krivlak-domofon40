using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Diagnostics;

namespace domofon40
{
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
}
