using Hotel.Core.CheckServices;
using System.Windows;
using System.Windows.Controls;

namespace Hotel.UI.Wpf.MVVM.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for AdminChangePasswordDialogView.xaml
    /// </summary>
    public partial class AdminChangePasswordDialogView : UserControl
    {
        public AdminChangePasswordDialogView()
        {
            InitializeComponent();
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                var passwordCheckService = new PasswordCheckService();
                var password = ((PasswordBox)sender).Password;
                if (passwordCheckService.CheckIfValid(password))
                {
                    ((dynamic)this.DataContext).NewPassword = password;
                }
                else
                {
                    ((dynamic)this.DataContext).NewPassword = null;
                }
            }
        }
        private void ConfirmPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).ConfirmedPassword = ((PasswordBox)sender).Password; }
        }
    }
}
