using Domain.Notifications;
using Domain.Primitives;

namespace Domain.NotificationHandler;

public interface INotificationHandler : IChainable<INotificationHandler>
{
    public string HandlerName { get; }
    public ChannelType ChannelType { get; }
    public bool IsActive { get; set; }
    public ValueTask<bool> TryHandle(INotification notification);
}
