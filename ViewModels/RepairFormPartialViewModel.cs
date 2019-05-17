using System.Collections.Generic;
using WebApp_TransportCompany.Models;

namespace WebApp_TransportCompany.ViewModels
{
    public class RepairFormPartialViewModel
    {
        public Repair Repair { get; set; }

        public IEnumerable<Truck> Trucks { get; set; }
        public bool Readonly { get; set; }
    }
}
