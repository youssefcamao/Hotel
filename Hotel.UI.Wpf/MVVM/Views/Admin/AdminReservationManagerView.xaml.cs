using System.Windows;
using System.Windows.Controls;

namespace Hotel.UI.Wpf.MVVM.Views.Admin
{
    /// <summary>
    /// Interaction logic for AdminReservationManagerView.xaml
    /// </summary>
    public partial class AdminReservationManagerView : UserControl
    {
        public AdminReservationManagerView()
        {
            InitializeComponent();
        }

        private void EndData_CalendarOpened(object sender, RoutedEventArgs e)
        {
            CalendarDateRange calendarDateRange = new CalendarDateRange();
            if (StartDatePicker.SelectedDate != null)
            {
                calendarDateRange.End = StartDatePicker.SelectedDate.Value;
                EndDatePicker.BlackoutDates.Clear();
                calendarDateRange.End = StartDatePicker.SelectedDate.Value;
                EndDatePicker.BlackoutDates.Add(calendarDateRange);
            }
        }
    }
}
