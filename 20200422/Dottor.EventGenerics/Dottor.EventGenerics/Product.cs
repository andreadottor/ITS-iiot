using System;
using System.Collections.Generic;
using System.Text;

namespace Dottor.EventGenerics
{
    class Product : EntityBase<int>
    {

        public decimal Price { get; set; }
    }
}
