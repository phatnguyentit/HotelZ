using System;

namespace HotelZ.Core.Data.Entities
{
    public class RoomType : BaseEntity
    {
        public Guid Id { get; set; }
        public RoomTypeEnum Type { get; set; }
    }
}
