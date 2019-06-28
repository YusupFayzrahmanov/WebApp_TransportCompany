using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp_TransportCompany.Models.Enums;

namespace WebApp_TransportCompany.Models
{
    /// <summary>
    /// Ремонт
    /// </summary>
    public class Repair
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Грузовик
        /// </summary>
        public Truck Truck { get; set; }


        /// <summary>
        /// Тип ремонта
        /// </summary>
        public RepairType RepairType { get; set; }
        
        /// <summary>
        /// Ссылка на предыдущий ремонт
        /// </summary>
        public Repair PreviousRepair { get; set; }
        
        /// <summary>
        /// Водитель
        /// </summary>
        public Driver Driver { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        /// 
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        /// <summary>
        /// Дата ремонта
        /// </summary>
        public DateTime RepairDate { get; set; }

        /// <summary>
        /// Гарантия
        /// </summary>
        public bool Guarantee { get; set; }

        /// <summary>
        /// Дата окончания гарантии
        /// </summary>
        public DateTime? GuaranteeDeadline { get; set; }

        /// <summary>
        /// Наименование компании
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

    }
}
