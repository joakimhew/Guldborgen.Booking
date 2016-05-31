using System.Collections.Generic;
using Guldborgen.Booking.Common.Models;

namespace Guldborgen.Booking.DataAccess
{
    public interface IRoleRepository : IRepository<Role>
    {
        IEnumerable<Role> FindRolesByUserId(int id);
    }
}