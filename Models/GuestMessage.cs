using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_TransportCompany.Models
{
    public class GuestMessage
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите имя")]
        public string Username { get; set; }
        
        [Required(ErrorMessage = "Введите Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите сообщение")]
        public string MessageText { get; set; }

        public DateTime Date { get; set; }

        public bool Published { get; set; }

        public string ImagePath { get; set; }


    }
}
