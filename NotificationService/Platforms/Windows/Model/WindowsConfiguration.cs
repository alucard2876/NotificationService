using Microsoft.Toolkit.Uwp.Notifications;
using NotificationService.Abstractions.Model;

namespace NotificationService.Platforms.Windows.Model
{
    public sealed class WindowsConfiguration : INotificationConfiguration
    {
        public ToastDuration ToastDuration { get; set; }

        public ToastScenario ToastScenario { get; set; }
    }
}
