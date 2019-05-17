using System.Collections.Generic;
using WebApp_TransportCompany.Models;

namespace WebApp_TransportCompany.ViewModels
{
    public class RefueilngViewModel
    {
        public IEnumerable<RefuelingCheck> RefuelingsByCheck { get; set; }

        public IEnumerable<RefuelingSensor> RefuelingsBySensor { get; set; }

        public RefuelingCheck RefuelingCheck { get; set; }

        public RefuelingSensor RefuelingSensor { get; set; }

        public IEnumerable<Truck> Trucks { get; set; }

        public IEnumerable<Driver> Drivers { get; set; }
    }
}
