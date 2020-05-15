using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrm.Core.Model
{
    public class Order
    {
        public int OrderId { get; private set; }
        public DateTimeOffset Created { get; set; }
        public string DeliveryAddress { get;  set; }
        
        public List<OrderProduct> OrderProducts { get; set; }
        

        public Order()
        {
            Created = DateTime.Now;
            OrderProducts = new List<OrderProduct>();
        }

       /* public string GenerateID()
        {
            OrderId = Guid.NewGuid().ToString("N");
            return OrderId;
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
        */
    }

    
}
