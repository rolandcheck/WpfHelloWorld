using System.Windows.Input;
using WpfGuiApp.Tools;
using WpfGuiApp.Views;

namespace WpfGuiApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private int _count;
        public int Count
        {
            get => _count;
            set
            {
                if (_count == value) return;

                _count = value;
                OnPropertyChanged();
            }
        }


        private readonly ViewManager _viewManager;

        public MainWindowViewModel()
        {
        }

        public MainWindowViewModel(ViewManager viewManager)
        {
            this._viewManager = viewManager;
        }

        public ICommand MyCommand => new RelayCommand((arg) => Count++, (arg) => Count < 10);

        public ICommand NewWindow => new RelayCommand((arg) =>
        {
            var (vm, window) = _viewManager.GetWindow<AboutWindowViewModel, AboutWindow>();
            window.Show();
        });
    }
}