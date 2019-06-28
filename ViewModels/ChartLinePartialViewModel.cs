using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_TransportCompany.ViewModels
{
    public class ChartLinePartialViewModel
    {
        /// <summary>
        /// Набор графиков
        /// </summary>
        public IEnumerable<ChartDataset> ChartDatasets { get; set; }

        /// <summary>
        /// Это название оси абсцисс(снизу графика, по дефолту у меня стоит перечисление месяцев)
        /// </summary>
        public string Labels { get; set; }

    }
}
