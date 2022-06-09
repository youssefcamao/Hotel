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
        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Password.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(SignupView), new PropertyMetadata(string.Empty));

        private void PasswordContainer_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Password = PasswordContainer.Password;
        }
    }
}
