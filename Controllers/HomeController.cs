using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp_TransportCompany.Extensions;

namespace WebApp_TransportCompany.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Test()
        {
            double[] data = new double[] { 1, 2, 3, 4, 5 };
            string Json = JsonConvert.SerializeObject(data);
            ViewData["Json"] = JsonConvert.SerializeObject(data);
            return View();
        }

        public IActionResult TestColor()
        {
            return Json(new object[] {
                ColorHelper.GetColorByID(1),
                ColorHelper.GetColorByID(2),
                ColorHelper.GetColorByID(3),
                ColorHelper.GetColorByID(4),
                ColorHelper.GetColorByID(23),
                ColorHelper.GetColorByID(46),
                ColorHelper.GetColorByID(254),
            });
        }
    }
}