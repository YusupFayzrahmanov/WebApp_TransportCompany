using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_TransportCompany.ViewModels
{
    public class ChartLinePartialViewModel
    {
        public IEnumerable<ChartDataset> ChartDatasets { get; set; }

        public string Labels { get; set; }

    }
}
