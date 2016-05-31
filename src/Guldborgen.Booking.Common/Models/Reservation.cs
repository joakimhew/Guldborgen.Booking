using System;

namespace Guldborgen.Booking.Common.Models
{
    public class Reservation
    {
        public int UserId { get; set; }
        public int LaundryTimeId { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
    }
}