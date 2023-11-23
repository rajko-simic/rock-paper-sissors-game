namespace BigBangProject.Externals.Interfaces;

public interface IRandomNumberClient
{
    Task<int> GetRandomValue();
}