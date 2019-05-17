using System.Collections.Generic;
using WebApp_TransportCompany.Models;

namespace WebApp_TransportCompany.ViewModels
{
    public class TruckViewModel
    {
        public Truck Truck;

        public IEnumerable<Truck> Trucks { get; set; }
    }
}
