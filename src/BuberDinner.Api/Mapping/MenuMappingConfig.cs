using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Contracts.Menus;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Menu;
using Mapster;
using MenuItem = BuberDinner.Domain.Menu.Entities.MenuItem;
using MenuSection = BuberDinner.Domain.Menu.Entities.MenuSection;

namespace BuberDinner.Api.Mapping
{
    public class MenuMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
                .Map(dest => dest.HostId, source => source.HostId)
                .Map(dest => dest, source => source.Request);

            config.NewConfig<Menu, MenuResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.HostId, src => src.HostId.Value)
                .Map(dest => dest.AverageRating, src => AverageRatingMap(src.AverageRating))
                .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(dinnerId => dinnerId.Value))
                .Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select(menuReviewId => menuReviewId.Value));

            config.NewConfig<MenuSection, MenuSectionResponse>()
                .Map(dest => dest.Id, src => src.Id.Value);

            config.NewConfig<MenuItem, MenuItemResponse>()
                .Map(dest => dest.Id, src => src.Id.Value);
        }

        private float? AverageRatingMap(AverageRating? averageRating)
        {
            if (averageRating is { } rating)
            {
                return rating.Value;
            }

            return null;
        }
    }
}