using System.Collections.Generic;

namespace Guldborgen.Booking.Common.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }  
    }
}