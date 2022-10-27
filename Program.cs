using var db = new UserContext();

db.AddRange(new User[] {
    new User() {
        Name = "John",
        Posts = new List<Post>() {
            new Post() {
                Title = "Hello World",
                Description = "This is my first post"
            }
        }
    },
});

db.SaveChanges();

var users =
    from user in db.Users
    orderby user.Id
    select user;

foreach (var user in users)
    Console.WriteLine($"Name: {user.Name}, ID: {user.Id}");
