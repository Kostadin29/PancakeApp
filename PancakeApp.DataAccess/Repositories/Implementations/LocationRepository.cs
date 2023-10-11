using Microsoft.EntityFrameworkCore;
using PancakeApp.DataAccess.DataContext;
using PancakeApp.DataAccess.Repositories.Interfaces;
using PancakeApp.Domain.Models;

namespace PancakeApp.DataAccess.Repositories.Implementations
{
    public class LocationRepository : IRepository<Location>
    {
        private PancakeAppDbContext _dbContext;

        public LocationRepository(PancakeAppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<List<Location>> GetAll()
        {
            return await _dbContext.Locations.ToListAsync();
        }
        public async Task<int> DeleteById(int id)
        {
            Location locationDb = await _dbContext.Locations.SingleOrDefaultAsync(x => x.Id == id);

            if (locationDb == null)
                throw new Exception($"Item with id:{id} was not found.");

            _dbContext.Locations.Remove(locationDb);
            await _dbContext.SaveChangesAsync();

            return locationDb.Id;
        }


        public Task<Location> GetById(int id)
        {
            return _dbContext.Locations.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task Insert(Location entity)
        {
            await _dbContext.Locations.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Location entity)
        {
            _dbContext.Locations.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
