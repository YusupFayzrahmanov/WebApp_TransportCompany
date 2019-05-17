using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp_TransportCompany.Models.Enums;

namespace WebApp_TransportCompany.Models
{
    /// <summary>
    /// Заказ
    /// </summary>
    public class Order
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
        /// Водитель
        /// </summary>
        public Driver Driver { get; set; }

        /// <summary>
        /// Дата начала
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Время завершения
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Состояние заказа
        /// </summary>
        public OrderState State { get; set; }

        /// <summary>
        /// Оплачен ли заказ
        /// </summary>
        public bool IsPaid { get; set; }

        /// <summary>
        /// Наименование компании
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Сумма заказа
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Price { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Точка отбытия
        /// </summary>
        public string DepPoint { get; set; }

        /// <summary>
        /// Точка прибытия
        /// </summary>
        public string EndPoint { get; set; }

        /// <summary>
        /// Дистанция
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Distance { get; set; }

        /// <summary>
        /// Вес груза
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? CargoWeight { get; set; }

        /// <summary>
        /// Тип груза
        /// </summary>
        public TypeOfCargo TypeOfCargo { get; set; }

        /// <summary>
        /// Доп. инфа
        /// </summary>
        public string Note { get; set; }


    }
}
