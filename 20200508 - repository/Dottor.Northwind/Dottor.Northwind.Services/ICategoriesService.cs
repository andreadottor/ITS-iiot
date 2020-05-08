using Dottor.Northwind.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dottor.Northwind.Services
{
    public interface ICategoriesService
    {

        void DeleteCategory(int id);

        IEnumerable<Category> GetAll();
    }
}
