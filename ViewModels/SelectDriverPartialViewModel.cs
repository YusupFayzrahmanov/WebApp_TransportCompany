using System.Collections.Generic;
using WebApp_TransportCompany.Models;

namespace WebApp_TransportCompany.ViewModels
{
    public class SelectDriverPartialViewModel
    {
        public bool Multiple { get; set; }

        public IEnumerable<Driver> Drivers { get; set; }

        public Driver Driver { get; set; }
    }
}
