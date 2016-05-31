using System.Collections.Generic;
using System.Data;
using Dapper;
using Guldborgen.Booking.Common.Models;

namespace Guldborgen.Booking.DataAccess.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IDbConnection _dbConnection;

        public RoleRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Role FindById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Role> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Role> Find(string sql)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Role entity)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(Role entity)
        {
            throw new System.NotImplementedException();
        }

        public void Add(Role entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Role> FindRolesByUserId(int id)
        {
            return _dbConnection
                .Query<Role>("SELECT R.* FROM dbo.UserRole UR JOIN dbo.[Role] R ON UR.RoleId = R.Id WHERE UR.UserId = @Id", 
                new {@Id = id});
        }
    }
}