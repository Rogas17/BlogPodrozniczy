using BlogPodrozniczy.Web.Models.Domena;
using Microsoft.EntityFrameworkCore;

namespace BlogPodrozniczy.Web.Data
{
    public class BlogDB : DbContext
    {
        public BlogDB(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BlogPost> Posty { get; set; }

        public DbSet<Tag> Tagi { get; set; }
    }
}
