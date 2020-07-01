using System;
using System.Collections.Generic;

namespace FoodApi.Entities.Models
{
    public partial class PayType
    {
        public PayType()
        {
            Order = new HashSet<Order>();
        }

        public int IdPayType { get; set; }
        public string Name { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
