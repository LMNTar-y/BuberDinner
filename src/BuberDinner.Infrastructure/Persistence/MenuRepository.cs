using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Menu;

namespace BuberDinner.Infrastructure.Persistence;

public class MenuRepository : IMenuRepository
{
    private static readonly List<Menu> Menus = new();

    public void Add(Menu menu)
    {
        Menus.Add(menu);
    }

    public Menu? GetById(Guid id)
    {
        return Menus.SingleOrDefault(m => m.Id.Value.Equals(id));
    }
}