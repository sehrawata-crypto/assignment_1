using Microsoft.EntityFrameworkCore;
using assignment_1.Data;
using assignment_1.Models;

var builder = new DbContextOptionsBuilder<AppDbContext>();
builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Assignment1DB;Trusted_Connection=True;");

using var context = new AppDbContext(builder.Options);

// Run all CRUD tests
TestDatabase();

// =====================
// TEST DATABASE METHOD
// =====================
void TestDatabase()
{
    Console.WriteLine("========== TEST DATABASE ==========\n");

    // 1. List all users first
    ListAllUsers();

    // 2. Add a new user
    AddUser("David Brown", "david@email.com", "780-777-8888");
    ListAllUsers();

    // 3. Update a user
    UpdateUser(1, "Alice Updated", "aliceupdated@email.com", "780-111-9999");
    ListAllUsers();

    // 4. Delete a user
    DeleteUser(4);
    ListAllUsers();
}

// =====================
// 1. LIST ALL USERS
// =====================
void ListAllUsers()
{
    Console.WriteLine("--- All Users ---");
    var users = context.Users.ToList();
    foreach (var user in users)
    {
        Console.WriteLine($"ID: {user.UserId} | Name: {user.Name} | Email: {user.EmailAddress} | Phone: {user.PhoneNumber}");
    }
    Console.WriteLine();
}

// =====================
// 2. ADD A NEW USER
// =====================
void AddUser(string name, string email, string phone)
{
    Console.WriteLine($"Adding user: {name}");
    var newUser = new User
    {
        Name = name,
        EmailAddress = email,
        PhoneNumber = phone
    };
    context.Users.Add(newUser);
    context.SaveChanges();
    Console.WriteLine("User added!\n");
}

// =====================
// 3. UPDATE A USER
// =====================
void UpdateUser(int userId, string newName, string newEmail, string newPhone)
{
    Console.WriteLine($"Updating user ID: {userId}");
    var user = context.Users.Find(userId);
    if (user != null)
    {
        user.Name = newName;
        user.EmailAddress = newEmail;
        user.PhoneNumber = newPhone;
        context.SaveChanges();
        Console.WriteLine("User updated!\n");
    }
    else
    {
        Console.WriteLine("User not found!\n");
    }
}

// =====================
// 4. DELETE A USER
// =====================
void DeleteUser(int userId)
{
    Console.WriteLine($"Deleting user ID: {userId}");
    var user = context.Users.Find(userId);
    if (user != null)
    {
        context.Users.Remove(user);
        context.SaveChanges();
        Console.WriteLine("User deleted!\n");
    }
    else
    {
        Console.WriteLine("User not found!\n");
    }
}