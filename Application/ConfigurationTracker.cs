using Domain.Configuration;

namespace Application;

public class ConfigurationObservable : IObservable<HandlersConfiguration>
{
    private readonly List<IObserver<HandlersConfiguration>> _observers = [];
    public IDisposable Subscribe(IObserver<HandlersConfiguration> observer)
    {
        _observers.Add(observer);
        return null!;
    }

    public void Notify(HandlersConfiguration configuration)
    {
        foreach (var observer in _observers)
        {
            observer.OnNext(configuration);
        }
    }
}