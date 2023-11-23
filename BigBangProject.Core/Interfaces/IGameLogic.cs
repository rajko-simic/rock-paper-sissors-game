namespace BigBangProject.Core.Interfaces;

public interface IWinConditionChecker
{
    string DetermineWinner(GameChoiceEnum userChoice, GameChoiceEnum computerChoice);
}