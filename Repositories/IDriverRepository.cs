using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_TransportCompany.Models;

namespace WebApp_TransportCompany.Repositories
{
    public interface IDriverRepository
    {
        Task<IEnumerable<Driver>> GetDrivers(IdentityUser user);

        Task<Driver> GetDriver(int id);

        Task AddDriver(Driver driver);

        Task DeleteDriver(Driver driver);

        Task UpdateDriver(Driver driver);
    }
}
