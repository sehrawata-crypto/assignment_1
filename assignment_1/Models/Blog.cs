using System.ComponentModel.DataAnnotations;

namespace assignment_1.Models
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }
        public string Url { get; set; }
        public bool IsPublic { get; set; }
        public int BlogTypeId { get; set; }

        // Navigation properties
        public BlogType BlogType { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}