using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Menu;
using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Infrastructure.Persistence.Repositories;

public class MenuRepository(BuberDinnerDbContext context) : IMenuRepository
{
    private readonly BuberDinnerDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public async Task Add(Menu menu)
    {
        _context.Add(menu);
        await _context.SaveChangesAsync();
    }

    public async Task<Menu?> GetById(Guid id)
    {
        return await _context.Menus.AsNoTracking().SingleOrDefaultAsync(m => m.Id.Value.Equals(id));
    }
}