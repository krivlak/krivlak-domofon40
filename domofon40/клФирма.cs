using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domofon40
{
    class клФирма
    {
        public static bool выбран = false;
       
        public static Guid  фирма = Guid.Empty;
        public static string наимен = "";
        public static string адрес = "";
        public static фирмы  deRow = null;

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
}
