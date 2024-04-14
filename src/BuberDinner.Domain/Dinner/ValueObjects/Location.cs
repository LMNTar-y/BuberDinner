using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects;

public class Location : ValueObject
{
    private Location(string name, string address, decimal latitude, decimal longitude)
    {
        Name = name;
        Address = address;
        Latitude = latitude;
        Longitude = longitude;
    }

    public string Name { get;}
    public string Address { get; }
    public decimal Latitude { get; }
    public decimal Longitude { get; }

    public static Location CreateNew(string name, string address, decimal latitude, decimal longitude)
    {
        return new Location(name, address, latitude, longitude);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Address;
        yield return Latitude;
        yield return Longitude;
    }
}