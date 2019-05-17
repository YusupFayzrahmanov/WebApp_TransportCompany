using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApp_TransportCompany.Models.Enums
{
    public enum TruckStatus
    {
        [Display(Name = "Занят")]
        InFlight,
        
        [Display(Name = "Свободен")]
        Free
    }
}
