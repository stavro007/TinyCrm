using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrm.Core.Services.Options
{
    public class UpDateOrderOptions
    {
        public int CustomerId { get; set; }
        public string DeliveryAddress { get; set; }

        public int OrderId { get;  set; }
    }
}
