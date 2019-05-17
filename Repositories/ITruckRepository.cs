using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_TransportCompany.Models;

namespace WebApp_TransportCompany.Repositories
{
    public interface ITruckRepository
    {
        Task<IEnumerable<Truck>> GetTrucks(IdentityUser user);

        Task<Truck> GetTruck(int id);

        Task AddTruck(Truck truck);

        void DeleteTruck(Truck truck);

        void UpdateTruck(Truck truck);
    }
}
