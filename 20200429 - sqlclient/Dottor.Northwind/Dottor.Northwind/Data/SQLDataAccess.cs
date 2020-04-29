using Dottor.Northwind.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Text;

namespace Dottor.Northwind.Data
{
    public class SQLDataAccess : IDataAccess
    {

        private readonly string _connectionString;

        public SQLDataAccess()
        {
            this._connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Pooling=False";
        }



        public IEnumerable<Category> GetCategories()
        {
            var list = new List<Category>();
            using (var connection = new SqlConnection(this._connectionString))
            {
                connection.Open();

                string query = "select CategoryID, CategoryName, Description from Categories";

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = System.Data.CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var category = new Category();
                            category.Id = reader.GetInt32(reader.GetOrdinal("CategoryID"));
                            //category.Id = (int)reader["CategoryID"];
                            //category.Id = (int)reader.GetValue(reader.GetOrdinal("CategoryID"));
                            //category.Id = reader.GetFieldValue<int>(reader.GetOrdinal("CategoryID"));

                            category.Name = reader["CategoryName"] as string;
                            category.Description = reader["Description"] as string;

                            // check DBNull
                            //if(reader["CategoryID"] != DBNull.Value)
                            //if (!reader.IsDBNull(reader.GetOrdinal("CategoryID")))
                            //{
                            //    category.Id = (int)reader["CategoryID"];
                            //}
                            //else
                            //{
                            //    category.Id = null;
                            //}

                            list.Add(category);
                        }
                    }
                }

            }
            return list;
        }

        public Category GetCategory(int id)
        {
            using (var connection = new SqlConnection(this._connectionString))
            {
                connection.Open();

                var query = @"
select 
    CategoryID, 
    CategoryName, 
    Description 
from Categories
where CategoryID = @catId";
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.Parameters.AddWithValue("catId", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var category = new Category();
                            category.Id = (int)reader["CategoryID"];
                            category.Name = reader["CategoryName"] as string;
                            category.Description = reader["Description"] as string;

                            return category;
                        }

                        return null;
                    }
                }
            }
        }

        public void DeleteCategory(int id)
        {
            using (var connection = new SqlConnection(this._connectionString))
            {
                connection.Open();

                var query = "delete from Categories where CategoryID = @catId";
                
                using(var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("catId", id);

                    var rowsAffected = command.ExecuteNonQuery();
                    //return rowsAffected == 1;
                }
            }
        }

        public int GetCategoriesCount()
        {
            using (var connection = new SqlConnection(this._connectionString))
            {
                connection.Open();

                var query = "select Count(*) from Categories";

                using (var command = new SqlCommand(query, connection))
                {
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public void Insert(Category category)
        {
            using (var connection = new SqlConnection(this._connectionString))
            {
                connection.Open();

                var query = @"
insert into Categories (CategoryName, Description)
values (@name, @description)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("name", category.Name);
                    command.Parameters.AddWithValue("description", category.Description);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(Category category)
        {
            using (var connection = new SqlConnection(this._connectionString))
            {
                connection.Open();

                var query = @"
update Categories 
set 
    CategoryName = @name, 
    Description = @description
where CategoryId = @id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("id", category.Id);
                    command.Parameters.AddWithValue("name", category.Name);
                    command.Parameters.AddWithValue("description", category.Description);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
