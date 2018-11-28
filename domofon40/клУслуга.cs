using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domofon40
{
    class клУслуга
    {
        public static Guid  услуга = Guid.Empty;
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
                .ThenBy(n=>n.порядок))
            {
                dictУслуг.Add(uRow.услуга, true);
            }
        }
      

    }
}
