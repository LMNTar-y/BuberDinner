using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.Events
{
    public record MenuCreated(Menu Menu) : IDomainEvent;
}