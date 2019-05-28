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
    public class ReportRepository:BaseRepository,IReportRepository
    {
        public ReportRepository(ApplicationDbContext context)
            :base(context)
        {

        }

        public async Task AddReport(Report report)
        {
            await _context.Reports.AddAsync(report);
            await Save();
        }

        public async Task DeleteReport(Report report)
        {
            _context.Reports.Remove(report);
            await Save();
        }

        public async Task<IEnumerable<Report>> GetDriverReports(Driver driver)
        {
            return await _context.Reports
                .Include(x => x.Driver)
                .Include(x => x.Truck)
                .Where(x => x.Driver.Id == driver.Id)
                .ToListAsync();
        }

        public async Task<Report> GetReport(int id)
        {
            return await _context.Reports
                .Include(x => x.Driver)
                .Include(x => x.Truck)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Report>> GetReports(IdentityUser user)
        {
            return await _context.Reports
                .Include(x => x.Driver)
                .Include(x => x.Truck)
                .Where(x => x.Truck.Identity.Id == user.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Report>> GetReports(Truck truck)
        {
            return await _context.Reports
                .Include(x => x.Driver)
                .Include(x => x.Truck)
                .Where(x => x.Truck.Id == truck.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Report>> GetReportsByDate(DateTime start, DateTime end)
        {
            return await _context.Reports
                .Include(x => x.Driver)
                .Include(x => x.Truck)
                .Where(x => x.DepartureDate >= start && x.ArrivalDate <= end)
                .ToListAsync();
        }

        public async Task UpdateReport(Report report)
        {
            _context.Reports.Update(report);
            await Save();
        }
    }
}
