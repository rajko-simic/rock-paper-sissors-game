using BigBangProject.Core.Models;

namespace BigBangProject.DTOs;

public class GameChoiceDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
}

public static class GameChoiceMapper
{
    public static GameChoice ToDtoToGameChoice(this GameChoiceDto dto)
    {
        return new GameChoice
        {
            Id = dto.Id,
            Name = dto.Name
        };
    }
    
    public static GameChoiceDto ToGameChoiceToDto(this GameChoice gameChoice)
    {
        return new GameChoiceDto
        {
            Id = gameChoice.Id,
            Name = gameChoice.Name
        };
    }
    
    public static List<GameChoiceDto> ToDtoList(this IEnumerable<GameChoice> gameChoices) => 
        gameChoices.Select(ToGameChoiceToDto).ToList();
}
