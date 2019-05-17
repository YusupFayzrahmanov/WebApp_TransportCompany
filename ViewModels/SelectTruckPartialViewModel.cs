using System.Collections.Generic;
using WebApp_TransportCompany.Models;

namespace WebApp_TransportCompany.ViewModels
{
    public class SelectTruckPartialViewModel
    {
        public bool Multiple { get; set; }

        public IEnumerable<Truck> Trucks { get; set; }

        public Truck Truck { get; set; }
    }
}
