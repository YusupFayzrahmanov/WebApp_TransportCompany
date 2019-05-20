using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_TransportCompany.Models;

namespace WebApp_TransportCompany.Repositories
{
    public interface IRepairRepository
    {
        Task<IEnumerable<Repair>> GetRepairs(IdentityUser user);

        Task<IEnumerable<Repair>> GetRepairs(Truck truck);

        Task<IEnumerable<Repair>> GetRepairs(Driver driver);

        Task<Repair> GetRepair(int id);

        Task<Repair> GetRepair(Truck truck);

        Task<Repair> GetRepair(Driver driver);

        Task AddRepair(Repair repair);

        Task DeleteRepair(Repair repair);

        Task UpdateRepair(Repair repair);


        Task<IEnumerable<RepairType>> GetRepairTypes(IdentityUser identityUser);

        Task<RepairType> GetRepairType(int id);

        Task AddRepairType(RepairType repairType);

        Task UpdateRepairType(RepairType repairType);

        Task RemoveRepairType(RepairType repairType);

    }
}
