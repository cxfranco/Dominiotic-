using System;
using System.Collections.Generic;

namespace FoodApi.Entities.Models
{
    public partial class OrderDetail
    {
        public int IdOrder { get; set; }
        public int Sequence { get; set; }
        public int? IdProduct { get; set; }
        public int? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? DicountPercent { get; set; }
        public decimal? Tax { get; set; }
        public decimal? TaxPercent { get; set; }
        public decimal? SubTotal { get; set; }

        public virtual Order IdOrderNavigation { get; set; }
        public virtual Product IdProductNavigation { get; set; }
    }
}
