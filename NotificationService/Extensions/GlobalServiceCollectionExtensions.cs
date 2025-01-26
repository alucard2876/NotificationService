using NotificationService.Abstractions.Model;
#if ANDROID
using NotificationService.Platforms.Android.Extensions;
using NotificationService.Platforms.Android.Model;
#endif
#if WINDOWS
using NotificationService.Platforms.Windows.Extensions;
using NotificationService.Platforms.Windows.Model;
#endif

namespace NotificationService.Extensions
{
    public static class GlobalServiceCollectionExtensions
    {
        public static IServiceCollection RegisterNotificationService(this IServiceCollection services, INotificationConfiguration configuration) 
        {
#if ANDROID
            return services.RegisterAndroidNotifiactionService(configuration as AndroidConfiguration);
#endif
#if WINDOWS
           return services.RegisterWindowsNotificationService(configuration as WindowsConfiguration);
#endif

            return services;
        }
    }
}
