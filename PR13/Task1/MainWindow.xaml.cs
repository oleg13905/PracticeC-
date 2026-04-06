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
        public string InteractionHistory { get; set; }
    }

    public partial class MainWindow : Window
    {
        public ObservableCollection<Client> Clients { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Clients = new ObservableCollection<Client>
            {
                new Client
                {
                    FullName = "Багдюн Олег",
                    Phone = "+375 33 642-01-62",
                    Email = "oleg.bagdun@gmail.com",
                    InteractionHistory = "Звонил 30.03, интересовался ценами"
                },
            };

            DataContext = this;
        }

        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            var client = new Client
            {
                FullName = txtFullName.Text,
                Phone = txtPhone.Text,
                Email = txtEmail.Text,
                InteractionHistory = txtHistory.Text
            };

            Clients.Add(client);
            ClearForm();
        }

        private void UpdateClient_Click(object sender, RoutedEventArgs e)
        {
            if (lvClients.SelectedItem is Client selected)
            {
                selected.FullName = txtFullName.Text;
                selected.Phone = txtPhone.Text;
                selected.Email = txtEmail.Text;
                selected.InteractionHistory = txtHistory.Text;

                lvClients.Items.Refresh();
            }
        }

        private void lvClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvClients.SelectedItem is Client selected)
            {
                txtFullName.Text = selected.FullName;
                txtPhone.Text = selected.Phone;
                txtEmail.Text = selected.Email;
                txtHistory.Text = selected.InteractionHistory;
            }
        }

        private void ClearForm()
        {
            txtFullName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtHistory.Text = "";
        }
    }
}