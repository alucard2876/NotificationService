using Microsoft.Toolkit.Uwp.Notifications;
using NotificationService.Abstractions.Model;

namespace NotificationService.Platforms.Windows.Model;

internal sealed class WindowsNotificationService : INotificationService
{
    private readonly object defaultResponse = new();
    private WindowsConfiguration windowsConfiguration;
    
    public Task Initialize(INotificationConfiguration configuration)
    {
        if (configuration is not WindowsConfiguration windowsConfiguration)
            return Task.FromException(new InvalidOperationException("Configuration is not for windows"));

        this.windowsConfiguration = windowsConfiguration;

        return Task.CompletedTask;
    }

    public Task<object> PushNotification(string title, string message)
    {
        return Task.Run(() =>
        {
            GetBuilder()?.AddText(title)?
                    .AddText(message)?
                    .Show();

            return defaultResponse;
        });
    }

    public Task<object> PushNotification(INotification notification)
    {
        return PushNotification(notification.Title, notification.Message);
    }

    private ToastContentBuilder GetBuilder()
    {
        return new ToastContentBuilder()
            .SetToastDuration(windowsConfiguration.ToastDuration)
            .SetToastScenario(windowsConfiguration.ToastScenario)
            .AddArgument("action", "viewConversation")
            .AddArgument("conversationId", 9813);
            
    }
}
