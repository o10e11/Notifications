using Domain.Configuration;
using Domain.NotificationHandler;

namespace Application.Configuration;

public class HandlersConfigurationBuilder
{
    private readonly IList<INotificationHandler> _notificationHandlers;

    public INotificationHandler? NotificationHandler { get; private set; } = null;
    public HandlersConfigurationBuilder(IList<INotificationHandler> notificationHandlers)
    {
        _notificationHandlers = notificationHandlers;
    }

    public void BuildNotificationChain(HandlersConfiguration configuration)
    {
        var enabledProviders = configuration
            .Where(t => t.IsEnabled)
            .ToList();

        foreach (var activeHandlers in _notificationHandlers)
        {
            activeHandlers.IsActive = false;
        }

        var handlers = (from configurationProviders in enabledProviders
                        join runtimeProviders in _notificationHandlers
                        on configurationProviders.ProviderName equals runtimeProviders.HandlerName
                        orderby configurationProviders.Priority
                        select runtimeProviders).ToList();

        if (!handlers.Any()) throw new HandlersConfigurationException();

        handlers[0].IsActive = true;
        handlers[0].SetNext(null!);

        for (int i = 0; i <= handlers.Count() - 2; i++)
        {
            handlers[i + 1].IsActive = true;
            handlers[i].SetNext(handlers[i + 1]);
        }

        NotificationHandler = handlers[0];
    }
}
