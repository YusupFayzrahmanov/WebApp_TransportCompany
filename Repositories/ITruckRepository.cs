using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_TransportCompany.Models;
using WebApp_TransportCompany.Models.Enums;

namespace WebApp_TransportCompany.Repositories
{
    public interface ITruckRepository
    {
        Task<IEnumerable<Truck>> GetTrucks(IdentityUser user);

        Task<IEnumerable<Truck>> GetTrucks(IdentityUser user, TruckStatus truckStatus);

        Task<IEnumerable<Truck>> GetTrucks(IdentityUser user, TruckCondition truckCondition);

        Task<Truck> GetTruck(int id);

        Truck GetTruckByCardNumber(string number);

        Task AddTruck(Truck truck);

        Task DeleteTruck(Truck truck);

        Task UpdateTruck(Truck truck);
    }
}
