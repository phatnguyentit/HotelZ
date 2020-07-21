using System;

namespace HotelZ.Core.Data.Entities
{
    public class Room : BaseEntity
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public RoomType RoomType { get; set; }
    }
}
