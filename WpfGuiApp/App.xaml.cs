using System;
using System.Collections.Generic;
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
            var services = new ServiceCollection();

            // viewModels
            services.AddTransient<AboutWindowViewModel>();
            services.AddTransient<MainWindowViewModel>();

            // services
            services.AddTransient<IMyService, MyService>();
            services.AddSingleton<ViewManager>(); // wanna have only one manager


            // building
            var container = services.BuildServiceProvider();


            // show main window
            var viewManager = container.GetService<ViewManager>();
            
            var (_, mainWindow) = viewManager.GetWindow<MainWindowViewModel, MainWindow>();
            mainWindow.ShowDialog(); 
        }
    }
}