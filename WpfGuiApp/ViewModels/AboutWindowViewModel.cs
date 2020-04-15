using System.Windows.Input;
using WpfGuiApp.Tools;
using WpfGuiApp.Tools.Commands;
using WpfGuiApp.Views;
using WpfGuiApp.Views.Interfaces;

namespace WpfGuiApp.ViewModels
{
    public class AboutWindowViewModel : ViewModelBase
    {
        private int _simpleProp = 1;

        public int SimpleProp
        {
            get => _simpleProp;
            set => SetProperty(ref _simpleProp, value);
        }

        public AboutWindowViewModel() { }

        public AboutWindowViewModel(IMyService myService)
        {
            _myService = myService;
        }

        private readonly IMyService _myService;

        public ICommand MyCommandAgain =>
            new ActionCommand(() => DifficultCalculations());

        public ICommand ExitCommand => new RelayCommand<ICloseable>(win => win.Close(), _ => SimpleProp > 100);

        private int DifficultCalculations()
        {
            return SimpleProp = _myService.DifficultCalculations(_simpleProp, _simpleProp);
        }
    }
}