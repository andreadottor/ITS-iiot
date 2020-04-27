using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Dottor.EventGenerics
{
    class Program
    {
        static void Main(string[] args)
        {

            var tm = new TimerManager("TEST");
            tm.Initialized += Tm_Initialized;
            tm.Initialize();


            // ======================================

            var item = new Item<int, string>(1, "Andrea");
            var item2 = new Item<Guid, DateTime>(Guid.NewGuid(), DateTime.Now);
            var item3 = new Item<string, string>("ABC", "Pordenone");
            var item4 = CreateItem("ABC", "Pordenone");
            var item5 = CreateItem(Guid.NewGuid(), DateTime.Now);

            var dict = new Dictionary<int, string>();
            var t1 = new Tuple<int, string, string>(1, "AAA", "BBB");

            // ======================================

            var list = new List<Product>();
            var random = new Random();
            for (int i = 0; i < 100; i++)
            {
                list.Add(new Product
                {
                    Id = i,
                    Name = "Prodotto " + i,
                    Price = random.Next(0, 1000)
                });
            }

            // prezzo inferiore a 100
            var priceLess100 = (from p in list
                                where p.Price <= 100 && p.Price > 0
                                select new { 
                                        Description = p.Name,
                                        Price = p.Price
                                    }).ToArray();

            var priceLess100_2 = list.Where(p => p.Price <= 100 && p.Price > 0)
                                    .Select(p => new {
                                        Description = p.Name,
                                        Price = p.Price
                                    })
                                    .ToArray();

            var priceLess100_3 = (from p in list
                                where p.Price <= 100 && p.Price > 0
                                select p.Name).ToArray();

            var first = list.First();
            var first2 = list.FirstOrDefault();


            var firstAfter100 = (from p in list
                                 where p.Price > 100
                                 orderby p.Price
                                 select p).FirstOrDefault();

            var firstAfter100_2 = list
                                    .Where(p => p.Price > 100)
                                    .OrderBy(p => p.Price)
                                    .FirstOrDefault();

            var firstAfter100_3 = list
                                    .OrderBy(p => p.Price)
                                    .FirstOrDefault(p => p.Price > 100);

            var p50 = list.FirstOrDefault(p => p.Id == 50);

            

            foreach (var product in priceLess100)
            {
                Console.WriteLine($"{product.Description}: {product.Price}");
            }
      


            Console.WriteLine("END");
            Console.ReadLine();
        }

        private static void Tm_Initialized(object sender, TimerInitializedEventArgs e)
        {
            Console.WriteLine($"TimerManager {e.Name} inizializzato");
        }

        public static Item<TKey, TValue> CreateItem<TKey, TValue>(TKey key, TValue value)
        {
            return new Item<TKey, TValue>(key, value);
        }

    }
}
