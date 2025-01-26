using NotificationService.Abstractions.Model.Enums;

namespace NotificationService.Abstractions.Model.Events;

public abstract class NotificationReactEventArgs
{
    public abstract NotificationServiceType ServiceType { get; }

    public TArgs GetCurrentArgs<TArgs>()
        where TArgs : NotificationReactEventArgs
        => (TArgs)this;
}
