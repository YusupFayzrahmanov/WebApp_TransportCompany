using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp_TransportCompany.Extensions;
using WebApp_TransportCompany.Models;
using WebApp_TransportCompany.Repositories;

namespace WebApp_TransportCompany.Controllers
{
    [Authorize]
    public class RefuelingController : Controller
    {
        private readonly IRefuelingRepository _refuelingRepository;

        private readonly IDriverRepository _driverRepository;

        private readonly ITruckRepository _truckRepository;

        private readonly IUserRepository _userRepository;

        private readonly IHostingEnvironment _hostingEnvironment;

        public RefuelingController(IRefuelingRepository refuelingRepository,
            IDriverRepository driverRepository, ITruckRepository truckRepository,
            IUserRepository userRepository, IHostingEnvironment hostingEnviroment)
        {
            _refuelingRepository = refuelingRepository;
            _driverRepository = driverRepository;
            _truckRepository = truckRepository;
            _userRepository = userRepository;
            _hostingEnvironment = hostingEnviroment;
        }

        // GET: Refueling
        public IActionResult IndexReport()
        {
            return View();
        }

        public IActionResult IndexSensor()
        {
            return View();
        }

        public IActionResult IndexCheck()
        {
            return View();
        }

        public IActionResult IndexCard()
        {
            return View();
        }

        public async Task<IActionResult> AddCheck(IFormFile checkExcel)
        {

            if (checkExcel != null)
            {
                var filePath = _hostingEnvironment.WebRootPath;
                filePath = Path.Combine(filePath, "Files");
                filePath = Path.Combine(filePath, checkExcel.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await checkExcel.CopyToAsync(fileStream);
                }
                var _tatneftReports = ExcelDataSet.Read(filePath);
                var _checks = from item in _tatneftReports
                              select new RefuelingCheck()
                              {
                                  GasStation = Models.Enums.GasStation.Tatneft,
                                  Liters = Convert.ToDecimal((double)item.Litres),
                                  Truck = _truckRepository.GetTruckByCardNumber(((string)item.CardNumber).
                                  Replace("держатель", string.Empty).
                                  Replace("№",string.Empty).Replace(" ", string.Empty).Replace(":", string.Empty)),
                                  RefuelDate = Convert.ToDateTime(((string)item.Date + " " + ((DateTime)item.Time).TimeOfDay).ToString()),
                                  Price = Convert.ToDecimal((double)item.Price)
                              };
                await _refuelingRepository.AddRangeRefuelingCheck(_checks.ToList());

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                    
            }
            

            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCard(TatneftCard tatneftCard, int? modelId)
        {
            if(modelId.HasValue)
            {
                tatneftCard.Id = modelId.Value;
                await _refuelingRepository.UpdateTatneftCard(tatneftCard);
            }
            else
            {
                tatneftCard.Identity = await _userRepository.GetIdentityUser(User);
                await _refuelingRepository.AddTatneftCard(tatneftCard);
            }
            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCard(int id)
        {
            await _refuelingRepository.DeleteTatneftCard(id);
            return Redirect(Request.Headers["Referer"].ToString());
        }


        [HttpPost]
        public async Task<IActionResult> CreateReport(RefuelingReport report, int truckId, int DriverId)
        {
            report.Driver = await _driverRepository.GetDriver(DriverId);
            report.Truck = await _truckRepository.GetTruck(truckId);
            await _refuelingRepository.AddRefuelingReport(report);
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public async Task<IActionResult> Edit(int id)
        {
            return PartialView("_RefuelingReportEditModalPartial", 
                await _refuelingRepository.GetRefuelingReport(id));
        }

        public async Task<IActionResult> Edit(RefuelingReport report, int truckId, int DriverId)
        {
            report.Driver = await _driverRepository.GetDriver(DriverId);
            report.Truck = await _truckRepository.GetTruck(truckId);
            await _refuelingRepository.UpdateRefuelingReport(report);
            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            await _refuelingRepository.DeleteRefuelingReport(await _refuelingRepository.GetRefuelingReport(id));
            return Json(Ok());
        }
    }
}