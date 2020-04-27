using System;
using System.Collections.Generic;
using System.Text;

namespace Dottor.WorkerServiceDemo.Services
{
    public interface IDataAccess
    {

        IEnumerable<string> GetList();

    }
}
