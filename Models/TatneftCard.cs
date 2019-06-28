using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace WebApp_TransportCompany.Models
{
    /// <summary>
    /// Карта для заправок ТатНефть
    /// </summary>
    public class TatneftCard
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Номер карты
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        public IdentityUser Identity { get; set; }

        /// <summary>
        /// Дата
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// Примечание
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Водители
        /// </summary>
        public IEnumerable<Driver> Drivers { get; set; } = new List<Driver>();
    }
}
