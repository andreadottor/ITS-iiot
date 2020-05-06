using Dottor.NorthwindDapper.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;

namespace Dottor.NorthwindDapper.Data
{
    class DapperDataAccess :IDataAccess
    {
        private readonly string _connectionString;

        public DapperDataAccess()
        {
            this._connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Pooling=False";
        }

        public IEnumerable<Category> GetCategories()
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                const string query = "select CategoryID as Id, CategoryName as Name, Description from Categories";
                return connection.Query<Category>(query);
            }
        }

        public Category GetCategory(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                const string query = @"
select 
    CategoryID as Id, 
    CategoryName as Name, 
    Description 
from Categories
where CategoryId = @CatId";

                return connection.QueryFirstOrDefault<Category>(query, new { CatId = id });
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
                const string query = @"
insert into Categories (CategoryName, Description)
values (@Name, @Description)";

                connection.Execute(query, category);
            }
        }

        public void Update(Category category)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                const string query = @"
update Categories 
set 
    CategoryName = @Name, 
    Description = @Description
where CategoryId = @Id";

                connection.Execute(query, category);
            }
        }

        public void DeleteCategory(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                const string query = @"delete from Categories where CategoryId = @id";
                //connection.Execute(query, new { id = id });
                connection.Execute(query, new { id });
            }
        }

    }
}
