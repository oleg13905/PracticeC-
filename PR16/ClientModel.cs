using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CrmDemo.Models
{
    public class ClientModel : INotifyPropertyChanged
    {
        private string fullName;
        private string phone;
        private string email;
        private string clientType = "Обычный";

        public string FullName
        {
            get => fullName;
            set { fullName = value; OnPropertyChanged(); }
        }

        public string Phone
        {
            get => phone;
            set { phone = value; OnPropertyChanged(); }
        }

        public string Email
        {
            get => email;
            set { email = value; OnPropertyChanged(); }
        }

        public string ClientType
        {
            get => clientType;
            set { clientType = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}