using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_TransportCompany.Repositories
{
    public interface IRepository:IDisposable
    {
        Task Save();
    }
}
