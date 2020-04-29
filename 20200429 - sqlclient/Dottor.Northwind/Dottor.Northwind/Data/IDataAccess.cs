using Dottor.Northwind.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dottor.Northwind.Data
{
    public interface IDataAccess
    {
        IEnumerable<Category> GetCategories();

        Category GetCategory(int id);

        void Insert(Category category);

        void DeleteCategory(int id);

        void Update(Category category);

        int GetCategoriesCount();

    }
}
