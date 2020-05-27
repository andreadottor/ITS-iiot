using ITS.Dottor.Northwind.SqlConsoleApp.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using static System.Console;
using Dapper;
using System.Linq;

namespace ITS.Dottor.Northwind.SqlConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Pooling=False";
            var products = new List<Product>();
            var query = "select ProductID, ProductName, UnitPrice from Products Where CategoryId = @catId";

            // ADO.NET
            /*using(var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using(var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = System.Data.CommandType.Text;
                    //command.Parameters.Add(new SqlParameter("catId", 1));
                    command.Parameters.AddWithValue("catId", 1);

                    // quando non mi aspetto dati di ritorno --> command.ExecuteNonQuery()
                    // quando ho un unico valore di ritorno  --> command.ExecuteScalar()

                    using(var reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            var product = new Product();
                            product.ProductID = (int)reader["ProductID"];
                            //product.ProductID = reader.GetInt32(reader.GetOrdinal("ProductID"));
                            //product.ProductID = (int)reader.GetValue(reader.GetOrdinal("ProductID"));

                            product.ProductName = reader["ProductName"] as string;

                            //if (!reader.IsDBNull(reader.GetOrdinal("UnitPrice")))
                            //    product.UnitPrice = (decimal)reader["UnitPrice"];

                            //if (reader["UnitPrice"] != DBNull.Value)
                            //    product.UnitPrice = (decimal)reader["UnitPrice"];

                            product.UnitPrice = (reader["UnitPrice"] == DBNull.Value) ? null : (decimal?)reader["UnitPrice"];

                            products.Add(product);
                        }
                    }
                }
            }*/


            // Dapper
            using (var connection = new SqlConnection(connectionString))
            {
                // lista        -> connection.Query<Product>(...)
                // dettaglio    -> connection.QueryFirstOrDefault<Product>(...)
                // inserimento, modifica, cancellazione     -> connection.Execute(...)
                // query che ritorna un singolo valore      -> connection.ExecuteScalar<int>(...)
                products = connection.Query<Product>(query, new { catId = 1 }).ToList();
            }

            foreach (var item in products)
            {
                WriteLine($"{item.ProductID} {item.ProductName}");
            }


            WriteLine("END");
            ReadKey();
        }
    }
}
