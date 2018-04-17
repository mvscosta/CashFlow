using CashFlow.Base.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CashFlow.Handler
{
    public partial class CashFlowContext : DbContext
    {
        public CashFlowContext()
            : base("CashFlowContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Transaction> Transaction { get; set; }
        public virtual DbSet<PaymentType> PaymentType { get; set; }
        public virtual DbSet<Resource> Resource { get; set; }
        public virtual DbSet<Base.Models.Role> Role { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //var conventions = new List<PluralizingTableNameConvention>().ToArray();
            //modelBuilder.Conventions.Remove(conventions);

            modelBuilder.Entity<Resource>()
                .HasOptional<Base.Models.Role>(r => r.Role);
        }
    }
}
