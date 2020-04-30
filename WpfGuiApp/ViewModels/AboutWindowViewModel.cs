using System.Windows.Input;
using WpfGuiApp.Services;
using WpfGuiApp.UiTools.Commands;
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

        public AboutWindowViewModel(IMyCalculator myCalculator)
        {
            _myCalculator = myCalculator;
        }

        private readonly IMyCalculator _myCalculator;

        public ICommand MyCommandAgain =>
            new ActionCommand(DifficultCalculations);

        public ICommand ExitCommand => new RelayCommand<ICloseable>(win => win.Close(), _ => SimpleProp > 100);

        private void DifficultCalculations()
        {
            SimpleProp = _myCalculator.Add(_simpleProp, _simpleProp + 1);
        }
    }
}