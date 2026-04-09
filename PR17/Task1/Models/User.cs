using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CrmDemo.Models
{
    public class User : INotifyPropertyChanged
    {
        private string _login;
        private string _passwordHash;
        private string _role;
        private string _fullName;

        public string Login
        {
            get => _login;
            set { _login = value; OnPropertyChanged(); }
        }

        public string PasswordHash
        {
            get => _passwordHash;
            set { _passwordHash = value; OnPropertyChanged(); }
        }

        public string Role
        {
            get => _role;
            set { _role = value; OnPropertyChanged(); }
        }

        public string FullName
        {
            get => _fullName;
            set { _fullName = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}