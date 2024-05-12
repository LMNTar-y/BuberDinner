using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValuesObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Guest.Entities;

public class GuestRating : Entity<GuestRatingId>
{
    private GuestRating(GuestRatingId guestRatingId,
        HostId hostId,
        DinnerId dinnerId,
        int rating,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(guestRatingId)
    {
        HostId = hostId;
        DinnerId = dinnerId;
        Rating = rating;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }
    private GuestRating()
    {
    }

    public HostId HostId { get; private set; }
    public DinnerId DinnerId { get; private set; }
    public int Rating { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    public static GuestRating CreateNew(HostId hostId,
        DinnerId dinnerId,
        int rating)
    {
        return new GuestRating(
                       GuestRatingId.CreateNew(),
                                  hostId,
                                  dinnerId,
                                  rating,
                                  DateTime.UtcNow,
                                  DateTime.UtcNow);
    }

    public void UpdateRating(int rating)
    {
        Rating = rating;
        UpdatedDateTime = DateTime.UtcNow;
    }
}