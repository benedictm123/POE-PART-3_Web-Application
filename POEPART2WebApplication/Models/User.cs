using System.ComponentModel.DataAnnotations;

namespace POEPART2WebApplication.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [MaxLength(50)]
        public string Role { get; set; }

        [MaxLength(20)]
        public string ContactNumber { get; set; }

        // Relationships
        public ICollection<Donation> Donations { get; set; } = new List<Donation>();
        public Volunteer Volunteer { get; set; }
    }
}
