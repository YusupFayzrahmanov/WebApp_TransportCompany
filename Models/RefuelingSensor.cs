﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp_TransportCompany.Models
{
    /// <summary>
    /// Заправка по датчику
    /// </summary>
    public class RefuelingSensor
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Транспорт, который был заправлен
        /// </summary>
        public Truck Truck { get; set; }

        /// <summary>
        /// Водитель
        /// </summary>
        public Driver Driver { get; set; }

        /// <summary>
        /// Дата заправки
        /// </summary>
        public DateTime RefuelDate { get; set; }

        /// <summary>
        /// Кол-во литров
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal Liters { get; set; }

        /// <summary>
        /// Цена за литр
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Price { get; set; }

    }
}