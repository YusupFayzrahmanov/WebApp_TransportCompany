using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApp_TransportCompany.Controllers
{
    public class TestFormController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FormPost(IEnumerable<TestData> testDatas)
        {
            return Json(testDatas);
        }
    }

    public class TestData
    {
        public string Field1 { get; set; }

        public string Field2 { get; set; }
    }
}