using FoodApi.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApi.Entities.DTOs
{
    public class ProductList
    {
        public List<Product> products = new List<Product>();
    }
}
