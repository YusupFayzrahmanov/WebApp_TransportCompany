﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp_TransportCompany.Data;
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

        private readonly UserManager<IdentityUser> _userManager;

        public RepairController(ITruckRepository truckRepository, 
            IRepairRepository repairRepository,
            UserManager<IdentityUser> userManager)
        {
            _repairRepository = repairRepository;
            _truckRepository = truckRepository;
            _userManager = userManager;
        }
        // GET: Repair
        public async Task<IActionResult> IndexRepair()
        {
            var _identityUser = await _userManager.GetUserAsync(User);
            var vm = new RepairViewModel()
            {
                Repairs = await _repairRepository.GetRepairs(_identityUser),
                Trucks = await _truckRepository.GetTrucks(_identityUser)
            };
            return View(vm);
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
            return View(await _repairRepository.GetRepair(id));
        }

        public async Task<IActionResult> Edit(int item)
        {
            var _identityUser = await _userManager.GetUserAsync(User);
            return View(new RepairFormPartialViewModel()
            {
                Repair = await _repairRepository.GetRepair(item),
                Trucks = await _truckRepository.GetTrucks(_identityUser)
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RepairFormPartialViewModel vm)
        {
            await _repairRepository.UpdateRepair(vm.Repair);
            return RedirectToAction("IndexRepair");
        }

        
    }
}