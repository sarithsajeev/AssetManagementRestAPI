using System;
using System.Collections.Generic;

namespace AssetManagement.Models
{
    public partial class UserRegistration
    {
        public int UId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public decimal? PhoneNumber { get; set; }
        public int? LId { get; set; }

        public virtual Login L { get; set; }
    }
}
