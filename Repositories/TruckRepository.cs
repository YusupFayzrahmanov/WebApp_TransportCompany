using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp_TransportCompany.Data;
using WebApp_TransportCompany.Models;
using WebApp_TransportCompany.Models.Enums;

namespace WebApp_TransportCompany.Repositories
{
    public class TruckRepository:BaseRepository, ITruckRepository
    {
        public TruckRepository(ApplicationDbContext context)
            :base(context)
        {

        }

        public async Task AddTruck(Truck truck)
        {
            await _context.Trucks.AddAsync(truck);
            await Save();
        }

        public async Task DeleteTruck(Truck truck)
        {
            _context.Trucks.Remove(truck);
            await Save();
        }

        public async Task<Truck> GetTruck(int id)
        {
            return await _context.Trucks
                .Include(x => x.Drivers)
                .Include(x => x.Orders)
                .Include(x => x.RefuelingChecks)
                .Include(x => x.RefuelingSensors)
                .Include(x => x.Repairs)
                .Include(x => x.Wheels)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public Truck GetTruckByCardNumber(string number)
        {
            return _context.Trucks
                .Include(x => x.TatneftCard)
                .FirstOrDefault(x => x.TatneftCard.Number == number);
        }

        public async Task<IEnumerable<Truck>> GetTrucks(IdentityUser user)
        {
            return await _context.Trucks
                .Include(x => x.Drivers)
                .Include(x => x.Orders)
                .Include(x => x.RefuelingChecks)
                .Include(x => x.RefuelingSensors)
                .Include(x => x.Repairs)
                .Include(x => x.Wheels)
                .Where(x => x.IsActual && x.Identity.Id == user.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Truck>> GetTrucks(IdentityUser user, TruckStatus truckStatus)
        {
            return await _context.Trucks
                .Include(x => x.Drivers)
                .Include(x => x.Orders)
                .Include(x => x.RefuelingChecks)
                .Include(x => x.RefuelingSensors)
                .Include(x => x.Repairs)
                .Include(x => x.Wheels)
                .Where(x => x.IsActual && x.Identity.Id == user.Id && x.Status == truckStatus)
                .ToListAsync();
        }

        public async Task<IEnumerable<Truck>> GetTrucks(IdentityUser user, TruckCondition truckCondition)
        {
            return await _context.Trucks
                .Include(x => x.Drivers)
                .Include(x => x.Orders)
                .Include(x => x.RefuelingChecks)
                .Include(x => x.RefuelingSensors)
                .Include(x => x.Repairs)
                .Include(x => x.Wheels)
                .Where(x => x.IsActual && x.Identity.Id == user.Id && x.Condition == truckCondition)
                .ToListAsync();
        }

        public async Task UpdateTruck(Truck truck)
        {
            _context.Trucks.Update(truck);
            await Save();
        }
    }
}
