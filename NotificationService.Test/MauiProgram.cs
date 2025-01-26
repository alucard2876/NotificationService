using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Uwp.Notifications;
using NotificationService.Extensions;
using NotificationService.Test.Helpers;

#if ANDROID
using NotificationService.Platforms.Android.Model;
#endif

#if WINDOWS
using NotificationService.Platforms.Windows.Model;
#endif

namespace NotificationService.Test;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => { fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"); });

        builder.Services.AddMauiBlazorWebView();
#if WINDOWS
        builder.RegisterNotificationService(new WindowsConfiguration
        {
            ToastDuration = Microsoft.Toolkit.Uwp.Notifications.ToastDuration.Long,
            ToastScenario = Microsoft.Toolkit.Uwp.Notifications.ToastScenario.Reminder
        });
#endif
#if ANDROID
        builder.RegisterNotificationService(new AndroidConfiguration
        {
            BadgeNumber = 42
        });
#endif
#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif
        var app = builder.Build();

        ServiceProviderHelper.PushServiceProvider(app.Services);

        return app;
    }
}