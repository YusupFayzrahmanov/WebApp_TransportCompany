using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp_TransportCompany.Data;
using WebApp_TransportCompany.Models;
using WebApp_TransportCompany.ViewModels;

namespace WebApp_TransportCompany.Controllers
{
    public class SalaryController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public SalaryController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Order
        public async Task<IActionResult> IndexSalary(IEnumerable<int> salary)
        {
            var _identityUser = await _userManager.GetUserAsync(User);
            var vm = new SalaryViewModel()
            {
               // Salaries = await _context.Salaries.Where(x => x.Identity.Id == _identityUser.Id).ToListAsync(),
               // Drivers = await _context.Drivers.Where(x => x.Identity.Id == _identityUser.Id).ToListAsync()
            };
            return View(vm);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Salary salary, int driverId)
        {

            return RedirectToAction("IndexOrder");
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int item)
        {
            _context.Salaries.Remove(await _context.Salaries.FindAsync(item));
            await _context.SaveChangesAsync();
            return Json(Ok());
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _context.Salaries.Include(x => x.Driver)
                .FirstOrDefaultAsync(x => x.Id == id));
        }

        public async Task<IActionResult> Edit(int? item)
        {
            var _identityUser = await _userManager.GetUserAsync(User);
            return View(new OrderFormPartialViewModel()
            {
                Order = await _context.Orders.FindAsync(item),
                Trucks = await _context.Trucks.Where(x => x.Identity.Id == _identityUser.Id && x.IsActual).ToListAsync()
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(OrderFormPartialViewModel vm)
        {
            _context.Orders.Update(vm.Order);
            await _context.SaveChangesAsync();
            return RedirectToAction("IndexOrder");
        }


    }
}