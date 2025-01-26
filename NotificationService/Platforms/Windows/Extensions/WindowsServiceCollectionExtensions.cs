using NotificationService.Abstractions.Model;
using NotificationService.Platforms.Windows.Model;

namespace NotificationService.Platforms.Windows.Extensions
{
    internal static class WindowsServiceCollectionExtensions
    {
        internal static IServiceCollection RegisterWindowsNotificationService(this MauiAppBuilder builder, WindowsConfiguration configuration)
        {
            INotificationService notificationService = new WindowsNotificationService();
            notificationService.Initialize(configuration);

            builder.Services.AddSingleton<INotificationService>(notificationService);

            return builder.Services;
        }
    }
}
