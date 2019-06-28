using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_TransportCompany.ViewModels
{
    public class ChartDataset
    {
        /// <summary>
        /// Идентификатор записи(это для формирования ссылки использую)
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Название линии
        /// </summary>
        public string label { get; set; }

        
        public string backgroundColor { get; set; }

        public string borderColor { get; set; }

        /// <summary>
        /// Значение линии
        /// </summary>
        public string data { get; set; }
    }
}
