using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Guldborgen.Booking.Common.Models;

namespace Guldborgen.Booking.Domain
{
    public interface IBookingService
    {
        #region Sync

        IEnumerable<LaundryTime> GetTimeSpans();
        IEnumerable<Reservation> GetReservations();
        void AddReservation(int userId, int laundryTimeId, DateTime date);

        #endregion

        #region Async

        Task<IEnumerable<LaundryTime>> GetTimeSpansAsync();
        Task<IEnumerable<Reservation>> GetReservationsAsync();
        Task AddReservationAsync(int userId, int laundryTimeId, DateTime date);
        
        #endregion
    }
}