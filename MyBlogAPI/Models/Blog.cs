using System.ComponentModel.DataAnnotations;

namespace MyBlogAPI.Models
{
    public class Blog
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [MaxLength(500)]
        public string Content { get; set; }
        [Display(Name = " Created At")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
