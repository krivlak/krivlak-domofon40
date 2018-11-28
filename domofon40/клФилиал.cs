using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domofon40
{
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
}
