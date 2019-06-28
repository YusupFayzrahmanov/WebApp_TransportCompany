using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApp_TransportCompany.Models;
using WebApp_TransportCompany.Repositories;

namespace WebApp_TransportCompany.Controllers
{
    [Authorize]
    public class WheelController : Controller
    {
        //private readonly ApplicationDbContext _context;

        private readonly IWheelRepository _wheelRepository;

        private readonly ITruckRepository _truckRepository;

        public WheelController(IWheelRepository wheelRepository, ITruckRepository truckRepository)
        {
            _wheelRepository = wheelRepository;
            _truckRepository = truckRepository;
        }

        public IActionResult IndexWheel()
        {
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var _wheel = await _wheelRepository.GetWheel(id);
            return PartialView("_WheelDetailsModalPartial", _wheel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Wheel wheel, int truckId, int wheelId)
        {
            if (wheelId != 0)
            {
                var _previousWheel = await _wheelRepository.GetWheel(wheelId);
                wheel.PreviousWheel = _previousWheel;
                _previousWheel.IsUsed = false;
                await _wheelRepository.UpdateWheel(_previousWheel);
            }

            wheel.Truck = await _truckRepository.GetTruck(truckId);
            wheel.IsUsed = true;
            await _wheelRepository.AddWheel(wheel);
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public async Task<IActionResult> Edit(int id)
        {
            var _wheel = await _wheelRepository.GetWheel(id);
            return PartialView("_WheelEditModalPartial", _wheel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Wheel wheel)
        {
            await _wheelRepository.UpdateWheel(wheel);
            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _wheelRepository.DeleteWheel(await _wheelRepository.GetWheel(id));
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}