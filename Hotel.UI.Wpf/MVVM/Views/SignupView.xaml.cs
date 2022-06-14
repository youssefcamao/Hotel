using Hotel.Core;
using System.Windows;
using System.Windows.Controls;

namespace Hotel.UI.Wpf.MVVM.Views
{
    /// <summary>
    /// Interaction logic for SignupView.xaml
    /// </summary>
    public partial class SignupView : UserControl
    {
        public SignupView()
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
                    ((dynamic)this.DataContext).Password = password;
                }
                else
                {
                    ((dynamic)this.DataContext).Password = null;
                }
            }
        }
    }
}
