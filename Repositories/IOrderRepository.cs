using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_TransportCompany.Models;

namespace WebApp_TransportCompany.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrders(IdentityUser user);

        Task<IEnumerable<Order>> GetOrders(Truck truck);

        Task<Order> GetOrder(int id);

        Task AddOrder(Order order);

        void DeleteOrder(Order order);

        void UpdateOrder(Order order);
    }
}
