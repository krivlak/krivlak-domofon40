using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;

namespace domofon40
{
    class клСервер
    {

        
        public static string сервер = "";

        static void GetИмяСервера()
        {
            string curDir = System.IO.Directory.GetCurrentDirectory();

            string sFile = curDir + @"\сервер.ini";

            клConfigRead oCfg = new клConfigRead();
            oCfg.read(sFile);

            сервер = oCfg.get_string("сервер".ToUpper());
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
}
