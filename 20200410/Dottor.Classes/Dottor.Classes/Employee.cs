using System;
using System.Collections.Generic;
using System.Text;

namespace Dottor.Classes
{
    class Employee: User
    {
        public string Company { get; set; }
        
        /// <summary>
        /// ctor
        /// </summary>
        public Employee()
        {
        }

        public Employee(string firstName, string lastName, string company)
            : base(firstName, lastName)
        {
            this.Company = company;
        }

        public override string GetDescription()
        {
            return $"{FirstName} {LastName} ({Company})";
        }

    }
}
