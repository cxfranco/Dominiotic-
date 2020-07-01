using System;
using System.Collections.Generic;

namespace FoodApi.Entities.Models
{
    public partial class Category
    {
        public Category()
        {
            Product = new HashSet<Product>();
        }

        public int IdCategory { get; set; }
        public string Name { get; set; }
        public int? Discount { get; set; }
        public string Description { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
