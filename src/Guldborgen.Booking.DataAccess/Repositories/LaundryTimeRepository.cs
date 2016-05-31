using System.Collections.Generic;
using System.Data;
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
    }
}