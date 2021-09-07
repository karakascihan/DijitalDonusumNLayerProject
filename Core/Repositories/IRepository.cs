using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
   public  interface IRepository<TEntity> where TEntity:class
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        //Tekil Ekleme
        Task AddAsync(TEntity entity);
        //Birden Çok ekleme için range eklemesi yapıyoruz
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);


    }
}
