using System.Windows.Input;
using WpfGuiApp.Tools;

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
            new RelayCommand(arg => DifficultCalculations());

        private int DifficultCalculations()
        {
            return SimpleProp = _myService.DifficultCalculations(_simpleProp, _simpleProp);
        }
    }
}