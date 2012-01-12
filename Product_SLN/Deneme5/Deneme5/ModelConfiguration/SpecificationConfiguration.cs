using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using Deneme5.Models;

namespace Deneme5.ModelConfiguration
{
    /*public class SpecificationConfiguration:EntityTypeConfiguration<Specification>
    {
        internal SpecificationConfiguration()
                {
                    this.HasMany(i => i.Product)
                        .WithMany(c => c.Specification)
                        .Map(mc =>
                        {
                            mc.MapLeftKey("SpecificationID");
                            mc.MapRightKey("ProductID");
                            mc.ToTable("ProductSpec");
                        });
                }
    }*/
}