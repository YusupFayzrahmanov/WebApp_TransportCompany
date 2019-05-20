using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp_TransportCompany.Models.Enums;

namespace WebApp_TransportCompany.Models
{
    /// <summary>
    /// Зарплата
    /// </summary>
    public class Salary
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Водитель
        /// </summary>
        public Driver Driver { get; set; }

        /// <summary>
        /// Дата операции
        /// </summary>
        public DateTime OperationDate { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Метод оплаты
        /// </summary>
        public PaymentMethod PaymentMethod { get; set; }

        /// <summary>
        /// Сумма з.п.
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Период оплаты - старт
        /// </summary>
        public DateTime StartPeriod { get; set; }

        /// <summary>
        /// Период оплаты - конец
        /// </summary>
        public DateTime EndPeriod { get; set; }

        /// <summary>
        /// Списано средств
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal WrittenOff { get; set; }

        /// <summary>
        /// Итого
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }

        /// <summary>
        /// Доп. инфа
        /// </summary>
        public string Note { get; set; }

    }
}
