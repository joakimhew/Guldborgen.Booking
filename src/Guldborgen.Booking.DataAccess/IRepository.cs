using System.Collections.Generic;
using System.Data;

namespace Guldborgen.Booking.DataAccess
{
    public interface IRepository<TEntity>
    {
        TEntity FindById(int id);
        IEnumerable<TEntity> FindAll();
        IEnumerable<TEntity> Find(string sql);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void Add(TEntity entity);

    }
}