namespace BigBangProject.Core.Interfaces;

public interface IChoiceSelector
{
    Task<GameChoiceEnum> SelectChoiceAsync(int choiceId);
}