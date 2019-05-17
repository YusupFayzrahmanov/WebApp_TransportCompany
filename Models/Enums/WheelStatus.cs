using System.ComponentModel.DataAnnotations;

namespace WebApp_TransportCompany.Models.Enums
{
    public enum WheelCondition
    {
        [Display(Name = "Отличное")]
        Perfect,

        [Display(Name = "Хорошее")]
        Good,

        [Display(Name = "Плохое")]
        Bad,

        [Display(Name = "Нужен ремонт")]
        NeedRepair,

        [Display(Name = "Сломано")]
        Broken
    }
}
