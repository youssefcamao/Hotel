using System;
using System.Windows.Input;

namespace Hotel.UI.Wpf.MVVM.Commands
{
    /// <summary>
    /// This command is the base command for all the commands that implements OnPropertyChanged
    /// </summary>
    public abstract class CommandBase : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public virtual bool CanExecute(object? parameter)
        {
            return true;
        }

        public abstract void Execute(object? parameter);
        protected void OnCanExcutedChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
