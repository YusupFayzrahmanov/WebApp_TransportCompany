using System.Collections.Generic;
using WebApp_TransportCompany.Models;

namespace WebApp_TransportCompany.ViewModels
{
    public class TruckDetailsViewModel
    {
        public Truck Truck { get; set; }

        public IEnumerable<Driver> Drivers { get; set; }

        public IEnumerable<Report> Reports { get; set; }

        public IEnumerable<Repair> Repairs { get; set; }

        public IEnumerable<Order> Orders { get; set; }

        public List<Wheel> Wheels { get; set; }

        public Wheel Wheel { get; set; } 

        //public IEnumerable<FuelConsumption> FuelConsumptions { get; set; }
    }
}
