using NotificationService.Abstractions.Model;
using NotificationService.Abstractions.Model.Enums;
using NotificationService.Abstractions.Model.Events;
using Plugin.LocalNotification;
using Plugin.LocalNotification.EventArgs;
using INotificationService = NotificationService.Abstractions.Model.INotificationService;

namespace NotificationService.Platforms.Android.Model
{
    internal sealed class AndroidNotificationService : INotificationService
    {
        private AndroidConfiguration androidConfiguration;

        public event Action<NotificationReactEventArgs>? NotificationReacted;

        public Task Initialize(INotificationConfiguration configuration)
        {
            if (configuration is not AndroidConfiguration androidConfiguration)
                throw new InvalidOperationException(nameof(INotificationConfiguration));

            this.androidConfiguration = androidConfiguration;

            LocalNotificationCenter.Current.NotificationReceived += OnNotificationReceived;
            LocalNotificationCenter.Current.NotificationsDisabled += OnNotificationDisabled;
            LocalNotificationCenter.Current.NotificationActionTapped += OnNotificationTapped;

            return Task.CompletedTask;
        }

        public Task<bool> PushNotification(string title, string message)
        {
            return LocalNotificationCenter.Current.Show(new NotificationRequest
            {
                BadgeNumber = androidConfiguration.BadgeNumber,
                Title = title,
                Description = message,
                Subtitle = title,
                NotificationId = 1337,
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(1),
                    RepeatType = NotificationRepeat.No
                }
            });
        }

        public Task<bool> PushNotification(INotification notification)
        {
            throw new NotImplementedException();
        }

        private void OnNotificationTapped(NotificationActionEventArgs e)
        {
            NotificationReacted?.Invoke(new AndroidNotificationEventArgs
            {
                ActionId = e.ActionId,
                IsDismissed = e.IsDismissed,
                IsTapped = e.IsTapped,
                Request = e.Request,
                Type = NotificationType.Click
            });
        }

        private void OnNotificationDisabled()
        {
            NotificationReacted?.Invoke(new AndroidNotificationEventArgs
            {
                Type = NotificationType.Remove
            });
        }

        private void OnNotificationReceived(NotificationEventArgs e)
        {
            NotificationReacted?.Invoke(new AndroidNotificationEventArgs
            {
                Type = NotificationType.Recieved,
                Request = e.Request,
            });
        }
        public void Dispose()
        {
            LocalNotificationCenter.Current.NotificationReceived -= OnNotificationReceived;
            LocalNotificationCenter.Current.NotificationsDisabled -= OnNotificationDisabled;
            LocalNotificationCenter.Current.NotificationActionTapped -= OnNotificationTapped;
        }
    }
}
