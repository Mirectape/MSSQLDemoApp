﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MSSQLDemoApp
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WorkersDBEntities1 : DbContext
    {
        public WorkersDBEntities1()
            : base("name=WorkersDBEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ProductsOrdered> ProductsOrdered { get; set; }
        public virtual DbSet<register> register { get; set; }
        public virtual DbSet<Workers> Workers { get; set; }
    }
}
