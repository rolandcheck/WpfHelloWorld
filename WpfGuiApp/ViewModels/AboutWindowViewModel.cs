using System.Windows.Input;
using WpfGuiApp.Tools;

namespace WpfGuiApp.ViewModels
{
    public class AboutWindowViewModel : ViewModelBase
    {
        public AboutWindowViewModel()
        {
        }

        public AboutWindowViewModel(IMyService myService)
        {
            _myService = myService;
        }

        private int _buttonText = 1;
        private readonly IMyService _myService;

        public ICommand MyCommandAgain =>
            new RelayCommand((arg) => ButtonText = _myService.DifficultCalculations(_buttonText, _buttonText));

        public int ButtonText
        {
            get => _buttonText;
            set
            {
                if (_buttonText == value) return;
                _buttonText = value;
                OnPropertyChanged();
            }
        }
    }
}