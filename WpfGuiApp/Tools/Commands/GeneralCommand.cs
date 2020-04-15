using System;

namespace WpfGuiApp.Tools.Commands
{
    public class GeneralCommand : RelayCommand<object>
    {
        public GeneralCommand(Action<object> execute, Predicate<object> canExecute = null) : base(execute, canExecute)
        {
        }
    }
}