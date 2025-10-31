using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POEPART2WebApplication.Models
{
    public class Donation
    {
        [Key]
        public int DonationID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }
        public User User { get; set; }

        [ForeignKey("Project")]
        public int ProjectID { get; set; }
        public Project Project { get; set; }

        public decimal Amount { get; set; }
        public DateTime DonationDate { get; set; }
    }
}
