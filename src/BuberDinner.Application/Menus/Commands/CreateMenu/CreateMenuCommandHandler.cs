using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.Entities;
using MediatR;

namespace BuberDinner.Application.Menus.Commands.CreateMenu
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, Menu>
    {
        public async Task<Menu> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            //Create Menu
            // var menu = Menu.Create(request.Name, request.Description, request.HostId);
            // foreach (var section in request.Sections)
            // {
            //     var menuSection = MenuSection.Create(section.Name, section.Description);
            //     foreach (var item in section.Items)
            //     {
            //         var menuItem = MenuItem.Create(item.Name, item.Description);
            //         menuSection.AddItem(menuItem);
            //     }
            //
            //     menu.AddSection(menuSection);
            // }
            
            //Persist Menu
            //Return Menu
            await Task.CompletedTask;

            return default(Menu)!;
        }
    }
}