using System.ComponentModel.DataAnnotations;

namespace CarTradeWebsite.Models
{
    public class OptionModel
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
