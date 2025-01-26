using Microsoft.Toolkit.Uwp.Notifications;
using NotificationService.Abstractions.Model.Enums;

namespace NotificationService.Abstractions.Model.Events;

public sealed class WindowsNotificationEventArgs : NotificationReactEventArgs
{
    public override NotificationServiceType ServiceType => NotificationServiceType.Windows;

    public ToastArguments? Args { get; init; }
}
