using Domain.Primitives;

namespace Domain.Notifications
{
    public class SmsNotification : INotification
    {
        public ChannelType ChannelType => ChannelType.SMS;
        public string PhoneNumber { get; init; } = string.Empty;
        public Guid Id { get; init; }
        public string Body { get; init; }
    }
}
