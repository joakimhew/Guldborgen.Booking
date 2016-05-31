using System;
using System.Collections.Generic;
using Guldborgen.Booking.Common.Models;

namespace Guldborgen.Booking.Domain
{
    public interface IBookingService
    {
        IEnumerable<LaundryTime> GetTimeSpans();
        IEnumerable<Reservation> GetReservations();
        void AddReservation(int userId, int laundryTimeId, DateTime date);
    }
}