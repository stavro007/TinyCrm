using System;
using System.Collections.Generic;
using TinyCrm.Core.Model;
using TinyCrm.Core.Services.Options;

namespace TinyCrm.Core.Services

{
    public interface IOrderService
    {
        bool CreateOrder(CreateOrderOptions opt);

        bool UpDateOrder(UpDateOrderOptions options);

        List<Order> SearchOrders(SearchOrderOptions options);
        
            
        

        
    }
}
