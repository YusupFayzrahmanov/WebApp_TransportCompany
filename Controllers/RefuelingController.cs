using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp_TransportCompany.Models;

namespace WebApp_TransportCompany.Controllers
{
    [Authorize]
    public class RefuelingController : Controller
    {
        // GET: Refueling
        public IActionResult IndexRefueling()
        {
            return View();
        }

        // GET: Refueling
        //public IActionResult IndexRefueling(Truck truck)
        //{
        //    return View();
        //}

        public async Task<IActionResult> Detais(int id)
        {
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View();
        }
        // GET: Refueling/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Refueling/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Refueling/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Refueling/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Refueling/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Refueling/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Refueling/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}