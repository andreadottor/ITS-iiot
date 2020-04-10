using System;
using System.Collections.Generic;
using System.Text;

namespace Dottor.Classes
{
    interface IUser
    {

        string FirstName { get; }
        string LastName { get; }

        DateTime BirthDate { get; }

        string GetDescription();

    }
}
