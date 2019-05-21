using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_TransportCompany.Models.Enums;
using WebApp_TransportCompany.ViewModels;

namespace WebApp_TransportCompany.Repositories
{
    public interface IStatisticsRepository
    {

        Task<List<ChartDataset>> GetTruckStatistics(IdentityUser identityUser, DateTime? dateTime);

        Task<List<ChartDataset>> GetDriverStatistics(IdentityUser identityUser, DateTime? dateTime);

        Task<List<ChartDataset>> GetOrderStatistic(IdentityUser identityUser, DateTime? dateTime);

        Task<ChartDataset> GetTruckStatistics(IdentityUser identityUser, DateTime? dateTime, int id);

        Task<ChartDataset> GetDriverStatistics(IdentityUser identityUser, DateTime? dateTime, int id);

        int GetStatusTruckCount(IdentityUser identityUser, TruckStatus truckStatus);

        int GetConditionTruckCount(IdentityUser identityUser, TruckCondition truckCondition);

        int GetStatusOrderCount(IdentityUser identityUser, OrderState orderState);

        int GetPaidOrderCount(IdentityUser identityUser, bool paid);
    }
}
