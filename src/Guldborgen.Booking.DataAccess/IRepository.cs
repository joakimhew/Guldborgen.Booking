using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Guldborgen.Booking.DataAccess
{
    public interface IRepository<TEntity>
    {
        #region Sync

        TEntity FindById(int id);
        IEnumerable<TEntity> FindAll();
        IEnumerable<TEntity> Find(string sql);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void Add(TEntity entity);

        #endregion

        #region Async

        Task<TEntity> FindByIdAsync(int id);
        Task<IEnumerable<TEntity>> FindAllAsync();
        Task<IEnumerable<TEntity>> FindAsync(string sql);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
        Task AddAsync(TEntity entity);


        #endregion

    }
}