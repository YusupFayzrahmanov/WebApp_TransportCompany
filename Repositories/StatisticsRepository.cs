using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebApp_TransportCompany.Data;
using WebApp_TransportCompany.Extensions;
using WebApp_TransportCompany.Models;
using WebApp_TransportCompany.Models.Enums;
using WebApp_TransportCompany.ViewModels;

namespace WebApp_TransportCompany.Repositories
{
    public class StatisticsRepository : BaseRepository, IStatisticsRepository
    {
        public StatisticsRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public async Task<List<ChartDataset>> GetDriverStatistics(IdentityUser identityUser, DateTime? dateTime)
        {
            var date = dateTime ?? DateTime.Now;
            //var stats = from order in _context.Orders
            //            where order.StartDate.Year == date.Year
            //            group order by order.Driver into driverToOrders
            //            select new
            //            {
            //                Driver = driverToOrders.Key,
            //                MonthsToOrders = from order in driverToOrders
            //                                 group order by order.StartDate.Month into monthToOrders
            //                                 select new
            //                                 {
            //                                     MonthToOrder = new
            //                                     {
            //                                         Orders = monthToOrders
            //                                     }
            //                                 }
            //            };

            List<ChartDataset> chartDatasets = new List<ChartDataset>();
            //foreach (var pair in stats)
            //{
            //    var driver = pair.Driver;
                
            //    foreach (var pair2 in pair.MonthsToOrders)
            //    {
            //        var month = pair2.MonthToOrder;

            //        foreach (var order in month.Orders)
            //        {
            //            chartDatasets.Add(new ChartDataset()
            //            {
            //                Label = driver.Name + " " + driver.Surname,
            //                Color = ColorHelper.GetColorByID(driver.Id),
            //                Data = 
            //            });
            //        }
            //    }
            //}

            var _statistics = from item in _context.Drivers
                              where item.DriverStatus != Models.Enums.DriverStatus.Fired
                              select new ChartDataset()
                              {
                                  id = item.Id,

                                  label = item.Name + item.Surname,

                                  backgroundColor = ColorHelper.GetColorByID(item.Id),

                                  borderColor = ColorHelper.GetColorByID(item.Id),

                                  data = JsonConvert.SerializeObject(GetMonthEarnings(item.Orders
                                    .Where(x => x.IsPaid && x.State == Models.Enums.OrderState.Close && x.StartDate.Year == date.Year)
                                    .ToList()))
                              };
            return await _statistics.ToListAsync();
        }

        public async Task<List<ChartDataset>> GetOrderStatistic(IdentityUser identityUser, DateTime? dateTime)
        {
            var date = dateTime ?? DateTime.Now;
            List<ChartDataset> _statistics = new List<ChartDataset>();
            var _orders = await _context.Orders
                .Where(x => x.IsPaid && x.State == Models.Enums.OrderState.Close && x.StartDate.Year == date.Year)
                .ToListAsync();

            _statistics.Add(new ChartDataset()
            {
                label = "Прибыль",

                backgroundColor = "#FF0000",

                borderColor = "#FF0000",

                data = JsonConvert.SerializeObject(GetMonthEarnings(_orders))
            });
            return _statistics;
        }

        public async Task<List<ChartDataset>> GetTruckStatistics(IdentityUser identityUser, DateTime? dateTime)
        {
            var date = dateTime ?? DateTime.Now;
            var _statistics = from item in _context.Trucks
                              where item.IsActual
                              select new ChartDataset()
                              {
                                  id = item.Id,

                                  label = item.Name + " " + item.Model,

                                  backgroundColor = ColorHelper.GetColorByID(item.Id),

                                  borderColor = ColorHelper.GetColorByID(item.Id),
                                  
                                  data = JsonConvert.SerializeObject(GetMonthEarnings(item.Orders
                                    .Where(x => x.IsPaid && x.State == Models.Enums.OrderState.Close && x.StartDate.Year == date.Year)
                                    .ToList()))
                              };
            return await _statistics.ToListAsync();
        }

        private static decimal[] GetMonthEarnings(List<Order> orders)
        {
            decimal[] data = new decimal[12];
            for (int i = 0; i < 12; i++)
            {
                data[i] = orders.Where(x => x.StartDate.Month == (i + 1)).Sum(x => x.Price) ?? 0;
            }

            return data;
        }

        public Task<int> GetStatusTruckCount(IdentityUser identityUser, TruckStatus truckStatus)
        {
            //return await _context.Trucks
            //    .Where(x => x.Identity.Id == identityUser.Id && x.IsActual && x.Status == truckStatus)
            //    .Count();
            throw new NotImplementedException();
        }

        public Task<int> GetConditionTruckCount(IdentityUser identityUser, TruckCondition truckCondition)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetStatusOrderCount(IdentityUser identityUser, OrderState orderState)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetPaidOrderCount(IdentityUser identityUser, bool paid)
        {
            throw new NotImplementedException();
        }

        //private ChartDataset GetAverageTruckDataset(DateTime dateTime)
        //{
        //    return new ChartDataset()
        //    {
        //        Label = "Среднее",

        //        Color = "#FF0000"
        //    };
        //}
    }
}
