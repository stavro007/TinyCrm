using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrm.Core.Services.Options
{
    public class ProductOptions
    {
        public string ProductId { get; set; }
        public decimal MinPrice { get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; }

        public decimal MaxPrice { get; set; }

        public string ProductCategory { get; set; }
    }
}
