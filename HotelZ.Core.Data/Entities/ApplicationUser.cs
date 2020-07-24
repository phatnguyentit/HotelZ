using Microsoft.AspNetCore.Identity;
using System;

namespace HotelZ.Core.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Nickname { get; set; }
        public DateTime CreatedDateTime{ get; set; }
        public DateTime? UpdatedDateTime { get; set; }
    }
}
