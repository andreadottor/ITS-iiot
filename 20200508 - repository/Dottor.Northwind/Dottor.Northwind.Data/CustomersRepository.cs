using Dottor.Northwind.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dottor.Northwind.Data
{
    public class CustomersRepository : ICustomersRepository
    {
        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Customer Get(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetByCountry(string country)
        {
            throw new NotImplementedException();
        }

        public void Insert(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
