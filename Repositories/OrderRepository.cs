using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp_TransportCompany.Data;
using WebApp_TransportCompany.Models;

namespace WebApp_TransportCompany.Repositories
{
    public class OrderRepository:BaseRepository, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context)
            :base(context)
        {

        }

        public async Task AddOrder(Order order)
        {
            await _context.Orders.AddAsync(order);
            await Save();
        }

        public async Task DeleteOrder(Order order)
        {
            _context.Orders.Remove(order);
            await Save();
        }

        public async Task<Order> GetOrder(int id)
        {
            return await _context.Orders
                .Include(x => x.Driver)
                .Include(x => x.Truck)
                    .ThenInclude(x => x.Identity)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Order>> GetOrders(IdentityUser user)
        {
            return await _context.Orders
                .Include(x => x.Driver)
                .Include(x => x.Truck)
                    .ThenInclude(x => x.Identity)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrders(Truck truck)
        {
            return await _context.Orders
                .Include(x => x.Driver)
                .Include(x => x.Truck)
                    .ThenInclude(x => x.Identity)
                .Where(x => x.Truck.Id == truck.Id)
                .ToListAsync();
        }

        public async Task UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            await Save();
        }
    }
}
