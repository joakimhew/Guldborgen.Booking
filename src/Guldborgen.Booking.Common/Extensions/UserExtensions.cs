using System.Linq;
using Guldborgen.Booking.Common.Models;

namespace Guldborgen.Booking.Common.Extensions
{
    public static class UserExtensions
    {
        public static bool HasRole(this User user, DistinctRole role)
        {
            return user.Roles.Any(x => x.Id == (int) role);
        }
    }
}