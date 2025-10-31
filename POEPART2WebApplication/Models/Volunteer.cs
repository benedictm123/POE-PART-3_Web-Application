using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POEPART2WebApplication.Models
{
    public class Volunteer
    {
        [Key]
        public int VolunteerID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }
        public User User { get; set; }

        public string Skills { get; set; }
        public string Availability { get; set; }

        // Relationship
        public ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}
