using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Menu;
using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Infrastructure.Persistence.Repositories;

public class MenuRepository(BuberDinnerDbContext context) : IMenuRepository
{
    private readonly BuberDinnerDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public void Add(Menu menu)
    {
        _context.Add(menu);
        _context.SaveChanges();
    }

    public Menu? GetById(Guid id)
    {
        return _context.Menus.AsNoTracking().SingleOrDefault(m => m.Id.Value.Equals(id));
    }
}