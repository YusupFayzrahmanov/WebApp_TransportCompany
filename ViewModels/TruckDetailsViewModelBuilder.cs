using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_TransportCompany.Models;

namespace WebApp_TransportCompany.ViewModels
{
    public class TruckDetailsViewModelBuilder
    {

        public TruckDetailsViewModel Build(Truck _truck, IEnumerable<Driver> _drivers)
        {
            return new TruckDetailsViewModel() { Truck = _truck, Drivers= _drivers };
        }
    }
}
