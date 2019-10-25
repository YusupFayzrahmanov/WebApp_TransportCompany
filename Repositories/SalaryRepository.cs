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
    public class SalaryRepository:BaseRepository, ISalaryRepository
    {
        public SalaryRepository(ApplicationDbContext context)
            :base(context)
        {

        }

        public async Task AddSalary(Salary salary)
        {
            await _context.Salaries.AddAsync(salary);
            await Save();
        }

        public async Task DeleteSalary(Salary salary)
        {
            _context.Salaries.Remove(salary);
            await Save();
        }

        public async Task<IEnumerable<Salary>> GetDirverSalaries(Driver driver)
        {
            return await _context.Salaries
                .Include(x => x.Driver)
                    .ThenInclude(x => x.Truck)
                .Where(x => x.Driver.Id == driver.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Salary>> GetSalaries(IdentityUser user)
        {
            return await _context.Salaries
               .Include(x => x.Driver)
                   .ThenInclude(x => x.Truck)
               .ToListAsync();
        }

        public async Task<IEnumerable<Salary>> GetSalariesByDate(DateTime start, DateTime end)
        {
            return await _context.Salaries
               .Include(x => x.Driver)
                   .ThenInclude(x => x.Truck)
               .Where(x => x.StartPeriod >= start && x.EndPeriod <= end)
               .ToListAsync();
        }

        public async Task<Salary> GetSalary(int id)
        {
            return await _context.Salaries
               .Include(x => x.Driver)
                   .ThenInclude(x => x.Truck)
               .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateSalary(Salary salary)
        {
            _context.Salaries.Update(salary);
            await Save();
        }
    }
}
