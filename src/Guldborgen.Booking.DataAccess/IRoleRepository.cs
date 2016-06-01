using System.Collections.Generic;
using System.Threading.Tasks;
using Guldborgen.Booking.Common.Models;

namespace Guldborgen.Booking.DataAccess
{
    public interface IRoleRepository : IRepository<Role>
    {
        #region Sync
        IEnumerable<Role> FindRolesByUserId(int id);
        #endregion

        #region Async
        Task<IEnumerable<Role>> FindRolesByUserIdAsync(int id);
        #endregion
    }
}