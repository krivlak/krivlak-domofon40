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
    
    public partial class звонки
    {
        public System.Guid звонок { get; set; }
        public System.Guid клиент { get; set; }
        public System.DateTime дата { get; set; }
        public string прим { get; set; }
    
        public virtual клиенты клиенты { get; set; }
    }
}
