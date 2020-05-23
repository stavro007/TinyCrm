using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TinyCrm.Core.Data;
using TinyCrm.Core.Model;
using TinyCrm.Core.Options;
using TinyCrm.Core.Services;
using TinyCrm.Core.Services.Options;

namespace TinyCrm.Web.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerService customerService_;
        private TinyCrmDBcontext dbcontext_;
        
        public CustomerController()
        {
            dbcontext_ = new TinyCrmDBcontext();
            customerService_ = new CustomerService(dbcontext_);
        }

        [HttpPost]
        public IActionResult Create([FromBody]CreateCustomerOptions opt )
        {
            if (opt == null)
            {
                return BadRequest();
            }

            var result = customerService_.CreateCustomer(opt);

            if(result == false)
            {
                return BadRequest();
            }

            return Json(result);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var customer = customerService_.GetCustomerById(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Json(customer);
        }

        public IActionResult Update(UpDateCustomerOptions opt)
        {
            var result = customerService_.UpDate(opt);

            return Json(result);
        }


        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            var customer = customerService_.SearchCustomers(new CustomerOptions()
            {
                CustomerId = id,
            }).SingleOrDefault();

            dbcontext_.Remove(customer);
            dbcontext_.SaveChanges();

            return Ok();

        }
        

        [HttpGet]
        public IActionResult Index()
        {
            var customerlist = customerService_
                .SearchCustomers(new CustomerOptions())
                .ToList();

            return Json(customerlist);
        }
    }
}