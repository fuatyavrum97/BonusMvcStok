﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BonusMvcStok.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DbMvcStokEntities : DbContext
    {
        public DbMvcStokEntities()
            : base("name=DbMvcStokEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblkategori> tblkategoris { get; set; }
        public virtual DbSet<tblmusteri> tblmusteris { get; set; }
        public virtual DbSet<tblpersonel> tblpersonels { get; set; }
        public virtual DbSet<tblsatislar> tblsatislars { get; set; }
        public virtual DbSet<tblurunler> tblurunlers { get; set; }
        public virtual DbSet<tbladmin> tbladmins { get; set; }
    }
}