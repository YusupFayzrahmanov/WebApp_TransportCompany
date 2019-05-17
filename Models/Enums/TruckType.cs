using System.ComponentModel.DataAnnotations;

namespace WebApp_TransportCompany.Models.Enums
{
    public enum TruckType
    {
        [Display(Name = "Открытый")]
        Open,

        [Display(Name = "Закрытый")]
        Close

        
    }
}
