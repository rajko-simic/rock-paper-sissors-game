using BigBangProject.Core.Interfaces;
using BigBangProject.Core.Models;

namespace BigBangProject.Core.Services;

public class GameService : IGameService
{
    private readonly IWinConditionChecker _gameLogic;
    private readonly IChoiceSelector _choiceSelector;
    private readonly IRandomChoiceSelector _randomChoiceSelector;

    public GameService(IChoiceSelector randomChoiceSelector, IRandomChoiceSelector randomChoiceSelector1, IWinConditionChecker gameLogic)
    {
        _choiceSelector = randomChoiceSelector;
        _randomChoiceSelector = randomChoiceSelector1;
        _gameLogic = gameLogic;
    }

    public IEnumerable<GameChoice> GetChoices()
    {
        return EnumHelper.EnumToGameChoiceList<GameChoiceEnum>();
    }

    public async Task<GameChoice> GetRandomChoice()
    {
        var gameChoiceEnum = await _randomChoiceSelector.SelectChoiceAsync();
        return gameChoiceEnum.ToGameChoice();
    }

    public async Task<PlayResult> PlayRound(int playerChoice)
    {
        var playerChoiceEnum = await _choiceSelector.SelectChoiceAsync(playerChoice);
        var computerChoiceEnum = await _randomChoiceSelector.SelectChoiceAsync();

        var gameResult = _gameLogic.DetermineWinner(playerChoiceEnum, computerChoiceEnum);

        return new PlayResult
        {
            Result = gameResult,
            PlayerChoice = (int)playerChoiceEnum,
            ComputerChoice = (int)computerChoiceEnum
        };
    }
}
