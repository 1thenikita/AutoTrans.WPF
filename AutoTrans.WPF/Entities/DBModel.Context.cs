﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutoTrans.WPF.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBEntities : DbContext
    {
        public DBEntities()
            : base("name=DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<ManufacrurersTransport> ManufacrurersTransports { get; set; }
        public virtual DbSet<ModelsTransport> ModelsTransports { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Route> Routes { get; set; }
        public virtual DbSet<SchedulesRoute> SchedulesRoutes { get; set; }
        public virtual DbSet<Stop> Stops { get; set; }
        public virtual DbSet<StopsInRoute> StopsInRoutes { get; set; }
        public virtual DbSet<Transport> Transports { get; set; }
        public virtual DbSet<TypesRoute> TypesRoutes { get; set; }
        public virtual DbSet<TypesTransport> TypesTransports { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
