using System.Collections.Generic;
using WebApp_TransportCompany.Models;

namespace WebApp_TransportCompany.ViewModels
{
    public class RepairFormPartialViewModel
    {
        public Repair Repair { get; set; }

        public int TruckId { get; set; }

        public int DriverId { get; set; }

        public int RepairTypeId { get; set; }

        public bool Readonly { get; set; }
    }
}
