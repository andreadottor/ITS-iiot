using System;
using System.Collections.Generic;
using System.Text;

namespace Dottor.EventGenerics
{
    class Item<TKey, TValue>
    {

        public TKey Key { get; set; }
        public TValue Value { get; set; }

        public Item()
        {

        }

        public Item(TKey key, TValue value)
        {
            this.Key = key;
            this.Value = value;
        }

    }
}
