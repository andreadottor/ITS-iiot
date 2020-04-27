using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Dottor.ListAndFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<User>();
            list.Add(new User(1, "Andrea", "Dottor"));
            list.Add(new User(2, "Mario", "Rossi"));
            list.Add(new User(2, "Mario", "Rossi"));

            var list2 = new List<User>
            {
                new User(1, "Andrea", "Dottor"),
                new User(2, "Mario", "Rossi")
            };

            var array = new User[] 
            {  
                new User(1, "Andrea", "Dottor"),
                new User(2, "Mario", "Rossi")
            };

            PrintList(list);
            PrintList(list2);
            PrintList(array);

            var dict = new Dictionary<int, User>();
            dict.Add(1, new User(1, "Andrea", "Dottor"));
            dict.Add(2, new User(2, "Mario", "Rossi"));

            // verifico se esiste un elemento con una particolare chiave
            // dict.ContainsKey(2)

            // recupero un elemento data la chiave del dictonary (e non l'indice)
            var user = dict[2];

            var userPippo = new User(3, "Pippo", "Pippo");
            if(dict.ContainsKey(3))
            {
                dict[3] = userPippo;
                Console.WriteLine(dict[3].FirstName);
            }
            else
            {
                dict.Add(userPippo.Id, userPippo);
            }

            // ====================================================
            // namespace System.IO
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "data-di-oggi.txt");
            
            // IDisposable
            using (var writer = new StreamWriter(filePath))
            {
                writer.Write(DateTime.Now.ToString("dd MMMM yyyy HH:mm:ss"));
            }

            using (var reader = new StreamReader(filePath))
            {
                var fileContent = reader.ReadToEnd();
                Console.WriteLine($"Il contenuto del file è: '{fileContent}'");
            }

            /*
                var fileAllText = File.ReadAllText(filePath);
                File.WriteAllText(filePath, DateTime.Now.ToString("dd MMMM yyyy HH:mm:ss"));
            */

            Console.WriteLine("END");
            Console.ReadLine();
        }




        public static void PrintList(IEnumerable<User> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }
        }
    }
}
