using System;
using System.Collections.Generic;

namespace FoodApi.Entities.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        public int IdOrder { get; set; }
        public int? IdSeller { get; set; }
        public int? IdCustomer { get; set; }
        public int? IdPayType { get; set; }
        public DateTime? DateOrder { get; set; }
        public string AddressDelivery { get; set; }
        public string Observation { get; set; }
        public decimal? TaxPercent { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? Tax { get; set; }
        public decimal? Total { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string Status { get; set; }

        public virtual Customer IdCustomerNavigation { get; set; }
        public virtual PayType IdPayTypeNavigation { get; set; }
        public virtual Seller IdSellerNavigation { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
