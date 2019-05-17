using System.Collections.Generic;
using WebApp_TransportCompany.Models;

namespace WebApp_TransportCompany.ViewModels
{
    public class OrderViewModel
    {
        public IEnumerable<Order> Orders { get; set; }

        public Order Order { get; set; }

        public IEnumerable<Truck> Trucks { get; set; }

    }
}
