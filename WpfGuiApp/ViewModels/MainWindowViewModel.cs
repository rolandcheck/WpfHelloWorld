using System.Windows.Input;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WpfGuiApp.FClasses;
using WpfGuiApp.Tools;
using WpfGuiApp.Tools.Commands;
using WpfGuiApp.Views;

namespace WpfGuiApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private int _count;

        public int Count
        {
            get => _count;
            set => SetProperty(ref _count, value);
        }

        public string MyValue { get; set; }

        private readonly ViewManager _viewManager;
        private readonly ILogger<MainWindowViewModel> _logger;

        public MainWindowViewModel() { }

        public MainWindowViewModel(ViewManager viewManager, ILogger<MainWindowViewModel> logger, IOptions<AppSettings> options)
        {
            _viewManager = viewManager;
            _logger = logger;

            MyValue = options.Value.ComplexSettingSet.ButtonContent;
        }


        public ICommand MyCommand => new ActionCommand(IncrementCount, () => Count < 10);

        private void IncrementCount()
        {
            Count++;
            _logger.LogInformation($"Count incremented, now value of Count = {Count}");
        }

        public ICommand NewWindow => new ActionCommand(() =>
        {
            var (vm, window) = _viewManager.GetWindow<AboutWindowViewModel, AboutWindow>();
            var res = window.ShowDialog();

            switch (res)
            {
                case true:
                {
                    Count = vm.SimpleProp;
                    break;
                }
            }
        });

        
    }
}