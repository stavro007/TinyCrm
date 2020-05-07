using System;
using System.Collections.Generic;
using System.Text;


namespace TinyCrm.console
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Created { get;  set; }
        public string Email { get; set; }
        public string VatNumber { get;  set; }
        public string Phone { get; set; }
        public decimal TotalGross { get; private set; }
        public bool IsActive { get; set; }

        public List<Order> orders = new List<Order>();


        /*public Customer(string firstName, string lastName,string vatNumber)
        {
            if (!IsValidVatNumber(vatNumber))
            {
                throw new Exception("Invalid VatNumber");
            }
            VatNumber = vatNumber;
            FirstName = firstName;
            LastName = lastName;
            Created = DateTime.Now;

        }
        */
        public bool IsValidVatNumber(string vat)
        {
            if (string.IsNullOrWhiteSpace(vat))
            {
                vat = vat.Trim();
            }

            int v;
            if (vat.Length == 9 && int.TryParse(vat, out v))
            {
                return true;
            }
            else return false;
        }

        public bool IsVaLidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                email = email.Trim();
            }

            if (email.Contains('@') && email.EndsWith(".com") || email.EndsWith(".gr"))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void AddOrder(Order aOrder)
        {
            orders.Add(aOrder);

        }




    }
}
