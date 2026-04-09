using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;

namespace CRMApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += (s, e) => LoadClients();
        }

        private void BtnClients_Click(object sender, RoutedEventArgs e)
        {
            LoadClients();
            ((Storyboard)Resources["TabAnimation"]).Begin(ContentPanel);
        }

        private void BtnDeals_Click(object sender, RoutedEventArgs e)
        {
            LoadDeals();
            ((Storyboard)Resources["TabAnimation"]).Begin(ContentPanel);
        }

        private void BtnTasks_Click(object sender, RoutedEventArgs e)
        {
            LoadTasks();
            ((Storyboard)Resources["TabAnimation"]).Begin(ContentPanel);
        }

        private void LoadClients()
        {
            ContentPanel.Children.Clear();

            var client1 = CreateClientCard("Багдюн Олег", "ООО БелТехСервис", "+375 29 1234567", "oleg@beltech.by", 12);
            var client2 = CreateClientCard("Петров Роман", "ЗАО МинскСтрой", "+375 33 2345678", "roman@minskstroy.by", 8);

            ContentPanel.Children.Add(client1);
            ContentPanel.Children.Add(client2);
        }

        private Border CreateClientCard(string name, string company, string phone, string email, int deals)
        {
            var card = new Border
            {
                Height = 80,
                Margin = new Thickness(0, 0, 0, 10),
                Background = new SolidColorBrush(Colors.White),
                CornerRadius = new CornerRadius(5),
                Cursor = Cursors.Hand
            };

            var stack = new StackPanel();
            stack.Children.Add(new TextBlock { Text = name, FontSize = 14, FontWeight = FontWeights.Bold, Margin = new Thickness(10, 10, 0, 0) });
            stack.Children.Add(new TextBlock { Text = company, FontSize = 11, Foreground = Brushes.Gray, Margin = new Thickness(10, 0, 0, 0) });
            stack.Children.Add(new TextBlock { Text = $"Сделок: {deals}", FontSize = 11, Foreground = Brushes.DarkGreen, Margin = new Thickness(10, 0, 0, 10) });

            var expandPanel = new StackPanel { Visibility = Visibility.Collapsed };
            expandPanel.Children.Add(new TextBlock { Text = $"Телефон: {phone}", Margin = new Thickness(10, 5, 0, 5), FontSize = 11 });
            expandPanel.Children.Add(new TextBlock { Text = $"Email: {email}", Margin = new Thickness(10, 0, 0, 5), FontSize = 11 });
            var editBtn = new Button { Content = "Редактировать", Width = 100, Height = 25, Margin = new Thickness(10, 5, 0, 10) };
            editBtn.Click += (s, e) => MessageBox.Show($"Редактирование: {name}", "CRM");
            expandPanel.Children.Add(editBtn);

            stack.Children.Add(expandPanel);
            card.Child = stack;

            card.MouseEnter += (s, e) =>
            {
                card.Background = new SolidColorBrush(Color.FromRgb(240, 248, 255));
            };
            card.MouseLeave += (s, e) =>
            {
                card.Background = new SolidColorBrush(Colors.White);
            };

            card.MouseLeftButtonDown += (s, e) =>
            {
                if (expandPanel.Visibility == Visibility.Collapsed)
                {
                    expandPanel.Visibility = Visibility.Visible;
                    var sb = (Storyboard)Resources["ExpandAnimation"];
                    sb.Begin(card);
                }
                else
                {
                    expandPanel.Visibility = Visibility.Collapsed;
                    card.Height = 80;
                }
            };

            return card;
        }

        private void LoadDeals()
        {
            ContentPanel.Children.Clear();

            ContentPanel.Children.Add(CreateDealCard("Поставка оборудования", "Багдюн Олег", "ООО БелТехСервис", "12500 BYN", "Активна"));
            ContentPanel.Children.Add(CreateDealCard("Разработка сайта", "Багдюн Олег", "ООО БелТехСервис", "4800 BYN", "Завершена"));
            ContentPanel.Children.Add(CreateDealCard("Строительные материалы", "Петров Роман", "ЗАО МинскСтрой", "35200 BYN", "Новая"));
            ContentPanel.Children.Add(CreateDealCard("ИТ-консалтинг", "Петров Роман", "ЗАО МинскСтрой", "9200 BYN", "Активна"));
        }

        private Border CreateDealCard(string title, string client, string company, string amount, string status)
        {
            var card = new Border
            {
                Height = 70,
                Margin = new Thickness(0, 0, 0, 10),
                Background = new SolidColorBrush(Colors.White),
                CornerRadius = new CornerRadius(5)
            };

            var grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            var leftStack = new StackPanel { Margin = new Thickness(10) };
            leftStack.Children.Add(new TextBlock { Text = title, FontWeight = FontWeights.Bold });
            leftStack.Children.Add(new TextBlock { Text = $"{client} / {company}", FontSize = 11, Foreground = Brushes.Gray });

            var rightStack = new StackPanel { Margin = new Thickness(10) };
            rightStack.Children.Add(new TextBlock { Text = amount, FontWeight = FontWeights.Bold, Foreground = Brushes.DarkGreen });
            rightStack.Children.Add(new TextBlock { Text = status, FontSize = 11, Foreground = status == "Активна" ? Brushes.Orange : Brushes.Green });

            grid.Children.Add(leftStack);
            grid.Children.Add(rightStack);
            Grid.SetColumn(leftStack, 0);
            Grid.SetColumn(rightStack, 1);
            card.Child = grid;

            card.MouseEnter += (s, e) =>
            {
                card.Background = new SolidColorBrush(Color.FromRgb(245, 248, 255));
            };
            card.MouseLeave += (s, e) =>
            {
                card.Background = new SolidColorBrush(Colors.White);
            };

            return card;
        }

        private void LoadTasks()
        {
            ContentPanel.Children.Clear();

            ContentPanel.Children.Add(CreateTaskCard("Позвонить клиенту", "Багдюн Олег", "ООО БелТехСервис", "Высокий", "Сегодня"));
            ContentPanel.Children.Add(CreateTaskCard("Отправить КП", "Багдюн Олег", "ООО БелТехСервис", "Средний", "Завтра"));
            ContentPanel.Children.Add(CreateTaskCard("Подготовить договор", "Петров Роман", "ЗАО МинскСтрой", "Высокий", "25.03.2024"));
            ContentPanel.Children.Add(CreateTaskCard("Выставить счет", "Петров Роман", "ЗАО МинскСтрой", "Низкий", "27.03.2024"));
        }

        private Border CreateTaskCard(string task, string client, string company, string priority, string date)
        {
            var card = new Border
            {
                Height = 60,
                Margin = new Thickness(0, 0, 0, 10),
                Background = new SolidColorBrush(Colors.White),
                CornerRadius = new CornerRadius(5)
            };

            var grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            var priorityColor = priority == "Высокий" ? "#E74C3C" : priority == "Средний" ? "#F39C12" : "#95A5A6";
            var indicator = new Border
            {
                Width = 8,
                Height = 8,
                CornerRadius = new CornerRadius(4),
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(priorityColor)),
                Margin = new Thickness(10, 20, 10, 0)
            };

            var infoStack = new StackPanel { Margin = new Thickness(0, 10, 0, 0) };
            infoStack.Children.Add(new TextBlock { Text = task, FontWeight = FontWeights.Bold });
            infoStack.Children.Add(new TextBlock { Text = $"{client} / {company}", FontSize = 11, Foreground = Brushes.Gray });

            var dateBlock = new TextBlock { Text = date, FontSize = 11, Foreground = Brushes.Red, Margin = new Thickness(0, 0, 10, 0), VerticalAlignment = VerticalAlignment.Center };

            grid.Children.Add(indicator);
            grid.Children.Add(infoStack);
            grid.Children.Add(dateBlock);
            Grid.SetColumn(indicator, 0);
            Grid.SetColumn(infoStack, 1);
            Grid.SetColumn(dateBlock, 2);
            card.Child = grid;

            card.MouseEnter += (s, e) =>
            {
                card.Background = new SolidColorBrush(Color.FromRgb(255, 250, 240));
            };
            card.MouseLeave += (s, e) =>
            {
                card.Background = new SolidColorBrush(Colors.White);
            };

            return card;
        }
    }
}