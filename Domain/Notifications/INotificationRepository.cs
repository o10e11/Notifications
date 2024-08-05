namespace Domain.Notifications;

public interface INotificationRepository
{
    public void Save(INotification notification);

}
