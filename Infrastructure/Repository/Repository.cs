using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Ardalis.Specification.EntityFrameworkCore;

using System.Threading.Tasks;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class Repository<TEntity> : RepositoryBase<TEntity>, IRepository<TEntity> where TEntity : class
    {
        private AppDbContext _context;
        private DbSet<TEntity> _dbSet;

        public Repository(AppDbContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task DeleteAsync(TEntity entityToDelete)
        {
            await Task.Run(() =>
            {
                if (_context.Entry(entityToDelete).State == EntityState.Detached)
                {
                    _dbSet.Attach(entityToDelete);
                }
                _dbSet.Remove(entityToDelete);
            });
        }

        public Task DeleteRange(IEnumerable<TEntity> entitiesToDelete)
        {
            _dbSet.RemoveRange(entitiesToDelete);
            return Task.CompletedTask;
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync<TKey>(TKey id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            return (await _dbSet.AddAsync(entity)).Entity;
        }
        
        public async Task<IList<TEntity>> AddRangeAsync(IList<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            await _context.SaveChangesAsync();

            return entities.ToList();
        }

        public async Task UpdateAsync(TEntity entityToUpdate)
        {
            await Task.Run(() =>
            {
                _dbSet.Attach(entityToUpdate);
                _context.Entry(entityToUpdate).State = EntityState.Modified;
            });
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] includes)
        {
            var query = includes
                .Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>(_dbSet, (current, include) => current.Include(include));

            return query;
        }
    }
}
