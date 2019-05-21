using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp_TransportCompany.Models;
using WebApp_TransportCompany.Repositories;

namespace WebApp_TransportCompany.Controllers
{
    [Authorize]
    public class RefuelingController : Controller
    {
        private readonly IRefuelingRepository _refuelingRepository;

        public RefuelingController(IRefuelingRepository refuelingRepository)
        {
            _refuelingRepository = refuelingRepository;

        }
        // GET: Refueling
        public IActionResult IndexRefueling()
        {
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(id);
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(id);
        }

        //[HttpPost]
        //public async Task<JsonResult> Delete(int item)
        //{
        //    await _salaryRepository.DeleteSalary(await _salaryRepository.GetSalary(item));
        //    return Json(Ok());
        //}
    }
}