using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;
using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Menu;

public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<MenuSection> _sections = new();
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();
    
    public string Name { get; }
    public string Description { get; }
    public float? AverageRating { get; private set; }
    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
    public HostId HostId { get; }

    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

    public DateTime CreatedDateTime { get;}
    public DateTime UpdatedDateTime { get; private set; }

    private Menu(MenuId menuId, string name, string description, HostId hostId, DateTime createdDateTime, DateTime updatedDateTime) : base(menuId)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Menu Create(
        string name, 
        string description, 
        HostId hostId)
    {
        return new Menu(
            MenuId.CreateUnique(),
            name, 
            description, 
            hostId, 
            DateTime.UtcNow, 
            DateTime.UtcNow);
    }

    public void AddSection(MenuSection section)
    {
        _sections.Add(section);
        UpdatedDateTime = DateTime.UtcNow;
    }

    public void RemoveSection(MenuSection section)
    {
        _sections.Remove(section);
        UpdatedDateTime = DateTime.UtcNow;
    }

    public void UpdateSection(MenuSection section)
    {
        var existingSection = _sections.Find(s => s.Id == section.Id);
        if (existingSection is null)
        {
            throw new InvalidOperationException("Section not found");
        }

        existingSection.Update(section);
        UpdatedDateTime = DateTime.UtcNow;
    }
}