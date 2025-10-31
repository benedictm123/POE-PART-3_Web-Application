using System.ComponentModel.DataAnnotations;

namespace POEPART2WebApplication.Models
{
    public class Project
    {
        [Key]
        public int ProjectID { get; set; }

        [Required]
        [MaxLength(150)]
        public string ProjectName { get; set; }

        public string Description { get; set; }
        public string Location { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Status { get; set; }

        // Relationships
        public ICollection<Donation> Donations { get; set; } = new List<Donation>();
        public ICollection<Event> Events { get; set; } = new List<Event>();
        public ICollection<Volunteer> Volunteers { get; set; } = new List<Volunteer>();
    }
}
