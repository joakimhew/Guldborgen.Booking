using System;
using System.Threading.Tasks;
using Guldborgen.Booking.Common.Models;

namespace Guldborgen.Booking.DataAccess
{
    public interface ISessionRepository : IRepository<UserSession>
    {
        #region Sync
        UserSession FindBySessionId(Guid id);
        #endregion

        #region Async

        Task<UserSession> FindBySessionIdAsync(Guid id);

        #endregion
    }
}