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
    [Authorize]
    public class OrderController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        private readonly IOrderRepository _orderRepository;

        private readonly ITruckRepository _truckRepository;

        private readonly IDriverRepository _driverRepository;

        public OrderController(ITruckRepository truckRepository,
            IOrderRepository orderRepository, 
            UserManager<IdentityUser> userManager,
            IDriverRepository driverRepository)
        {
            _orderRepository = orderRepository;
            _truckRepository = truckRepository;
            _userManager = userManager;
            _driverRepository = driverRepository;
        }

        // GET: Order
        public IActionResult IndexOrder()
        {
            return View();
        }

        public async Task<IActionResult> GetOrderByTruck(int id)
        {
            var _truck = await _truckRepository.GetTruck(id);
            var _orders = await _orderRepository.GetOrders(_truck);
            return RedirectToAction("IndexOrder", new { orders = _orders });
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Order order, int truckId, int DriverId)
        {
            var _truck = await _truckRepository.GetTruck(truckId);
            order.Driver = await _driverRepository.GetDriver(DriverId);
            _truck.Status = Models.Enums.TruckStatus.InFlight;
            order.Truck = _truck;
            order.IsPaid = false;
            await _truckRepository.UpdateTruck(_truck);
            await _orderRepository.AddOrder(order);
            return RedirectToAction("IndexOrder");
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int item)
        {
            var _item = await _orderRepository.GetOrder(item);
            _item.Truck.Status = Models.Enums.TruckStatus.Free;
            await _truckRepository.UpdateTruck(_item.Truck);
            await _orderRepository.DeleteOrder(_item);
            return Json(Ok());
        }

        public async Task<IActionResult> Details(int id)
        {
            return PartialView("_OrderDetailsModalPartial", 
                await _orderRepository.GetOrder(id));
        }

        public async Task<IActionResult> Edit(int item)
        {
            var _identityUser = await _userManager.GetUserAsync(User);
            return View(new OrderFormPartialViewModel()
            {
                Order = await _orderRepository.GetOrder(item),
                Trucks = await _truckRepository.GetTrucks(_identityUser)
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Order order, int truckId, int DriverId)
        {
            order.Truck = await _truckRepository.GetTruck(truckId);
            order.Driver = await _driverRepository.GetDriver(DriverId);
            await _orderRepository.UpdateOrder(order);
            return RedirectToAction("IndexOrder");
        }

        [HttpGet]
        public async Task<IActionResult> Close(int item)
        {
            var _order = await _orderRepository.GetOrder(item);
            _order.State = Models.Enums.OrderState.Close;
            _order.Truck.Status = Models.Enums.TruckStatus.Free;
            await _truckRepository.UpdateTruck(_order.Truck);
            await _orderRepository.UpdateOrder(_order);
            return RedirectToAction("IndexOrder");
        }

        [HttpGet]
        public async Task<IActionResult> ClosePayment(int item)
        {
            var _order = await _orderRepository.GetOrder(item);
            _order.IsPaid = true;
            await _orderRepository.UpdateOrder(_order);
            return RedirectToAction("IndexOrder");
        }
        
    }
}