using Microsoft.EntityFrameworkCore;
using PancakeApp.DataAccess.DataContext;
using PancakeApp.DataAccess.Repositories.Interfaces;
using PancakeApp.Domain.Models;
using System.Security.Cryptography.X509Certificates;

namespace PancakeApp.DataAccess.Repositories.Implementations
{
    public class OrderRepository : IRepository<Order>
    {
        private PancakeAppDbContext _dbContext;

        public OrderRepository(PancakeAppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<List<Order>> GetAll()
        {
            return await _dbContext.Orders
                .Include(x => x.Location)
                .Include(x => x.PancakeOrders)
                .ThenInclude(x => x.Pancake)
                .ToListAsync();
        }

        public async Task<Order> GetById(int id)
        {
            return await _dbContext.Orders.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task Insert(Order entity)
        {
            await _dbContext.Orders.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Order entity)
        {
            _dbContext.Orders.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<int> DeleteById(int id)
        {
            Order orderDb = await _dbContext.Orders.SingleOrDefaultAsync(x => x.Id == id);

            if(orderDb == null)
                 throw new Exception($"Item with Id: {id} was not found!");

            _dbContext.Orders.Remove(orderDb);
            await _dbContext.SaveChangesAsync();

            return orderDb.Id;
           
        }
    }
}
