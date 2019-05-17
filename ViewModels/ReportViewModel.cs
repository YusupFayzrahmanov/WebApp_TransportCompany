using System.Collections.Generic;
using WebApp_TransportCompany.Models;

namespace WebApp_TransportCompany.ViewModels
{
    public class ReportViewModel
    {
        public IEnumerable<Report> Reports { get; set; }

        public Report Report { get; set; }

        public IEnumerable<Truck> Trucks { get; set; }
    }
}
