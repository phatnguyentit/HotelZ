using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelZ.Core.Data.Entities
{
    public class Hotel : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        
        public decimal StarRating { get; set; }
    }
}
