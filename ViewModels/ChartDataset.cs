using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_TransportCompany.ViewModels
{
    public class ChartDataset
    {
        public int id { get; set; }

        public string label { get; set; }

        public string backgroundColor { get; set; }

        public string borderColor { get; set; }

        public string data { get; set; }
    }
}
