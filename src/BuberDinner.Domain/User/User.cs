using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.User;

public class User : AggregateRoot<UserId, Guid>
{
    private User(
        UserId userId,
        string firstName,
        string lastName,
        string email,
        string password,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(userId)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    private User() : base()
    {
    }

    public string FirstName { get; private set; } 
    public string LastName { get; private set; }
    public string Email { get; private set; } 
    public string Password { get; private set; }

    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    public void UpdateProfile(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        UpdatedDateTime = DateTime.UtcNow;
    }

    public void UpdatePassword(string password)
    {
        Password = password;
        UpdatedDateTime = DateTime.UtcNow;
    }

    public static User Create(string firstName, string lastName, string email, string password)
    {
        return new User(UserId.Create(), firstName, lastName, email, password, DateTime.UtcNow, DateTime.UtcNow);
    }
}