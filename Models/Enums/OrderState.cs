using System.ComponentModel.DataAnnotations;

namespace WebApp_TransportCompany.Models.Enums
{
    public enum OrderState
    {
        [Display(Name = "Открыт")]
        Open,

        [Display(Name = "Закрыт")]
        Close
    }
}
