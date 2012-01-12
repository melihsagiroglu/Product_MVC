using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Deneme5.Models
{
    public class Specification
    {
        public int SpecificationID { get; set; }
        public string SpecName { get; set; }
        //public virtual ICollection<ProductSpecModels> ProductSpec { get; set; }
        //public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<ProductSpec> ProductSpec { get; set; }
    }
}