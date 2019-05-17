using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_TransportCompany.ViewModels;

namespace WebApp_TransportCompany.Repositories
{
    public interface IStatisticsRepository
    {

        Task<List<ChartDataset>> GetTruckStatistics(IdentityUser identityUser, DateTime? dateTime);

        Task<List<ChartDataset>> GetDriverStatistics(IdentityUser identityUser, DateTime? dateTime);

        Task<List<ChartDataset>> GetOrderStatistic(IdentityUser identityUser, DateTime? dateTime);
    }
}
