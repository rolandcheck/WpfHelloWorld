using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using WpfGuiApp.Utils;
using WpfGuiApp.ViewModels;

namespace WpfGuiApp.Services
{
    public class ViewManager
    {
        private readonly IServiceProvider _container;
        private Dictionary<Type, Type> _mappings = new Dictionary<Type, Type>();

        public ViewManager(IServiceProvider container)
        {
            _container = container;
            RegisterMappings();
        }

        private void RegisterMappings()
        {
            var types = Assembly.GetExecutingAssembly().GetExportedTypes();

            var viewmodelTypes = types.Where(x => x.IsSubclassOf(typeof(ViewModelBase)));
            var winTypes = types.Where(x => x.IsSubclassOf(typeof(Window))).ToList();

            foreach (var vmType in viewmodelTypes)
            {
                var winType = winTypes.FirstOrDefault(x => x.Name.StartsWith(vmType.Name.TrimEnd("ViewModel")));
                _mappings.Add(vmType, winType);
            }
        }


        public (TVm, Window) GetWindow<TVm>()
            where TVm : ViewModelBase
        {
            var vm = _container.GetService<TVm>();

            if(_mappings.TryGetValue(typeof(TVm), out var winType))
            {
                var window = (Window)Activator.CreateInstance(winType);
                window.DataContext = vm;
                return (vm, window);
            }

            throw new InvalidOperationException("Could not find vm & window mapping");
        }
    }
}