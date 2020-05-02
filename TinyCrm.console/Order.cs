using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrm.console
{
    public class Order
    {
        public string OrderId { get; private set; }
        public string DeliveryAddress { get; private set; }
        public decimal TotalAmount { get; private set; }
        
        public List<Product> products { get; set; }

        public Order()
        {
            OrderId = GenerateID();
            TotalAmount = 0M;
        }

        public string GenerateID()
        {
            OrderId = Guid.NewGuid().ToString("N");
            return OrderId;
        }

        public void AddProduct(Product aProduct)
        {
            products.Add(aProduct);
        }

        public decimal Calculate_TotalAmount()
        {
            var total = 0M;
            foreach(Product p in products)
            {
                total = total + p.Price;
            }
            return total;
        }
    }

    
}
