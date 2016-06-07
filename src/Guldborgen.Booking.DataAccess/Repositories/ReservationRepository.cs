using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Guldborgen.Booking.Common.Models;

namespace Guldborgen.Booking.DataAccess.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly IDbConnection _dbConnection;

        #region Sync

        public ReservationRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Reservation FindById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Reservation> FindAll()
        {
            return _dbConnection.Query<Reservation>("SELECT * FROM dbo.[Reservation]");
        }

        public IEnumerable<Reservation> Find(string sql)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Reservation entity)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(Reservation entity)
        {
            throw new System.NotImplementedException();
        }

        public void Add(Reservation entity)
        {
            _dbConnection.Execute("usp_AddReservation", new
            {
                entity.Username,
                entity.LaundryTimeId,
                entity.Date
            }, commandType: CommandType.StoredProcedure);
        }

        #endregion

        #region Async

        public async Task<Reservation> FindByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Reservation>> FindAllAsync()
        {
            var result = await _dbConnection
                .QueryAsync<Reservation>("SELECT * FROM dbo.[Reservation]");

            return result;
        }

        public async Task<IEnumerable<Reservation>> FindAsync(string sql)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateAsync(Reservation entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task RemoveAsync(Reservation entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task AddAsync(Reservation entity)
        {
            await _dbConnection.ExecuteAsync("usp_AddReservation", new
            {
                entity.Username,
                entity.LaundryTimeId,
                entity.Date
            }, commandType: CommandType.StoredProcedure);
        }


        #endregion

    }
}