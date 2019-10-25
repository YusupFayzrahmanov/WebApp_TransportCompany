using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp_TransportCompany.Models
{
    /// <summary>
    /// Отчет
    /// </summary>
    public class Report
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Грузовик
        /// </summary>
        [ForeignKey("TruckId")]
        public Truck Truck { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? TruckId { get; set; }

        /// <summary>
        /// Водитель
        /// </summary>
        [ForeignKey("DriverId")]
        public Driver Driver { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? DriverId { get; set; }

        /// <summary>
        /// Дата отбытия
        /// </summary>
        public DateTime DepartureDate { get; set; }

        /// <summary>
        /// Дата прибытия
        /// </summary>
        public DateTime ArrivalDate { get; set; }

        /// <summary>
        /// Оставшееся топливо перед отбытием
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal DepartureRemainderFuel { get; set; }

        /// <summary>
        /// Оставшееся топливо после прибытия
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal ArrivalRemainderFuel { get; set; }

        /// <summary>
        /// Пробег до отбытия
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal DepartureMileage { get; set; }

        /// <summary>
        /// Пробег после прибытия
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal ArrivalMileage { get; set; }

        /// <summary>
        /// Получено денег
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal ReceivedMoney { get; set; }

        /// <summary>
        /// Потрачено денег
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal SpentMoney { get; set; }

        /// <summary>
        /// Средняя цена топлива
        /// </summary>
        public decimal AverageFuelPrice { get; set; }

        /// <summary>
        /// Средний расход топлива
        /// </summary>
        public decimal AverageFuelConsumption { get; set; }

        /// <summary>
        /// Доп. инфа
        /// </summary>
        public string Note { get; set; }

    }
}
