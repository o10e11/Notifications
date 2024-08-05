using Domain.Primitives;

namespace Domain.Notifications
{
    public interface INotification
    {
        public ChannelType ChannelType { get; }
        public Guid Id { get; init; }
        public string Body { get; init; }
    }
}
