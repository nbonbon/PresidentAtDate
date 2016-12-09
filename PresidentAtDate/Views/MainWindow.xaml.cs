using PresidentAtDate.ViewModels;
using System.Windows;

namespace PresidentAtDate.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new PresidentViewModel();
        }
    }
}
