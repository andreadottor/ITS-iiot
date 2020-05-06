using Dottor.NorthwindDapper.Data;
using Dottor.NorthwindDapper.Models;
using System;

namespace Dottor.NorthwindDapper
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataAccess data = new DapperContribDataAccess();
            var categories = data.GetCategories();

            var cat12 = data.GetCategory(12);
            var cat3 = data.GetCategory(3);

            var newCategory = new Category
            { 
                CategoryName = "ITS",
                Description = "Categoria di prova"
            };

            data.Insert(newCategory);
            data.DeleteCategory(12);
            categories = data.GetCategories();
        }
    }
}
