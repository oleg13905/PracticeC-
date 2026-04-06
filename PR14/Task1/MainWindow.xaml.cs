using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
        public ObservableCollection<Client> Clients { get; } = new ObservableCollection<Client>();

        public MainWindow()
        {
            InitializeComponent();
            Clients.Add(new Client
            {
                FullName = "Багдюн Олег",
                Phone = "+375336420162",
                Email = "bagdun@gmail.com",
                InteractionHistory = "Договор 25.03"
            });

            DataContext = this;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e) => AddClient();

        private void BtnEdit_Click(object sender, RoutedEventArgs e) => EditClient();

        private void BtnDelete_Click(object sender, RoutedEventArgs e) => DeleteClient();

        private void MenuAddClient_Click(object sender, RoutedEventArgs e) => AddClient();

        private void MenuEditClient_Click(object sender, RoutedEventArgs e) => EditClient();

        private void MenuDeleteClient_Click(object sender, RoutedEventArgs e) => DeleteClient();

        private void MenuExit_Click(object sender, RoutedEventArgs e) => Close();

        private void MenuAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("CRM v1.0", "О программе");
        }

        private void AddClient()
        {
            string name = txtFullName.Text.Trim();
            if (string.IsNullOrEmpty(name)) return;

            Clients.Add(new Client
            {
                FullName = name,
                Phone = txtPhone.Text,
                Email = txtEmail.Text,
                InteractionHistory = txtHistory.Text
            });
            ClearForm();
        }

        private void EditClient()
        {
            Client selected = lvClients.SelectedItem as Client;
            if (selected != null)
            {
                selected.FullName = txtFullName.Text;
                selected.Phone = txtPhone.Text;
                selected.Email = txtEmail.Text;
                selected.InteractionHistory = txtHistory.Text;
                lvClients.Items.Refresh();
            }
        }

        private void DeleteClient()
        {
            Client selected = lvClients.SelectedItem as Client;
            if (selected != null)
            {
                MessageBoxResult result = MessageBox.Show(
                    "Удалить " + selected.FullName + "?", "Подтверждение",
                    MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    Clients.Remove(selected);
                    ClearForm();
                }
            }
        }

        private void lvClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Client selected = lvClients.SelectedItem as Client;
            if (selected != null)
            {
                txtFullName.Text = selected.FullName;
                txtPhone.Text = selected.Phone;
                txtEmail.Text = selected.Email;
                txtHistory.Text = selected.InteractionHistory;
            }
            else
            {
                ClearForm();
            }
        }

        private void ClearForm()
        {
            txtFullName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtHistory.Text = "";
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control)
            {
                if (e.Key == Key.N) AddClient();
                else if (e.Key == Key.E) EditClient();
                else if (e.Key == Key.D) DeleteClient();
            }
        }
    }
}