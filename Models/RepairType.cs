using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("IdentityId")]
        public IdentityUser Identity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string IdentityId { get; set; }

        /// <summary>
        /// Наименование тип ремонта
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Ресурс километров
        /// </summary>
        public decimal KilometersResource { get; set; }

        /// <summary>
        /// Ресурс времени(месяцы)
        /// </summary>
        public int TimeResourceMonth { get; set; }
    }
}
