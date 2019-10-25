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
    public class FineRepository:BaseRepository, IFineRepository
    {
        public FineRepository(ApplicationDbContext context)
            :base(context)
        {

        }

        public async Task AddFine(Fine fine)
        {
            await _context.Fines.AddAsync(fine);
        }

        public async Task<IEnumerable<Fine>> GetDriverFines(Driver driver)
        {
            return await _context.Fines
                .Include(x => x.Driver)
                .Include(x => x.Truck)
                    .ThenInclude(x => x.Drivers)
                .Where(x => x.Driver.Id == driver.Id)
                .ToListAsync();
        }

        public async Task<Fine> GetFine(int id)
        {
            return await _context.Fines.FindAsync(id);
        }

        public async Task<IEnumerable<Fine>> GetFines(IdentityUser identityUser)
        {
            return await _context.Fines
                .Include(x => x.Driver)
                .Include(x => x.Truck)
                    .ThenInclude(x => x.Drivers)
                .ToListAsync();
        }

        public async Task<IEnumerable<Fine>> GetTruckFines(Truck truck)
        {
            return await _context.Fines
                .Include(x => x.Driver)
                .Include(x => x.Truck)
                    .ThenInclude(x => x.Drivers)
                .Where(x => x.Truck.Id == truck.Id)
                .ToListAsync();
        }

        public async Task RemoveFine(Fine fine)
        {
            _context.Fines.Remove(fine);
            await Save();
        }

        public async Task UpdateFine(Fine fine)
        {
            _context.Fines.Update(fine);
            await Save();
        }
    }
}
