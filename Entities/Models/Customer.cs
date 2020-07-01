using System;
using System.Collections.Generic;

namespace FoodApi.Entities.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Order = new HashSet<Order>();
        }

        public int IdCustomer { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Identification { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
