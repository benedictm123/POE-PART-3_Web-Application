using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POEPART2WebApplication.Models
{
    public class Event
    {
        [Key]
        public int EventID { get; set; }

        [ForeignKey("Project")]
        public int ProjectID { get; set; }
        public Project Project { get; set; }

        [Required]
        [MaxLength(150)]
        public string EventName { get; set; }

        public DateTime EventDate { get; set; }
        public string Description { get; set; }
    }
}
