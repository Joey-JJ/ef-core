using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

public class UserContext : DbContext
{
    public DbSet<User>? Users { get; set; }
    public DbSet<Post>? Posts { get; set; }
    public string DbPath { get; }


    public UserContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "users.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlite($"Data Source={DbPath}");
}

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public List<Post>? Posts { get; set; }
}

public class Post
{
    [Key]
    public int What { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
}
