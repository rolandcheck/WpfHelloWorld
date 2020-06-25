using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using NLog.Extensions.Logging;

using System.Windows;
using WpfGuiApp.FClasses;
using WpfGuiApp.Services;
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
            var services = new ServiceCollection();

            ConfigureServices(services);

            // building
            var container = services.BuildServiceProvider();

            // show main window
            var viewManager = container.GetService<ViewManager>();
            
            var (_, mainWindow) = viewManager.GetWindow<MainWindowViewModel>();
            mainWindow.ShowDialog(); 
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // viewModels
            services.AddTransient<AboutWindowViewModel>();
            services.AddTransient<MainWindowViewModel>();

            // services
            services.AddTransient<IMyCalculator, MyCalculator>();
            services.AddSingleton<ViewManager>(); // wanna have only one manager

            // read external json configurations
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // strongly-typed setting class
            services.Configure<AppSettings>(config.GetSection(nameof(AppSettings)));

            // setting up logging
            services.AddLogging(builder =>
            {
                var conf = new NLogLoggingConfiguration(config.GetSection(nameof(NLog)));
                builder.AddNLog(conf);
            });
        }
    }
}
