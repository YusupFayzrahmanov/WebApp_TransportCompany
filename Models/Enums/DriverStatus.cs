using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_TransportCompany.Models.Enums
{
    public enum DriverStatus
    {
        [Display(Name = "Работает")]
        Work,

        [Display(Name = "Уволен")]
        Fired,

        [Display(Name = "В отпуске")]
        Vacation,

        [Display(Name = "На больничном")]
        Ambulance
    }
}
