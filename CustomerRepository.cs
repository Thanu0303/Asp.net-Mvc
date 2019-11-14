using MvcApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication.Infrastructure
{
    public class CustomerRepository : IRepository<Customer, string>
    {
        static List<Customer> customerList;
        public CustomerRepository()
        {
            if (customerList == null)
            {
                customerList = new List<Customer>();
                AddItemsToList();
            }
        }
        private void AddItemsToList()
        {
            Customer c1 = new Customer {
                CustomerId = "5star",
                CompanyName = "Ramesh Corporation",
                ContactName = "Ramesh Mehata",
                City = "Valsad",
                Country = "India"
            };
            customerList.Add(c1);
            customerList.Add(new Customer
            {
                CustomerId = "6star",
                CompanyName = " Suresh Corporation",
                ContactName = "Suresh Raj",
                City = "Bangalore",
                Country = "India"
            });
            customerList.Add(new Customer
            {
                CustomerId = "7star",
                CompanyName = " Rajesh Corporation",
                ContactName = "Rajesh Malhotra",
                City = "Baroda",
                Country = "India"
            });
            customerList.Add(new Customer
            {
                CustomerId = "8star",
                CompanyName = " Mahesh Corporation",
                ContactName = "Mahesh Malhotra",
                City = "Lucknow",
                Country = "India"
            });
        }
        public IQueryable<Customer> GetAll()
        {
            var query = from item in customerList select item;
            return query.AsQueryable();
        }

        public Customer GetDetails(string identity)
        {
            return customerList.FirstOrDefault(c => c.CustomerId.Equals(identity));
        }

        public void CreateNew(Customer item)
        {
            if(item != null)
            {
                customerList.Add(item);
            }
        }

        public void Delete(string identity)
        {
            if (!string.IsNullOrEmpty(identity))
            {
                customerList.RemoveAll(c => c.CustomerId == identity);
            }
        }

        public void Update(Customer item)
        {
            if(item != null)
            {
                customerList.RemoveAll(c => c.CustomerId == item.CustomerId);
                customerList.Add(item);
            }
        }
    }
}