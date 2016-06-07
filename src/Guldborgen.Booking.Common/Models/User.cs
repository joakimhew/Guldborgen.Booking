using System;
using System.Collections.Generic;
using System.Security.Principal;

namespace Guldborgen.Booking.Common.Models
{
    public class User : IPrincipal
    {

        private string _username;
        public int? Id { get; set; }

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                Identity = new GenericIdentity(value);
            }
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }

        public IIdentity Identity { get; private set; }
    }
}