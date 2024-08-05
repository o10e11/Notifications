using Domain.Notifications;
using Domain.Primitives;

namespace Domain.NotificationHandler;

public abstract class EmailNotificationHandler : ChainableNotificationHandler<EmailNotification>
{
    public override ChannelType ChannelType => ChannelType.EMAIL;
}
