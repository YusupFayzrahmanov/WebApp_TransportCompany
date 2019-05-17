using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_TransportCompany.Models;

namespace WebApp_TransportCompany.ViewModels
{
    public class OrderFormPartialViewModel
    {
        public Order Order { get; set; }
        public IEnumerable<Truck> Trucks { get; set; }
        public bool Readonly { get; set; }
    }
}
