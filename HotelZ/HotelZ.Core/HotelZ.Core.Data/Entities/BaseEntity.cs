using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

namespace HotelZ.Core.Data.Entities
{
    public class BaseEntity
    {
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }

        public static explicit operator BaseEntity(EntityEntry v)
        {
            throw new NotImplementedException();
        }
    }
}
