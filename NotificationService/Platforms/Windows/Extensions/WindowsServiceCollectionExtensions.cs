using NotificationService.Abstractions.Model;
using NotificationService.Platforms.Windows.Model;

namespace NotificationService.Platforms.Windows.Extensions
{
    internal static class WindowsServiceCollectionExtensions
    {
        internal static IServiceCollection RegisterWindowsNotificationService(this IServiceCollection services, WindowsConfiguration configuration)
        {
            INotificationService notificationService = new WindowsNotificationService();
            notificationService.Initialize(configuration);

            services.AddSingleton<INotificationService>(notificationService);

            return services;
        }
    }
}
