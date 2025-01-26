using NotificationService.Platforms.Android.Model;

namespace NotificationService.Platforms.Android.Extensions
{
    internal static class AndroidServiceCollectionExtensions
    {
        internal static IServiceCollection RegisterAndroidNotifiactionService(this IServiceCollection services, AndroidConfiguration configuration)
        {
            return services;
        }
    }
}
