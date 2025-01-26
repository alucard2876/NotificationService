using NotificationService.Abstractions.Model;
using Plugin.LocalNotification;
using INotificationService = NotificationService.Abstractions.Model.INotificationService;

namespace NotificationService.Platforms.Android.Model
{
    internal sealed class AndroidNotificationService : INotificationService
    {
        private AndroidConfiguration androidConfiguration;

        public Task Initialize(INotificationConfiguration configuration)
        {
            if (configuration is not AndroidConfiguration androidConfiguration)
                throw new InvalidOperationException(nameof(INotificationConfiguration));

            this.androidConfiguration = androidConfiguration;
            return Task.CompletedTask;
        }

        public Task<object> PushNotification(string title, string message)
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
            }).ContinueWith(r => (object)r.Result);
        }

        public Task<object> PushNotification(INotification notification)
        {
            throw new NotImplementedException();
        }
    }
}
