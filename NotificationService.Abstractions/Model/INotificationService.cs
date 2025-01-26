using NotificationService.Abstractions.Model.Events;
using System;
using System.Threading.Tasks;

namespace NotificationService.Abstractions.Model;

public interface INotificationService : IDisposable
{
    event Action<NotificationReactEventArgs> NotificationReacted;

    Task Initialize(INotificationConfiguration configuration);

    Task<bool> PushNotification(string title, string message);

    Task<bool> PushNotification(INotification notification);
}
