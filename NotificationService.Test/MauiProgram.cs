using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Uwp.Notifications;
using NotificationService.Extensions;
#if WINDOWS
using NotificationService.Platforms.Windows.Model;
using NotificationService.Test.Helpers;
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
        builder.Services.RegisterNotificationService(new WindowsConfiguration
        {
            ToastDuration = Microsoft.Toolkit.Uwp.Notifications.ToastDuration.Long,
            ToastScenario = Microsoft.Toolkit.Uwp.Notifications.ToastScenario.Reminder
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