using System.ComponentModel.DataAnnotations;

namespace WebApp_TransportCompany.Models.Enums
{
    public enum TruckCondition
    {
      
        [Display(Name = "Работоспособен")]
        Good,

        [Display(Name = "Сломан")]
        IsBroken,

        [Display(Name = "Продан")]
        Saled

    }
}
