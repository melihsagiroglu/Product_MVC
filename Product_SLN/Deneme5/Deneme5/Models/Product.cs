using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Deneme5.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        [Required]
        public string ProductName { get; set; }
        public DateTime RecordTime { get; set; }
        public virtual Category Category { get; set; }
        //public virtual ICollection<ProductSpecModels> ProductSpec { get; set; }
        //public virtual ICollection<Specification> Specification { get; set; }
        public virtual ICollection<ProductSpec> ProductSpec { get; set; }
    }
}