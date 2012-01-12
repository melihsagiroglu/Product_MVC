using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Deneme5.Models;

namespace Deneme5.DAL
{
    public class ProductInitializer : DropCreateDatabaseIfModelChanges<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {
            var products = new List<Product>            
             {                new Product { ProductName = "Carson",RecordTime= DateTime.Parse("2005-09-01"),CategoryID=1 }                
             };
            products.ForEach(s => context.Product.Add(s));
            context.SaveChanges();

            var category = new List<Category>            
             {                new Category { CategoryName = "a", ParentID=0}               
             };
            category.ForEach(s => context.Category.Add(s));
            context.SaveChanges();
        }
    }
}