using System.Collections.Generic;
using WebApp_TransportCompany.Models;

namespace WebApp_TransportCompany.ViewModels
{
    public class DriverFormPartialViewModel
    {
        public Driver Driver { get; set; }

        public IEnumerable<Truck> Trucks { get; set; }

        public bool Readonly { get; set; }
    }
}
