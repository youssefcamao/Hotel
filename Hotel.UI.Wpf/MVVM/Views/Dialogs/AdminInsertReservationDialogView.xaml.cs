using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hotel.UI.Wpf.MVVM.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for AdminInsertReservatoinDialogView.xaml
    /// </summary>
    public partial class AdminInsertReservationDialogView : UserControl
    {


        public bool HasEmailError
        {
            get { return (bool)GetValue(HasEmailErrorProperty); }
            set { SetValue(HasEmailErrorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for isEmailValid.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HasEmailErrorProperty =
            DependencyProperty.Register("HasEmailError", typeof(bool), typeof(AdminInsertReservationDialogView), new PropertyMetadata(false));


        public AdminInsertReservationDialogView()
        {
            InitializeComponent();
            StartDatePicker.BlackoutDates.AddDatesInPast();
        }

        private void EndDate_CalendarOpened(object sender, RoutedEventArgs e)
        {
            CalendarDateRange calendarDateRange = new CalendarDateRange();
            if (StartDatePicker.SelectedDate != null)
            {
                calendarDateRange.End = StartDatePicker.SelectedDate.Value;
            }
            EndDateDatePicker.BlackoutDates.Add(calendarDateRange);
        }

        private void StartDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            EndDateDatePicker.SelectedDate = null;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var hasError = Validation.GetHasError(EmailBox);
            HasEmailError = hasError;

        }
    }
}
