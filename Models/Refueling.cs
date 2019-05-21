using System;
using WebApp_TransportCompany.Models.Enums;

namespace WebApp_TransportCompany.Models
{
    public class Refueling
    {
        public RefuelingReport RefuelingReport { get; set; }

        public RefuelingCheck RefuelingCheck { get; set; }

        public RefuelingSensor RefuelingSensor { get; set; }

        public Truck Truck { get; set; }

        public Driver Driver { get; set; }

        public GasStation GasStation { get; set; }

        public DateTime RefuelDate { get; set; }

        /// <summary>
        /// Кол-во литров
        /// </summary>
        public decimal Liters { get; set; }

        /// <summary>
        /// Цена за литр
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Итого
        /// </summary>
        public decimal Total { get; set; }
    }
}
