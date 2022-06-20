using Hotel.UI.Wpf.MVVM.Commands;
using Hotel.UI.Wpf.MVVM.ValidationRules;
using MaterialDesignThemes.Wpf;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Hotel.UI.Wpf.MVVM.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        private ValidationError? _validationProp;
        private Brush _defaultForgroundBrush;
        private Brush _hintAssitsDefaultColor;
        public LoginView()
        {
            InitializeComponent();
            _defaultForgroundBrush = PasswordContainer.Foreground;
            _hintAssitsDefaultColor = HintAssist.GetForeground(PasswordContainer);
        }
        public AsyncCommandBase LoginCommand
        {
            get { return (AsyncCommandBase)GetValue(LoginCommandProperty); }
            set { SetValue(LoginCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LoginCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoginCommandProperty =
            DependencyProperty.Register("LoginCommand", typeof(AsyncCommandBase), typeof(LoginView), new PropertyMetadata(null));


        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Password.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(LoginView), new PropertyMetadata(string.Empty));

        private void PasswordContainer_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Password = PasswordContainer.Password;
            if (_validationProp != null)
            {
                ResetLoginContainersStyle();
            }
        }


        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               await LoginCommand.ExecuteAsync(null);
            }
            catch (ArgumentNullException)
            {
                PasswordContainer.BorderBrush = (Brush)FindResource("MaterialDesignValidationErrorBrush");
                EmailContainer.BorderBrush = (Brush)FindResource("MaterialDesignValidationErrorBrush");
                CreateValidationError();
                PasswordContainer.Foreground = Brushes.DarkRed;
                EmailContainer.Foreground = Brushes.DarkRed;
                HintAssist.SetForeground(PasswordContainer, Brushes.DarkRed);
                HintAssist.SetForeground(EmailContainer, Brushes.DarkRed);
            }
        }

        private void CreateValidationError()
        {
            String errorMessage = "Wrong Email or Password";
            _validationProp = new ValidationError(new EmptyValidationRule(),
            PasswordContainer.GetBindingExpression(PasswordBox.TagProperty));
            Validation.MarkInvalid(PasswordContainer.GetBindingExpression(PasswordBox.TagProperty), _validationProp);
            _validationProp.ErrorContent = errorMessage;
        }

        private void EmailContainer_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (_validationProp != null)
            {
                ResetLoginContainersStyle();
            }
        }

        private void ResetLoginContainersStyle()
        {
            var propertyTag = PasswordBox.TagProperty;
            Validation.ClearInvalid(PasswordContainer.GetBindingExpression(propertyTag));
            PasswordContainer.BorderBrush = (Brush)FindResource("MaterialDesignDivider");
            EmailContainer.BorderBrush = (Brush)FindResource("MaterialDesignDivider");
            if (_defaultForgroundBrush != null)
            {
                EmailContainer.Foreground = _defaultForgroundBrush;
                PasswordContainer.Foreground = _defaultForgroundBrush;
                HintAssist.SetForeground(PasswordContainer, _hintAssitsDefaultColor);
                HintAssist.SetForeground(EmailContainer, _hintAssitsDefaultColor);
            }
        }

        private void Container_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LoginButton_Click(sender, e);
            }
        }
    }
}
