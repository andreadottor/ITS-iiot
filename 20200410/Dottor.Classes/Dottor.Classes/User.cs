using System;
using System.Collections.Generic;
using System.Text;

namespace Dottor.Classes
{
    class User : IUser, ICloneable, IDescription
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public User()
        {
        }

        public User(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public virtual string GetDescription()
        {
            return $"{FirstName} {LastName}";
        }

        public object Clone()
        {
            return new User()
            { 
                BirthDate = this.BirthDate,
                FirstName = this.FirstName,
                LastName = this.LastName
            };
            
        }
    }
}
