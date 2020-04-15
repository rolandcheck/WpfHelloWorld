using System.Windows.Input;
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


        private readonly ViewManager _viewManager;

        public MainWindowViewModel() { }

        public MainWindowViewModel(ViewManager viewManager)
        {
            _viewManager = viewManager;
        }


        public ICommand MyCommand => new ActionCommand(() => Count++, () => Count < 10);

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