using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApp_TransportCompany.Data;
using WebApp_TransportCompany.Extensions;
using WebApp_TransportCompany.Models;
using WebApp_TransportCompany.ViewModels;

namespace WebApp_TransportCompany.Controllers
{
    public class GuestBookController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly Random rand;

        public GuestBookController(ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = context;
            rand = new Random();
        }

        public async Task<IActionResult> Index(string message, bool? success)
        {
            var _idTestStr = rand.Next(0, TuringTest._vocabulary.Length);
            var _testStr = TuringTest._vocabulary[_idTestStr];
            var _position = rand.Next(0, _testStr.Length);
            var _outStr = _testStr.Substring(0, _position) + "_" + _testStr.Substring(_position+1);

            var vm = new GuestBookViewModel()
            {
                PublishedGuestMessages = await _context.GuestMessages.Where(x => x.Published).ToListAsync(),

                AllGuestMessages = await _context.GuestMessages.ToListAsync(),

                Message = message,

                Success = success,

                IdTest = _idTestStr,

                TestText = _outStr
            };


            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> AddMessage(GuestBookViewModel vm, IFormFile File)
        {
            if(vm.OutTestText != TuringTest._vocabulary[vm.IdTest])
            {
                return RedirectToAction("Index", new { message = "Ошибка! Тест Тьюринга не пройден!", success = false });
            }
            if (ModelState.IsValid)
            {
                if (File != null)
                {
                    vm.GuestMessage.ImagePath = "/Files/" + File.FileName;
                    using (var fileStream = new FileStream(_hostingEnvironment.WebRootPath + vm.GuestMessage.ImagePath, FileMode.Create))
                    {
                        await File.CopyToAsync(fileStream);
                    }
                }
                else
                {
                    vm.GuestMessage.ImagePath = "/Files/default.png";
                }
                vm.GuestMessage.Date = DateTime.Now;
                vm.GuestMessage.Published = false;
                await _context.GuestMessages.AddAsync(vm.GuestMessage);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index",
                    new
                    {
                        message = "Сообщение добавлено! Идентификатор сообщения " + vm.GuestMessage.Id.ToString(),
                        success = true
                    });
            }
            else
            {
                return RedirectToAction("Index", new { message = "Сообщение не удалось добавить!", success = false });
            }

        }

        [Authorize]
        public async Task<IActionResult> PublishMessage(int id)
        {
            var message = await _context.GuestMessages.FindAsync(id);
            message.Published = true;
            _context.GuestMessages.Update(message);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { message = "Сообщение опубликовано!", success = true });
        }

        [Authorize]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            var message = await _context.GuestMessages.FindAsync(id);
            _context.GuestMessages.Remove(message);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { message = "Сообщение удалено!", success = true });
        }
    }
}