using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrm.console
{
    public class Product
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; private set; }
            
        

        public Product(string productid,string name,string description)
        {
            ProductId = productid;
            Name = name;
            Description = description;
            Price = RandomPrice();

        }

        private decimal RandomPrice()
        {
            var rand = new Random();
            decimal price = Convert.ToDecimal(rand.NextDouble());
            return price;
            
        }

        

    }
    
}
