using System.Windows;

namespace CrmDemo
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();

            PasswordBox.PasswordChar = '*';

            PasswordBox.PasswordChanged += (s, e) =>
            {
                if (DataContext is ViewModels.LoginViewModel vm)
                {
                    vm.Password = PasswordBox.Password;
                }
            };
        }
    }
}