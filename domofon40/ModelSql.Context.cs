﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class domofon14Entities1 : DbContext
    {
        public domofon14Entities1()
            : base("name=domofon14Entities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual ObjectResult<задание1монтажникам_Result> задание1монтажникам(Nullable<System.Guid> дом, Nullable<System.Guid> вид_услуги)
        {
            var домParameter = дом.HasValue ?
                new ObjectParameter("дом", дом) :
                new ObjectParameter("дом", typeof(System.Guid));
    
            var вид_услугиParameter = вид_услуги.HasValue ?
                new ObjectParameter("вид_услуги", вид_услуги) :
                new ObjectParameter("вид_услуги", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<задание1монтажникам_Result>("задание1монтажникам", домParameter, вид_услугиParameter);
        }
    }
}
