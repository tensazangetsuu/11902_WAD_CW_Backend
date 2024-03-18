using _11902_WAD_CW_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace _11902_WAD_CW_backend.Data
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
