using BigBangProject.Core.Interfaces;
using BigBangProject.Core.Models;
using BigBangProject.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BigBangProject.Controllers;

[ApiController]
[Route("[controller]")]
public class GameController : ControllerBase
{
    private readonly IGameService _gameService;

    public GameController(IGameService gameService)
    {
        _gameService = gameService;
    }

    [HttpGet("choices")]
    public ActionResult<List<GameChoiceDto>> GetChoices()
    {
        return _gameService.GetChoices().ToDtoList();
    }

    [HttpGet("choice")]
    public async Task<ActionResult<GameChoiceDto>> GetRandomChoice()
    {
        return (await _gameService.GetRandomChoice())
            .ToGameChoiceToDto();
    }

    [HttpPost("play")]
    public async Task<ActionResult<PlayResultDto>> Play([FromBody] PlayRequestDto request)
    {
        return (await _gameService.PlayRound(request.Player))
            .ToPlayResultToDto();
    }
}
