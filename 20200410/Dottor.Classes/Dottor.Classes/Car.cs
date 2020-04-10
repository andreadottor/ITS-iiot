using System;
using System.Collections.Generic;
using System.Text;

namespace Dottor.Classes
{
    abstract class Car: IDescription
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public abstract string GetDescription();

        public virtual string GetDescription(string prefix)
        {
            return $"{prefix} {GetDescription()}";
        }
    }
}
