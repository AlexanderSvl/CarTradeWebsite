using System.ComponentModel.DataAnnotations;

namespace CarTradeWebsite.Models
{
    public class ImageModel
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public string URL { get; set; }
    }
}
