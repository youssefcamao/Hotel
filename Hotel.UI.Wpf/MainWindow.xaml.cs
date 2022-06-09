using Hotel.UI.Wpf.MVVM.ViewModels;
using MaterialDesignThemes.Wpf;
using System.Windows;
using System.Windows.Input;

namespace Hotel.UI.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //Theme Code ========================>
        public bool IsDarkTheme { get; set; }
        private readonly PaletteHelper _paletteHelper = new PaletteHelper();
        private void Btn_ExitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void themeToggle_Click(object sender, RoutedEventArgs e)
        {
            //Theme Code ========================>

            //get the current theme used in the application
            ITheme theme = _paletteHelper.GetTheme();

            //if condition true, then set IsDarkTheme to false and, SetBaseTheme to light
            if (IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                IsDarkTheme = false;
                theme.SetBaseTheme(Theme.Light);
            }

            //else set IsDarkTheme to true and SetBaseTheme to dark
            else
            {
                IsDarkTheme = true;
                theme.SetBaseTheme(Theme.Dark);
            }

            //to apply the changes use the SetTheme function
            _paletteHelper.SetTheme(theme);
            //===================================>
        }

        private void Card_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void Btn_MinimizeApp(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Btn_Maximize(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == System.Windows.WindowState.Normal)
            {
                this.WindowState = System.Windows.WindowState.Maximized;
            }
            else
            {
                this.WindowState = System.Windows.WindowState.Normal;
            }
        }

        private void MenuToggleButton_Click(object sender, RoutedEventArgs e)
        {
            var content = ViewController.Content;
            if (content is AdminViewModel adminViewModel)
            {
                if (adminViewModel.IsNavigationMenuExpanded == false)
                {
                    adminViewModel.IsNavigationMenuExpanded = true;
                }
                else
                {
                    adminViewModel.IsNavigationMenuExpanded = false;
                }
            }
        }
    }
}
