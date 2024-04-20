using BuberDinner.Domain.Menu;
using MediatR;

namespace BuberDinner.Application.Menus.Commands.CreateMenu;

public record CreateMenuCommand(
    string Name,
    string Description,
    List<MenuSectionCommand> Sections,
    string HostId) : IRequest<Menu>;

public record MenuSectionCommand(
    string Name,
    string Description,
    List<MenuItemCommand> Items);

public record MenuItemCommand(
    string Name,
    string Description);