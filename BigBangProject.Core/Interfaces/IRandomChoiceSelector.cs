namespace BigBangProject.Core.Interfaces;

public interface IRandomChoiceSelector
{
    Task<GameChoiceEnum> SelectChoiceAsync();
}