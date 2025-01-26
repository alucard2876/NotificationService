using NotificationService.Abstractions.Model;
using NotificationService.Test.Helpers;

namespace NotificationService.Test;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new MainPage();
    }

    protected override void CleanUp()
    {
        ServiceProviderHelper.GetService<INotificationService>()?.Dispose();
    }
}