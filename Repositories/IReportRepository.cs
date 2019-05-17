using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_TransportCompany.Models;

namespace WebApp_TransportCompany.Repositories
{
    public interface IReportRepository
    {
        Task<IEnumerable<Report>> GetReports(IdentityUser user);

        Task<IEnumerable<Report>> GetReports(Truck truck);

        Task<IEnumerable<Report>> GetDriverReports(Driver driver);

        Task<IEnumerable<Report>> GetReportsByDate(DateTime start, DateTime end);
        Task<Report> GetReport(int id);

        Task AddReport(Report report);

        void DeleteReport(Report report);

        void UpdateReport(Report report);
    }
}
