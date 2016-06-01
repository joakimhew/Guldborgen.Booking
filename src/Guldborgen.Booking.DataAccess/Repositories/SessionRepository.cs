using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Guldborgen.Booking.Common.Models;

namespace Guldborgen.Booking.DataAccess.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly IDbConnection _dbConnection;

        public SessionRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        #region Sync

        public UserSession FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserSession> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserSession> Find(string sql)
        {
            throw new NotImplementedException();
        }

        public void Update(UserSession entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(UserSession entity)
        {
            _dbConnection.Execute("usp_DeleteUserSession",
                new {entity.UserId}, commandType: CommandType.StoredProcedure);
        }

        public void Add(UserSession entity)
        {
            _dbConnection.Execute("usp_AddUserSession",
                new {entity.Id, entity.UserId, entity.ExpirationDate}, commandType: CommandType.StoredProcedure);
        }

        public UserSession FindBySessionId(Guid id)
        {
            return _dbConnection
               .Query<UserSession>("SELECT * FROM dbo.UserSession WHERE Id = @Id", new { @Id = id })
               .FirstOrDefault();
        }

        #endregion

        #region Async

        public async Task<UserSession> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserSession>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserSession>> FindAsync(string sql)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(UserSession entity)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(UserSession entity)
        {
            await _dbConnection.ExecuteAsync("usp_DeleteUserSession",
                new { entity.UserId }, commandType: CommandType.StoredProcedure);
        }

        public async Task AddAsync(UserSession entity)
        {
            await _dbConnection.ExecuteAsync("usp_AddUserSession",
                new { entity.Id, entity.UserId, entity.ExpirationDate }, commandType: CommandType.StoredProcedure);
        }

        public async Task<UserSession> FindBySessionIdAsync(Guid id)
        {
            var result = await _dbConnection
               .QueryAsync<UserSession>("SELECT * FROM dbo.UserSession WHERE Id = @Id", new { @Id = id });

            return result.FirstOrDefault();
        }

        #endregion
    }
}