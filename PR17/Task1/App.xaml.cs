using System.Windows;
using CrmDemo.ViewModels;

namespace CrmDemo
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var loginWindow = new LoginWindow();
            loginWindow.DataContext = new LoginViewModel();
            loginWindow.Show();
        }
    }
}