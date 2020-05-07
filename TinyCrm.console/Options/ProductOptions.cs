using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrm.console.Options
{
    public class ProductOptions
    {
        public int ProductId { get; set; }
        public decimal MinPrice { get; set; }

        public decimal MaxPrice { get; set; }

        public string ProductCategory { get; set; }
    }
}
