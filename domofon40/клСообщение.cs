using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domofon40
{
    class клСообщение
    {
        public static Guid клиент  = Guid.Empty;
        public static bool отправлен = false;
        public static string текст = "";
        public static string код = "";
        public static DateTime? дата=null;
        public static string телефон = "";
        public static decimal баланс = 0;
        public static decimal старый_баланс = 0;
        public static decimal стоимость = 0;
        public static int лимит = 0;
        public static int сообщений_за_день = 0;
        public static int длина_сообщения = 0;
        public static int русских  = 0;
        public static int латинских = 0;
        public static bool программисту = true;


    }
}
