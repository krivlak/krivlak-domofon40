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
    
    public partial class подключения
    {
        public System.Guid подключение { get; set; }
        public System.Guid клиент { get; set; }
        public System.DateTime дата_с { get; set; }
        public Nullable<System.DateTime> дата_по { get; set; }
        public System.Guid услуга { get; set; }
        public string номер_дог { get; set; }
        public System.DateTime дата_дог { get; set; }
        public int номер_пп { get; set; }
        public System.Guid мастер { get; set; }
    
        public virtual клиенты клиенты { get; set; }
        public virtual услуги услуги { get; set; }
        public virtual сотрудники сотрудники { get; set; }
    }
}
