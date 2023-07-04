using PresidentAtDate.ViewModels;
using System.Runtime.Versioning;
using System.Windows;

namespace PresidentAtDate.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [SupportedOSPlatform("windows")]
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new PresidentViewModel();
        }
    }
}
