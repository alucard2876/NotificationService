namespace NotificationService.Test.Helpers;

public static class ServiceProviderHelper
{
    private static IServiceProvider internalServiceProvider;

    public static void PushServiceProvider(IServiceProvider serviceProvider)
    {
        if (serviceProvider is null || internalServiceProvider is not null)
            return;

        internalServiceProvider = serviceProvider;
    }

    public static TService? GetService<TService>()
        => internalServiceProvider.GetService<TService>();
}
