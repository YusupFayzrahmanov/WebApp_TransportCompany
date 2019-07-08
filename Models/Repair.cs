using System;
using System.ComponentModel.DataAnnotations.Schema;

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
        [ForeignKey("TruckId")]
        public Truck Truck { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int TruckId { get; set; }


        /// <summary>
        /// Тип ремонта
        /// </summary>
        [ForeignKey("RepairTypeId")]
        public RepairType RepairType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? RepairTypeId { get; set; }

        /// <summary>
        /// Ссылка на предыдущий ремонт
        /// </summary>
        [ForeignKey("PreviousRepairId")]
        public Repair PreviousRepair { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? PreviousRepairId { get; set; }

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
