using Northwind.Dottor.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Dottor.Data
{
    public interface IProductsRepository
    {

        IEnumerable<Product> GetAll();

        Product GetById(int productId);

        int Count();

        void Insert(Product product);

        void Update(Product product);

        void Delete(int productId);

    }
}
