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
using WebApp_TransportCompany.Models.Enums;
using WebApp_TransportCompany.Repositories;

namespace WebApp_TransportCompany.Controllers
{
    [Authorize]
    public class TruckController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITruckRepository _truckRepository;

        public TruckController(ApplicationDbContext context, 
            UserManager<IdentityUser> userManager, ITruckRepository truckRepository)
        {
            _context = context;
            _userManager = userManager;
            _truckRepository = truckRepository;
        }

        // GET: Truck
        public async Task<IActionResult> IndexTruck(TruckStatus? status, TruckCondition? condition)
        {
            var _identityUser = await _userManager.GetUserAsync(User);
            var _vm = new TruckViewModel();
            if (status.HasValue)
            {
                _vm.Trucks = await _truckRepository.GetTrucks(_identityUser, status.Value);
            }
            if(condition.HasValue)
            {
                _vm.Trucks = await _truckRepository.GetTrucks(_identityUser, condition.Value);
            }
            else
            {
                _vm.Trucks = await _truckRepository.GetTrucks(_identityUser);
            }
            return View(_vm);
        }

        // GET: Truck/Details/5
        public async Task<IActionResult> Details(int truck)
        {
            var _truck = await _truckRepository.GetTruck(truck);

            var vm = new TruckDetailsViewModel()
            {
                Truck = _truck,
                Drivers = _truck.Drivers,
                Orders = _truck.Orders,
                //Repairs = await _repairs.Skip(Math.Max(0, _repairs.Count() - 10)).ToListAsync(),
                Repairs = _truck.Repairs,
                Reports = _truck.Reports,
                Wheels = _truck.Wheels.ToList()
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
            await _truckRepository.AddTruck(truck);
            return RedirectToAction("IndexTruck");
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int item)
        {
            var _item = await _truckRepository.GetTruck(item);
            _item.IsActual = false;
            await _truckRepository.UpdateTruck(_item);
            return Json(Ok());
        }

        public async Task<IActionResult> Edit(int item)
        {
            return View(new TruckFormPartialViewModel() { Truck = await _truckRepository.GetTruck(item) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TruckFormPartialViewModel vm)
        {
            await _truckRepository.UpdateTruck(vm.Truck);
            return RedirectToAction("IndexTruck");
        }

    }
}