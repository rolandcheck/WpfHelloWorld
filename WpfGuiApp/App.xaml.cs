using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WpfGuiApp.Tools;
using WpfGuiApp.ViewModels;
using WpfGuiApp.Views;

namespace WpfGuiApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var viewManager = new ViewManager();

            var services = new ServiceCollection();
            // viewModels
            services.AddTransient<AboutWindowViewModel>();
            services.AddTransient<MainWindowViewModel>();

            // services
            services.AddTransient<IMyService, MyService>();

            // workaround
            services.AddSingleton(viewManager);

            var container = services.BuildServiceProvider();
            viewManager.SetContainer(container);


            var (_, mainWindow) = viewManager.GetWindow<MainWindowViewModel, MainWindow>();
            mainWindow.ShowDialog(); 
        }
    }
}