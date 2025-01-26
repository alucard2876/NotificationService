using NotificationService.Abstractions.Model;
using NotificationService.Test.Helpers;

namespace NotificationService.Test;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        ServiceProviderHelper.GetService<INotificationService>()?.PushNotification("Test", "From xaml");
    }
}