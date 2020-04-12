using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using WpfGuiApp.ViewModels;

namespace WpfGuiApp.Tools
{
    public class ViewManager
    {
        private ServiceProvider container;

        public ViewManager()
        {
        }

        public ViewManager(ServiceProvider container)
        {
            this.container = container;
        }

        public (TVm, TWindow) GetWindow<TVm, TWindow>()
            where TVm : ViewModelBase
            where TWindow : Window, new()
        {
            var vm = container.GetService<TVm>();
            var view = new TWindow
            {
                DataContext = vm,
            };

            return (vm, view);
        }

        internal void SetContainer(ServiceProvider container)
        {
            this.container = container;
        }
    }
}