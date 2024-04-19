﻿using BuberDinner.Domain.Dinner.Entities;
using BuberDinner.Domain.Dinner.Enums;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Dinner;

public sealed class Dinner : AggregateRoot<DinnerId>
{

    private readonly List<Reservation> _reservations = new();

    private Dinner(
        DinnerId dinnerId, 
        string name, 
        string description, 
        DateTime startDateTime, 
        DateTime endDateTime,
        bool isPublic, 
        int maxGuests,
        Price price, 
        HostId hostId, 
        MenuId menuId, 
        string imageUrl, 
        Location location, 
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(dinnerId)
    {
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        Status = DinnerStatus.Upcoming;
        IsPublic = isPublic;
        MaxGuests = maxGuests;
        Price = price;
        HostId = hostId;
        MenuId = menuId;
        ImageUrl = imageUrl;
        Location = location;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public string Name { get; }
    public string Description { get; }
    public DateTime StartDateTime { get; }
    public DateTime EndDateTime { get; }
    public DateTime StartedDateTime { get; private set; }
    public DateTime EndedDateTime { get; private set; }
    public DinnerStatus Status { get; private set; } // Upcoming, InProgress, Ended, Cancelled
    public bool IsPublic { get; }
    public int MaxGuests { get; }
    public Price Price { get; }
    public HostId HostId { get; }
    public MenuId MenuId { get; }
    public string ImageUrl { get; }
    public Location Location { get; }
    public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; private set; }

    public static Dinner Create(
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        bool isPublic,
        int maxGuests,
        Price price,
        HostId hostId,
        MenuId menuId,
        string imageUrl,
        Location location)
    {
        return new Dinner(
                       DinnerId.CreateUnique(), 
                                  name, 
                                  description, 
                                  startDateTime, 
                                  endDateTime, 
                                  isPublic, 
                                  maxGuests, 
                                  price, 
                                  hostId, 
                                  menuId, 
                                  imageUrl, 
                                  location, 
                                  DateTime.UtcNow, 
                                  DateTime.UtcNow);
    }

    public void DinnerStarted()
    {
        Status = DinnerStatus.InProgress;
        StartedDateTime = DateTime.UtcNow;
        UpdatedDateTime = DateTime.UtcNow;
    }

    public void DinnerEnded()
    {
        Status = DinnerStatus.Ended;
        EndedDateTime = DateTime.UtcNow;
        UpdatedDateTime = DateTime.UtcNow;
    }
    public void DinnerCancelled()
    {
        Status = DinnerStatus.Cancelled;
        UpdatedDateTime = DateTime.UtcNow;
    }

    public void AddReservation(Reservation reservation)
    {
        _reservations.Add(reservation);
        UpdatedDateTime = DateTime.UtcNow;
    }

    public void RemoveReservation(Reservation reservation)
    {
        _reservations.Remove(reservation);
        UpdatedDateTime = DateTime.UtcNow;
    }
}