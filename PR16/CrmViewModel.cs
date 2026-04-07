using CrmDemo.Models;
using CrmDemo.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CrmDemo.ViewModels
{
	public class CrmViewModel
	{
		private readonly ClientService _service = new ClientService();
		public ObservableCollection<ClientModel> Clients { get; } = new ObservableCollection<ClientModel>();
		public ClientModel SelectedClient { get; set; }
		public bool IsLoading { get; set; }

		public ICommand LoadCommand { get; }

		public CrmViewModel()
		{
			LoadCommand = new RelayCommand(async () => await LoadClients());
		}

		private async Task LoadClients()
		{
			IsLoading = true;
			Clients.Clear();
			var clients = await _service.LoadClientsAsync();
			foreach (var client in clients)
			{
				Clients.Add(client);
			}
			IsLoading = false;
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
}