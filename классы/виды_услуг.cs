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
    
    public partial class виды_услуг
    {
        public виды_услуг()
        {
            this.услуги = new HashSet<услуги>();
        }
    
        public System.Guid вид_услуги { get; set; }
        public string наимен { get; set; }
        public int порядок { get; set; }
        public int услуг
        {
            get 
            {
                return услуги.Count;
            }
        }

        public override string ToString()
        {
            return наимен;
        }
    
        public virtual ICollection<услуги> услуги { get; set; }
    }
}
