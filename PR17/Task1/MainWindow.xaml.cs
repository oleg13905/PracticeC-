using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using CrmDemo.Models;
using CrmDemo.Services;
using CrmDemo.Commands;

namespace CrmDemo
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private readonly DataService _dataService;
        private readonly NamedPipeService _pipeService;
        private FileWatcherService _fileWatcher;
        private readonly User _currentUser;

        public ObservableCollection<Client> Clients { get; private set; }
        public ObservableCollection<Deal> Deals { get; private set; }

        private Client _selectedClient;
        private Deal _selectedDeal;
        private bool _isLoading;
        private string _statusMessage;
        private string _notifications;

        public Client SelectedClient
        {
            get => _selectedClient;
            set
            {
                _selectedClient = value;
                OnPropertyChanged();
            }
        }

        public Deal SelectedDeal
        {
            get => _selectedDeal;
            set { _selectedDeal = value; OnPropertyChanged(); }
        }

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged();
                var loadingIndicator = FindName("LoadingIndicator") as System.Windows.Controls.ProgressBar;
                if (loadingIndicator != null)
                    loadingIndicator.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public string StatusMessage
        {
            get => _statusMessage;
            set { _statusMessage = value; OnPropertyChanged(); }
        }

        public string Notifications
        {
            get => _notifications;
            set { _notifications = value; OnPropertyChanged(); }
        }

        public ICommand LoadCommand { get; private set; }
        public ICommand AddCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand AddDealCommand { get; private set; }
        public ICommand SendNotificationCommand { get; private set; }

        public MainWindow(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _dataService = new DataService();
            _pipeService = new NamedPipeService();

            Clients = new ObservableCollection<Client>();
            Deals = new ObservableCollection<Deal>();
            _statusMessage = "Готов";
            _notifications = "";

            LoadCommand = new RelayCommand(LoadData);
            AddCommand = new RelayCommand(AddClient, () => _currentUser?.Role == "Admin" || _currentUser?.Role == "Manager");
            SaveCommand = new RelayCommand(SaveClient, () => SelectedClient != null);
            DeleteCommand = new RelayCommand(DeleteClient, () => SelectedClient != null && _currentUser?.Role == "Admin");
            AddDealCommand = new RelayCommand(AddDeal, () => SelectedClient != null && _currentUser?.Role == "Admin");
            SendNotificationCommand = new RelayCommand(SendNotification, () => SelectedDeal != null);

            DataContext = this;
            Title = $"CRM System - {_currentUser?.FullName} ({_currentUser?.Role})";

            InitializeServices();
            LoadData();
        }

        private void InitializeServices()
        {
            _pipeService.StartServer(OnMessageReceived);
            _fileWatcher = new FileWatcherService("crm_data.json", OnFileChanged);
        }

        private void OnMessageReceived(string message)
        {
            Dispatcher.Invoke(() =>
            {
                Notifications += $"[{DateTime.Now:HH:mm:ss}] {message}\n";
                StatusMessage = "Получено новое уведомление";
            });
        }

        private void OnFileChanged(string path, WatcherChangeTypes changeType)
        {
            Dispatcher.Invoke(() =>
            {
                if (changeType == WatcherChangeTypes.Changed)
                {
                    StatusMessage = "Данные были изменены другим пользователем. Нажмите 'Загрузить' для обновления.";
                    Notifications += $"[{DateTime.Now:HH:mm:ss}] ВНИМАНИЕ: Файл данных был изменен!\n";
                }
            });
        }

        private void LoadData()
        {
            IsLoading = true;
            StatusMessage = "Загрузка данных...";

            var data = _dataService.LoadCrmData();

            Clients.Clear();
            foreach (var client in data.Clients)
                Clients.Add(client);

            Deals.Clear();
            foreach (var deal in data.Deals)
                Deals.Add(deal);

            StatusMessage = $"Загружено {Clients.Count} клиентов и {Deals.Count} сделок";
            IsLoading = false;
        }

        private void SaveClient()
        {
            if (SelectedClient == null) return;

            IsLoading = true;
            StatusMessage = "Сохранение...";

            var data = _dataService.LoadCrmData();

            int existingIndex = data.Clients.FindIndex(c => c.FullName == SelectedClient.FullName);
            if (existingIndex >= 0)
                data.Clients[existingIndex] = SelectedClient;
            else
                data.Clients.Add(SelectedClient);

            _dataService.SaveCrmData(data);

            StatusMessage = $"Клиент {SelectedClient.FullName} сохранен";
            _pipeService.SendMessage($"Клиент {SelectedClient.FullName} был обновлен пользователем {_currentUser.FullName}");

            IsLoading = false;
        }

        private void AddClient()
        {
            var newClient = new Client { FullName = "Новый клиент", Phone = "+375", Email = "new@email.com" };
            Clients.Add(newClient);
            SelectedClient = newClient;
        }

        private void DeleteClient()
        {
            if (SelectedClient == null) return;

            var result = MessageBox.Show($"Удалить клиента {SelectedClient.FullName}?", "Подтверждение",
                MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                IsLoading = true;

                var data = _dataService.LoadCrmData();
                data.Clients.RemoveAll(c => c.FullName == SelectedClient.FullName);
                _dataService.SaveCrmData(data);

                Clients.Remove(SelectedClient);
                SelectedClient = null;

                StatusMessage = "Клиент удален";
                _pipeService.SendMessage($"Клиент был удален пользователем {_currentUser.FullName}");

                IsLoading = false;
            }
        }

        private void AddDeal()
        {
            if (SelectedClient == null) return;

            var newDeal = new Deal
            {
                Id = Deals.Count + 1,
                ClientName = SelectedClient.FullName,
                Amount = 0,
                Date = DateTime.Now,
                Status = "Новая",
                Manager = _currentUser.FullName
            };

            Deals.Add(newDeal);
            SelectedDeal = newDeal;

            var data = _dataService.LoadCrmData();
            data.Deals.Add(newDeal);
            _dataService.SaveCrmData(data);

            StatusMessage = "Сделка добавлена";
        }

        private void SendNotification()
        {
            if (SelectedDeal == null) return;

            var message = $"Сделка #{SelectedDeal.Id} для {SelectedDeal.ClientName} на сумму {SelectedDeal.Amount:C} изменила статус на '{SelectedDeal.Status}'";
            _pipeService.SendMessage(message);
            StatusMessage = "Уведомление отправлено";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}