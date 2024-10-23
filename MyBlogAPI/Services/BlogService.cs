using MyBlogAPI.Data;
using MyBlogAPI.Interfaces;
using MyBlogAPI.Models;

namespace MyBlogAPI.Services
{
    public class BlogService : IBlog
    {
        private readonly BlogDbContext _dbContext;
        public BlogService(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Blog> GetBlogs()
        {
            return _dbContext.Blogs.ToList();
        }
        public Blog GetBlogById(int id)
        {
            var blog = _dbContext.Blogs.FirstOrDefault(b => b.Id == id);
            if (blog == null) { return null; }
            return blog;
        }
        public Blog CreateBlog(Blog blog)
        {
            _dbContext.Blogs.Add(blog);
            _dbContext.SaveChanges();
            return blog;
        }
        public Blog UpdateBlog(int id, Blog blog) 
        {
            var blogPost = GetBlogById(id);
            if (blogPost == null) { return null; }
            blogPost.Title = blog.Title;
            blogPost.Content = blog.Content;
            _dbContext.SaveChanges();
            return blogPost;
        }
        public Blog DeleteBlog(int id) {
        var blogPost = GetBlogById(id);
            if(blogPost == null) { return null; }
            _dbContext.Blogs.Remove(blogPost);
            _dbContext.SaveChanges();
            return blogPost;
        }
    }
}
