using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domofon40
{
    class клКлиент
    {
        public static Guid клиент = Guid.Empty;
        public static bool выбран = false;
        public static string фио = "";
    //    public static клиент dcRow = null;
    //    public static DataSet.клиентRow dsRow = null;
        public static string Фамилия = "";
        public static string Имя = "";
        public static string Отчество = "";
        public static string наимен_поселка = "";
        public static string наимен_улицы = "";
        public static int дом = 0;
        public static string корпус = "";
        public static int  квартира = 0;
        public static string телефон = "";
        public static bool есть_договор = false;
        public static string адрес = "";
        public static bool изменен = false;
        public static клиенты deRow = null;

        //public static void dcАдрес()
        //{
        //    string текст = " ул. " + dcRow.дом1.улица1.наимен.Trim()
        //        + " дом " + dcRow.дом1.номер.ToString().Trim() 
        //        + " " + dcRow.дом1.корпус 
        //        + " кв. " + dcRow.квартира.ToString();

        //    if (dcRow.ввод > 0)
        //    {
        //        текст += " ввод " + dcRow.ввод.ToString();
        //    }
        //    адрес = текст;

        //}


    }
}
