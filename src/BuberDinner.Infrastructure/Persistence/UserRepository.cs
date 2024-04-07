using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> Users = new();
    public User? GetByEmail(string email)
    {
        var user = Users.SingleOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        
        return user;
    }

    public void Add(User user)
    {
        Users.Add(user);
    }
}