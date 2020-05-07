using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using TinyCrm.console.TinyCrmDbContext;
using TinyCrm.console.Options;
using System.Security.Cryptography.X509Certificates;

namespace TinyCrm.console
{
    class Program

    {
        public static void SearchCustomers(TinyCrmDBcontext db, CustomerOptions opt)
        {
            var customerList = new List<Customer>();
            
            string optCustomerId = Convert.ToString(opt.CustomerId);
            string optCustomerDateFrom = Convert.ToString(opt.CreatedFrom);
            string optCustomerDateTo = Convert.ToString(opt.CreatedTo);

            if (!(optCustomerId == "0"))  // ean exei dosei id o xrhsths sto UI tha epistrepsei to monadiko record
            {
                var customer = db
                   .Set<Customer>()
                   .Where(c => c.CustomerId == opt.CustomerId)
                   .SingleOrDefault();

                Console.WriteLine($"Monadiko apotelesma:O/H {customer.FirstName} {customer.LastName}");

            }
            else
            {
                if (!String.IsNullOrWhiteSpace(opt.LastName))
                {
                    //int numberOfrecords = 2;
                    customerList = db
                       .Set<Customer>()
                       .Where(c => c.LastName == opt.LastName)
                       //.Take(numberOfrecords)                 // gia na paroume ta prota dyo stoixeia
                       .ToList();

                }
                if (!String.IsNullOrWhiteSpace(opt.FirstName))
                {
                    int numberOfrecords = 2;
                    customerList = db
                       .Set<Customer>()
                       .Where(c => c.FirstName == opt.FirstName)
                       //.Take(numberOfrecords)              // gia na paroume ta prota dyo stoixeia
                       .ToList();

                }
                if (!String.IsNullOrWhiteSpace(opt.VatNumber))
                {
                    int numberOfrecords = 2;
                    customerList = db
                       .Set<Customer>()
                       .Where(c => c.VatNumber == opt.VatNumber)
                      // .Take(numberOfrecords)                     // gia na paroume ta prota dyo stoixeia
                       .ToList();

                }
                if (String.IsNullOrWhiteSpace(optCustomerDateFrom) && String.IsNullOrWhiteSpace(optCustomerDateTo))
                {
                    
                    //int numberOfrecords = 2;    // bazo dokimastika na epistrefei mexri 2 records afoy den exo 500 eggrafes sth bash
                    customerList = db
                       .Set<Customer>()
                       .Where(c => c.Created >= opt.CreatedFrom && c.Created <= opt.CreatedTo)
                       //.Take(numberOfrecords)
                       .ToList();
                       
                }
                
            }
            Console.WriteLine("Apotelesmata anazhthsh");
            
            foreach(Customer c in customerList)
            {
                Console.WriteLine($" o kyrios {c.FirstName} {c.LastName} me CustomerId: {c.CustomerId}");
            }
            
        }

        public static void SearchProducts(TinyCrmDBcontext db,ProductOptions opt)
        {
            var productList = new List<Product>();

            string optCustomerMinPrice = Convert.ToString(opt.MinPrice);
            string optCustomerMaxPrice = Convert.ToString(opt.MaxPrice);

            string optProductId = Convert.ToString(opt.ProductId);

            if (!(optProductId == "0"))  // ean exei dosei id o xrhsths sto UI tha epistrepsei to monadiko record
            {
                var product = db
                   .Set<Product>()
                   .Where(p => p.ProductId == opt.ProductId)
                   .SingleOrDefault();

                Console.WriteLine($"Monadiko apotelesma:To product {product.Name} {product.ProductCategory}");

            }
            else
            {
                if (!String.IsNullOrWhiteSpace(optCustomerMinPrice) && !String.IsNullOrWhiteSpace(optCustomerMaxPrice))
                {
                    productList = db
                  .Set<Product>()
                  .Where(p => p.Price >= opt.MinPrice && p.Price <= opt.MaxPrice)
                  .Take(2)
                  .ToList();
                }


            }
            Console.WriteLine("Ta prointa poy brethikan einai");
            foreach(Product p in productList)
            {
                Console.WriteLine($"NAME: {p.Name} " +
                                    $"Category: {p.ProductCategory} ");
            }

        }


        static void Main(string[] args)
        {

            var tinyCrmDbContext = new TinyCrmDBcontext();

            Console.WriteLine("Eisagete filtra anazhthshs gia Products");

            Console.WriteLine("ProductID");
            string productid = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(productid))
            {
                productid = "0";         // ean de balei kati o xrhths dino mia timh 0 poy ksero oti den yparxei sth bash
            }
            Console.WriteLine("Eisagete elaxisth timh prointos");
            decimal min_price = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Eisagete megisth timh prointos");
            decimal max_price = Convert.ToDecimal(Console.ReadLine());


            var searchOptions = new ProductOptions
            {

                ProductId = Convert.ToInt32(productid),
                MinPrice = min_price,
                MaxPrice = max_price,
            };

            SearchProducts(tinyCrmDbContext, searchOptions);
            
            
             Console.WriteLine("Eisagete filtra anazhthshs Customers");

             Console.WriteLine("CustomerID");
             string customerid = Console.ReadLine();
             if (String.IsNullOrWhiteSpace(customerid)){
                 customerid = "0";         // ean de balei kati o xrhths dino mia timh 0 poy ksero oti den yparxei sth bash
             }

             Console.WriteLine("VatNumber");
             string vatnumber = Console.ReadLine();

             Console.WriteLine("FirstName");
             string firstname = Console.ReadLine();

             Console.WriteLine("LastName");
             string lastname = Console.ReadLine();

             Console.WriteLine("Enter CreatedFrom date");
             DateTime userDateTimeFrom;
             if (!DateTime.TryParse(Console.ReadLine(), out userDateTimeFrom)) {

                 Console.WriteLine("Lathos eisagogi");
             }
            DateTime userDateTimeTo;
            Console.WriteLine("Enter CreatedTo date");
             if (!DateTime.TryParse(Console.ReadLine(), out userDateTimeTo))
             {

                 Console.WriteLine("Lathos eisagogi");
             }
            // dhmiourgoume ena customeroptions antikeimeno symfona me ta kritiria toy xristi
            var searchOptionsC = new CustomerOptions
             {

                 CustomerId = Convert.ToInt32(customerid),
                 FirstName = firstname,
                 LastName = lastname,
                 VatNumber = vatnumber,
                 CreatedFrom = userDateTimeFrom,
                 CreatedTo = userDateTimeTo,

             };

             SearchCustomers(tinyCrmDbContext, searchOptionsC);
             



        }
    }
}
