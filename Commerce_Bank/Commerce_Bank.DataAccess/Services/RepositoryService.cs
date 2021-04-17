using Commerce_Bank.DataAccess.Model;
using Commerce_Bank.DataAccess.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Commerce_Bank.DataAccess.Services
{
   
    public class RepositoryService<T> : IRepositoryService<T> where T : class
    {
        protected readonly CommerceBankAppContext _context;
        private readonly DbSet<T> entities;
        public RepositoryService(CommerceBankAppContext context)
        {
            _context = context;
            entities = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> FindAll()
        {
            return await entities.AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return await entities.Where(expression).AsNoTracking().ToListAsync();
        }
        public void Create(T entity)
        {
            entities.Add(entity);
        }
        public async Task<int> Update(T entity)
        {
            entities.Update(entity);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Delete(T entity)
        {
            entities.Remove(entity);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Save(T entity)
        {
            entities.Add(entity);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }
        public async Task<T> GetBy(Expression<Func<T, bool>> expression)
        {
            return await entities.Where(expression).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}

