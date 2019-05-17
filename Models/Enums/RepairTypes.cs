using System.ComponentModel.DataAnnotations;

namespace WebApp_TransportCompany.Models.Enums
{
    public enum RepairTypes
    {
        [Display(Name = "Технический осмотр тягача")]
        TechnicalInspectionTruck,

        [Display(Name = "Технический осмотр прицепа")]
        TechnicalInspectionTrailer,

        [Display(Name = "Замена колеса")]
        ChangeWheel,

        [Display(Name = "Ремонт колеса")]
        RepairWheel,

        [Display(Name = "Ремонт электроники")]
        Electronics,

        [Display(Name = "Ремонт двигателя")]
        Engine,

        [Display(Name = "Косметический ремонт")]
        Cosmetic
    }
}
