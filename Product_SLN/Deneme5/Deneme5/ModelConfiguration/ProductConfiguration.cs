using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using Deneme5.Models;

namespace Deneme5.ModelConfiguration
{
    /*public class ProductConfiguration :EntityTypeConfiguration<Product>
    {
        internal ProductConfiguration()
        {
            this.HasMany(i => i.Specification)
                .WithMany(c => c.Product)
                .Map(mc =>
                {
                    mc.MapLeftKey("ProductID");
                    mc.MapRightKey("SpecificationID");
                    mc.ToTable("ProductSpec");
                });
        }
    }*/
}