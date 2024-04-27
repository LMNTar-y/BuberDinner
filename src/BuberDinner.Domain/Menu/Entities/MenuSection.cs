using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Menu.Entities;

public class MenuSection : Entity<MenuSectionId>
{
    private MenuSection(MenuSectionId menuSectionId, string name, string description) : base(menuSectionId)
    {
        Name = name;
        Description = description;
    }

    private List<MenuItem> _items = new();
    public string Name { get; set; }
    public string Description { get; set; }

    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

    public static MenuSection Create(string name, string description)
    {
        return new MenuSection(MenuSectionId.CreateUnique(), name, description);
    }

    public void AddItem(MenuItem item)
    {
        _items.Add(item);
    }

    public void RemoveItem(MenuItem item)
    {
        _items.Remove(item);
    }

    public void Update(MenuSection section)
    {
        Name = section.Name;
        Description = section.Description;
        _items = section._items;
    }

    private MenuSection()
    {
    }
}