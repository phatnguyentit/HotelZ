using System.ComponentModel.DataAnnotations;

namespace HotelZ.Core.Data.Entities
{
    public class Configuration : BaseEntity
    {
        [Key]
        public string Key { get; set; }

        public string Value { get; set; }
    }
}
