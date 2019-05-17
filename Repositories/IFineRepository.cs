using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_TransportCompany.Models;

namespace WebApp_TransportCompany.Repositories
{
    public interface IFineRepository
    {
        Task<Fine> GetFine(int id);

        Task<IEnumerable<Fine>> GetFines(IdentityUser identityUser);

        Task<IEnumerable<Fine>> GetTruckFines(Truck truck);

        Task<IEnumerable<Fine>> GetDriverFines(Driver driver);

        Task AddFine(Fine fine);

        void UpdateFine(Fine fine);

        void RemoveFine(Fine fine);

    }
}
