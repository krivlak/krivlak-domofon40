using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domofon40
{
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
}
