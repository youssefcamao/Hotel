using System;
using System.Windows.Input;

namespace Hotel.UI.Wpf.MVVM.ViewModels.Dialogs
{
    public class ConfirmationDialogViewModel
    {
        public ConfirmationDialogViewModel(string message, ICommand confirmationCommand)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }
            else if (confirmationCommand == null)
            {
                throw new ArgumentNullException(nameof(confirmationCommand));
            }
            Message = message;
            ConfirmationCommand = confirmationCommand;
        }
        public string Message { get; }
        public ICommand ConfirmationCommand { get; }
    }
}
