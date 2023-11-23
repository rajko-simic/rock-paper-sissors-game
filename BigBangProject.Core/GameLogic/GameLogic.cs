using BigBangProject.Core.Interfaces;

namespace BigBangProject.Core.GameLogic;

public class WinConditionChecker : IWinConditionChecker
{
    public string DetermineWinner(GameChoiceEnum userChoice, GameChoiceEnum computerChoice)
    {
        if (userChoice == computerChoice)
        {
            return "It's a tie!";
        }

        return userChoice switch
        {
            GameChoiceEnum.Rock => computerChoice is GameChoiceEnum.Scissors or GameChoiceEnum.Lizard ? "You win!" : "You lose!",
            GameChoiceEnum.Paper => computerChoice is GameChoiceEnum.Rock or GameChoiceEnum.Spock ? "You win!" : "You lose!",
            GameChoiceEnum.Scissors => computerChoice is GameChoiceEnum.Paper or GameChoiceEnum.Lizard ? "You win!" : "You lose!",
            GameChoiceEnum.Lizard => computerChoice is GameChoiceEnum.Spock or GameChoiceEnum.Paper ? "You win!" : "You lose!",
            GameChoiceEnum.Spock => computerChoice is GameChoiceEnum.Scissors or GameChoiceEnum.Rock ? "You win!" : "You lose!",
            _ => throw new InvalidOperationException("Invalid game logic.")
        };
    }
}