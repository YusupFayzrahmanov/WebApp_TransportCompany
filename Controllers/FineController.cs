using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp_TransportCompany.Controllers
{
    [Authorize]
    public class FineController : Controller
    {
        public IActionResult IndexFine()
        {
            return View();
        }
    }
}