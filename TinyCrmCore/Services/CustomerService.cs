using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using TinyCrm.Core.Data;
using TinyCrm.Core.Model;
using TinyCrm.Core.Services.Options;

namespace TinyCrm.Core.Services
{
    public class CustomerService: ICustomerService
    {
        private TinyCrmDBcontext db_;

        public CustomerService(TinyCrmDBcontext db)
        {
            db_ = db;
        }

        public IQueryable<Customer> SearchCustomers(CustomerOptions opt)   // search function
        {
            //string optCustomerId = Convert.ToString(opt.CustomerId);
            //string optCustomerDateFrom = Convert.ToString(opt.CreatedFrom);
            //string optCustomerDateTo = Convert.ToString(opt.CreatedTo);

            if (opt.CustomerId != null)  // ean exei dosei id o xrhsths sto UI tha epistrepsei to monadiko record
            {
                var queryId = db_
                    .Set<Customer>()
                    .AsQueryable();

                queryId = queryId.Where(c => c.CustomerId == opt.CustomerId);
                //Console.WriteLine($"id pelati einai {opt.CustomerId}");

                return queryId;
            }
            else
            {
                var query = db_
                    .Set<Customer>()
                    .AsQueryable();

                if (!String.IsNullOrWhiteSpace(opt.LastName))
                {
                    query = query.Where(c => c.LastName == opt.LastName);
                }
                if (!String.IsNullOrWhiteSpace(opt.FirstName))
                {
                    query = query.Where(c => c.FirstName == opt.FirstName);
                }
                if (!String.IsNullOrWhiteSpace(opt.VatNumber))
                {
                    query = query.Where(c => c.VatNumber == opt.VatNumber);
                }
               // if (!String.IsNullOrWhiteSpace(opt.CreatedFrom) && !String.IsNullOrWhiteSpace(optCustomerDateTo))
                //{
                 //   query = query.Where(c => c.Created >= opt.CreatedFrom && c.Created <= opt.CreatedTo);
               // }
                query.Take(500);
                return query;
            }
        }

        public Customer UpDate(UpDateCustomerOptions opt)
        {
            if (opt == null) return null;
            var customer = SearchCustomers(new CustomerOptions()
            {
                CustomerId = opt.CustomerId,
            }).SingleOrDefault();

            if (customer != null)
            {
                customer.FirstName = opt.FirstName;
                customer.LastName = opt.LastName;
                customer.IsActive = false;
            }

            return customer;

        }

        public Customer GetCustomerById(int opt)
        {
            var po = new CustomerOptions();
            po.CustomerId = opt;
            var customer = SearchCustomers(po).SingleOrDefault();

            return customer;
        }

       
        public bool CreateCustomer(CreateCustomerOptions opt)
        {
            if (opt == null) return false;

            var customer = new Customer()
            {
                FirstName = opt.FirstName,
                LastName = opt.LastName,
                Email = opt.Email,
                VatNumber = opt.VatNumber,
                Created = DateTime.Now
            };
            db_.Add(customer);
            //db_.SaveChanges();

            if(db_.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
