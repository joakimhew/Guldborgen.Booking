using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
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

        public async Task<Role> FindByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Role>> FindAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Role>> FindAsync(string sql)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateAsync(Role entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task RemoveAsync(Role entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task AddAsync(Role entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Role> FindRolesByUserId(int id)
        {
            return _dbConnection
                .Query<Role>("SELECT R.* FROM dbo.UserRole UR JOIN dbo.[Role] R ON UR.RoleId = R.Id WHERE UR.UserId = @Id", 
                new {@Id = id});
        }

        public async Task<IEnumerable<Role>> FindRolesByUserIdAsync(int id)
        {
            var result = await _dbConnection
                .QueryAsync<Role>(
                    "SELECT R.* FROM dbo.userRole UR JOIN dbo.[Role] R ON UR.RoleId = R.Id WHERE UR.UserId = @Id",
                    new {@Id = id});

            return result;
        }
    }
}