﻿using System;
using System.Collections.Generic;
using System.Text;
using TinyCrm.Core.Model;

namespace TinyCrm.Core.Services.Options
{
    public class CreateProductOptions
    {
        public string ProductId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ProductCategory Category { get; set; }
    }
}
