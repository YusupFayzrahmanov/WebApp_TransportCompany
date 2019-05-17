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
    public class DriverRepository:BaseRepository, IDriverRepository
    {
        public DriverRepository(ApplicationDbContext context)
            :base(context)
        {

        }

        public async Task AddDriver(Driver driver)
        {
            await _context.Drivers.AddAsync(driver);
        }

        public void DeleteDriver(Driver driver)
        {
            _context.Drivers.Remove(driver);
        }

        public async Task<Driver> GetDriver(int id)
        {
            return await _context.Drivers
                .Include(x => x.TruckHistories)
                .Include(x => x.Orders)
                .Include(x => x.Repairs)
                .Include(x => x.Salaries)
                .Include(x => x.Reports)
                .Include(x => x.Truck)
                    .ThenInclude(x => x.Identity)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Driver>> GetDrivers(IdentityUser user)
        {
            return await _context.Drivers
                .Include(x => x.TruckHistories)
                .Include(x => x.Orders)
                .Include(x => x.Repairs)
                .Include(x => x.Salaries)
                .Include(x => x.Reports)
                .Include(x => x.Truck)
                    .ThenInclude(x => x.Identity)
                .Where(x => x.Identity.Id == user.Id)
                .ToListAsync();
        }

        public void UpdateDriver(Driver driver)
        {
            _context.Drivers.Update(driver);
        }
    }
}
