using System;

namespace Guldborgen.Booking.Common.Extensions
{
    public static class TimeSpanExtensions
    {
        public static bool IsWithinTargetRange(this TimeSpan sourceTimeSpan, TimeSpan startTime, TimeSpan endTime)
        {
            return (sourceTimeSpan >= startTime && sourceTimeSpan < endTime);
        }

        public static string ToHourMinutes(this TimeSpan t)
        {
            return $"{t.Hours.ToString("D2")}:{t.Minutes.ToString("D2")}";
        }
    }
}