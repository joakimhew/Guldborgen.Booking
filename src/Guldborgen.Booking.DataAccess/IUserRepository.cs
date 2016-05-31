
using Guldborgen.Booking.Common.Models;

namespace Guldborgen.Booking.DataAccess
{
    public interface IUserRepository : IRepository<User>
    {
        User FindByEmail(string email);
        string GetUserPasswordHash(string email);
    }
}