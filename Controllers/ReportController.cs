using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApp_TransportCompany.Data;
using WebApp_TransportCompany.Models;
using WebApp_TransportCompany.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using WebApp_TransportCompany.Repositories;

namespace WebApp_TransportCompany.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        private readonly IReportRepository _reportRepository;

        private readonly ITruckRepository _truckRepository;

        private readonly IDriverRepository _driverRepository;

        private readonly UserManager<IdentityUser> _userManager;

        public ReportController(ITruckRepository truckRepository,
            IReportRepository reportRepository,
            IDriverRepository driverRepository,
            UserManager<IdentityUser> userManager)
        {
            _reportRepository = reportRepository;
            _truckRepository = truckRepository;
            _driverRepository = driverRepository;
            _userManager = userManager;
        }

        // GET: Report
        public async Task<IActionResult> IndexReport()
        {
            var _identityUser = await _userManager.GetUserAsync(User);
            var vm = new ReportViewModel()
            {
                Reports = await _reportRepository.GetReports(_identityUser),
                Trucks = await _truckRepository.GetTrucks(_identityUser)
            };
            return View(vm);
        }

        
        public async Task<IActionResult> GetReportByTruck(int id)
        {
            var _reports = await _reportRepository.GetReports(await _truckRepository.GetTruck(id));
            return RedirectToAction("IndexReport", new { reports = _reports });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Report report, int truckId)
        {
            //report.Identity = await _userManager.GetUserAsync(User);
            report.Truck = await _truckRepository.GetTruck(truckId);
            await _reportRepository.AddReport(report);
            return RedirectToAction("IndexReport");
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int item)
        {
            var _item = await _reportRepository.GetReport(item);
            _reportRepository.DeleteReport(_item);
            return Json(Ok());
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _reportRepository.GetReport(id));
        }

        public async Task<IActionResult> Edit(int item)
        {
            var _identityUser = await _userManager.GetUserAsync(User);
            return View(new ReportFormPartialViewModel()
            {
                Report = await _reportRepository.GetReport(item),
                Trucks = await _truckRepository.GetTrucks(_identityUser)
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ReportFormPartialViewModel vm)
        {
            _reportRepository.UpdateReport(vm.Report);
            return RedirectToAction("IndexReport");
        }


        
    }
}