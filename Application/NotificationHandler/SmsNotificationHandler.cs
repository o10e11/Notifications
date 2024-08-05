using Domain.Notifications;
using Domain.Primitives;

namespace Domain.NotificationHandler
{
    public abstract class SmsNotificationHandler : ChainableNotificationHandler<SmsNotification>
    {
        public override ChannelType ChannelType => ChannelType.SMS;
    }
}
