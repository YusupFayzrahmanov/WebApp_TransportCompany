using System.ComponentModel.DataAnnotations;

namespace WebApp_TransportCompany.Models.Enums
{
    public enum WheelPlace
    {
        [Display(Name = "Переднее правое")]
        TruckFrontRight,

        [Display(Name = "Переднее левое")]
        TruckFrontLeft,

        [Display(Name = "Заднее правое фронтовое")]
        TruckBackFirstRightFirst,

        [Display(Name = "Заднее правое внутреннее")]
        TruckBackFirstRightSecond,

        [Display(Name = "Заднее левое фронтовое")]
        TruckBackFirstLeftFirst,

        [Display(Name = "Заднее левое внутреннее")]
        TruckBackFirstLeftSecond,

        [Display(Name = "2ое заднее прав. фронтовое")]
        TruckBackSecondRightFirst,

        [Display(Name = "2ое заднее прав. внутреннее")]
        TruckBackSecondRightSecond,

        [Display(Name = "2ое заднее лев. фронтовое")]
        TruckBackSecondLeftFirst,

        [Display(Name = "2ое заднее лев. внутреннее")]
        TruckBackSecondLeftSecond,

        [Display(Name = "Прицеп прав. 1ое")]
        TrailerRightFirst,

        [Display(Name = "Прицеп прав. 2ое")]
        TrailerRightSecond,

        [Display(Name = "Прицеп прав. 3ее")]
        TrailerRightThird,

        [Display(Name = "Прицеп лев. 1ое")]
        TrailerLeftFirst,

        [Display(Name = "Прицеп лев. 2ое")]
        TrailerLeftSecond,

        [Display(Name = "Прицеп лев. 3ее")]
        TrailerLeftThird,

        [Display(Name = "Запаска(переднее)")]
        StepneyFront,

        [Display(Name = "Запаска(заднее)")]
        StepneyBack,

        [Display(Name = "Запаска(прицеп)")]
        StepneyTrailer,
    }
}
