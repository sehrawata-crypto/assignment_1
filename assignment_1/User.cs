using System.ComponentModel.DataAnnotations;

namespace assignment_1.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}