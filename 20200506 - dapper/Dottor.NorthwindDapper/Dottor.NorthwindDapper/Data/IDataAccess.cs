using Dottor.NorthwindDapper.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dottor.NorthwindDapper.Data
{
    interface IDataAccess
    {
        IEnumerable<Category> GetCategories();

        Category GetCategory(int id);

        void Insert(Category category);

        void DeleteCategory(int id);

        void Update(Category category);

        int GetCategoriesCount();
    }
}
