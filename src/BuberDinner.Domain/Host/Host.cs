using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.Host;

public class Host : AggregateRoot<HostId, Guid>
{
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuId> _menuIds = new();
    private AverageRating? _averageRating;

    private Host(
        HostId hostId,
        UserId userId,
        string firstName,
        string lastName,
        string profileImage,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(hostId)
    {
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }
    private Host()
    {
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string ProfileImage { get; private set; }
    public UserId UserId { get; private set; }
    public double AverageRating { get; private set; }

    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();

    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    public void UpdateProfile(string firstName, string lastName, string profileImage)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        UpdatedDateTime = DateTime.UtcNow;
    }

    public void AddDinner(DinnerId dinnerId)
    {
        _dinnerIds.Add(dinnerId);
        UpdatedDateTime = DateTime.UtcNow;
    }

    public void AddMenu(MenuId menuId)
    {
        _menuIds.Add(menuId);
        UpdatedDateTime = DateTime.UtcNow;
    }

    public void UpdateAverageRating(Rating averageRating)
    {
        if (_averageRating is null)
        {
            _averageRating = Common.ValueObjects.AverageRating.CreateNew(averageRating.Value, 1);
        }
        else
        {
            _averageRating.AddNewRating(averageRating);
        }

        AverageRating = _averageRating.Value;
        UpdatedDateTime = DateTime.UtcNow;
    }

    public void RemoveRating(Rating rating)
    {
        if (_averageRating is not null)
        {
            _averageRating.RemoveRating(rating);
            AverageRating = _averageRating.Value;
            UpdatedDateTime = DateTime.UtcNow;
        }
    }

    public static Host Create(
        UserId userId,
        string firstName,
        string lastName,
        string profileImage)
    {
        return new Host(
                       HostId.CreateUnique(),
                                  userId,
                                  firstName,
                                  lastName,
                                  profileImage,
                                  DateTime.UtcNow,
                                  DateTime.UtcNow);
    }
}