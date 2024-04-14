using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects;

public class Price : ValueObject
{
    private Price(string currency, double amount)
    {
        Currency = currency;
        Amount = amount;
    }

    public double Amount { get; }
    public string Currency { get; }

    public static Price CreateNew(string currency, double amount)
    {
        return new Price(currency, amount);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}