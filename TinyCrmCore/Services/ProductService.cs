using System;
using System.Linq;
using TinyCrm.Core.Data;
using TinyCrm.Core.Model;
using TinyCrm.Core.Services.Options;

namespace TinyCrm.Core.Services
{
    public class ProductService: IProductService
    {

        private TinyCrmDBcontext db_;

        public ProductService(TinyCrmDBcontext db)
        {
            db_ = db;
        }

        public ProductService()
        {
        }

        public IQueryable<Product> SearchProducts(ProductOptions opt)  // search function
        {
            string optCustomerMinPrice = Convert.ToString(opt.MinPrice);
            string optCustomerMaxPrice = Convert.ToString(opt.MaxPrice);

            string optProductId = Convert.ToString(opt.ProductId);

            if (!(optProductId == "0"))  
            {
                var queryId = db_
                    .Set<Product>()
                    .AsQueryable();

                queryId = queryId.Where(p => p.ProductId == opt.ProductId);
                return queryId;
            }
            else
            {
                var query = db_
                  .Set<Product>()
                  .AsQueryable();
                if (!String.IsNullOrWhiteSpace(optCustomerMinPrice) && !String.IsNullOrWhiteSpace(optCustomerMaxPrice))
                {


                    query = query.Where(p => p.Price >= opt.MinPrice && p.Price <= opt.MaxPrice);
                    query.Take(500);
                    return query;
                }
                return query;
            }
        }

        public Product Update(UpDateProductOptions opt)   // update function
        {

            if (opt == null) return null;
            var product = SearchProducts(new ProductOptions()
            {
                ProductId = opt.ProductId,
            }).SingleOrDefault();

            if (product != null)
            {
                product.Name = opt.Name;
                product.Price = opt.Price;
            }
            
            return product;

        }

        public Product GetProductById(string opt)          // getproductbyid function
        {
            var po = new ProductOptions();
            po.ProductId = opt;
            var product = SearchProducts(po).SingleOrDefault();

            return product;
        }

        public Product CreateProduct(CreateProductOptions opt)
        {
            var product = new Product()
            {
                Name = opt.Name,
                Price = opt.Price,
                Category = opt.Category,
            };
            db_.Add(product);
            db_.SaveChanges();
            return product;
        }

        
    }
}
