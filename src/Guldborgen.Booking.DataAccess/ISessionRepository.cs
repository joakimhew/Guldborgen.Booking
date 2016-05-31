using System;
using Guldborgen.Booking.Common.Models;

namespace Guldborgen.Booking.DataAccess
{
    public interface ISessionRepository : IRepository<UserSession>
    {
        UserSession FindBySessionId(Guid id);
    }
}