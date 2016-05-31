using System;
using System.Collections.Generic;
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
    }
}