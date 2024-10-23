using Microsoft.EntityFrameworkCore;
using MyBlogAPI.Models;

namespace MyBlogAPI.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext>options) : base(options) { }
        public DbSet<Blog> Blogs { get; set; }
    }
}
