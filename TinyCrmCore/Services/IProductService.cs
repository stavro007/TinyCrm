using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCrm.Core.Model;
using TinyCrm.Core.Services.Options;

namespace TinyCrm.Core.Services
{
    interface IProductService
    {
        IQueryable<Product> SearchProducts(
            ProductOptions options);

        Product CreateProduct(CreateProductOptions opt);

        Product Update(UpDateProductOptions options);

        Product GetProductById(string opt);
    }
}
