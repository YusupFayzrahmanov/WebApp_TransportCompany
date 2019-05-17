using System.Collections.Generic;
using WebApp_TransportCompany.Models;

namespace WebApp_TransportCompany.ViewModels
{
    public class RepairViewModel
    {
        public IEnumerable<Repair> Repairs { get; set; }

        public Repair Repair { get; set; }

        public IEnumerable<Truck> Trucks { get; set; }

    }
}
