// ViewModels/CRMViewModel.cs
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CRMApp.Models;
using CRMApp.Repositories;

namespace CRMApp.ViewModels
{
    public class CRMViewModel : INotifyPropertyChanged
    {
        private readonly IClientRepository _repository;
        private ObservableCollection<Client> _clients;
        private Client _selectedClient;
        private string _statusMessage;
        private bool _isBusy;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public CRMViewModel()
        {
            _repository = new ClientRepository();
            _clients = new ObservableCollection<Client>();

            LoadClientsCommand = new RelayCommand(async () => await LoadClientsAsync());
            AddClientCommand = new RelayCommand(AddClient);
            UpdateClientCommand = new RelayCommand(UpdateClient);
            DeleteClientCommand = new RelayCommand(async () => await DeleteClientAsync());
            SaveClientsCommand = new RelayCommand(async () => await SaveChangesAsync());
        }

        public ObservableCollection<Client> Clients
        {
            get => _clients;
            set
            {
                _clients = value;
                OnPropertyChanged();
            }
        }

        public Client SelectedClient
        {
            get => _selectedClient;
            set
            {
                _selectedClient = value;
                OnPropertyChanged();
            }
        }

        public string StatusMessage
        {
            get => _statusMessage;
            set
            {
                _statusMessage = value;
                OnPropertyChanged();
            }
        }

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoadClientsCommand { get; }
        public ICommand AddClientCommand { get; }
        public ICommand UpdateClientCommand { get; }
        public ICommand DeleteClientCommand { get; }
        public ICommand SaveClientsCommand { get; }

        private async Task LoadClientsAsync()
        {
            try
            {
                IsBusy = true;
                StatusMessage = "Загрузка клиентов...";

                var clients = await _repository.GetAllClientsAsync();
                Clients.Clear();
                foreach (var client in clients)
                {
                    Clients.Add(client);
                }

                StatusMessage = $"Загружено {Clients.Count} клиентов";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Ошибка: {ex.Message}";
                MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void AddClient()
        {
            var newClient = new Client
            {
                Id = 0,
                Name = "Новый клиент",
                Company = "Новая компания",
                Phone = "+375 29 0000000",
                Email = "new@client.by",
                DealsCount = 0,
                Status = "Новый"
            };

            Clients.Add(newClient);
            SelectedClient = newClient;
            StatusMessage = "Добавлен новый клиент. Измените данные в таблице и нажмите Сохранить.";
        }

        private void UpdateClient()
        {
            if (SelectedClient == null)
            {
                MessageBox.Show("Выберите клиента для редактирования", "Предупреждение",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            StatusMessage = $"Редактирование клиента {SelectedClient.Name}. Измените данные в таблице и нажмите Сохранить.";
            MessageBox.Show($"Редактирование клиента: {SelectedClient.Name}\nИзмените данные прямо в таблице и нажмите Сохранить.",
                "Редактирование", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private async Task DeleteClientAsync()
        {
            if (SelectedClient == null)
            {
                MessageBox.Show("Выберите клиента для удаления", "Предупреждение",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var result = MessageBox.Show($"Удалить клиента {SelectedClient.Name}?", "Подтверждение",
                MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                var clientToDelete = SelectedClient;
                Clients.Remove(clientToDelete);
                StatusMessage = $"Клиент {clientToDelete.Name} удален. Нажмите Сохранить.";
            }
        }

        private async Task SaveChangesAsync()
        {
            try
            {
                IsBusy = true;
                StatusMessage = "Сохранение изменений...";

                var currentClients = await _repository.GetAllClientsAsync();

                foreach (var client in Clients)
                {
                    if (client.Id == 0)
                    {
                        await _repository.AddClientAsync(client);
                    }
                    else
                    {
                        await _repository.UpdateClientAsync(client);
                    }
                }

                foreach (var client in currentClients)
                {
                    bool stillExists = false;
                    foreach (var c in Clients)
                    {
                        if (c.Id == client.Id)
                        {
                            stillExists = true;
                            break;
                        }
                    }
                    if (!stillExists)
                    {
                        await _repository.DeleteClientAsync(client);
                    }
                }

                await _repository.SaveChangesAsync();
                await LoadClientsAsync();

                MessageBox.Show("Данные успешно сохранены!", "Успех",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Ошибка сохранения: {ex.Message}";
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}