using FoodApi.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApi.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private FoodContext _dbContext;
        private BaseRepository<Category> _category;
        private BaseRepository<Customer> _customer;
        private BaseRepository<PayType> _payType;
        private BaseRepository<Product> _product;
        private BaseRepository<Seller> _seller;
        private BaseRepository<Order> _order;
        private BaseRepository<OrderDetail> _orderDetail;

        public UnitOfWork(FoodContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IRepository<Category> Category
        {
            get
            {
                return _category ??
                                    (_category = new BaseRepository<Category>(_dbContext));
            }
        }

        public IRepository<Customer> Customer
        {
            get
            {
                return _customer ??
                                    (_customer = new BaseRepository<Customer>(_dbContext));
            }
        }

        public IRepository<PayType> PayType
        {
            get
            {
                return _payType ??
                                    (_payType = new BaseRepository<PayType>(_dbContext));
            }
        }

        public IRepository<Product> Product
        {
            get
            {
                return _product ??
                                    (_product = new BaseRepository<Product>(_dbContext));
            }
        }

        public IRepository<Seller> Seller
        {
            get
            {
                return _seller ??
                                    (_seller = new BaseRepository<Seller>(_dbContext));
            }
        }

        public IRepository<Order> Order
        {
            get
            {
                return _order ??
                                    (_order = new BaseRepository<Order>(_dbContext));
            }
        }

        public IRepository<OrderDetail> OrderDetail
        {
            get
            {
                return _orderDetail ??
                                    (_orderDetail = new BaseRepository<OrderDetail>(_dbContext));
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

    }
}