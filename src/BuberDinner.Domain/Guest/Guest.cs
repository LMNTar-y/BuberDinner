using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.Entities;
using BuberDinner.Domain.Guest.ValuesObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;
using BuberDinner.Domain.Models;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.Guest;

public class Guest : AggregateRoot<GuestId>
{
    private List<DinnerId> _upcomingDinnerIds = new();
    private List<DinnerId> _pastDinnerIds = new();
    private List<BillId> _billIds = new();
    private List<MenuReviewId> _menuReviewIds = new();
    private List<GuestRating> _ratings = new();

    private Guest(
        GuestId guestId,
        UserId userId,
        string firstName,
        string lastName,
        string profileImage,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(guestId)
    {
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string ProfileImage { get; private set; }
    public UserId UserId { get; }

    public IReadOnlyList<DinnerId> UpcomingDinnerIds => _upcomingDinnerIds.AsReadOnly();
    public IReadOnlyList<DinnerId> PastDinnerIds => _pastDinnerIds.AsReadOnly();
    public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    public IReadOnlyList<GuestRating> Ratings => _ratings.AsReadOnly();

    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; private set; }

    public void UpdateProfile(string firstName, string lastName, string profileImage)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        UpdatedDateTime = DateTime.UtcNow;
    }

    public void AddUpcomingDinner(DinnerId dinnerId)
    {
        _upcomingDinnerIds.Add(dinnerId);
        UpdatedDateTime = DateTime.UtcNow;
    }

    public void AddPastDinner(DinnerId dinnerId)
    {
        _pastDinnerIds.Add(dinnerId);
        UpdatedDateTime = DateTime.UtcNow;
    }

    public void AddBill(BillId billId)
    {
        _billIds.Add(billId);
        UpdatedDateTime = DateTime.UtcNow;
    }

    public void AddMenuReview(MenuReviewId menuReviewId)
    {
        _menuReviewIds.Add(menuReviewId);
        UpdatedDateTime = DateTime.UtcNow;
    }

    public void AddRating(GuestRating rating)
    {
        _ratings.Add(rating);
        UpdatedDateTime = DateTime.UtcNow;
    }

    public static Guest Create(
        UserId userId,
        string firstName,
        string lastName,
        string profileImage)
    {
        return new Guest(
            GuestId.CreateUnique(), 
            userId, 
            firstName, 
            lastName,
            profileImage,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}