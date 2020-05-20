using Microsoft.EntityFrameworkCore;
using Northwind.Dottor.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Northwind.Dottor.Data
{
    public class ProductsRepository : IProductsRepository
    {

        private readonly NorthwindContext _northwindContext;

        public ProductsRepository(NorthwindContext northwindContext)
        {
            _northwindContext = northwindContext;
        }


        public IEnumerable<Product> GetAll()
        {
            return _northwindContext.Products
                        .OrderBy(p => p.ProductName)
                        .ToArray();
        }

        public Product GetById(int productId)
        {
            return _northwindContext.Products.FirstOrDefault(p => p.ProductID == productId);
        }

        public int Count()
        {
            return _northwindContext.Products.Count();
        }

        public void Delete(int productId)
        {
            // Metodo 1
            //var product = _northwindContext.Products.FirstOrDefault(p => p.ProductID == productId);
            //_northwindContext.Products.Remove(product);

            // Metodo 2
            var product = new Product
            {
                ProductID = productId
            };
            _northwindContext.Entry(product).State = EntityState.Deleted;

            _northwindContext.SaveChanges();
        }

        public void Insert(Product product)
        {
            _northwindContext.Products.Add(product);
            _northwindContext.SaveChanges();
        }

        public void Update(Product product)
        {
            // Metodo 1:
            //var temp = _northwindContext.Products.FirstOrDefault(p => p.ProductID == product.ProductID);
            //temp.ProductName = product.ProductName;
            //temp.QuantityPerUnit = product.QuantityPerUnit;
            //temp.CategoryID = product.CategoryID;
            //temp.Discontinued = product.Discontinued;
            //temp.ReorderLevel = product.ReorderLevel;
            //temp.SupplierID = product.SupplierID;
            //temp.UnitPrice = product.UnitPrice;
            //temp.UnitsInStock = product.UnitsInStock;
            //temp.UnitsOnOrder = product.UnitsOnOrder;

            //  Metodo 2:
            //_northwindContext.Entry(product).State = EntityState.Modified;

            // Metodo 3:
            _northwindContext.Update(product);

            _northwindContext.SaveChanges();

        }
    }
}
