using System.Collections.Generic;
using WebApp_TransportCompany.Models;

namespace WebApp_TransportCompany.ViewModels
{
    public class DriverViewModel
    {
        public IEnumerable<Driver> Drivers { get; set; }

        public Driver Driver { get; set; }

        public IEnumerable<Truck> Trucks { get; set; }
       
    }
}
