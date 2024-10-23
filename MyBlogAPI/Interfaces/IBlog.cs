using MyBlogAPI.Models;

namespace MyBlogAPI.Interfaces
{
    public interface IBlog
    {
        public List<Blog> GetBlogs();
        public Blog GetBlogById(int id);
        public Blog CreateBlog(Blog blog);
        public Blog UpdateBlog(int id, Blog blog);
        public Blog DeleteBlog(int id);
    }
}
