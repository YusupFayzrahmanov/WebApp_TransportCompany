using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_TransportCompany.Models
{
    /// <summary>
    /// Штрафы ПДД
    /// </summary>
    public class Fine
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Дата
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Сумма
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Грузовик
        /// </summary>
        [ForeignKey("TruckId")]
        public Truck Truck { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int TruckId { get; set; }

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
        /// Причина
        /// </summary>
        public string Principle { get; set; }

    }
}
