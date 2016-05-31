using System;
using System.Collections.Generic;
using System.Web.WebPages;
using Guldborgen.Booking.Common.Extensions;
using Guldborgen.Booking.Common.Models;

namespace Guldborgen.Booking.Web.ViewModels
{
    public class BookingCalendarViewModel
    {

        public BookingCalendarViewModel()
        {
            LaundryReservations = new Dictionary<DateTime, IEnumerable<Time>>();
        }

        public int CurrentWeek { get; set; }
        public Dictionary<DateTime, IEnumerable<Time>> LaundryReservations { get; set; } 
    }

    public class LaundryReservation
    {
        public DateTime Date { get; set; }
        public Time LaundryTime { get; set; }
    }

    public class Time
    {
        public bool IsBooked { get; set; }
        public LaundryTime LaundryTime { get; set; }
    }
}