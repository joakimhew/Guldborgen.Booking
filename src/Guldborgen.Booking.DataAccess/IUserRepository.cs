
using System.Threading.Tasks;
using Guldborgen.Booking.Common.Models;

namespace Guldborgen.Booking.DataAccess
{
    public interface IUserRepository : IRepository<User>
    {
        #region Sync

        User FindByEmail(string email);
        User FindByUsername(string username);
        string GetUserPasswordHash(string email);

        #endregion

        #region Async

        Task<User> FindByEmailAsync(string email);
        Task<User> FindByUsernameAsync(string username);
        Task<string> GetUserPasswordHashAsync(string email);

        #endregion

    }
}