using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelZ.Core.Data.Entities
{
    public class Room : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Number { get; set; }
        public RoomType RoomType { get; set; }
    }
}
