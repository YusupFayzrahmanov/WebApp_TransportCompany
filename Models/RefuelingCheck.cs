﻿using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp_TransportCompany.Models.Enums;

namespace WebApp_TransportCompany.Models
{
    /// <summary>
    /// Заправка по чеку
    /// </summary>
    public class RefuelingCheck
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Транспорт, который был заправлен
        /// </summary>
        [ForeignKey("TruckId")]
        public Truck Truck { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? TruckId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TatneftCard TatneftCard { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? TatneftCardId { get; set; }

        /// <summary>
        /// Дата заправки
        /// </summary>
        public DateTime RefuelDate { get; set; }

        /// <summary>
        /// Заправочная станция
        /// </summary>
        public GasStation GasStation { get; set; }

        /// <summary>
        /// Кол-во литров
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal Liters { get; set; }

        /// <summary>
        /// Цена за литр
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
    }
}
