using BigBangProject.Core.Models;

namespace BigBangProject.DTOs;

public class PlayResultDto
{
    public string Result { get; set; }
    public int PlayerChoice { get; set; }
    public int ComputerChoice { get; set; }
}

public static class PlayResultMapper
{
    public static PlayResult ToDtoToPlayResult(this PlayResultDto dto)
    {
        return new PlayResult
        {
            Result = dto.Result,
            PlayerChoice = dto.PlayerChoice,
            ComputerChoice = dto.ComputerChoice
        };
    }

    public static PlayResultDto ToPlayResultToDto(this PlayResult playResult)
    {
        return new PlayResultDto
        {
            Result = playResult.Result,
            PlayerChoice = playResult.PlayerChoice,
            ComputerChoice = playResult.ComputerChoice
        };
    }
}