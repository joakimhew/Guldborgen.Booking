using System.Collections.Generic;
using System.Linq;
using Guldborgen.Booking.Common;
using Guldborgen.Booking.Common.Models;

namespace Guldborgen.Booking.Web
{
    public static class Current
    {
        public static User User { get; set; }
        public static IEnumerable<Role> Roles { get; set; }
        public static UserSession UserSession { get; set; }
    }
}