using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrm.console
{
    class Order
    {
        public string OrderId { get; private set; }
        public string DeliveryAddress { get; private set; }
        public decimal TotalAmount { get; private set; }
        
        private List<Product> product;


        public string GenerateID()
        {
            OrderId = Guid.NewGuid().ToString("N");
            return OrderId;
        }
    }

    
}
