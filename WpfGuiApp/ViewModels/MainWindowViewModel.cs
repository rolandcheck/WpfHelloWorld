using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WpfGuiApp.FClasses;
using WpfGuiApp.Services;
using WpfGuiApp.UiTools.Commands;
using WpfGuiApp.Views;

namespace WpfGuiApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region **Properties**

        private int _count;
        private readonly ViewManager _viewManager;
        private readonly ILogger<MainWindowViewModel> _logger;
        private readonly IOptions<AppSettings> _options;
        private IntervalTypesEnum _selectedIntervalType;
        private ObservableCollection<string> _stringsList = new ObservableCollection<string>();

        public IntervalTypesEnum SelectedIntervalType
        {
            get => _selectedIntervalType;
            set => SetProperty(ref _selectedIntervalType, value);
        }

        public int Count
        {
            get => _count;
            set => SetProperty(ref _count, value);
        }

        public ObservableCollection<string> StringsList
        {
            get => _stringsList;
            set => SetProperty(ref _stringsList, value);
        }

        #endregion **Properties**

        public MainWindowViewModel() { }

        public MainWindowViewModel(ViewManager viewManager, ILogger<MainWindowViewModel> logger, IOptions<AppSettings> options)
        {
            _viewManager = viewManager;
            _logger = logger;
            _options = options;
        }

        #region **Commands**

        public ICommand NewWindow => new ActionCommand(OpenAboutWindow);

        private void OpenAboutWindow()
        {
            var (vm, window) = _viewManager.GetWindow<AboutWindowViewModel, AboutWindow>();
            var res = window.ShowDialog();

            // return data from vm?
            if (res is true)
            {
                Count = vm.SimpleProp;
            }
        }

        public ICommand MyCommand => new ActionCommand(IncrementCount, () => Count < 10);

        private void IncrementCount()
        {
            Count++;
            StringsList.Add(Count.ToString());
            _logger.LogInformation($"Count incremented, now value of Count = {Count}");
        }

        #endregion **Commands**
    }
}