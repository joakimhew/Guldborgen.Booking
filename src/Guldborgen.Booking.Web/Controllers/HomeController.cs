using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Guldborgen.Booking.Common.Extensions;
using Guldborgen.Booking.Common.Helpers;
using Guldborgen.Booking.Common.Models;
using Guldborgen.Booking.Domain;
using Guldborgen.Booking.Web.Attributes;
using Guldborgen.Booking.Web.ViewModels;

namespace Guldborgen.Booking.Web.Controllers
{
    public class HomeController : AsyncController
    {
        private readonly IBookingService _bookingService;
        private readonly IAccountService _accountService;


        private static IEnumerable<Reservation> _reservations;
        private static IEnumerable<LaundryTime> _laundryTimes;

        public HomeController(
            IBookingService bookingService, 
            IAccountService accountService)
        {
            _bookingService = bookingService;
            _accountService = accountService;
        }

        // GET: Home
        [Route("")]
        [CustomAuthorizeUser]
        public async Task<ActionResult> Index()
        {

            _reservations = await _bookingService.GetReservationsAsync();
            _laundryTimes = await _bookingService.GetTimeSpansAsync();

            IndexViewModel model = new IndexViewModel();

            DateTime currentDateTime = DateTime.Now;

            TimeSpan currentTimeSpan = new TimeSpan(currentDateTime.Hour,
                currentDateTime.Minute, currentDateTime.Second);

            var todaysReservations = _reservations
                .Where(x => x.Date.ToShortDateString() == currentDateTime.ToShortDateString());

            foreach (var reservation in todaysReservations)
            {
                LaundryTime laundryTime = _laundryTimes
                    .FirstOrDefault(x => x.Id == reservation.LaundryTimeId);

                if (laundryTime != null && currentTimeSpan.IsWithinTargetRange(
                    laundryTime.StartTime, laundryTime.EndTime))
                {
                    model.LaundryRoomStatus = LaundryRoomStatus.Busy;
                    model.CurrentUser = await _accountService.GetUserByIdAsync(reservation.UserId);
                    model.UserComment = reservation.Comment;

                    break;
                }

                model.LaundryRoomStatus = LaundryRoomStatus.Free;
            }

            return View(model);
        }

        [Route("{week:int?}")]
        [CustomAuthorizeUser]
        public ActionResult BookingCalendar(int? week)
        {
            if (!week.HasValue)
            {
                week = DateTime.Now.GetIso8601WeekOfYear();
            }

            DateTime firstDate = DateTimeHelpers.FirstDateOfWeekIso8601(DateTime.Now.Year, week.Value);

            BookingCalendarViewModel model = new BookingCalendarViewModel
            {
                CurrentWeek = week.Value
            };

            for (int index = 0; index < 7; index++)
            {
                var currentDate = firstDate.AddDays(index);
                var currentReservations = new Time[_laundryTimes.Count()];

                for (int i = 0; i < _laundryTimes.Count(); i++)
                {
                    var timeSpan = _laundryTimes.ElementAt(i);

                    var isBooked = _reservations
                        .Any(x => x.LaundryTimeId == timeSpan.Id
                                  && x.Date.ToShortDateString() == currentDate.ToShortDateString());

                    currentReservations[i] = new Time { IsBooked = isBooked, LaundryTime = timeSpan };
                }

                model.LaundryReservations.Add(currentDate, currentReservations);
            }

            return PartialView(model);
        }

        [Route("{week:int?}")]
        [HttpPost]
        [CustomAuthorizeUser]
        public async Task<ActionResult> Reserve(int timespanId, DateTime date)
        {
            Debug.Write($"Timespan id: {timespanId} | Date: {date}");

            if (Current.User.Id != null)
               await _bookingService.AddReservationAsync(Current.User.Id.Value, timespanId, date);

            return RedirectToAction("Index", "Home");
        }
    }
}