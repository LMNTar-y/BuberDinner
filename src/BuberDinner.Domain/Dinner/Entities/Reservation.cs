using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Dinner.Enums;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValuesObjects;
using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Dinner.Entities;

public class Reservation : Entity<ReservationId>
{
    private Reservation(ReservationId reservationId, 
        int guestCount,
        GuestId guestId, 
        BillId billId, 
        DateTime createdDateTime, 
        DateTime updatedDateTime) : base(reservationId)
    {
        GuestCount = guestCount;
        Status = ReservationStatus.PendingGuestConfirmation;
        GuestId = guestId;
        BillId = billId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public int GuestCount { get; private set; }
    public ReservationStatus Status { get; private set; } // PendingGuestConfirmation, Reserved, Cancelled
    public GuestId GuestId { get; private set; }
    public BillId BillId { get; private set; }
    public DateTime ArrivalDateTime { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    public static Reservation CreateNew(int guestCount,
        GuestId guestId, 
        BillId billId)
    {
        return new Reservation(
            ReservationId.CreateNew(), 
            guestCount,
            guestId, 
            billId,
            DateTime.UtcNow, 
            DateTime.UtcNow);
    }

    public void ConfirmReservation(DateTime arrivalDateTime)
    {
        ArrivalDateTime = arrivalDateTime;
        Status = ReservationStatus.Reserved;
    }

    public void CancelReservation()
    {
        Status = ReservationStatus.Cancelled;
    }

    public void UpdateGuestCount(int guestCount)
    {
        GuestCount = guestCount;
    }

    private Reservation()
    {
    }
}