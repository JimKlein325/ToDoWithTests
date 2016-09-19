using Microsoft.EntityFrameworkCore;


namespace TravelBlog.Models
{
    public class TravelBlogTestDbContext : TravelBlogDbContext
    {


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TravelBlogTest;integrated security=True");
        }
    }
}
