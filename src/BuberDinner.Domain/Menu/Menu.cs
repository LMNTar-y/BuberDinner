using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;
using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Menu;

public sealed class Menu : AggregateRoot<MenuId, Guid>
{
    private readonly List<MenuSection> _sections = new();
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();
    
    public string Name { get; private set; }
    public string Description { get; private set; }
    public AverageRating? AverageRating { get; private set; }
    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
    public HostId HostId { get; private set; }

    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Menu(MenuId menuId, string name, string description, HostId hostId, DateTime createdDateTime, DateTime updatedDateTime) : base(menuId)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }
    private Menu()
    { }

    public static Menu Create(
        string name, 
        string description, 
        HostId hostId)
    {
        var MenuIdTest = MenuId.CreateUnique();
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