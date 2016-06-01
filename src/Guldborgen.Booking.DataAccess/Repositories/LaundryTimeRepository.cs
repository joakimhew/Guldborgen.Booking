using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Guldborgen.Booking.Common.Models;

namespace Guldborgen.Booking.DataAccess.Repositories
{
    public class LaundryTimeRepository : ILaundryTimeRepository
    {

        private readonly IDbConnection _dbConnection;

        public LaundryTimeRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        #region Sync

        public LaundryTime FindById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<LaundryTime> FindAll()
        {
            return _dbConnection.Query<LaundryTime>("SELECT * FROM dbo.[LaundryTime]");
        }

        public IEnumerable<LaundryTime> Find(string sql)
        {
            throw new System.NotImplementedException();
        }

        public void Update(LaundryTime entity)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(LaundryTime entity)
        {
            throw new System.NotImplementedException();
        }

        public void Add(LaundryTime entity)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region Async

        public async Task<LaundryTime> FindByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<LaundryTime>> FindAllAsync()
        {
            var result = await _dbConnection
                .QueryAsync<LaundryTime>("SELECT * FROM dbo.[LaundryTime]");

            return result;
        }

        public async Task<IEnumerable<LaundryTime>> FindAsync(string sql)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateAsync(LaundryTime entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task RemoveAsync(LaundryTime entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task AddAsync(LaundryTime entity)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}