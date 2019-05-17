using System.ComponentModel.DataAnnotations;

namespace WebApp_TransportCompany.Models.Enums
{
    public enum PaymentMethod
    {
        [Display(Name = "Безналичный")]
        Cashless,

        [Display(Name = "Наличный")]
        Cash
    }
}
