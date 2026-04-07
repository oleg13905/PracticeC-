using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CrmDemo
{
    public class Client : INotifyPropertyChanged
    {
        private string fullName;
        private string phone;

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

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public class CrmViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Client> Clients { get; } = new ObservableCollection<Client>();
        private Client selectedClient;
        private bool isLoading;

        public Client SelectedClient
        {
            get => selectedClient;
            set { selectedClient = value; OnPropertyChanged(); }
        }

        public bool IsLoading
        {
            get => isLoading;
            set { isLoading = value; OnPropertyChanged(); }
        }

        public ICommand LoadCommand { get; }

        public CrmViewModel()
        {
            LoadCommand = new RelayCommand(async () => await LoadAsync());
        }

        private async Task LoadAsync()
        {
            IsLoading = true;
            await Task.Delay(1000); 

            Clients.Clear();
            Clients.Add(new Client { FullName = "Багдюн Олег", Phone = "+375295672345" });
            Clients.Add(new Client { FullName = "Петров Рома", Phone = "+375294355891" });

            IsLoading = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly System.Action _action;
        public RelayCommand(System.Action action) { _action = action; }
        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter) => _action();
        public event System.EventHandler CanExecuteChanged;
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new CrmViewModel();
        }
    }
}