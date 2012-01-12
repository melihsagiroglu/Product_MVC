using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Deneme5.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Deneme5.DAL
{
    public class ProductContext:DbContext
    {
        public DbSet<Product> Product { get; set; }        
        public DbSet<Category> Category { get; set; }        
        public DbSet<Specification> Specification { get; set; }
        //public DbSet<ProductSpec> ProductSpec { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) 
        { 
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Category>()
            .HasOptional(c => c.ParentCategory)
            .WithMany()
            .HasForeignKey(c => c.ParentID);


            /*modelBuilder.Entity<Category>().HasKey(p => p.ProductID);
            modelBuilder.Entity<Product>()
                .HasOptional(u => u.Category)
                .WithRequired();*/

            /*modelBuilder.Entity<Product>()
                .HasMany(e => e.Specification)
                .WithMany(e => e.Product)
                .Map(m =>
                {
                    m.ToTable("ProductSpec");
                    m.MapLeftKey("SpecificationID");
                    m.MapRightKey("ProductID");
                });*/ 
        }

        public DbSet<ProductSpec> ProductSpecs { get; set; }
    }
}