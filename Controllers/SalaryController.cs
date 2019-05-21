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

        public SalaryController(IUserRepository userRepository,
            ISalaryRepository salaryRepository)
        {
            _userRepository = userRepository;
            _salaryRepository = salaryRepository;
        }

        // GET: Order
        public IActionResult IndexSalary(string query)
        {
            //var _identityUser = await _userManager.GetUserAsync(User);
            //var vm = new SalaryViewModel()
            //{
            //   // Salaries = await _context.Salaries.Where(x => x.Identity.Id == _identityUser.Id).ToListAsync(),
            //   // Drivers = await _context.Drivers.Where(x => x.Identity.Id == _identityUser.Id).ToListAsync()
            //};
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Salary salary, int driverId)
        {

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