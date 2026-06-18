using Microsoft.EntityFrameworkCore;
using assignment_1.Data;
using assignment_1.Models;

var builder = new DbContextOptionsBuilder<AppDbContext>();
builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Assignment1DB;Trusted_Connection=True;");

using var context = new AppDbContext(builder.Options);

// Step 3: Add 3 BlogTypes first (required for Blogs)
var blogType = new BlogType { Status = "Active", Name = "Personal", Description = "Personal blog" };
context.BlogTypes.Add(blogType);

// Add 3 PostTypes (required for Posts)
var postType = new PostType { Status = "Active", Name = "Article", Description = "Article post" };
context.PostTypes.Add(postType);

context.SaveChanges();

// Step 3: Add 3 Users
var user1 = new User { Name = "Alice Smith", EmailAddress = "alice@email.com", PhoneNumber = "780-111-2222" };
var user2 = new User { Name = "Bob Jones", EmailAddress = "bob@email.com", PhoneNumber = "780-333-4444" };
var user3 = new User { Name = "Carol White", EmailAddress = "carol@email.com", PhoneNumber = "780-555-6666" };
context.Users.AddRange(user1, user2, user3);
context.SaveChanges();

// Add a Blog first
var blog = new Blog { Url = "https://myblog.com", IsPublic = true, BlogTypeId = blogType.BlogTypeId };
context.Blogs.Add(blog);
context.SaveChanges();

// Step 4: Add a new Post linked to a User
var post = new Post
{
    Title = "My First Post",
    Content = "This is my first post content.",
    BlogId = blog.BlogId,
    PostTypeId = postType.PostTypeId,
    UserId = user1.UserId
};
context.Posts.Add(post);
context.SaveChanges();

Console.WriteLine("✅ Done! 3 users and 1 post added successfully!");
