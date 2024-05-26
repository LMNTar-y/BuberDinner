using BuberDinner.Domain.Host.ValueObjects;

namespace BuberDinner.Application.UnitTests.TestsUtils.Common
{
    public static class Constants
    {
        public static class Menu
        {
            public const string Name = "Test Menu";
            public const string Description = "Test Menu Description";
            public const string SectionName = "Test Menu Section Name";
            public const string SectionDescription = "Test Menu Section Description";
            public const string ItemName = "Test Menu Item Name";
            public const string ItemDescription = "Test Menu Item Description";

            public static string SectionNameFromIndex(int index) 
                => $"{SectionName} {index}";
            public static string SectionDescriptionFromIndex(int index)
                => $"{SectionDescription} {index}";
            public static string ItemNameFromIndex(int index)
                => $"{ItemName} {index}";
            public static string ItemDescriptionFromIndex(int index)
                => $"{ItemDescription} {index}";
        }

        public static class Host
        {
            public static readonly HostId Id = HostId.Create(Guid.NewGuid());
        }
    }
}