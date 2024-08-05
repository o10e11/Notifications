using Application;
using Domain.Notifications;
using Domain.Primitives;

namespace Domain.NotificationHandler;
public abstract class ChainableNotificationHandler<Notification> : 
    IChainable<INotificationHandler>,
    INotificationHandler where Notification : class, INotification
    
{
    private INotificationHandler? _nextHandler;
    public abstract ChannelType ChannelType { get; }
    public abstract string HandlerName { get; }
    public bool IsActive { get; set; }

    public INotificationHandler? SetNext(INotificationHandler? nextHandler)
    {
        _nextHandler = nextHandler;
        return _nextHandler;
    }
    public async ValueTask<bool> TryHandle(INotification notificaiton)
    {
        if (!IsActive)
        {
            return await new ValueTask<bool>(false);
        }

        if (!notificaiton.ChannelType.Equals(ChannelType))
        {
            return await SentToNext(notificaiton);
        }

        try
        {
            await Handle((notificaiton as Notification)!);
        }
        catch (NotificationHandlerException ex)
        {
            Console.WriteLine(ex.Message);
            return await SentToNext(notificaiton);
        }

        return await new ValueTask<bool>(true);
    }

    protected abstract Task Handle(Notification notification);

    private ValueTask<bool> SentToNext(INotification notificaiton)
        => _nextHandler != null
            ? _nextHandler.TryHandle(notificaiton)
            : new ValueTask<bool>(false);
}
