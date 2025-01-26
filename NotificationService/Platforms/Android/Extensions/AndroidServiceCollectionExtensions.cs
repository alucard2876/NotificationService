using NotificationService.Abstractions.Model;
using NotificationService.Platforms.Android.Model;
using Plugin.LocalNotification;
using INotificationService = NotificationService.Abstractions.Model.INotificationService;

namespace NotificationService.Platforms.Android.Extensions
{
    internal static class AndroidServiceCollectionExtensions
    {
        internal static IServiceCollection RegisterAndroidNotificationService(this MauiAppBuilder builder, AndroidConfiguration configuration)
        {
            builder.UseLocalNotification();
            var service = new AndroidNotificationService();
            service.Initialize(configuration);

            builder.Services.AddSingleton<INotificationService>(service);

            return builder.Services;
        }
    }
}
