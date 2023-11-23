using BigBangProject.Core.Interfaces;

namespace BigBangProject.Core.GameLogic;

public class ChoiceSelector : IChoiceSelector
{
    public async Task<GameChoiceEnum> SelectChoiceAsync(int choiceId)
    {
        var result = choiceId.ToGameChoiceEnum();
        return await Task.FromResult(result);
    }
}