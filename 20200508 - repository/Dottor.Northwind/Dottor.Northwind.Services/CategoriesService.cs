using Dottor.Northwind.Data;
using Dottor.Northwind.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dottor.Northwind.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoriesService()
        {
            _categoriesRepository = new CategoriesRepository();
        }

        public void DeleteCategory(int id)
        {
            _categoriesRepository.Delete(id);
            
            // log su db dell'operazione
        }

        public IEnumerable<Category> GetAll()
        {
            return _categoriesRepository.GetAll();
        }
        
    }
}
