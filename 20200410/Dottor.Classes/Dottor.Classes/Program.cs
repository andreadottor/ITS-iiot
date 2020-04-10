using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Dottor.Classes
{
    class Program
    {
        static void Main(string[] args)
        {

            var list = new List<User>();
            list.Add(new User("Andrea", "Dottor"));
            list.Add(new Employee("Mario", "Rossi", "ACME"));

            Print(list);

            var list2 = new List<IDescription>();
            list2.Add(new User());
            list2.Add(new CarFiat("Panda"));

            Print(list2);
        }

        static void Print(IEnumerable<IDescription> list)
        {
            foreach (var item in list)
            {
                if(item is Car)
                {
                    var car = item as Car;

                    Console.WriteLine("CAR");
                }

                Console.WriteLine(item.GetDescription());
            }
        }


    }
}
