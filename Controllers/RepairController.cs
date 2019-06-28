using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApp_TransportCompany.Models;
using WebApp_TransportCompany.Repositories;
using WebApp_TransportCompany.ViewModels;

namespace WebApp_TransportCompany.Controllers
{
    [Authorize]
    public class RepairController : Controller
    {
        private readonly IRepairRepository _repairRepository;

        private readonly ITruckRepository _truckRepository;

        private readonly IUserRepository _userRepository;

        public RepairController(ITruckRepository truckRepository, 
            IRepairRepository repairRepository,
            IUserRepository userRepository)
        {
            _repairRepository = repairRepository;
            _truckRepository = truckRepository;
            _userRepository = userRepository;
        }
        // GET: Repair
        public IActionResult IndexRepair()
        {
            
            return View();
        }

        public async Task<IActionResult> GetRepairByTruck(int id)
        {
            var _repairs = await _repairRepository.GetRepairs(await _truckRepository.GetTruck(id));
            return RedirectToAction("IndexRepair", new { repairs = _repairs });
        }

        // GET: Repair/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Repair repair, int truckId)
        {
            repair.Truck = await _truckRepository.GetTruck(truckId);
            await _repairRepository.AddRepair(repair);
            return RedirectToAction("IndexRepair");
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int item)
        {
            await _repairRepository.DeleteRepair(await _repairRepository.GetRepair(item));
            return Json(Ok());
        }

        public async Task<IActionResult> Details(int id)
        {
            return PartialView("_RepairDetailsModalPartial", 
                await _repairRepository.GetRepair(id));
        }

        public async Task<IActionResult> Edit(int item)
        {
            var _identityUser = await _userRepository.GetIdentityUser(User);
            return View(new RepairFormPartialViewModel()
            {
                Repair = await _repairRepository.GetRepair(item)
                //Trucks = await _truckRepository.GetTrucks(_identityUser)
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RepairFormPartialViewModel vm)
        {
            await _repairRepository.UpdateRepair(vm.Repair);
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult RepairType()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRepairType(RepairType repairType)
        {
            repairType.Identity = await _userRepository.GetIdentityUser(User);
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public async Task<IActionResult> EditRepairType(int id)
        {
            return PartialView("~/Views/Shared/RepairPartial/_RepairTypeEditModalPartial.cshtml", 
                await _repairRepository.GetRepairType(id));
        }

        [HttpPost]
        public async Task<IActionResult> EditRepairType(RepairType repairType)
        {
            repairType.Identity = await _userRepository.GetIdentityUser(User);
            await _repairRepository.UpdateRepairType(repairType);
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}