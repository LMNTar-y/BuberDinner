using BuberDinner.Domain.Menu;
using MediatR;

namespace BuberDinner.Application.Menus.Commands.CreateMenu;

public record CreateMenuCommand(
    string Name,
    string Description,
    List<CreateMenuSectionCommand> Sections,
    string HostId) : IRequest<Menu>;

public record CreateMenuSectionCommand(
    string Name,
    string Description,
    List<CreateMenuItemCommand> Items);

public record CreateMenuItemCommand(
    string Name,
    string Description);