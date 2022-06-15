using System.Windows.Controls;

namespace Hotel.UI.Wpf.MVVM.Views
{
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserView : UserControl
    {
        public UserView()
        {
            InitializeComponent();
        }

        private void YouCantTouchButton_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            YouCantTouchButton.Opacity = 0;
        }

        private void YouCantTouchButton_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            YouCantTouchButton.Opacity = 1;
        }
    }
}
