//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace domofon40
{
    using System;
    using System.Collections.Generic;
    
    public partial class оплачено
    {
        public System.Guid оплата { get; set; }
        public int месяц { get; set; }
        public int год { get; set; }
        public int сумма { get; set; }
        public System.Guid услуга { get; set; }
        public int дней { get; set; }
        public int длина_мес { get; set; }
        public int цена { get; set; }
        public System.Guid платеж { get; set; }
    
        public virtual оплаты оплаты { get; set; }
        public virtual услуги услуги { get; set; }
    }
}
