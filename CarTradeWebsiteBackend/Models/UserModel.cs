using CarTradeWebsite.Models;
using System.ComponentModel.DataAnnotations;

namespace CarTradeWebsite
{
    public class UserModel
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        [Required]
        public DateTime DateOfCreation { get; set; }
    }
}
