using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_TransportCompany.Models.Enums
{
    public enum TypeOfCargo
    {
        [Display(Name = "Пиво")]
        Beer,

        [Display(Name = "Строительные материалы")]
        BuildingMaterials
    }
}
