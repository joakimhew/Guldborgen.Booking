using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Guldborgen.Booking.Common.Models;

namespace Guldborgen.Booking.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _dbConnection;

        public UserRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public User FindById(int id)
        {
            return _dbConnection.Query<User>(
                "SELECT U.* " +
                "FROM dbo.[User] U " +
                " WHERE U.Id = @Id", new {@Id = id}).FirstOrDefault();
        }

        public IEnumerable<User> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> Find(string sql)
        {
            throw new System.NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(User entity)
        {
            throw new System.NotImplementedException();
        }

        public void Add(User entity)
        {
            throw new System.NotImplementedException();
        }

        public User FindByEmail(string email)
        {
            return _dbConnection.Query<User>(
               "SELECT U.* " +
               "FROM dbo.[User] U " +
               " WHERE U.Email = @Email", new { @Email = email }).FirstOrDefault();
        }

        public string GetUserPasswordHash(string email)
        {
            return _dbConnection
               .Query<string>("SELECT * FROM dbo.tvf_GetUserPasswordHash(@Email)", new { @Email = email })
               .FirstOrDefault();
        }
    }
}