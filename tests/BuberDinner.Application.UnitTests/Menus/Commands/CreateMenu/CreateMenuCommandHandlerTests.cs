using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Application.UnitTests.Menus.Commands.TestUtils;
using BuberDinner.Application.UnitTests.TestsUtils.Common.Menus.Extensions;
using BuberDinner.Domain.Menu;
using FluentAssertions;
using Moq;

namespace BuberDinner.Application.UnitTests.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandlerTests
{
    private readonly CreateMenuCommandHandler _sut;
    private readonly Mock<IMenuRepository> _mockMenuRepository;

    public CreateMenuCommandHandlerTests()
    {
        _mockMenuRepository = new Mock<IMenuRepository>();
        _sut = new CreateMenuCommandHandler(_mockMenuRepository.Object);
    }

    public sealed class When_Instantiating : CreateMenuCommandHandlerTests
    {
        [Fact]
        public void MenuRepositoryIsNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            IMenuRepository menuRepository = null!;

            // Act
            Action action = () => new CreateMenuCommandHandler(menuRepository);

            // Assert
            action.Should().Throw<ArgumentNullException>().WithMessage("Value cannot be null. (Parameter 'menuRepository')");
        }
    }

    public sealed class When_calling_Handle : CreateMenuCommandHandlerTests
    {
        [Theory]
        [MemberData(nameof(ValidCreateMenuCommands))]
        public async Task CreateMenuCommandIsValid_ShouldCreateAndReturnMenu(CreateMenuCommand createMenuCommand)
        {
            //Act
            var result = await _sut.Handle(createMenuCommand, CancellationToken.None);

            //Assert
            result.Should().BeOfType<Menu>();
            result.ValidateCreatedFrom(createMenuCommand);
            _mockMenuRepository.Verify(x => x.Add(result), Times.Once);
        }

        public static IEnumerable<object[]> ValidCreateMenuCommands()
        {
            yield return [CreateMenuCommandUtils.CreateCommand()];
            yield return
            [
                CreateMenuCommandUtils.CreateCommand(
                    CreateMenuCommandUtils.CreateSectionsCommand(3))
            ];
            yield return
            [
                CreateMenuCommandUtils.CreateCommand(
                    CreateMenuCommandUtils.CreateSectionsCommand(3,
                        CreateMenuCommandUtils.CreateItemsCommand(3)))
            ];
        }

        [Fact]
        public async Task CreateMenuCommandIsNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            CreateMenuCommand createMenuCommand = null!;

            // Act
            Func<Task> action = async () => await _sut.Handle(createMenuCommand, CancellationToken.None);

            // Assert
            await action.Should().ThrowAsync<NullReferenceException>();
        }

        [Fact]
        public async Task RepositoryThrowsException_ShouldThrowSameException()
        {
            // Arrange
            var createMenuCommand = CreateMenuCommandUtils.CreateCommand();
            _mockMenuRepository.Setup(x => x.Add(It.IsAny<Menu>())).Throws<Exception>();

            // Act
            Func<Task> action = async () => await _sut.Handle(createMenuCommand, CancellationToken.None);

            // Assert
            await action.Should().ThrowAsync<Exception>();
        }
    }
}