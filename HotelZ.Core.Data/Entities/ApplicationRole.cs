using Microsoft.AspNetCore.Identity;
using System;

namespace HotelZ.Core.Data.Entities
{
    public class ApplicationRole : IdentityRole
    {
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
    }
}
