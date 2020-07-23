using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelZ.Core.Data.Entities
{
    public class RoomType : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public RoomTypeEnum Type { get; set; }
    }
}
