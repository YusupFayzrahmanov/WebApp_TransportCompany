using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_TransportCompany.ViewModels
{
    public class ChartLinePartialViewModelBuilder
    {
        static readonly string[] DefaultLabel = new string[] { "Янв", "Фев", "Март", "Апр", "Май", "Июнь", "Июль", "Авг", "Сен", "Окт", "Ноя", "Дек" };

        public ChartLinePartialViewModel Build(List<ChartDataset> chartDatasets, string[] labels = null)
        {
            labels = labels ?? DefaultLabel;
            chartDatasets = chartDatasets ?? new List<ChartDataset>();
            return new ChartLinePartialViewModel()
            {
                Labels = JsonConvert.SerializeObject(labels),

                ChartDatasets = JsonConvert.SerializeObject(chartDatasets)
            };

        }
    }
}
