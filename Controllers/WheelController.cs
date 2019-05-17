using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp_TransportCompany.Data;
using WebApp_TransportCompany.Extensions;
using WebApp_TransportCompany.Models;

namespace WebApp_TransportCompany.Controllers
{
    public class WheelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WheelController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Details(int id)
        {
            var _wheel = await _context.Wheels.FindAsync(id);
            return View(_wheel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Wheel wheel, int truckId, int wheelId)
        {
            if(wheelId != 0)
            {
                var _previousWheel = await _context.Wheels.FindAsync(wheelId);
                wheel.PreviousWheel = _previousWheel;
                _previousWheel.IsUsed = false;
                _context.Wheels.Update(_previousWheel);
            }
            var _truck = await _context.Trucks.FindAsync(truckId);
            wheel.Truck = _truck;
            wheel.IsUsed = true;
            await _context.Wheels.AddAsync(wheel);
            await _context.SaveChangesAsync();
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public async Task<IActionResult> Edit(int id)
        {
            var _wheel = await _context.Wheels.FindAsync(id);
            return View(_wheel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Wheel wheel)
        {
            _context.Wheels.Update(wheel);
            await _context.SaveChangesAsync();
            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var _wheel = await _context.Wheels.FindAsync(id);
            _context.Wheels.Remove(_wheel);
            await _context.SaveChangesAsync();
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public JsonResult TestExcel()
        {
            return Json(ExcelDataSet.Read());
        }
        
    }
}