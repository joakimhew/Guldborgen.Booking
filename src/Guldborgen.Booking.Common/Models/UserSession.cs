using System;

namespace Guldborgen.Booking.Common.Models
{
    public class UserSession
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}