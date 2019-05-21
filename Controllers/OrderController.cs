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

        public OrderController(ITruckRepository truckRepository,
            IOrderRepository orderRepository, 
            UserManager<IdentityUser> userManager)
        {
            _orderRepository = orderRepository;
            _truckRepository = truckRepository;
            _userManager = userManager;
        }

        // GET: Order
        public async Task<IActionResult> IndexOrder()
        {
            var _identityUser = await _userManager.GetUserAsync(User);
            var vm = new OrderViewModel()
            {
                Orders = await _orderRepository.GetOrders(_identityUser),
                Trucks = await _truckRepository.GetTrucks(_identityUser)
            };
            return View(vm);
        }

        public async Task<IActionResult> GetOrderByTruck(int id)
        {
            var _truck = await _truckRepository.GetTruck(id);
            var _orders = await _orderRepository.GetOrders(_truck);
            return RedirectToAction("IndexOrder", new { orders = _orders });
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Order order, int truckId)
        {
            //order.Identity = await _userManager.GetUserAsync(User);
            var _truck = await _truckRepository.GetTruck(truckId);
            _truck.Status = Models.Enums.TruckStatus.InFlight;
            order.Truck = _truck;
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
            return View(await _orderRepository.GetOrder(id));
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
        public IActionResult Edit(OrderFormPartialViewModel vm)
        {
            _orderRepository.UpdateOrder(vm.Order);
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