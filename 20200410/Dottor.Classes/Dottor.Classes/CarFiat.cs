using System;
using System.Collections.Generic;
using System.Text;

namespace Dottor.Classes
{
    class CarFiat : Car
    {
        public CarFiat()
        {
            this.Make = "FIAT";
        }

        public CarFiat(string model)
        {
            this.Make = "FIAT";
            this.Model = model;
        }

        public override string GetDescription()
        {
            return $"{Make} {Model}";
        }
    }
}
