using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

namespace domofon40
{
    class клTemp
    {
        public static string Caption = "";
        public static void tempExcel()
        {
            System.Diagnostics.Process[] просессы = Process.GetProcessesByName("Excel");
            foreach (Process uPr in просессы)
            {
                if (uPr.MainWindowTitle == "Microsoft Excel - temp"
                    || uPr.MainWindowTitle == "Microsoft Excel - temp.xlsx")
                {
                    uPr.CloseMainWindow();
                    System.Threading.Thread.Sleep(500);
                }
            }
            
        }
        public static void tempWord()
        {
            System.Diagnostics.Process[] просессы = Process.GetProcessesByName("WINWORD");
            foreach (Process uPr in просессы)
            {
                if (uPr.MainWindowTitle == "temp - Microsoft Word"
                    || uPr.MainWindowTitle == "temp.docx - Microsoft Word"
                    || uPr.MainWindowTitle == "temp.doc [Режим ограниченой функциональности] - Microsoft Word"
                    || uPr.MainWindowTitle == "temp [Режим ограниченой функциональности] - Microsoft Word")
                {
                    uPr.CloseMainWindow();
//                    uPr.Close();
                    System.Threading.Thread.Sleep(500);

                }
            }

        }
        public static void закрытьWord()
        {
            System.Diagnostics.Process[] просессы = Process.GetProcessesByName("WINWORD");
            foreach (Process uPr in просессы)
            {
                if (uPr.MainWindowTitle.ToUpper().IndexOf("TEMP") >-1)
                {
//                    uPr.Dispose();
                    try
                    {
                        uPr.CloseMainWindow();
                    }
                    catch
                    {
                        MessageBox.Show("Закройте " + uPr.MainWindowTitle);
                    }
//                    uPr.Kill();
                    //                    uPr.Close();
                    System.Threading.Thread.Sleep(500);

                }
            }

        }
    }
}
