using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domofon40
{

    public partial class виды_оплат
    {
        public int оплат => оплаты.Count;

        public override string ToString()
        {
            return наимен;
        }


    }
    public partial class виды_услуг
    {

        
        public int услуг => услуги.Count;

        public override string ToString()
        {
            return наимен;
        }


    }

    public partial class дома
    {

        public int квартир => клиенты.Count;
       
        public bool неуникальный { get; set; }
        public bool выбран  { get; set; }
      

    }

    public partial class поселки
    {

        public int улиц => улицы.Count;
        

        //public override string ToString()
        //{
        //    return наимен;
        //}


    }

    public partial class сотрудники
    {
        public override string ToString()
        {
            return фио;
        }

    }

    public partial class улицы
    {

        public int домов => дома.Count;
        
        //public override string ToString()
        //{
        //    return поселки.наимен.Trim()+" "+ наимен ;
        //}


    }

    public partial class услуги
    {

        //public string наимен_вида
        //{
        //    get
        //    {
        //        if (виды_услуг != null)
        //        {
        //            return виды_услуг.наимен;
        //        }
        //        else
        //        {
        //            return "";
        //        }
        //    }
        //}
        public int порядок_вида
        {
            get
            {
                if (виды_услуг != null)
                {
                    return виды_услуг.порядок;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int последовательность
        {
            get
            {
                return виды_услуг.порядок * 100 + порядок;
            }
        }
        public override string ToString()
        {
            return обозначение;
        }

        public int клиентов => клиенты.Count;


    }

    public partial class подключения
    {
        public bool в_задание { get; set; } = false;
        //public string фио_мастера
        //{
        //    get
        //    {
        //        if (сотрудники != null)
        //        {
        //            return сотрудники.фио;
        //        }
        //        else
        //        {
        //            return "";
        //        }
        //    }
        //}

        public string адрес
        {
            get
            {
                if (клиенты != null)
                {
                    return клиенты.адрес;
                }
                else
                {
                    return "";
                }
            }
        }

        //public string фио
        //{
        //    get
        //    {
        //        if (клиенты != null)
        //        {
        //            return клиенты.фио;
        //        }
        //        else
        //        {
        //            return "";
        //        }
        //    }
        //}
        //public string наимен_услуги
        //{
        //    get
        //    {
        //        if (услуги != null)
        //        {
        //            return услуги.наимен;
        //        }
        //        else
        //        {
        //            return "";
        //        }
        //    }
        //}

     

    }

    public partial class простои
    {
     

        public string адрес
        {
            get
            {
                if (клиенты != null)
                {
                    return клиенты.адрес;
                }
                else
                {
                    return "";
                }
            }
        }
        public int подъезд
        {
            get
            {
                if (клиенты != null)
                {
                    return клиенты.подъезд;
                }
                else
                {
                    return 0;
                }
            }
        }

        //public string фио
        //{
        //    get
        //    {
        //        if (клиенты != null)
        //        {
        //            return клиенты.фио;
        //        }
        //        else
        //        {
        //            return "";
        //        }
        //    }
        //}
        //public string наимен_услуги
        //{
        //    get
        //    {
        //        if (услуги != null)
        //        {
        //            return услуги.наимен;
        //        }
        //        else
        //        {
        //            return "";
        //        }
        //    }
        //}



    }


    public partial class клиенты
    {
        public string адрес
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(дома.улицы.наимен.Trim());
                sb.Append(" ");
                sb.Append(дома.номер);
                if (дома.корпус.Trim() != String.Empty)
                {
                    sb.Append(" ");
                    sb.Append(дома.корпус.Trim());
                }
                sb.Append(" кв.");
                sb.Append(квартира.ToString().Trim());
                if (ввод > 0)
                {
                    sb.Append(" ввод ");
                    sb.Append(ввод.ToString().Trim());
                }

                return sb.ToString();
            }
        }

        public override string ToString()
        {
            return фио;
        }
        //public DateTime ? звонок
        //{
        //    get
        //    {
        //        DateTime? dt = null;
        //        if(звонки.Any())
        //        {
        //            dt = звонки.Max(n => n.дата);
        //        }
        //        return dt;
        //    }
        //}

    }

    public partial class льготы
    {
        public string адрес
        {
            get
            {
                if (клиенты != null)
                {
                    return клиенты.адрес;
                }
                else
                {
                    return "";
                }
            }
        }
        //public string фио
        //{
        //    get
        //    {
        //        if (клиенты != null)
        //        {
        //            return клиенты.фио;
        //        }
        //        else
        //        {
        //            return "";
        //        }
        //    }
        //}
        //public string наимен_услуги
        //{
        //    get
        //    {
        //        if (услуги != null)
        //        {
        //            return услуги.наимен;
        //        }
        //        else
        //        {
        //            return "";
        //        }
        //    }
        //}


        //public bool наш { get; set; } = false; 

    }

    public partial class отключения
    {
        public bool в_задание { get; set; } = false;
        public string адрес
        {
            get
            {
                if (клиенты != null)
                {
                    return клиенты.адрес;
                }
                else
                {
                    return "";
                }
            }
        }
        //public string фио
        //{
        //    get
        //    {
        //        if (клиенты != null)
        //        {
        //            return клиенты.фио;
        //        }
        //        else
        //        {
        //            return "";
        //        }
        //    }
        //}
        //public string наимен_услуги
        //{
        //    get
        //    {
        //        if (услуги != null)
        //        {
        //            return услуги.наимен;
        //        }
        //        else
        //        {
        //            return "";
        //        }
        //    }
        //}

        //public string фио_мастера
        //{
        //    get
        //    {
        //        if (сотрудники != null)
        //        {
        //            return сотрудники.фио;
        //        }
        //        else
        //        {
        //            return "";
        //        }
        //    }
        //}


    }
    public partial class повторы
    {
        public bool в_задание { get; set; } = false;
        public string адрес
        {
            get
            {
                if (клиенты != null)
                {
                    return клиенты.адрес;
                }
                else
                {
                    return "";
                }
            }
        }
        //public string фио 
        //{
        //    get
        //    {
        //        if (клиенты != null)
        //        {
        //            return клиенты.фио;
        //        }
        //        else
        //        {
        //            return "";
        //        }
        //    }
        //}
        //public string наимен_услуги
        //{
        //    get
        //    {
        //        if (услуги != null)
        //        {
        //            return услуги.наимен;
        //        }
        //        else
        //        {
        //            return "";
        //        }
        //    }
        //}

        //public string фио_мастера
        //{
        //    get
        //    {
        //        if (сотрудники != null)
        //        {
        //            return сотрудники.фио;
        //        }
        //        else
        //        {
        //            return "";
        //        }
        //    }
        //}
    }
    //public partial class простои
    //{
    //    public string адрес
    //    {
    //        get
    //        {
    //            if (клиенты != null)
    //            {
    //                return клиенты.адрес;
    //            }
    //            else
    //            {
    //                return "";
    //            }
    //        }
    //    }
    //}
    //public partial class предупреждения
    //{
    //    public string адрес
    //    {
    //        get
    //        {
    //            if (клиенты != null)
    //            {
    //                return клиенты.адрес;
    //            }
    //            else
    //            {
    //                return "";
    //            }
    //        }
    //    }
    //}
    public partial class звонки
    {
        public string адрес
        {
            get
            {
                if (клиенты != null)
                {
                    return клиенты.адрес;
                }
                else
                {
                    return "";
                }
            }
        }
        public string телефон
        {
            get
            {
                if (клиенты != null)
                {
                    return клиенты.телефон;
                }
                else
                {
                    return "";
                }
            }
            set
            {
                if (клиенты != null)
                {
                    клиенты.телефон =value;
                }
               
            }
        }

        public int год { get; set; }
        public int месяц { get; set; }
    }



    public partial class оплаты
    {
        public string адрес
        {
            get
            {
                if (клиенты != null)
                {
                    return клиенты.адрес;
                }
                else
                {
                    return "";
                }
            }
        }
       
        //public int всего
        //{
        //    get
        //    {
        //        int сумма = 0;
        //        if (оплачено.Any())
        //        {
        //            сумма += оплачено.Sum(n => n.сумма);
        //        }
        //        if (опл_работы.Any())
        //        {
        //            сумма += (int)опл_работы.Sum(n => n.стоимость);
        //        }
        //        //if (возврат.Count>0)
        //        //{
        //        //    сумма-=возврат.Sum(n=>n.сумма);
        //        //}


        //        return сумма;
        //    }
        //}

        public int оплатить { get; set; }
     
       

    }

    public partial class работы
    {
    
        public override string ToString()
        {
            return прейскурант.Trim() + "  " + наимен.Trim();
        }
    }

    public partial class опл_работы
    {
        public int зарплата
        {
            get
            {
                int ss = 0;
                if (стоимость > ст_материалов)
                {
                    ss=стоимость - ст_материалов;
                }
                return ss;
            }
        }
    }
}