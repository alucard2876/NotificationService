using NotificationService.Abstractions.Model.Enums;
using Plugin.LocalNotification;

namespace NotificationService.Abstractions.Model.Events;

public sealed class AndroidNotificationEventArgs : NotificationReactEventArgs
{
    public override NotificationServiceType ServiceType => NotificationServiceType.Android;

    public bool IsTapped { get; set; }

    public bool IsDismissed { get; set; }

    public NotificationRequest Request { get; set; }

    public int ActionId { get; set; }

    public NotificationType Type { get; set; }
}
