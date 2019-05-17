using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApp_TransportCompany.Data;
using WebApp_TransportCompany.Models;
using Microsoft.EntityFrameworkCore;
using WebApp_TransportCompany.ViewModels;
using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace WebApp_TransportCompany.Controllers
{
    [Authorize]
    public class TruckController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public TruckController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Truck
        public async Task<IActionResult> IndexTruck()
        {
            var _identityUser = await _userManager.GetUserAsync(User);
            var _vm = new TruckViewModel()
            {
                Trucks = await _context.Trucks.Where(x => x.Identity.Id == _identityUser.Id && x.IsActual).ToListAsync()
            };
            return View(_vm);
        }

        // GET: Truck/Details/5
        public async Task<IActionResult> Details(int truck)
        {
            var _truck = await _context.Trucks.FindAsync(truck);
            var _orders = _context.Orders.Where(x => x.Truck.Id == truck);
            var _repairs = _context.Repairs.Where(x => x.Truck.Id == truck);
            var _reports = _context.Reports.Where(x => x.Truck.Id == truck);
            var _wheels = await _context.Wheels.Where(x => x.Truck.Id == truck && x.IsUsed).ToListAsync();

            var vm = new TruckDetailsViewModel()
            {
                Truck = _truck,
                Drivers = await _context.Drivers.Where(x => x.Truck.Id == truck).ToListAsync(),
                Orders = await _orders.Skip(Math.Max(0, _orders.Count() - 10)).ToListAsync(),
                Repairs = await _repairs.Skip(Math.Max(0, _repairs.Count() - 10)).ToListAsync(),
                Reports = await _reports.Skip(Math.Max(0, _reports.Count() - 10)).ToListAsync(),
                Wheels = _wheels != null ? _wheels : new List<Wheel>()
            };

            return View(vm);
        }

        // GET: Truck/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Truck truck)
        {
            truck.Identity = await _userManager.GetUserAsync(User);
            truck.IsActual = true;
            await _context.Trucks.AddAsync(truck);
            await _context.SaveChangesAsync();
            return RedirectToAction("IndexTruck");
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int item)
        {
            var _item = await _context.Trucks.FindAsync(item);
            _item.IsActual = false;
            _context.Trucks.Update(_item);
            await _context.SaveChangesAsync();
            return Json(Ok());
        }

        public async Task<IActionResult> Edit(int? item)
        {
            return View(new TruckFormPartialViewModel() { Truck = await _context.Trucks.FindAsync(item) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TruckFormPartialViewModel vm)
        {
            _context.Trucks.Update(vm.Truck);
            await _context.SaveChangesAsync();
            return RedirectToAction("IndexTruck");
        }

    }
}