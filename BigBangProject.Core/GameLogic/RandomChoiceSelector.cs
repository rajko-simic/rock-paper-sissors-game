using BigBangProject.Core.Interfaces;
using BigBangProject.Externals.Interfaces;

namespace BigBangProject.Core.GameLogic;

public class RandomChoiceSelector : IRandomChoiceSelector
{
    private readonly IRandomNumberClient _randomNumberClient;

    public RandomChoiceSelector(IRandomNumberClient randomNumberClient)
    {
        _randomNumberClient = randomNumberClient;
    }

    public async Task<GameChoiceEnum> SelectChoiceAsync()
    {
        var randomResult = await _randomNumberClient.GetRandomValue();
        var choice = randomResult % 5;
        return choice.ToGameChoiceEnum();
    }
}
