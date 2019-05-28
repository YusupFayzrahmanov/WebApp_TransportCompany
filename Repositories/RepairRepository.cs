using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp_TransportCompany.Data;
using WebApp_TransportCompany.Models;

namespace WebApp_TransportCompany.Repositories
{
    public class RepairRepository:BaseRepository,IRepairRepository
    {
        public RepairRepository(ApplicationDbContext context)
            :base(context)
        {

        }

        public async Task AddRepair(Repair repair)
        {
            await _context.Repairs.AddAsync(repair);
            await Save();
        }

        public async Task AddRepairType(RepairType repairType)
        {
            await _context.RepairTypes.AddAsync(repairType);
            await Save();
        }

        public async Task DeleteRepair(Repair repair)
        {
            _context.Repairs.Remove(repair);
            await Save();
        }

        public async Task<Repair> GetRepair(int id)
        {
            return await _context.Repairs
                .Include(x => x.Truck)
                .ThenInclude(x => x.Identity)
                .Include(x => x.Driver)
                .ThenInclude(x => x.Truck)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Repair> GetRepair(Truck truck)
        {
            return await _context.Repairs
                .Include(x => x.PreviousRepair)
                .Include(x => x.RepairType)
                .Include(x => x.Truck)
                    .ThenInclude(x => x.Identity)
                .Include(x => x.Driver)
                    .ThenInclude(x => x.Truck)
                .FirstOrDefaultAsync(x => x.Truck.Id == truck.Id);
        }

        public async Task<Repair> GetRepair(Driver driver)
        {
            return await _context.Repairs
                .Include(x => x.PreviousRepair)
                .Include(x => x.RepairType)
                .Include(x => x.Truck)
                    .ThenInclude(x => x.Identity)
                .Include(x => x.Driver)
                    .ThenInclude(x => x.Truck)
                .FirstOrDefaultAsync(x => x.Driver.Id == driver.Id);
        }

        public async Task<IEnumerable<Repair>> GetRepairs(IdentityUser user)
        {
            return await _context.Repairs
               .Include(x => x.PreviousRepair)
               .Include(x => x.RepairType)
               .Include(x => x.Truck)
                   .ThenInclude(x => x.Identity)
               .Include(x => x.Driver)
                   .ThenInclude(x => x.Truck)
               .Where(x => x.Truck.Identity.Id == user.Id)
               .ToListAsync();
        }

        public async Task<IEnumerable<Repair>> GetRepairs(Truck truck)
        {
            return await _context.Repairs
               .Include(x => x.PreviousRepair)
               .Include(x => x.RepairType)
               .Include(x => x.Truck)
                   .ThenInclude(x => x.Identity)
               .Include(x => x.Driver)
                   .ThenInclude(x => x.Truck)
               .Where(x => x.Truck.Id == truck.Id)
               .ToListAsync();
        }

        public async Task<IEnumerable<Repair>> GetRepairs(Driver driver)
        {
            return await _context.Repairs
               .Include(x => x.PreviousRepair)
               .Include(x => x.RepairType)
               .Include(x => x.Truck)
                   .ThenInclude(x => x.Identity)
               .Include(x => x.Driver)
                   .ThenInclude(x => x.Truck)
               .Where(x => x.Driver.Id == driver.Id)
               .ToListAsync();
        }

        public async Task<RepairType> GetRepairType(int id)
        {
            return await _context.RepairTypes.FindAsync(id);
        }

        public async Task<IEnumerable<RepairType>> GetRepairTypes(IdentityUser identityUser)
        {
            return await _context.RepairTypes
                .Where(x => x.Identity.Id == identityUser.Id)
                .ToListAsync();
        }

        public async Task RemoveRepairType(RepairType repairType)
        {
            _context.RepairTypes.Remove(repairType);
            await Save();
        }

        public async Task UpdateRepair(Repair repair)
        {
            _context.Repairs.Update(repair);
            await Save();
        }

        public async Task UpdateRepairType(RepairType repairType)
        {
            _context.RepairTypes.Update(repairType);
            await Save();
        }
    }
}
