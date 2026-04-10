using System.Windows;
using CRMApp.ViewModels;

namespace CRMApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new CRMViewModel();
        }
    }
}