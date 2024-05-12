using BuberDinner.Domain.Menu.Events;
using MediatR;

namespace BuberDinner.Application.Menus.Events;

public class DummyCreateMenuEventHandler : INotificationHandler<MenuCreated>
{
    public async Task Handle(MenuCreated notification, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        Console.WriteLine($"Menu created: {notification.Menu.Name}");
    }
}