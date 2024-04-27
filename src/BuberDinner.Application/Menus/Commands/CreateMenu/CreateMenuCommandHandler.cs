using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.Entities;
using MediatR;

namespace BuberDinner.Application.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandler(IMenuRepository menuRepository) : IRequestHandler<CreateMenuCommand, Menu>
{
    private readonly IMenuRepository _menuRepository = menuRepository ?? throw new ArgumentNullException(nameof(menuRepository));

    public async Task<Menu> Handle(CreateMenuCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
            
        var menu = Menu.Create(command.Name, command.Description, command.HostId);

        foreach (var section in command.Sections)
        {
            var menuSection = MenuSection.Create(section.Name, section.Description);
            foreach (var item in section.Items)
            {
                var menuItem = MenuItem.Create(item.Name, item.Description);
                menuSection.AddItem(menuItem);
            }
            
            menu.AddSection(menuSection);
        }
            
        _menuRepository.Add(menu);
            
        return menu;
    }
}