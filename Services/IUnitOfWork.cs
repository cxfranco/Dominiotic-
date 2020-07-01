using FoodApi.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApi.Services
{
    public interface IUnitOfWork
    {
        IRepository<Category> Category { get; }
        IRepository<Customer> Customer { get; }
        IRepository<PayType> PayType { get; }
        IRepository<Product> Product { get; }
        IRepository<Seller> Seller { get; }
        IRepository<Order> Order { get; }
        IRepository<OrderDetail> OrderDetail { get; }

        void Save();
    }
}