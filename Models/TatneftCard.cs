using System;

namespace WebApp_TransportCompany.Models
{
    /// <summary>
    /// Карта для заправок ТатНефть
    /// </summary>
    public class TatneftCard
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Номер карты
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Дата
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// Примечание
        /// </summary>
        public string Note { get; set; }
    }
}
