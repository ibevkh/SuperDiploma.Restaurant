namespace SuperDiploma.Restaurant.DataContext.Entities.Models;

public class AdminDbo
{
    public int Id { get; set; }

    public string Username { get; set; }

    public string PasswordHash { get; set; }

    public string Role { get; set; }
}