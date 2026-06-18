using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace assignment_1.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string Title { get; set; }
        [Column("Content")]
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }

        public int PostTypeId { get; set; }
        public PostType PostType { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}