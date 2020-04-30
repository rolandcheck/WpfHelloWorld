using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using WpfGuiApp.ViewModels;

namespace WpfGuiApp.Services
{
    public class ViewManager
    {
        private readonly IServiceProvider _container;

        public ViewManager(IServiceProvider container)
        {
            _container = container;
        }

        public (TVm, TWindow) GetWindow<TVm, TWindow>()
            where TVm : ViewModelBase
            where TWindow : Window, new()
        {
            var vm = _container.GetService<TVm>();
            var view = new TWindow
            {
                DataContext = vm,
            };

            return (vm, view);
        }
    }
}