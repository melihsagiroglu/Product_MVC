using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Deneme5.Models
{
    public class ProductSpec
    {
        public int ProductSpecID { get; set; }

        //[Key, Column(Order = 1, TypeName = "int")]
        //[ForeignKey("Product")]
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }

        //[Key, Column(Order = 2, TypeName = "int")]
        //[ForeignKey("Specification")]
        public int SpecificationID { get; set; }
        public virtual Specification Specification { get; set; }

        /*public int ProductID { get; set; }
        public virtual ICollection<Product> Product {get;set;}
        public int SpecificationID { get; set; }
        public virtual ICollection<Specification> Specification { get; set; }*/
    }
}