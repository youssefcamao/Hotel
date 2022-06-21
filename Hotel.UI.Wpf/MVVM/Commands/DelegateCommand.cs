using System;
using System.Windows.Input;

namespace Hotel.UI.Wpf.MVVM.Commands
{
    /// <summary>
    /// This Method can be used to Initiate a command from <see cref="Action"/>
    /// </summary>
    public class DelegateCommand : ICommand
    {
        private readonly Action<object> _executeAction;

        public DelegateCommand(Action<object>? executeAction)
        {
            if (executeAction == null)
            {
                throw new ArgumentNullException(nameof(executeAction));
            }
            _executeAction = executeAction;
        }
        public void Execute(object parameter) => _executeAction(parameter);

        public bool CanExecute(object? parameter) => true;

        public event EventHandler CanExecuteChanged;
    }
}
