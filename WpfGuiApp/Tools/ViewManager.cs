using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using WpfGuiApp.ViewModels;

namespace WpfGuiApp.Tools
{
    public class ViewManager
    {
        private readonly IServiceProvider _container;

        public ViewManager(IServiceProvider container)
        {
            this._container = container;
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