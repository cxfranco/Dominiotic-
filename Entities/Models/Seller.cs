using System;
using System.Collections.Generic;

namespace FoodApi.Entities.Models
{
    public partial class Seller
    {
        public Seller()
        {
            Order = new HashSet<Order>();
        }

        public int IdSeller { get; set; }
        public string Name { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
