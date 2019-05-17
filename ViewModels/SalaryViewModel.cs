using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_TransportCompany.Models;

namespace WebApp_TransportCompany.ViewModels
{
    public class SalaryViewModel
    {
        public IEnumerable<Salary> Salaries { get; set; } = new List<Salary>();

        public Salary Salary { get; set; }

        public IEnumerable<Driver> Drivers { get; set; } = new List<Driver>();
    }
}
