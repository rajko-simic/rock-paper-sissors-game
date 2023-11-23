using BigBangProject.Core.Models;

namespace BigBangProject.Core.Interfaces;

public interface IGameService
{
    IEnumerable<GameChoice> GetChoices();
    Task<GameChoice> GetRandomChoice();
    Task<PlayResult> PlayRound(int playerChoice);
}