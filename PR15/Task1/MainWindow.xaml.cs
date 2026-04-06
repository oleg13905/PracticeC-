using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Task1
{
    public class Client
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ClientType { get; set; } = "Обычный";
        public string InteractionHistory { get; set; }
    }

    public partial class MainWindow : Window
    {
        public ObservableCollection<Client> Clients { get; } = new ObservableCollection<Client>();
        public Client SelectedClient { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Clients.Add(new Client
            {
                FullName = "Багдюн Олег",
                Phone = "+375336420211",
                Email = "oleg@gmail.com",
                ClientType = "VIP"
            });
         
            DataContext = this;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Client newClient = new Client { FullName = "Новый клиент" };
            Clients.Add(newClient);
            SelectedClient = newClient;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Сохранено!");
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedClient != null)
            {
                Clients.Remove(SelectedClient);
                SelectedClient = null;
            }
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            SelectedClient = null;
        }
    }
}