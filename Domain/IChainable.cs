namespace Domain;

public interface IChainable<IHandler>
{
    IHandler SetNext(IHandler next);
}
