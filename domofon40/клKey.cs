using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace domofon40
{
    class клKey
    {
          public static  void int_KeyPress(object senderT, KeyPressEventArgs eT)
        {

            if (!Char.IsDigit(eT.KeyChar) && !Char.IsControl(eT.KeyChar))
            {
                    eT.Handled = true;
                    System.Media.SystemSounds.Beep.Play();
            }
       
        }


        public static void intсоЗнаком(object senderT, KeyPressEventArgs eT)
        {

            if (!Char.IsDigit(eT.KeyChar) && !Char.IsControl(eT.KeyChar) && eT.KeyChar != '-')
            {
                eT.Handled = true;
                System.Media.SystemSounds.Beep.Play();
            }

        }


        public static void decimal_KeyPress(object senderT, KeyPressEventArgs eT)
          {
              char сепаратор = (char)System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator.ToString()[0];

              char[] aChar = { ',', '.', '/', 'б', 'ю', '.', '?' };
              if (aChar.Contains(eT.KeyChar))
              {
                  eT.KeyChar = сепаратор;
              }

              if (!Char.IsDigit(eT.KeyChar) && !Char.IsControl(eT.KeyChar))
              {
                  TextBox tb = (TextBox)senderT;
                  if (eT.KeyChar != сепаратор || tb.Text.IndexOf(сепаратор) != -1)
                  {
                      eT.Handled = true;
                      System.Media.SystemSounds.Beep.Play();
                  }
              }
          }

        public static void decimalсоЗнаком(object senderT, KeyPressEventArgs eT)
        {
            char сепаратор = (char)System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator.ToString()[0];

            char[] aChar = { ',', '.', '/', 'б', 'ю', '.', '?' };
            if (aChar.Contains(eT.KeyChar))
            {
                eT.KeyChar = сепаратор;
            }

            if (!Char.IsDigit(eT.KeyChar) && !Char.IsControl(eT.KeyChar) && eT.KeyChar != '-')
            {
                TextBox tb = (TextBox)senderT;
                if (eT.KeyChar != сепаратор || tb.Text.IndexOf(сепаратор) != -1)
                {
                    eT.Handled = true;
                    System.Media.SystemSounds.Beep.Play();
                }
            }
        }


    }
    
}
