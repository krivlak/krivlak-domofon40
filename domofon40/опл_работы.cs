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
    
    public partial class опл_работы
    {
        public System.Guid оплата { get; set; }
        public System.Guid работа { get; set; }
        public int стоимость { get; set; }
        public System.Guid мастер { get; set; }
        public int ст_материалов { get; set; }
        public System.Guid задание { get; set; }
        public int номер { get; set; }
    
        public virtual оплаты оплаты { get; set; }
        public virtual работы работы { get; set; }
        public virtual сотрудники сотрудники { get; set; }
    }
}
