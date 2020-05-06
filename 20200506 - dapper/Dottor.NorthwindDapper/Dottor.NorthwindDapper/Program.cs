using Dottor.NorthwindDapper.Data;
using System;

namespace Dottor.NorthwindDapper
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataAccess data = new DapperDataAccess();
            var categories = data.GetCategories();

            var cat12 = data.GetCategory(12);
            var cat3 = data.GetCategory(3);

        }
    }
}
