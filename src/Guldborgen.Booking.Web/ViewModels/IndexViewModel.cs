using System.Security.Principal;
using Guldborgen.Booking.Common.Models;

namespace Guldborgen.Booking.Web.ViewModels
{
    public class IndexViewModel
    {
        public LaundryRoomStatus LaundryRoomStatus { get; set; }
        public string UserComment { get; set; }
        public User CurrentUser { get; set; }
        public int CurrentApartmentId { get; set; }
    }

    public enum LaundryRoomStatus
    {
        Free,
        Busy,
        Closed
    }
}