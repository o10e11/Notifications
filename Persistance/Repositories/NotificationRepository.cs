using Domain.Notifications;

namespace Persistance.Repositories;

public class NotificationRepository : INotificationRepository
{
    private readonly List<INotification> _notifications = new List<INotification>();
    public void Save(INotification notification)
    {
        _notifications.Add(notification);
    }
}
