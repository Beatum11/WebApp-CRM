using Microsoft.EntityFrameworkCore;

namespace Web_Service.Models
{
    public class ContentDbContext : DbContext
    {

        public ContentDbContext(DbContextOptions<ContentDbContext> options) : base(options)
        {

        }

        public DbSet<Client>? Clients { get; set; }

        public DbSet<Project>? Projects { get; set;}

        public DbSet<Service>? Services { get; set; }

        public DbSet<BlogPost>? BlogPosts { get; set; }

    }
}
