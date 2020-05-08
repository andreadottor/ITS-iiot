using Dottor.Northwind.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dottor.Northwind.Data
{
    public interface ICustomersRepository : IRepository<Customer, string>
    {
        IEnumerable<Customer> GetByCountry(string country);
    }
}
