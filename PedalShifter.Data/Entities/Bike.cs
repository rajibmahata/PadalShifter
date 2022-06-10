
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedalShifter.Data.Entities
{
    public class Bike
    {
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal DailyRate { get; set; }
        [Required]
        [MaxLength(5000)]
        public string Description { get; set; }
        public int Category { get; set; }

        [Required(ErrorMessage = "Please add an image of your bike.")]
        public string MainImage { get; set; }
        public string UserId { get; set; }
        public string SerialNumber { get; set; }
    }
}
