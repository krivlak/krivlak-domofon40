using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domofon40
{
    class клМесяц
    {
        public static int год = System.DateTime.Today.Year;
        public static int месяц = System.DateTime.Today.Month;
        public static string наимен = "";
        public static System.Boolean выбран = false;
        public static string[] аНаимен = { "за год", "январь", "февраль", "март", "апрель", "май", "июнь", "июль", "август", "сентябрь", "октябрь", "ноябрь", "декабрь" };

    }
}
