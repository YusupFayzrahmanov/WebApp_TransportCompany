using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp_TransportCompany.Models.Enums;

namespace WebApp_TransportCompany.Models
{
    /// <summary>
    /// Грузовик
    /// </summary>
    public class Truck
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identity
        /// </summary>
        public IdentityUser Identity { get; set; }

        /// <summary>
        /// Карта татнефть
        /// </summary>
        public TatneftCard TatneftCard { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Модель
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Гос. знак
        /// </summary>
        public string TruckLicState { get; set; }

        /// <summary>
        /// Гос. знак прицепа
        /// </summary>
        public string TrailerLicState { get; set; }

        /// <summary>
        /// Пробег
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal Mileage { get; set; }

        /// <summary>
        /// Тип
        /// </summary>
        public TruckType Type { get; set; }

        /// <summary>
        /// Макс. грузоподъемность
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal WeightLimit { get; set; }

        /// <summary>
        /// Макс. объем
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal MaxSize { get; set; }

        /// <summary>
        /// Свидетельство о регистрации ТС
        /// </summary>
        public string RegistrationCertificate { get; set; }

        /// <summary>
        /// Состояние
        /// </summary>
        public TruckCondition Condition { get; set; }
        
        /// <summary>
        /// Год выпуска
        /// </summary>
        public DateTime? YearOfIssue { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        public TruckStatus Status { get; set; }

        /// <summary>
        /// Флаг актуальности
        /// </summary>
        public bool IsActual { get; set; }


        /// <summary>
        /// Доп. инфа
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Колеса
        /// </summary>
        public IEnumerable<Wheel> Wheels { get; set; } = new List<Wheel>();

        /// <summary>
        /// Заказы
        /// </summary>
        public IEnumerable<Order> Orders { get; set; } = new List<Order>();

        /// <summary>
        /// Ремонты
        /// </summary>
        public IEnumerable<Repair> Repairs { get; set; } = new List<Repair>();

        /// <summary>
        /// Заправки по чекам
        /// </summary>
        public IEnumerable<RefuelingCheck> RefuelingChecks { get; set; } = new List<RefuelingCheck>();

        /// <summary>
        /// Заправки по сенсору
        /// </summary>
        public IEnumerable<RefuelingSensor> RefuelingSensors { get; set; } = new List<RefuelingSensor>();

        /// <summary>
        /// Заправки по отчетам
        /// </summary>
        public IEnumerable<RefuelingReport> RefuelingReports { get; set; } = new List<RefuelingReport>();

        /// <summary>
        /// Водители
        /// </summary>
        public IEnumerable<Driver> Drivers { get; set; } = new List<Driver>();

        /// <summary>
        /// Отчеты
        /// </summary>
        public IEnumerable<Report> Reports { get; set; } = new List<Report>();

        /// <summary>
        /// Штрафы
        /// </summary>
        public IEnumerable<Fine> Fines { get; set; } = new List<Fine>();


    }
}
