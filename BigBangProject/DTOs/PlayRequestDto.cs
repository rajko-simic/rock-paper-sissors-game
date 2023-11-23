using BigBangProject.Core.Models;

namespace BigBangProject.DTOs;

public class PlayRequestDto
{
    public int Player { get; set; }
}

public static class PlayRequestMapper
{
    public static PlayRequest ToDtoToPlayRequest(this PlayRequestDto dto)
    {
        return new PlayRequest
        {
            Player = dto.Player
        };
    }

    public static PlayRequestDto ToPlayRequestToDto(this PlayRequest playRequest)
    {
        return new PlayRequestDto
        {
            Player = playRequest.Player
        };
    }
}