using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using TinyCrm.Core.Data;
using TinyCrm.Core.Model;
using TinyCrm.Core.Services;
using TinyCrm.Core.Services.Options;


//using TinyCrm.Core.Data;
//sing TinyCrm.Core.Services;
//using TinyCrm.Core.Services.Options;
//using TinyCrm.Core.Model;

namespace TinyCrm.console
{
    class Program

    {
        static void Main(string[] args)
        {

            /*Console.WriteLine("Eisagete filtra anazhthshs gia Products");

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

               ProductId = productid,
               MinPrice = min_price,
               MaxPrice = max_price,
           };

           var query = tinyCrmDbContext.Set<Product>().AsQueryable();
           query = SearchProducts(tinyCrmDbContext, searchOptions);
           */
            /*
            //var set = tinyCrmDbContext.Set<Customer>();

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

            // include records from another type
            var customer = SearchCustomers(tinyCrmDbContext, searchOptionsC).Include(c => c.Orders).ToList();
            */
            // one to many 
            //var tinyCrmDbContext = new TinyCrmDBcontext();
            //customerservice_ = new CustomerService(tinyCrmDbContext);

            /*var product = new Product()
            {
                ProductId = "PRD444545",
                Category = ProductCategory.Mobiles,
                Name = "Huawei p9",
                Price = 150M
            };

            var customerWithOrders = new Customer()
            {
                FirstName = "Georgios",
                LastName = "Nikolaou",
                Email = "gio@gmail.com",
            };

            var order = new Order() 
            { 
                    DeliveryAddress = "Athens",
            };

            order.OrderProducts.Add(new OrderProduct()
            {
                Product = product,

            });

            customerWithOrders.Orders.Add(order);

            tinyCrmDbContext.Add(customerWithOrders);
            tinyCrmDbContext.SaveChanges();

            tinyCrmDbContext.Dispose();

            // select customer with order 
            */
            //var update = new UpDateOrderOptions()
            //{
            // CustomerId = 1,
            //OrderId = 1,
            // DeliveryAddress = "Perachora",
            //};
            //CustomerService customerservice_;
            //OrderService orderservice = new OrderService(tinyCrmDbContext, customerservice_);
            //bool a = orderservice.UpDateOrder( update);

            /*var updatepr = new UpDateProductOptions()
            {
                Name = "Huawei",
                ProductId = "PRD444545",
                Price = 160,
            };

            ProductService prservice = new ProductService();
            prservice.Update(updatepr);
            *
            //tinyCrmDbContext.SaveChanges();
            //tinyCrmDbContext.Dispose();

            */

            /*var tinyCrmDbContext = new TinyCrmDBcontext();
            var customerWithOrders = new Customer()
            {
                FirstName = "Georgios",
                LastName = "Nikolaou",
                Email = "gio@gmail.com",
                };

                tinyCrmDbContext.Add(customerWithOrders);
                tinyCrmDbContext.SaveChanges();
                tinyCrmDbContext.Dispose();
                */
            var context = new TinyCrmDBcontext();

            ICustomerService customerService = new CustomerService(
                    context);

            var customer = customerService.CreateCustomer(
                    new CreateCustomerOptions()
                    {
                        FirstName = "Dimitris",
                        LastName = "Pnevmatikos",
                        VatNumber = "123456789",

                    });
                        
                   




        }
}
}
