using Dottor.Northwind.Data;
using Dottor.Northwind.Models;
using System;

namespace Dottor.Northwind
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataAccess data = new SQLDataAccess();

            // inserimento
            var newCategory = new Category 
            {
                Name = "Nuova categoria",
                Description = "Descrizione lunga della nuova categoria"
            };
            data.Insert(newCategory);

            // cancellazione
            //data.DeleteCategory(9);

            // lettura
            var categories = data.GetCategories();

            foreach (var item in categories)
            {
                Console.WriteLine($"{item.Id}) {item.Name}: {item.Description}");
            }

            var category5 = data.GetCategory(5);
            Console.WriteLine($"CATEGORIA 5: {category5.Name}");




            Console.WriteLine("END");
            Console.ReadLine();
        }
    }
}
