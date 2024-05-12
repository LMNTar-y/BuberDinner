﻿using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValuesObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;

namespace BuberDinner.Domain.MenuReview;

public class MenuReview : AggregateRoot<MenuReviewId, Guid>
{
    private MenuReview(
        MenuReviewId menuReviewId,
        int rating,
        string comment,
        HostId hostId,
        MenuId menuId,
        GuestId guestId,
        DinnerId dinnerId,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(menuReviewId)
    {
        Rating = rating;
        Comment = comment;
        HostId = hostId;
        MenuId = menuId;
        GuestId = guestId;
        DinnerId = dinnerId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    private MenuReview() : base()
    {
    }

    public int Rating { get; private set; }
    public string Comment { get; private set; }
    public HostId HostId { get; private set; }
    public MenuId MenuId { get; private set; }
    public GuestId GuestId { get; private set; }
    public DinnerId DinnerId { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    public void Update(int rating, string comment)
    {
        Rating = rating;
        Comment = string.IsNullOrWhiteSpace(comment) ? Comment : comment;
        UpdatedDateTime = DateTime.UtcNow;
    }

    public static MenuReview CreateNew(
        int rating,
        string comment,
        HostId hostId,
        MenuId menuId,
        GuestId guestId,
        DinnerId dinnerId)
    {
        return new MenuReview(
                       MenuReviewId.CreateUnique(),
                                  rating,
                                  comment,
                                  hostId,
                                  menuId,
                                  guestId,
                                  dinnerId,
                                  DateTime.UtcNow,
                                  DateTime.UtcNow);
    }
}