using Dottor.NorthwindDapper.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using Dapper.Contrib.Extensions;

namespace Dottor.NorthwindDapper.Data
{
    class DapperContribDataAccess : IDataAccess
    {
        private readonly string _connectionString;

        public DapperContribDataAccess()
        {
            this._connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Pooling=False";
        }

        public IEnumerable<Category> GetCategories()
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                return connection.GetAll<Category>();
            }
        }

        public Category GetCategory(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Get<Category>(id);
            }
        }

        public int GetCategoriesCount()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                const string query = "select Count(*) from Categories";
                return connection.ExecuteScalar<int>(query);
            }
        }

        public void Insert(Category category)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Insert(category);
            }
        }

        public void Update(Category category)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Update(category);
            }
        }

        public void DeleteCategory(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Delete(new Category
                { 
                    CategoryId = id
                });

                //var category = connection.Get<Category>(id);
                //connection.Delete(category);
            }
        }
    }
}
