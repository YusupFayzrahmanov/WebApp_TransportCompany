using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp_TransportCompany.Models.Enums;

namespace WebApp_TransportCompany.Models
{
    /// <summary>
    /// Водитель
    /// </summary>
    public class Driver
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
        public int? TruckId { get; set; }

        /// <summary>
        /// Ссылка на пользователя
        /// </summary>
        [ForeignKey("IdentityId")]
        public IdentityUser Identity { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string IdentityId { get; set; }

        /// <summary>
        /// Номер карты татнефть
        /// </summary>
        [ForeignKey("TatneftCardId")]
        public TatneftCard TatneftCard { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? TatneftCardId { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Первый тел.
        /// </summary>
        public string FirstPhone { get; set; }

        /// <summary>
        /// Второй тел.
        /// </summary>
        public string SecondPhone { get; set; }

        /// <summary>
        /// Адрес
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Статус водителя
        /// </summary>
        public DriverStatus DriverStatus { get; set; }

        /// <summary>
        /// Доп. информация
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Архив грузовиков
        /// </summary>
        public IEnumerable<DriverTruckHistory> TruckHistories { get; set; } = new List<DriverTruckHistory>();

        /// <summary>
        /// Заказы
        /// </summary>
        public IEnumerable<Order> Orders { get; set; } = new List<Order>();

        /// <summary>
        /// З.П. водителя
        /// </summary>
        public IEnumerable<Salary> Salaries { get; set; } = new List<Salary>();

        /// <summary>
        /// Ремонты водителя
        /// </summary>
        public IEnumerable<Repair> Repairs { get; set; } = new List<Repair>();

        /// <summary>
        /// Отчеты
        /// </summary>
        public IEnumerable<Report> Reports { get; set; } = new List<Report>();

        /// <summary>
        /// Список штрафов
        /// </summary>
        public IEnumerable<Fine> Fines { get; set; } = new List<Fine>();

        /// <summary>
        /// Отчеты о заправках
        /// </summary>
        public IEnumerable<RefuelingReport> RefuelingReports { get; set; } = new List<RefuelingReport>();


    }
}
