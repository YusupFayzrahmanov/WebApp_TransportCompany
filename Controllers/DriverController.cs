using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_TransportCompany.Data;
using WebApp_TransportCompany.Models;
using WebApp_TransportCompany.Repositories;
using WebApp_TransportCompany.ViewModels;

namespace WebApp_TransportCompany.Controllers
{
    //[Authorize]
    public class DriverController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        private readonly IDriverRepository _driverRepository;

        private readonly ITruckRepository _truckRepository;

        public DriverController(IDriverRepository driverRepository,
            ITruckRepository truckRepository,
            UserManager<IdentityUser> userManager)
        {
            _driverRepository = driverRepository;
            _truckRepository = truckRepository;
            _userManager = userManager;
        }
        // GET: Driver
        public async Task<IActionResult> IndexDriver()
        {
            var _identityUser = await _userManager.GetUserAsync(User);

            var _vm = new DriverViewModel()
            {
                Drivers = await _driverRepository.GetDrivers(_identityUser),
                Trucks = await _truckRepository.GetTrucks(_identityUser)
            };
            return View(_vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Driver driver, int truckId)
        {
            driver.Truck = await _truckRepository.GetTruck(truckId);
            driver.Identity = await _userManager.GetUserAsync(User);
            await _driverRepository.AddDriver(driver);
            return RedirectToAction("IndexDriver");
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _driverRepository.GetDriver(id));
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int item)
        {
            var _driver = await _driverRepository.GetDriver(item);
            await _driverRepository.DeleteDriver(_driver);
            return Json(Ok());
        }

        public async Task<IActionResult> Edit(int item)
        {
            var _identityUser = await _userManager.GetUserAsync(User);

            return View(new DriverFormPartialViewModel()
            {
                Driver = await _driverRepository.GetDriver(item),
                Trucks = await _truckRepository.GetTrucks(_identityUser)
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DriverFormPartialViewModel vm)
        {
            await _driverRepository.UpdateDriver(vm.Driver);
            return RedirectToAction("IndexDriver");
        }
    }
}