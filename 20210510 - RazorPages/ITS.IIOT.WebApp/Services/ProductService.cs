namespace ITS.IIOT.WebApp.Services
{
    using ITS.IIOT.WebApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProductService
    {
        private readonly List<Product> _products;

        public ProductService()
        {
            _products = new List<Product>();
            for (int i = 0; i < 10; i++)
            {
                _products.Add(new Product()
                {
                    Id = i,
                    Name = $"Prodotto {i}",
                    Code = $"ABC{i}"
                });
            }
        }

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public void Insert(Product product)
        {
            product.Id = _products.Max(p => p.Id) + 1;
            _products.Add(product);
        }
    }
}
