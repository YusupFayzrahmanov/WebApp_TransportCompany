using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp_TransportCompany.Models.Enums;

namespace WebApp_TransportCompany.Models
{
    /// <summary>
    /// Колесо
    /// </summary>
    public class Wheel
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
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Предыдущее колесо
        /// </summary>
        public Wheel PreviousWheel { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        /// <summary>
        /// Текущий пробег
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal CurrentMileage { get; set; }

        /// <summary>
        /// Флаг использования
        /// </summary>
        public bool IsUsed { get; set; }

        /// <summary>
        /// Дата установки
        /// </summary>
        public DateTime InstallationDate { get; set; }

        /// <summary>
        /// Дата поломки
        /// </summary>
        public DateTime? BreakdownDate { get; set; }

        /// <summary>
        /// Состояние
        /// </summary>
        public WheelCondition Condition { get; set; }

        /// <summary>
        /// Место
        /// </summary>
        public WheelPlace Place { get; set; }

        /// <summary>
        /// Доп. инфа
        /// </summary>
        public string Note { get; set; }

    }
}
