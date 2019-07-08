using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_TransportCompany.Models
{
    /// <summary>
    /// История грузовиков водителя
    /// </summary>
    public class DriverTruckHistory
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
        /// Начало
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Конец
        /// </summary>
        public DateTime EndDate { get; set; }
    }
}
