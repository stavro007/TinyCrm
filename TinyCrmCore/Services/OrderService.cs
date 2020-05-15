using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCrm.Core.Data;
using TinyCrm.Core.Model;
using TinyCrm.Core.Services.Options;

namespace TinyCrm.Core.Services
{
    class OrderService: IOrderService
    {

        private TinyCrmDBcontext db_;
        private ICustomerService customerservice_;
        private IProductService productservice_;

        public OrderService(TinyCrmDBcontext db, ICustomerService customerservice)
        {
            db_ = db;
            customerservice_ = customerservice;
        }

        public OrderService()
        {
        }

        // function to create a new order
        public bool CreateOrder(CreateOrderOptions opt)
        {
            if (opt == null) return false;
            Order order;
            var customer = customerservice_.SearchCustomers(new CustomerOptions()
            {
                CustomerId = opt.CustomerId,
            }).SingleOrDefault();

            foreach(var p in opt.ProductIds)
            {
                var id = productservice_.SearchProducts(new ProductOptions()
                {
                    ProductId = p,
                });
            }

            order = new Order()
            {
                DeliveryAddress = "Athina",
            };

            customer.Orders.Add(order);
            var orderProduct = new OrderProduct();
            foreach (var p in opt.ProductIds)
            {
                orderProduct.ProductId = p;
                orderProduct.OrderId = order.OrderId;

                order.OrderProducts.Add(orderProduct);
            }
            db_.Add(order);
            db_.SaveChanges();

            if(db_.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // function update an order
        public bool UpDateOrder(UpDateOrderOptions opt)
        {
            if (opt == null) return false;
           

            var customer = customerservice_.SearchCustomers(new CustomerOptions()
            {
                CustomerId = opt.CustomerId,
            }).FirstOrDefault();

            if (customer != null)
            {
                foreach (var or in customer.Orders)
                {
                    if (or.OrderId == opt.OrderId)
                    {
                        or.DeliveryAddress = opt.DeliveryAddress;
                    }
                }
                db_.SaveChanges();
                return true;
            }
            else return false;
        }

        
        // find for specific orders
        public List<Order> SearchOrders(SearchOrderOptions opt)
        {

            if (opt == null) return null;

            var customers = db_.Set<Customer>()
                .Where(ord => opt.CustomerId == ord.CustomerId)
                .Include(c => c.Orders)
                .ToList();
            
            if (customers.Count() > 0)
            {
                var orders = new List<Order>();

                foreach (var c in customers)
                {
                    foreach (var el in c.Orders)
                    {
                        orders.Add(el);
                    }
                }

                return orders;
            }
            else return null;
        }
    }
}
