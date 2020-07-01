using System;
using System.Collections.Generic;

namespace FoodApi.Entities.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        public int IdProduct { get; set; }
        public string Name { get; set; }
        public int? Stock { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public int? IdCategory { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string Status { get; set; }

        public virtual Category IdCategoryNavigation { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
