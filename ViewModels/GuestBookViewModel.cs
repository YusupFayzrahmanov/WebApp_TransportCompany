using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_TransportCompany.Models;

namespace WebApp_TransportCompany.ViewModels
{
    public class GuestBookViewModel
    {
        public IEnumerable<GuestMessage> PublishedGuestMessages { get; set; } = new List<GuestMessage>();

        public IEnumerable<GuestMessage> AllGuestMessages { get; set; } = new List<GuestMessage>();

        public string Message { get; set; }

        public bool? Success { get; set; }

        public GuestMessage GuestMessage { get; set; }

        public string TestText { get; set; }
        
        public int IdTest { get; set; }

        public string OutTestText { get; set; }
        
    }
}
