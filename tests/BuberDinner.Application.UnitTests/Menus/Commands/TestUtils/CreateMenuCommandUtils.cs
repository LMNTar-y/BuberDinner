using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Application.UnitTests.TestsUtils.Common;

namespace BuberDinner.Application.UnitTests.Menus.Commands.TestUtils;

public class CreateMenuCommandUtils
{
    public static CreateMenuCommand CreateCommand(
        List<CreateMenuSectionCommand>? sections = null) => 
        new (Constants.Menu.Name,
            Constants.Menu.Description,
            sections ?? CreateSectionsCommand(),
            Constants.Host.Id.Value.ToString());
    

    public static List<CreateMenuSectionCommand> CreateSectionsCommand(int sectionCount = 1,
        List<CreateMenuItemCommand>? itemCommands = null) =>
        Enumerable.Range(0, sectionCount)
            .Select(index => new CreateMenuSectionCommand(
                Constants.Menu.SectionNameFromIndex(index),
                Constants.Menu.SectionDescriptionFromIndex(index),
                itemCommands ?? CreateItemsCommand()))
            .ToList();
    public static List<CreateMenuItemCommand> CreateItemsCommand(int itemCount = 1) =>
        Enumerable
            .Range(0, itemCount)
            .Select(index => new CreateMenuItemCommand(
                Constants.Menu.ItemNameFromIndex(index),
                Constants.Menu.ItemDescriptionFromIndex(index)))
            .ToList();
}