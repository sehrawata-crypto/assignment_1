using System.ComponentModel.DataAnnotations;

namespace assignment_1.Models
{
    public class BlogType
    {
        [Key]
        public int BlogTypeId { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Blog> Blogs { get; set; }
    }
}