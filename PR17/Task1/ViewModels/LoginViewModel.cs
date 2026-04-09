using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using CrmDemo.Services;
using CrmDemo.Commands;

namespace CrmDemo.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly DataService _dataService;
        private string _username;
        private string _password;
        private bool _isLoading;

        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        public bool IsLoading
        {
            get => _isLoading;
            set { _isLoading = value; OnPropertyChanged(); }
        }

        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }

        public LoginViewModel()
        {
            _dataService = new DataService();
            _username = "";
            _password = "";
            _isLoading = false;

            LoginCommand = new RelayCommand(Login);
            RegisterCommand = new RelayCommand(Register);
        }

        private void Login()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Введите логин и пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            IsLoading = true;

            var users = _dataService.LoadUsers();
            var user = users.Find(u => u.Login == Username);

            if (user != null && _dataService.VerifyPassword(Password, user.PasswordHash))
            {
                var mainWindow = new MainWindow(user);
                mainWindow.Show();
                Application.Current.Windows[0]?.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            IsLoading = false;
        }

        private void Register()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Введите логин и пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (Password.Length < 6)
            {
                MessageBox.Show("Пароль должен быть не менее 6 символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            IsLoading = true;

            var users = _dataService.LoadUsers();

            if (users.Exists(u => u.Login == Username))
            {
                MessageBox.Show("Пользователь с таким логином уже существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                IsLoading = false;
                return;
            }

            var newUser = new Models.User
            {
                Login = Username,
                PasswordHash = "",
                Role = "Manager",
                FullName = Username
            };

            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(Password);
                byte[] hash = sha256.ComputeHash(bytes);
                newUser.PasswordHash = Convert.ToBase64String(hash);
            }

            users.Add(newUser);
            _dataService.SaveUsers(users);

            MessageBox.Show("Регистрация успешна! Теперь войдите в систему.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

            IsLoading = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}