using CarParts.Persistence.Context;
using CarsParts.Application.Repositories;
using System;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarParts.Persistence.Repository
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly CarPartsDbContext carPartsDbContext;

        public Repository(CarPartsDbContext carPartsDbContext)
        {
            this.carPartsDbContext = carPartsDbContext;
        }

        public async Task CreateAsync(T entity)
        {
            await carPartsDbContext.Set<T>().AddAsync(entity);
            await carPartsDbContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await this.carPartsDbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await this.carPartsDbContext.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await this.carPartsDbContext.Set<T>().FindAsync(id);
        }

      

        public async Task RemoveAsync(T entity)
        {
            this.carPartsDbContext.Set<T>().Remove(entity);
            await this.carPartsDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            this.carPartsDbContext.Set<T>().Update(entity);
            await this.carPartsDbContext.SaveChangesAsync();
        }
    }
}
