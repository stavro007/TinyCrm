using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCrm.Core.Model;
using TinyCrm.Core.Services.Options;

namespace TinyCrm.Core.Services
{
    public interface ICustomerService
    {
        IQueryable<Customer> SearchCustomers(
            CustomerOptions options);
        

        bool CreateCustomer(CreateCustomerOptions options);

        Customer UpDate(UpDateCustomerOptions options);

        Customer GetCustomerById(int id);
    }
}
