using NotificationService.Abstractions.Model;

namespace NotificationService.Platforms.Android.Model;

public sealed class AndroidConfiguration : INotificationConfiguration
{
    public int BadgeNumber { get; set; }
}
