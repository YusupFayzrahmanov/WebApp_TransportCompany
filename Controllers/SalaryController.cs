using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp_TransportCompany.Data;
using WebApp_TransportCompany.Models;
using WebApp_TransportCompany.Repositories;
using WebApp_TransportCompany.ViewModels;

namespace WebApp_TransportCompany.Controllers
{
    public class SalaryController : Controller
    {
        private readonly IUserRepository _userRepository;

        private readonly ISalaryRepository _salaryRepository;

        private readonly IDriverRepository _driverRepository;

        public SalaryController(IUserRepository userRepository,
            ISalaryRepository salaryRepository, IDriverRepository driverRepository)
        {
            _userRepository = userRepository;
            _salaryRepository = salaryRepository;
            _driverRepository = driverRepository;
        }

        // GET: Order
        public IActionResult IndexSalary(string query)
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SalaryFormViewModel vm)
        {
            vm.Salary.Driver = await _driverRepository.GetDriver(vm.DriverId);
            await _salaryRepository.AddSalary(vm.Salary);
            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int item)
        {
            await _salaryRepository.DeleteSalary(await _salaryRepository.GetSalary(item));
            return Json(Ok());
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _salaryRepository.GetSalary(id));
        }

        public async Task<IActionResult> Edit(int item)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit()
        {
            
            return Redirect(Request.Headers["Referer"].ToString());
        }


    }
}