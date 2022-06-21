using System.Windows;
using System.Windows.Controls;

namespace Hotel.UI.Wpf.MVVM.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for AdminAddNewUser.xaml
    /// </summary>
    public partial class AdminAddNewUser : UserControl
    {
        public AdminAddNewUser()
        {
            InitializeComponent();
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).Password = ((PasswordBox)sender).Password; }
        }
    }
}
