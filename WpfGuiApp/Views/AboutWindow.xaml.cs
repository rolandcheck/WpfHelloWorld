using System.Windows;
using WpfGuiApp.Views.Interfaces;

namespace WpfGuiApp.Views
{
    /// <summary>
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window, ICloseable
    {
        public AboutWindow()
        {
            InitializeComponent();
        }

        private void SafeExitClick(object sender, RoutedEventArgs e) => DialogResult = true;
    }
}