using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domofon40
{
    class клРазрешение
    {
        public static Guid разрешение = Guid.NewGuid();
        public static Guid клиент = Guid.Empty;
        public static string телефон = "";
        public static string эл_почта = "";
        public static DateTime дата_с = DateTime.Today;
        public static DateTime? дата_по = null ;
        public static bool выбран = false;
        public static string все_телефоны = "";
        public static int номер = 0;
    }
}
