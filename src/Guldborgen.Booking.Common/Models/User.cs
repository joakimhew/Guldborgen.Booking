using System;
using System.Collections.Generic;

namespace Guldborgen.Booking.Common.Models
{
    public class User
    {
        public int? Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Role> Roles { get; set; } 
    }
}