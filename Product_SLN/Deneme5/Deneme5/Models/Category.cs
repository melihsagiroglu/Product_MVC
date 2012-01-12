using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Deneme5.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int? ParentID { get; set; }
        public virtual ICollection<Product> Product { get; set; }
        public virtual Category ParentCategory { get; set; }
    }
}