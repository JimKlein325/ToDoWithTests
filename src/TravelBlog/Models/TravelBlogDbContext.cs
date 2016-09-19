using Microsoft.EntityFrameworkCore;


namespace TravelBlog.Models
{
    public class TravelBlogDbContext : DbContext
    {
        public DbSet<Location> Locations { get; set; }

        public DbSet<Experience> Experiences { get; set; }

        public DbSet<People> Peoples { get; set; }

        public DbSet<PeopleExperience> PeopleExperiences { get; set; }

        public DbSet<PeopleLocation> PeopleLocations { get; set; }
        public DbSet<Suggestion> Suggestions { get; set; }

        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TravelBlog;integrated security=True");
        }
    }
}
