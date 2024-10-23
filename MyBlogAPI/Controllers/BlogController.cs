using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBlogAPI.Data;
using MyBlogAPI.DTO;
using MyBlogAPI.Interfaces;
using MyBlogAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyBlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlog _blogService;
        public BlogController(IBlog blogService)
        {
            _blogService = blogService;
        }
        // GET: api/<BlogController>
        [HttpGet]
        public async Task<IEnumerable<BlogDTO>> GetAllBlogs()
        {    
            var blogList = _blogService.GetBlogs();
            var blogDTOList = blogList.Select(blog => new BlogDTO 
            {
                Title = blog.Title,
                Content = blog.Content,
            });
            return blogDTOList;
        }

        // GET api/<BlogController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> GetBlogById(int id)
        {
            var blogPost = _blogService.GetBlogById(id);
            if (blogPost == null)
            {
                return NotFound();
            }
            return blogPost;
        }

        // POST api/<BlogController>
        [HttpPost]
        public async Task<ActionResult<Blog>> CreateBlog(BlogDTO blog)
        {
            var blogModel = new Blog()
            {
                Title = blog.Title,
                Content = blog.Content
            };
            _blogService.CreateBlog(blogModel);
            
            return CreatedAtAction("GetBlogById", new { id = blogModel.Id}, blog);
        }

        // PUT api/<BlogController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BlogDTO>> UpdateBlog(int id, BlogDTO blogDTO)
        {
            var existingBlog = _blogService.GetBlogById(id);
            if (existingBlog == null) { return NotFound(); }    
            
            existingBlog.Title = blogDTO.Title;
            existingBlog.Content = blogDTO.Content;
            _blogService.UpdateBlog(id, existingBlog);
            return Ok("Update Successfully");// NoContent();
        }

        // DELETE api/<BlogController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBlog(int id)
        {
            var blog = _blogService.GetBlogById(id);
            if (blog == null) { return NotFound(); }
            _blogService.DeleteBlog(id);            
            return Ok("Blog deleted");

        }
    }
}
