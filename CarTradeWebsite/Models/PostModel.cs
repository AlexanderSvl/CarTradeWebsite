using System.ComponentModel.DataAnnotations;

namespace CarTradeWebsite.Models
{
    public class PostModel
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        public IEnumerable<ImageModel> CarImages { get; set; }

        [Required]
        public string CoverImageURL { get; set; }

        [Required]
        [StringLength(50)]
        public string CarMake { get; set; }

        [Required]
        [StringLength(50)]
        public string CarModel { get; set; }

        [Required]
        [StringLength(50)]
        public string FuelType { get; set; }

        [Required]
        [StringLength(50)]
        public string MotorDisplacement { get; set; }

        [Required]
        [StringLength(50)]
        public string TransmissionType { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        [StringLength(1000)]
        public string Location { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public IEnumerable<OptionModel> Options { get; set; }

        [Required]
        public DateTime DateOfCreation { get; set; }
    }
}
