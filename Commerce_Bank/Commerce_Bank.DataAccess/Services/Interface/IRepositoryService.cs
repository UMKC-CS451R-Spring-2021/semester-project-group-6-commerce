using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Commerce_Bank.DataAccess.Services.Interface
{
   
    public interface IRepositoryService<T> where T : class
    {
        //this is use for dependency injection. This is to avoid tight coupling to your implementing classes
        Task<IEnumerable<T>> FindAll();
        Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(T entity);
        Task<int> Save(T entity);
        Task<int> Commit();
        Task<T> GetBy(Expression<Func<T, bool>> expression);
    }
}
