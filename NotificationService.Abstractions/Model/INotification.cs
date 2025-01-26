namespace NotificationService.Abstractions.Model;

public interface INotification
{
    string Title { get; set; }

    string Message { get; set; }

    object Icon { get; set; }
}
