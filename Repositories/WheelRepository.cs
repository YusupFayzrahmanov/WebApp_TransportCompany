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
    public class WheelRepository:BaseRepository, IWheelRepository
    {
        public WheelRepository(ApplicationDbContext context)
            :base(context)
        {

        }

        public async Task AddWheel(Wheel wheel)
        {
            await _context.Wheels.AddAsync(wheel);
        }

        public void DeleteWheel(Wheel wheel)
        {
            _context.Wheels.Remove(wheel);
        }

        public async Task<IEnumerable<Wheel>> GetTruckUnusedWheels(Truck truck)
        {
            return await _context.Wheels
                .Include(x => x.PreviousWheel)
                    .ThenInclude(x => x.Truck)
                .Include(x => x.Truck)
                .Where(x => x.IsUsed == false && x.Truck.Id == truck.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Wheel>> GetTruckUsedWheels(Truck truck)
        {
            return await _context.Wheels
                .Include(x => x.PreviousWheel)
                    .ThenInclude(x => x.Truck)
                .Include(x => x.Truck)
                .Where(x => x.IsUsed && x.Truck.Id == truck.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Wheel>> GetTruckWheels(Truck truck)
        {
            return await _context.Wheels
                .Include(x => x.PreviousWheel)
                    .ThenInclude(x => x.Truck)
                .Include(x => x.Truck)
                .Where(x => x.Truck.Id == truck.Id)
                .ToListAsync();
        }

        public async Task<Wheel> GetWheel(int id)
        {
            return await _context.Wheels
                .Include(x => x.PreviousWheel)
                    .ThenInclude(x => x.Truck)
                .Include(x => x.Truck)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Wheel>> GetWheels(IdentityUser user)
        {
            return await _context.Wheels
                .Include(x => x.PreviousWheel)
                    .ThenInclude(x => x.Truck)
                .Include(x => x.Truck)
                .Where(x => x.Truck.Identity.Id == user.Id)
                .ToListAsync();
        }

        public void UpdateWheel(Wheel wheel)
        {
            _context.Wheels.Update(wheel);
        }
    }
}
