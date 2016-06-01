using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Guldborgen.Booking.Common.Models;
using Guldborgen.Booking.DataAccess;

namespace Guldborgen.Booking.Domain
{
    public class BookingService : IBookingService
    {
        private readonly ILaundryTimeRepository _laundryTimeRepository;
        private readonly IReservationRepository _reservationRepository;

        public BookingService(
            ILaundryTimeRepository laundryTimeRepository,
            IReservationRepository reservationRepository)
        {
            _laundryTimeRepository = laundryTimeRepository;
            _reservationRepository = reservationRepository;
        }

        #region Sync

        public IEnumerable<LaundryTime> GetTimeSpans()
        {
            return _laundryTimeRepository.FindAll();
        }

        public IEnumerable<Reservation> GetReservations()
        {
            return _reservationRepository.FindAll();
        }

        public void AddReservation(int userId, int laundryTimeId, DateTime date)
        {
            _reservationRepository.Add(new Reservation
            {
                UserId = userId,
                LaundryTimeId = laundryTimeId,
                Date = date
            });
        }

        #endregion


        #region Async

        public async Task<IEnumerable<LaundryTime>> GetTimeSpansAsync()
        {
            return await _laundryTimeRepository.FindAllAsync();
        }

        public async Task<IEnumerable<Reservation>> GetReservationsAsync()
        {
            return await _reservationRepository.FindAllAsync();
        }

        public async Task AddReservationAsync(int userId, int laundryTimeId, DateTime date)
        {
            await _reservationRepository.AddAsync(new Reservation
            {
                UserId = userId,
                LaundryTimeId = laundryTimeId,
                Date = date
            });
        }

        #endregion
    }
}