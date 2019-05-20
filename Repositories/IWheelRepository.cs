using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_TransportCompany.Models;

namespace WebApp_TransportCompany.Repositories
{
    public interface IWheelRepository
    {
        Task<IEnumerable<Wheel>> GetWheels(IdentityUser user);

        Task<IEnumerable<Wheel>> GetTruckWheels(Truck truck);

        Task<IEnumerable<Wheel>> GetTruckUsedWheels(Truck truck);

        Task<IEnumerable<Wheel>> GetTruckUnusedWheels(Truck truck);

        Task<Wheel> GetWheel(int id);

        Task AddWheel(Wheel wheel);

        Task DeleteWheel(Wheel wheel);

        Task UpdateWheel(Wheel wheel);


    }
}
