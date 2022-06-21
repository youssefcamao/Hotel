using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hotel.UI.Wpf.MVVM.Commands
{
    /// <summary>
    /// Base command for all the async commmands and improves the logic of a normal <see cref="ICommand"/> to make working with async easier 
    /// </summary>
    public abstract class AsyncCommandBase : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
            await ExecuteAsync(parameter);
        }
        public abstract Task ExecuteAsync(object? parameter);
    }
}
