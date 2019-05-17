using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_TransportCompany.Models
{
    /// <summary>
    /// Тип ремонта
    /// </summary>
    public class RepairType
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        public IdentityUser Identity { get; set; }

        /// <summary>
        /// Наименование тип ремонта
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Ресурс километров
        /// </summary>
        public decimal? KilometersResource { get; set; }

        /// <summary>
        /// Ресурс времени
        /// </summary>
        public TimeSpan TimeResource { get; set; }
    }
}
