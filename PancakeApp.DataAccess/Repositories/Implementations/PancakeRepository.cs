using Microsoft.EntityFrameworkCore;
using PancakeApp.DataAccess.DataContext;
using PancakeApp.DataAccess.Repositories.Interfaces;
using PancakeApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PancakeApp.DataAccess.Repositories.Implementations
{
    public class PancakeRepository : IPancakeRepository
    {
        private PancakeAppDbContext _dbContext;

        public PancakeRepository(PancakeAppDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        public async Task<List<Pancake>> GetAll()
        {
            return await _dbContext.Pancakes.ToListAsync();
        }

        public async Task<Pancake> GetById(int id)
        {
            return await _dbContext.Pancakes.SingleOrDefaultAsync(x => x.Id == id);
        }


        public async Task Insert(Pancake entity)
        {
            await _dbContext.Pancakes.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Pancake entity)
        {
            _dbContext.Pancakes.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<int> DeleteById(int id)
        {
            Pancake pancakeDb = await _dbContext.Pancakes.SingleOrDefaultAsync(x => x.Id ==id);

            if (pancakeDb == null) 
            {
                throw new Exception($"Item with Id:{id} was not found!");            
            }

            _dbContext.Pancakes.Remove(pancakeDb);
            await _dbContext.SaveChangesAsync();

            return pancakeDb.Id;
        }

        public List<Pancake> GetPancakesOnPromotion()
        {
            return _dbContext.Pancakes.Where(pancake => pancake.IsOnPromotion).ToList();
        }
    }
}
