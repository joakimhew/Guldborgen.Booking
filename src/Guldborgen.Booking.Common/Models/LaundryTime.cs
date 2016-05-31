using System;

namespace Guldborgen.Booking.Common.Models
{

    //TODO: Change name
    public class LaundryTime
    {
        public int Id { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}