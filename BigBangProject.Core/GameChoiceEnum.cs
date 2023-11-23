using BigBangProject.Core.Models;

namespace BigBangProject.Core;

public enum GameChoiceEnum
{
    Rock,
    Paper,
    Scissors,
    Lizard,
    Spock
}

public static class EnumExtensions
{
    public static GameChoiceEnum ToGameChoiceEnum(this int intValue)
    {
        // You can add validation to check if the int value is valid for the enum
        if (!Enum.IsDefined(typeof(GameChoiceEnum), intValue))
        {
            throw new ArgumentOutOfRangeException(nameof(intValue), "Value is not a valid member of the TestEnum enum");
        }

        return (GameChoiceEnum)intValue;
    }

    public static GameChoice ToGameChoice(this GameChoiceEnum enumValue)
    {
        return new GameChoice
        {
            Id = (int)enumValue,
            Name = enumValue.ToString()
        };
    }
}

public static class EnumHelper
{
    public static List<GameChoice> EnumToGameChoiceList<T>() where T : Enum
    {
        var list = new List<GameChoice>();

        foreach (var value in Enum.GetValues(typeof(T)))
        {
            list.Add(new GameChoice
            {
                Id = (int)value,
                Name = value.ToString()
            });
        }

        return list;
    }
}