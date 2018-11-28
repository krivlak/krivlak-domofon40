using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace domofon40
{
    class клConfigRead
    {
         struct config_var
        {
           public string sVarName;
           public string sValue;
        }

        //public struct config_var
        //{
        //    public string sVarName;
        //    public string sValue;
        //}
        List<config_var> mVars = new List<config_var>();
        public void read(string sFileName)
        {
            if (sFileName == null || sFileName.Length == 0)
                throw new Exception("Передано пустое значение имени файла!");
            if (!File.Exists(sFileName))
                throw new Exception("Нет кофигурационного файла: " + sFileName);
            // Все есть читаем 
            mVars.Clear();
            config_var mVar;
            string sStr, sName, sValue;
            int iPos;
            using (StreamReader sr = new StreamReader(sFileName, Encoding.GetEncoding(1251)))
            {
                while (true)
                {
                    sStr = sr.ReadLine();
                    if (sStr == null || sStr.Length == 0)
                        break;
                    if (sStr.Substring(0, 1) == ";" ||
                            sStr.Substring(0, 1) == "*" ||
                            sStr.Substring(0, 2) == "--" ||
                            sStr.Substring(0, 2) == "//" ||
                            sStr.Substring(0, 3).ToUpper() == "REM")
                        continue;
                    // 
                    iPos = sStr.IndexOf("=");
                    if (iPos > 0)
                        sName = sStr.Substring(0, iPos).ToUpper().Trim(' ');
                    else
                        continue;
                    sValue = sStr.Substring(iPos + 1).Trim(' ');
                    mVar = new config_var();
                    mVar.sVarName = sName;
                    mVar.sValue = sValue;
                    mVars.Add(mVar);
                }// Конец цикла 
            }// конец работы с файлом 
        }
        private int locate_name(string sName)
        {
            for (int i = 0; i < mVars.Count; i++)
            {
                if (mVars[i].sVarName == sName)
                    return i;
            }
            return -1;
        }
        // Получить символьное значение 
        public string get_string(string sName)
        {
            int iPos = locate_name(sName);
            if (iPos == -1)
                return "";
            else
                return mVars[iPos].sValue;
        }
        // Получить целое значение 
        public int get_int(string sName)
        {
            int iPos = locate_name(sName);
            if (iPos == -1)
                return 0;
            else
            {
                int iRet = 0;
                try
                {
                    iRet = Convert.ToInt32(mVars[iPos].sValue);
                }
                catch { iRet = 0; }
                return iRet;
            }
        }
        // Получить десятичное значение 
        public decimal get_decimal(string sName)
        {
            int iPos = locate_name(sName);
            decimal dRet = 0;
            if (iPos == -1)
                return dRet;
            else
            {
                dRet = 0;
                try
                {
                    dRet = Convert.ToDecimal(mVars[iPos].sValue);
                }
                catch { dRet = 0; }
                return dRet;
            }
        }
        // Получить дату 
        public DateTime get_date(string sName)
        {
            int iPos = locate_name(sName);
            DateTime dDate = new DateTime(1900, 01, 01);
            DateTime dDateRet = new DateTime(1900, 01, 01);
            if (iPos == -1)
                return dDate;
            else
            {
                if (conv_str_to_date(mVars[iPos].sValue, ref dDateRet))
                    return dDateRet;
                else
                    return dDate;
            }
        }
        // Преобразовать в дату 
        private bool conv_str_to_date(string sValue, ref DateTime dDate)
        {
            int iPos;
            int iDay;
            int iMonth;
            int iYear = 2007;
            bool isDate = true;
            if (sValue.Contains("."))
            {
                iPos = sValue.IndexOf(".");
                if (sValue.IndexOf(".", iPos + 1) == -1)
                {
                    iDay = Convert.ToInt16(sValue.Substring(0, iPos));
                    iMonth = Convert.ToInt16(sValue.Substring(iPos + 1));
                    try
                    {
                        dDate = new DateTime(iYear, iMonth, iDay);
                    }
                    catch
                    {
                        isDate = false;
                    }
                }
                else // Есть третья точка 
                {
                    int iPos1;
                    iPos1 = sValue.IndexOf(".", iPos + 1);
                    iDay = Convert.ToInt16(sValue.Substring(0, iPos));
                    iMonth = Convert.ToInt16(sValue.Substring(iPos + 1, iPos1 - iPos - 1));
                    if (sValue.IndexOf(".") > 0)
                        iYear = Convert.ToInt16(sValue.Substring(iPos1 + 1, 4));
                    else
                        iYear = Convert.ToInt16(sValue.Substring(iPos1 + 1));
                    if (iYear < 100)
                        iYear = iYear + 2000;
                    try
                    {
                        dDate = new DateTime(iYear, iMonth, iDay);
                    }
                    catch
                    {
                        isDate = false;
                    }
                }
            }
            else
                isDate = false;
            return isDate;
        }
        public void Dispose()
        {
            //Освобождаем ресурсы
            GC.SuppressFinalize(this);
        }

    
    }
}
