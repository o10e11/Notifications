using Domain.Primitives;

namespace Domain.Notifications;
public class EmailNotification : INotification
{
    public ChannelType ChannelType => ChannelType.EMAIL;
    public Guid Id { get; init; }
    public string Subject { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Body { get; init; } = string.Empty;
}
