using System.Collections.Generic;
using System.Data;
using Dapper;
using Guldborgen.Booking.Common.Models;

namespace Guldborgen.Booking.DataAccess.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly IDbConnection _dbConnection;

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
                entity.UserId,
                entity.LaundryTimeId,
                entity.Date
            }, commandType: CommandType.StoredProcedure);
        }
    }
}