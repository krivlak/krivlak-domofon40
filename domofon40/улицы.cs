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
    
    public partial class улицы
    {
        public улицы()
        {
            this.дома = new HashSet<дома>();
        }
    
        public System.Guid улица { get; set; }
        public string наимен { get; set; }
        public System.Guid поселок { get; set; }
    
        public virtual поселки поселки { get; set; }
        public virtual ICollection<дома> дома { get; set; }
    }
}
