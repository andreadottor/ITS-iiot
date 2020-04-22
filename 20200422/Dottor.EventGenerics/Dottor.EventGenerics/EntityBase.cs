using System;
using System.Collections.Generic;
using System.Text;

namespace Dottor.EventGenerics
{
    abstract class EntityBase<T>
    {
        public T Id { get; set; }

        public string Name { get; set; }
    }
}
