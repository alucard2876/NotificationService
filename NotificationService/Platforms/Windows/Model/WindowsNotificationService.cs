using Microsoft.Toolkit.Uwp.Notifications;
using NotificationService.Abstractions.Model;
using NotificationService.Abstractions.Model.Events;

namespace NotificationService.Platforms.Windows.Model;

internal sealed class WindowsNotificationService : INotificationService
{
    private readonly bool defaultResponse = true;
    private WindowsConfiguration? windowsConfiguration;

    public event Action<NotificationReactEventArgs>? NotificationReacted;

    public Task Initialize(INotificationConfiguration configuration)
    {
        if (configuration is not WindowsConfiguration windowsConfiguration)
            return Task.FromException(new InvalidOperationException("Configuration is not for windows"));

        this.windowsConfiguration = windowsConfiguration;
        ToastNotificationManagerCompat.OnActivated += OnActivated;

        return Task.CompletedTask;
    }

    public Task<bool> PushNotification(string title, string message)
    {
        return Task.Run(() =>
        {
            GetBuilder()?.AddText(title)?
                    .AddText(message)?
                    .Show();

            return defaultResponse;
        });
    }

    public Task<bool> PushNotification(INotification notification)
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

    private void OnActivated(ToastNotificationActivatedEventArgsCompat args)
    {
        NotificationReacted?.Invoke(new WindowsNotificationEventArgs
        {
            Args = ToastArguments.Parse(args.Argument)
        });
    }

    public void Dispose()
    {
        ToastNotificationManagerCompat.OnActivated -= OnActivated;
    }
}
