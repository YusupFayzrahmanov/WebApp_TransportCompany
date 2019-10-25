using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApp_TransportCompany.Models.Enums;

namespace WebApp_TransportCompany.Models
{
    /// <summary>
    /// Заправка по отчету
    /// </summary>
    public class RefuelingReport
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Водитель
        /// </summary>
        [ForeignKey("DriverId")]
        public Driver Driver { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int DriverId { get; set; }

        /// <summary>
        /// Транспорт, который был заправлен
        /// </summary>
        [ForeignKey("TruckId")]
        public Truck Truck { get; set; }

        /// <summary>
        /// Внешний ключ
        /// </summary>
        public int? TruckId { get; set; }
        
        /// <summary>
        /// Дата заправки
        /// </summary>
        public DateTime RefuelDate { get; set; }

        /// <summary>
        /// Заправочная станция
        /// </summary>
        public GasStation GasStation { get; set; }

        /// <summary>
        /// Кол-во литров
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal Liters { get; set; }

        /// <summary>
        /// Цена за литр
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

    }
}
