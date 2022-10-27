using var db = new UserContext();


var users =
    from user in db.Users
    orderby user.Id
    select user;

// db.AddRange(new User[] {
//     new User() { Name = "John"},
//     new User() { Name = "Franco"},
//     new User() { Name = "Boris"},
//     new User() { Name = "Henk"},
// });

// db.SaveChanges();

foreach (var user in users)
    Console.WriteLine($"Name: {user.Name}, ID: {user.Id}");
