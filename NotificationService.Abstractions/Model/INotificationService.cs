using System.Threading.Tasks;

namespace NotificationService.Abstractions.Model;

public interface INotificationService
{

    Task Initialize(INotificationConfiguration configuration);

    Task<object> PushNotification(string title, string message);

    Task<object> PushNotification(INotification notification);
}
