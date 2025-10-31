using Microsoft.EntityFrameworkCore;

namespace POEPART2WebApplication.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<POEPART2WebApplication.Models.Project> Projects { get; set; }
        public DbSet<POEPART2WebApplication.Models.User> Users { get; set; }
        public DbSet<POEPART2WebApplication.Models.Donation> Donations { get; set; }
        public DbSet<POEPART2WebApplication.Models.Volunteer> Volunteers { get; set; }
        public DbSet<POEPART2WebApplication.Models.Event> Events { get; set; }

        
    }
}
