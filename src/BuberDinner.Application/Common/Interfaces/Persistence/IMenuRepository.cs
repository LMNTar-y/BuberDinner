using BuberDinner.Domain.Menu;

namespace BuberDinner.Application.Common.Interfaces.Persistence;

public interface IMenuRepository
{
    Task Add(Menu menu);
    Task<Menu?> GetById(Guid id);
}