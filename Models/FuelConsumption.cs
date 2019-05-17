using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace WebApp_TransportCompany.Models
{
    /// <summary>
    /// Расход топлива
    /// </summary>
    public class FuelConsumption
    {
        public int Id { get; set; }

        public IdentityUser IdentityUser { get; set; }

        /// <summary>
        /// Ссылка на грузовик
        /// </summary>
        public Truck Truck { get; set; }

        /// <summary>
        /// Водители
        /// </summary>
        public IEnumerable<Driver> Drivers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<RefuelingReport> Refuelings { get; set; }

        /// <summary>
        /// Начало отчета о расходе топлива
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Конец даты отчета о расходе топлива
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Расход по отчету
        /// </summary>
        public decimal? ConsumptionToReport { get; set; }

        /// <summary>
        /// Расходы по чекам
        /// </summary>
        public decimal? ConsumptionToCheck { get; set; }

        /// <summary>
        /// Расход по датчикам
        /// </summary>
        public decimal? ConsumptionToSensor { get; set; }


    }
}
